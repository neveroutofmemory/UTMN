using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainForm : Form
    {
        static private readonly Pen GameFieldPen = new Pen(Color.AntiqueWhite, 8f);
        static private readonly Pen SignPen = new Pen(Color.Aquamarine, 6f);

        static private readonly Cell cell0 = new Cell() { cellIndex = 0};
        static private readonly Cell cell1 = new Cell() { cellIndex = 1};   ///
        static private readonly Cell cell2 = new Cell() { cellIndex = 2};   /// 0 | 1 | 2
        static private readonly Cell cell3 = new Cell() { cellIndex = 3};   /// --+---+--
        static private readonly Cell cell4 = new Cell() { cellIndex = 4};   /// 3 | 4 | 5
        static private readonly Cell cell5 = new Cell() { cellIndex = 5};   /// --+---+--
        static private readonly Cell cell6 = new Cell() { cellIndex = 6};   /// 6 | 7 | 8
        static private readonly Cell cell7 = new Cell() { cellIndex = 7};   ///
        static private readonly Cell cell8 = new Cell() { cellIndex = 8};

        static private readonly List<Cell> RandomOrderCells = new List<Cell> { cell2, cell4, cell0, cell7, cell6, cell5, cell8, cell3, cell1 };
        static private readonly List<Cell> previousCells = new List<Cell>();

        static private readonly Cell emptyCell = new Cell() { sign = Sign.None, cellIndex = 90 };
        static private Cell _currentCell;

        static private readonly List<byte> CellFieldCrossIndexesNow = new List<byte>();
        static private readonly List<byte> CellFieldCircleIndexesNow = new List<byte>();

        readonly (byte, byte, byte)[] winningPositions = {
            (0, 1, 2),
            (3, 4, 5),
            (6, 7, 8),
            (0, 3, 6),
            (1, 4, 7),
            (2, 5, 8),
            (0, 4, 8),
            (2, 4, 6)
        };

        static private byte moveIndex = 1;

        static private bool isEventInvokedByMouseClick;

        private Sign winnerSign = Sign.None;
        public Sign StarterSign { private get; set; } = Sign.None;
        public Opponent GameOpponent { private get; set; } = Opponent.None;

        public enum Sign : ushort
        {
            Cross = 0,
            Circle = 1,
            Tie,
            None
        }

        public enum Opponent
        {
            None,
            Person,
            Computer
        }

        public MainForm()
        {
            InitializeComponent();

            new MenuForm(this).Show();

            // Обновление формы. Первичный вызов события для отрисовки поля.
            Form1_ResizeEnd(null, EventArgs.Empty);
        }

        // Или другим способом выбирать случяйную клетку.
        private void GameFieldPicBox_MouseClick(object sender, MouseEventArgs e)
        {
            isEventInvokedByMouseClick = true;

            float mouseX = e.X;
            float mouseY = e.Y;

            // Срабатывает со второго хода, т.к. на первом _currentCell == null
            if (_currentCell != null)
            {
                // Cохраняет предыдущую клетку.
                previousCells.Add(_currentCell);
            }

            // Найти клетку, в которую нажал игрок.
            _currentCell = FindCell(mouseX, mouseY);

            if (_currentCell != null)
            {
                // Обновление формы. И сделать ход.
                Form1_ResizeEnd(null, EventArgs.Empty);
            }

            // Проверка, есть ли победитель.
            if (IsGameOver())
            {
                // Если игра с компьютером, меняет знак-победитель.
                if (GameOpponent == Opponent.Computer)
                {
                    winnerSign = ChangeWinnerSign();
                }

                switch (winnerSign)
                {
                    case Sign.Cross:

                        MessageBox.Show("Победили крестики!");

                        winnerSign = Sign.None;
                        break;

                    case Sign.Circle:

                        MessageBox.Show("Победили нолики!");

                        winnerSign = Sign.None;
                        break;

                    case Sign.Tie:

                        MessageBox.Show("Ничья.");

                        winnerSign = Sign.None;
                        break;
                }

                this.Close();
            }

            isEventInvokedByMouseClick = false;
        }

        // Изменение размеров поля.
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            gameFieldPicBox.Width = this.Width - 40;
            gameFieldPicBox.Height = this.Height - 59;

            gameFieldPicBox.Image = new Bitmap(gameFieldPicBox.Width, gameFieldPicBox.Height);

            DrawField();

            // Проверка, вызвано ли событие Form1_ResizeEnd кликом мыши.
            if (isEventInvokedByMouseClick)
            {
                MakeAMove();

                // Если игрок выбрал игру с компьютером.
                if (GameOpponent == Opponent.Computer)
                {
                    MakeComputerMove();
                }
            }
        }

        private bool IsGameOver()
        {
            CellFieldCrossIndexesNow.Clear();
            CellFieldCircleIndexesNow.Clear();

            var listsOfIndexes = GetListsOfIndexes();

            List<byte> ListOfCrossIndexes = listsOfIndexes.Item1;
            List<byte> ListOfCircleIndexes = listsOfIndexes.Item2;

            for (int pos = 0; pos < winningPositions.Length; pos++)
            {
                if (ListOfCrossIndexes.Contains(winningPositions[pos].Item1) && ListOfCrossIndexes.Contains(winningPositions[pos].Item2) && ListOfCrossIndexes.Contains(winningPositions[pos].Item3))
                {
                    winnerSign = Sign.Cross;

                    return true;
                }
            }

            for (int pos = 0; pos < winningPositions.Length; pos++)
            {
                if (ListOfCircleIndexes.Contains(winningPositions[pos].Item1) && ListOfCircleIndexes.Contains(winningPositions[pos].Item2) && ListOfCircleIndexes.Contains(winningPositions[pos].Item3))
                {
                    winnerSign = Sign.Circle;

                    return true;
                }
            }

            if (moveIndex >= 10)
            {
                winnerSign = Sign.Tie;

                return true;
            }

            return false;
        }

        private void MakeAMove()
        {
            // Рисует текущий знак.
            switch (DecideCrossOrCircle(moveIndex))
            {
                case Sign.Circle:
                    DrawCircle(_currentCell);
                    break;

                case Sign.Cross:
                    DrawCross(_currentCell);
                    break;

                case Sign.None:
                    return;
            }
            
            // Отрисовывает предыдущие знаки.
            for (byte cellInListIndex = 0; cellInListIndex < previousCells.Count; cellInListIndex++)
            {
                switch (DecideCrossOrCircle(cellInListIndex))
                {
                    case Sign.Circle:
                        DrawCross(previousCells[cellInListIndex]);
                        break;

                    case Sign.Cross:
                        DrawCircle(previousCells[cellInListIndex]);
                        break;
                }
            }

            moveIndex++;
        }

        private void MakeComputerMove()
        {
            // Cохраняет предыдущую клетку.
            previousCells.Add(_currentCell);

            // Берёт одну клетку из списка.
            foreach (Cell cell in RandomOrderCells)
            {
                if (cell.sign == Sign.None)
                {
                    cell.sign = DecideCrossOrCircle(moveIndex);

                    _currentCell = cell;

                    break;
                }
            }

            MakeAMove();

            // Проверка, есть ли победитель.
            if (IsGameOver())
            {
                // Если игра с компьютером, меняет знак-победитель.
                if (GameOpponent == Opponent.Computer)
                {
                    winnerSign = ChangeWinnerSign();
                }

                switch (winnerSign)
                {
                    case Sign.Cross:

                        MessageBox.Show("Победили крестики!");

                        winnerSign = Sign.None;
                        break;

                    case Sign.Circle:

                        MessageBox.Show("Победили нолики!");

                        winnerSign = Sign.None;
                        break;

                    case Sign.Tie:

                        MessageBox.Show("Ничья.");

                        winnerSign = Sign.None;
                        break;
                }

                this.Close();
            }
        }

        private Sign ChangeWinnerSign()
        {
            switch (winnerSign)
            {
                case Sign.Cross:

                    return Sign.Circle;

                case Sign.Circle:

                    return Sign.Cross;

                case Sign.Tie:

                    return Sign.Tie;
            }

            throw new Exception();
        }

        private (List<byte>, List<byte>) GetListsOfIndexes()
        {
            byte crossOrCircleSwapIndex = Convert.ToByte(moveIndex - 1);

            previousCells.Add(_currentCell);

            // Заполняет list previousCells пустыми ячейками.
            for (int i = 0; i < (10 - moveIndex); i++)
            {
                previousCells.Add(emptyCell);
            }

            foreach (Cell cell in previousCells)
            {
                // 90 = index пустой ячейки.
                if (cell.cellIndex == 90)
                    continue;

                if (DecideCrossOrCircle(crossOrCircleSwapIndex) == Sign.Cross)
                {
                    CellFieldCrossIndexesNow.Add(cell.cellIndex);
                    crossOrCircleSwapIndex++;
                }
                else if (DecideCrossOrCircle(crossOrCircleSwapIndex) == Sign.Circle)
                {
                    CellFieldCircleIndexesNow.Add(cell.cellIndex);
                    crossOrCircleSwapIndex++;
                }
            }

            previousCells.Remove(_currentCell);

            // Удаляет из priveousCells пустые ячейки.
            for (int i = 0; i < (10 - moveIndex); i++)
            {
                previousCells.Remove(emptyCell);
            }

            return (CellFieldCrossIndexesNow, CellFieldCircleIndexesNow);
        }

        private Sign DecideCrossOrCircle(byte index)
        {
            if (StarterSign == Sign.None)
                return Sign.None;

            // Выбор знака на основе чётности текущего хода.
            if (index % 2 == (ushort)StarterSign)
                return Sign.Circle;
            else
                return Sign.Cross;
        }

        private void DrawField()
        {
            using var g = Graphics.FromImage(gameFieldPicBox.Image);

            // Рисует линии на игровом поле.
            g.DrawLine(GameFieldPen, 0, gameFieldPicBox.Height / 3, gameFieldPicBox.Width, gameFieldPicBox.Height / 3);
            g.DrawLine(GameFieldPen, 0, gameFieldPicBox.Height * 2 / 3, gameFieldPicBox.Width, gameFieldPicBox.Height * 2 / 3);
            g.DrawLine(GameFieldPen, gameFieldPicBox.Width / 3, 0, gameFieldPicBox.Width / 3, gameFieldPicBox.Height);
            g.DrawLine(GameFieldPen, gameFieldPicBox.Width * 2 / 3, 0, gameFieldPicBox.Width * 2 / 3, gameFieldPicBox.Height);
        }

        private void DrawCircle(Cell cell)
        {
            using var g = Graphics.FromImage(gameFieldPicBox.Image);

            g.DrawEllipse(SignPen, cell.upperLeftPoint.X, cell.upperLeftPoint.Y, cell.downRightPoint.X - cell.upperLeftPoint.X, cell.downRightPoint.Y - cell.upperLeftPoint.Y);
        }

        private void DrawCross(Cell cell)
        {
            using var g = Graphics.FromImage(gameFieldPicBox.Image);

            g.DrawLine(SignPen, cell.upperLeftPoint, cell.downRightPoint);
            g.DrawLine(SignPen,
                (cell.upperLeftPoint.X + gameFieldPicBox.Width / 3),
                cell.upperLeftPoint.Y,
                (cell.downRightPoint.X - gameFieldPicBox.Width / 3),
                cell.downRightPoint.Y);
        }

        // Поиск клетки.
        private Cell FindCell(float x, float y)
        {
            Sign newSign = DecideCrossOrCircle(moveIndex);

            // Список клеток.
            cell0.upperLeftPoint = new PointF(0, 0);
            cell0.downRightPoint = new PointF(gameFieldPicBox.Width / 3, gameFieldPicBox.Height / 3);

            cell1.upperLeftPoint = new PointF(gameFieldPicBox.Width / 3, 0);
            cell1.downRightPoint = new PointF(gameFieldPicBox.Width * 2 / 3, gameFieldPicBox.Height / 3);

            cell2.upperLeftPoint = new PointF(gameFieldPicBox.Width * 2 / 3, 0);
            cell2.downRightPoint = new PointF(gameFieldPicBox.Width, gameFieldPicBox.Height / 3);

            cell3.upperLeftPoint = new PointF(0, gameFieldPicBox.Height / 3);
            cell3.downRightPoint = new PointF(gameFieldPicBox.Width / 3, gameFieldPicBox.Height * 2 / 3);

            cell4.upperLeftPoint = new PointF(gameFieldPicBox.Width / 3, gameFieldPicBox.Height / 3);
            cell4.downRightPoint = new PointF(gameFieldPicBox.Width * 2 / 3, gameFieldPicBox.Height * 2 / 3);

            cell5.upperLeftPoint = new PointF(gameFieldPicBox.Width * 2 / 3, gameFieldPicBox.Height / 3);
            cell5.downRightPoint = new PointF(gameFieldPicBox.Width, gameFieldPicBox.Height * 2 / 3);

            cell6.upperLeftPoint = new PointF(0, gameFieldPicBox.Height * 2 / 3);
            cell6.downRightPoint = new PointF(gameFieldPicBox.Width / 3, gameFieldPicBox.Height);

            cell7.upperLeftPoint = new PointF(gameFieldPicBox.Width / 3, gameFieldPicBox.Height * 2 / 3);
            cell7.downRightPoint = new PointF(gameFieldPicBox.Width * 2 / 3, gameFieldPicBox.Height);

            cell8.upperLeftPoint = new PointF(gameFieldPicBox.Width * 2 / 3, gameFieldPicBox.Height * 2 / 3);
            cell8.downRightPoint = new PointF(gameFieldPicBox.Width, gameFieldPicBox.Height);

            // Проверка, в какую клетку указывают координаты.
            if (x >= cell0.upperLeftPoint.X && y >= cell0.upperLeftPoint.Y && x < cell0.downRightPoint.X && y < cell0.downRightPoint.Y)
            {
                // Знак для этой клетки ещё не выбирался.
                if (cell0.sign != Sign.None)
                    return null;

                cell0.sign = newSign;

                return cell0;
            }
            else if (x >= cell1.upperLeftPoint.X && y >= cell1.upperLeftPoint.Y && x < cell1.downRightPoint.X && y < cell1.downRightPoint.Y)
            {
                if (cell1.sign != Sign.None)
                    return null;

                cell1.sign = newSign;

                return cell1;
            }
            else if (x >= cell2.upperLeftPoint.X && y >= cell2.upperLeftPoint.Y && x < cell2.downRightPoint.X && y < cell2.downRightPoint.Y)
            {
                if (cell2.sign != Sign.None)
                    return null;

                cell2.sign = newSign;

                return cell2;
            }
            else if (x >= cell3.upperLeftPoint.X && y >= cell3.upperLeftPoint.Y && x < cell3.downRightPoint.X && y < cell3.downRightPoint.Y)
            {
                if (cell3.sign != Sign.None)
                    return null;

                cell3.sign = newSign;

                return cell3;
            }
            else if (x >= cell4.upperLeftPoint.X && y >= cell4.upperLeftPoint.Y && x < cell4.downRightPoint.X && y < cell4.downRightPoint.Y)
            {
                if (cell4.sign != Sign.None)
                    return null;

                cell4.sign = newSign;

                return cell4;
            }
            else if (x >= cell5.upperLeftPoint.X && y >= cell5.upperLeftPoint.Y && x < cell5.downRightPoint.X && y < cell5.downRightPoint.Y)
            {
                if (cell5.sign != Sign.None)
                    return null;

                cell5.sign = newSign;

                return cell5;
            }
            else if (x >= cell6.upperLeftPoint.X && y >= cell6.upperLeftPoint.Y && x < cell6.downRightPoint.X && y < cell6.downRightPoint.Y)
            {
                if (cell6.sign != Sign.None)
                    return null;

                cell6.sign = newSign;

                return cell6;
            }
            else if (x >= cell7.upperLeftPoint.X && y >= cell7.upperLeftPoint.Y && x < cell7.downRightPoint.X && y < cell7.downRightPoint.Y)
            {
                if (cell7.sign != Sign.None)
                    return null;

                cell7.sign = newSign;

                return cell7;
            }
            else if (x >= cell8.upperLeftPoint.X && y >= cell8.upperLeftPoint.Y && x <= cell8.downRightPoint.X && y <= cell8.downRightPoint.Y)
            {
                if (cell8.sign != Sign.None)
                    return null;

                cell8.sign = newSign;

                return cell8;
            }
            else
                throw new ArgumentOutOfRangeException();
        }
    }    
}
