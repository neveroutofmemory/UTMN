using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    
    public partial class Form1 : Form
    {

        private string OCRAccessKey = "b4fd63bbad88957";
        private string FilePath { get; set; }

        public SortedDictionary<string, string> availableLanguages = new SortedDictionary<string, string>
        {
            { "Arabic", "ara" },
            { "Bulgarian", "bul" },
            { "Chinese(Simplified)", "chs" },
            { "Chinese(Traditional)", "cht" },
            { "Croatian", "hrv" },
            { "Czech", "cze" },
            { "Danish", "dan" },
            { "Dutch", "dut" },
            { "English", "eng" },
            { "Finnish", "fin" },
            { "French", "fre" },
            { "German", "ger" },
            { "Greek", "gre" },
            { "Hungarian", "hun" },
            { "Korean", "kor" },
            { "Italian", "ita" },
            { "Japanese", "jpn" },
            { "Polish", "pol" },
            { "Portuguese", "por" },
            { "Russian", "rus" },
            { "Slovenian", "slv" },
            { "Spanish", "spa" },
            { "Swedish", "swe" },
            { "Turkish", "tur" },
        };

        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = new BindingSource(availableLanguages, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.SelectedValue = "rus";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilePath = ""; 
            pictureBox1.BackgroundImage = null;
            label3.Text = "No loaded file";
            richTextBox1.Text = "";
            label4.Text = "";

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files (*.png,*.jpg,*.JPG,*.png)|*.png;*.jpg;*.JPG;*.pdf;";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                FilePath = fileDialog.FileName;
                if (fileInfo.Extension == ".pdf")
                    label3.Text = Path.GetFileName(fileDialog.FileName);
                else
                    pictureBox1.BackgroundImage = Image.FromFile(fileDialog.FileName);
            }
        }

        private async void RecognizeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath) )
                return;

            richTextBox1.Text = "";

            button1.Enabled = false;
            RecognizeButton.Enabled = false;

            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(1, 1, 1);

                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(OCRAccessKey), "apikey");

                string selectedLanguage = (string)comboBox1.SelectedValue;
                
                form.Add(new StringContent(selectedLanguage), "language");
                form.Add(new StringContent("true"), "scale");

                byte[] fileData = File.ReadAllBytes(FilePath);

                if(Path.GetExtension(FilePath) == ".pdf")
                    form.Add(new ByteArrayContent(fileData, 0, fileData.Length), "PDF", "pdf.pdf");
                else
                    form.Add(new ByteArrayContent(fileData, 0, fileData.Length), "image", "image.jpg");


                label4.Text = "Loading...";
                HttpResponseMessage response = await httpClient.PostAsync("https://api.ocr.space/Parse/Image", form);

                string strContent = await response.Content.ReadAsStringAsync();

                //Чтение тела запроса и привидение его к классу ResponseObject
                ResponseObject ocrResult = JsonConvert.DeserializeObject<ResponseObject>(strContent);


                if (ocrResult.OCRExitCode == 1)
                {
                    for (int i = 0; i < ocrResult.ParsedResults.Count(); i++)
                    {
                        richTextBox1.Text = richTextBox1.Text + ocrResult.ParsedResults[i].ParsedText;
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: " + strContent);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Something went wrong. Try again! Exception: {exception}");
            }
            label4.Text = "Complete!";
            button1.Enabled = true;
            RecognizeButton.Enabled = true;
        }
    }
    public class ResponseObject
    {
        public ParsedResult[] ParsedResults { get; set; }
        public int OCRExitCode { get; set; }
        public bool IsErroredOnProcessing { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
    }

    public class ParsedResult
    {
        public object FileParseExitCode { get; set; }
        public string ParsedText { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
    }
}
