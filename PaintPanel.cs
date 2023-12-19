using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koridorchiki
{ 
    // Панель, которая рисует игру
    public class PaintPanel : Panel
    {
        private Label label;

        private Pen P1 = new Pen(Color.Gray);
        private Pen P2 = new Pen(Color.Black, 2);

        private GameBoard Board = new GameBoard(2, 3);

        private const int Indent = 10;
        private const int Margin = 12;
        private const int Rad = 25;

        // Конструктор. В нем настраиваем обработчик события щелчка мыши
        public PaintPanel() : base ()
        {
            ResizeRedraw = true;
            MouseClick += new MouseEventHandler(panel1_MouseClick);
        }

        // Переопределение ролительского метода отрисовки. Рисуем игровое поле с ходами, сделанными на данный момент
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Gr = e.Graphics;

            Gr.Clear(BackColor);

            int Width = Size.Width - 2 * Indent;
            int Height = Size.Height - 2 * Indent;

            int W = Width / Board.GetColumnCount();
            int H = Height / Board.GetRowCount();

            for (int R = 0; R <= Board.GetRowCount(); ++R)
            {
                Gr.DrawLine(P1, new Point(Indent, Indent + R * H), new Point(Indent + Width, Indent + R * H));
            }

            for (int C = 0; C <= Board.GetColumnCount(); ++C)
            {
                Gr.DrawLine(P1, new Point(Indent + C * W, Indent), new Point(Indent + C * W, Indent + Height));
            }

            for (int R = 0; R < Board.GetRowCount(); ++R)
            {
                for (int C = 0; C < Board.GetColumnCount(); ++C)
                {
                    Cell cell = Board.GetCell(R, C);

                    if (cell.IsBottom())
                    {
                        Gr.DrawLine(P2, new Point(Indent + C * W, Indent + (R + 1) * H), new Point(Indent + (C + 1) * W, Indent + (R + 1) * H));
                    }
                    if (cell.IsRight())
                    {
                        Gr.DrawLine(P2, new Point(Indent + (C + 1) * W, Indent + R * H), new Point(Indent + (C + 1) * W, Indent + (R + 1) * H));
                    }
                    if (cell.IsLeft())
                    {
                        Gr.DrawLine(P2, new Point(Indent + C * W, Indent + R * H), new Point(Indent + C * W, Indent + (R + 1) * H));
                    }
                    if (cell.IsTop())
                    {
                        Gr.DrawLine(P2, new Point(Indent + C * W, Indent + R * H), new Point(Indent + (C + 1) * W, Indent + R * H));
                    }

                    if (cell.GetMark() == 'X')
                    {
                        DrawChar(Gr, R, C, 'X');
                    }
                    if (cell.GetMark() == 'O')
                    {
                        DrawChar(Gr, R, C, 'O');
                    }
                }
            }
        }

        // Отрисовка знака игрока (Х или О)
        private void DrawChar(Graphics G, int R, int C, char M)
        {
            int Width = Size.Width - 2 * Indent;
            int Height = Size.Height - 2 * Indent;

            int W = Width / Board.GetColumnCount();
            int H = Height / Board.GetRowCount();

            int Left = C * W + Indent + Margin;
            int Top = R * H + Indent + Margin;

            if (M == 'X')
            {
                G.DrawLine(P2, new Point(Left, Top), new Point(Left + W - 2 * Margin, Top + H - 2 * Margin));
                G.DrawLine(P2, new Point(Left + W - 2 * Margin, Top), new Point(Left, Top + H - 2 * Margin));
            }
            else if (M == 'O')
            {
                G.DrawEllipse(P2, Left, Top, W - 2 * Margin, H - 2 * Margin);
            }
        }

        // Формируем ход, который должен быть сделан на игровом поле,
        // исходя из координат х,у точки, в которой игрок щелкнул мышкой
        private Move GetMove(int x, int y)
        {
            int Width = Size.Width - 2 * Indent;
            int Height = Size.Height - 2 * Indent;

            int W = Width / Board.GetColumnCount();
            int H = Height / Board.GetRowCount();

            for (int RR = 0; RR <= Board.GetRowCount(); ++RR)
            {
                if (y >= Indent + RR * H - Rad && y <= Indent + RR * H + Rad)
                {
                    for (int CC = 0; CC < Board.GetColumnCount(); ++CC)
                    {
                        if (x > Indent + CC * W && x < Indent + (CC + 1) * W)
                        {
                            if (RR < Board.GetRowCount())
                            {
                                if (!Board.GetCell(RR, CC).IsTop())
                                    return new MoveBorder(RR, CC, Border.TOP);
                                else
                                    return null;
                            }
                            if (RR > 0)
                            {
                                if (!Board.GetCell(RR - 1, CC).IsBottom())
                                    return new MoveBorder(RR - 1, CC, Border.BOTTOM);
                                else
                                    return null;
                            }
                        }
                    }
                }
            }

            for (int CC = 0; CC <= Board.GetColumnCount(); ++CC)
            {
                if (x >= Indent + CC * W - Rad && x <= Indent + CC * W + Rad)
                {
                    for (int RR = 0; RR < Board.GetRowCount(); ++RR)
                    {
                        if (y > Indent + RR * H && y < Indent + (RR + 1) * H)
                        {
                            if (CC < Board.GetColumnCount())
                            {
                                if (!Board.GetCell(RR, CC).IsLeft())
                                    return new MoveBorder(RR, CC, Border.LEFT);
                                else
                                    return null;
                            }
                            if (CC > 0)
                            {
                                if (!Board.GetCell(RR, CC - 1).IsRight())
                                    return new MoveBorder(RR, CC - 1, Border.RIGHT);
                                else
                                    return null;
                            }
                        }
                    }
                }
            }

            int R = (y - Indent) / H;
            int C = (x - Indent) / W;
            if (R >= 0 && R < Board.GetRowCount() && C >= 0 && C < Board.GetColumnCount())
            {
                if (Board.GetCell(R, C).IsSet() && Board.GetCell(R, C).IsEmpty())
                    return new MoveChar(R, C, Board.GetMark());
                else
                    return null;
            }

            return null;
        }

        // Обрабатываем событие щелчка мышкой на игровом поле
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Move move = GetMove(e.X, e.Y);

            if (move != null)
            {
                Board.DoMove(move);
                Invalidate();
                Refresh();

                if (Board.GameOver())
                {
                    label.Text = Board.GetVictor() == ' ' ? "Ничья" : "Выиграл " + Board.GetVictor();
                }
                else if (Board.IsPrize())
                {
                    label.Text = Board.GetMark() + " имеет" + Environment.NewLine +  "призовой ход";
                }
                else
                {
                    label.Text = "Ход " + Board.GetMark();
                }
            }
        }

        // Получаем ссылку на метку для текста
        // Метка находится на основной форме
        public void SetLabel(Label label)
        {
            this.label = label;
        }

        // Начинаем игру сначала, создаем игровое поле нужного размера
        public void FixBoard(int Rows, int Columns)
        {
            Board = new GameBoard(Rows, Columns);
            label.Text = "Ход X";
            Invalidate();
            Refresh();
        }

    }
}
