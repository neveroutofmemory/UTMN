using System.Drawing;

namespace TicTacToe
{
    public class Cell
    {
        public MainForm.Sign sign = MainForm.Sign.None;

        public byte cellIndex;

        public PointF upperLeftPoint;
        public PointF downRightPoint;
    }
}
