using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
#include <typeinfo>
#include <string>
*/

namespace Koridorchiki
{
    // Игровое поле. Содержит двумерный массив клеток
    public class GameBoard
    {
        private int RowCount, ColumnCount;
        private Cell[,] Cells;                   // Cell** cells;

        private char M = 'X';                 // char M = 'X';  // на C++ так и будет
        private bool Prize = false;

        // Конструктор. Принимает количество строк и столбцов
        public GameBoard(int RowCount, int ColumnCount)
        {
            this.RowCount = RowCount;
            this.ColumnCount = ColumnCount;
            Cells = new Cell[RowCount, ColumnCount];  // Cell** cells = new Cell* [RowCount];
            for (int R = 0; R < RowCount; ++R)
            {            // cells[R] = new Cell[ColumnCount];
                for (int C = 0; C < ColumnCount; ++C)
                {
                    Cells[R, C] = new Cell();              // cells[R][C] = *(new Cell()); 
                }
            }
        }

        // Делаем ход на игровом поле
        public void DoMove(Move M)    // void DoMove(Move *M)
        {
            if (M.GetType() == typeof(MoveChar)) {         // if (typeid(MoveChar) == typeid(*M))
                MoveChar Mark = (MoveChar)M;
                Move(Mark.GetRow(), Mark.GetColumn(), Mark.GetMark());
            } else if (M.GetType() == typeof(MoveBorder)) {
                MoveBorder Bor = (MoveBorder)M;
                Move(Bor.GetRow(), Bor.GetColumn(), Bor.GetBorder());
            }
        }

        // Внутренний вспомогательный метод: делаем ход - простановку знака
        private void Move(int Row, int Column, char Mark)
        {
            Cells[Row, Column].SetMark(Mark);
        }

        // Внутренний вспомогательный метод: делаем ход - закрашивание границы клетки
        private void Move(int Row, int Column, Border B)      //  void Move(int Row, int Column, Border* B)
        {
            Prize = false;

            switch (B)                                 
            {
                case Border.RIGHT:
                    Cells[Row, Column].SetRight();
                    PutMarkMayBe(Row, Column);
                    if (Column < ColumnCount - 1)
                    {
                        Cells[Row, Column + 1].SetLeft();
                        PutMarkMayBe(Row, Column + 1);
                    }
                    break;
                case Border.BOTTOM:
                    Cells[Row, Column].SetBottom();
                    PutMarkMayBe(Row, Column);
                    if (Row < RowCount - 1)
                    {
                        Cells[Row + 1, Column].SetTop();
                        PutMarkMayBe(Row + 1, Column);
                    }
                    break;
                case Border.LEFT:
                    Cells[Row, Column].SetLeft();
                    PutMarkMayBe(Row, Column);
                    if (Column > 0)
                    {
                        Cells[Row, Column - 1].SetRight();
                        PutMarkMayBe(Row, Column - 1);
                    }
                    break;
                case Border.TOP:
                    Cells[Row, Column].SetTop();
                    PutMarkMayBe(Row, Column);
                    if (Row > 0)
                    {
                        Cells[Row - 1, Column].SetBottom();
                        PutMarkMayBe(Row - 1, Column);
                    }
                    break;
            }

            if (!Prize)
            {
                ChangeMark();
            }
        }

        // Проставляем знак в клетке, если надо (если все границы закрашены)
        private void PutMarkMayBe(int Row, int Column)
        {
            if (Cells[Row, Column].IsSet())
            {
                Cells[Row, Column].SetMark(M);
                Prize = true;
            }
        }

        // Меняем знак игрока при переходе хода от игрока к игроку
        private void ChangeMark()
        {
            if (M == 'X')
            {
                M = 'O';
            }
            else
            {
                M = 'X';
            }
        }

        // Узнаём, есть ли право призового хода у игрока, который только что ходил
        public bool IsPrize()
        {
            return Prize;
        }

        // Проверяем, не завершилась ли игра
        public bool GameOver()
        {
            for (int R = 0; R < RowCount; ++R)
            {
                for (int C = 0; C < ColumnCount; ++C)
                {
                    if (Cells[R, C].IsEmpty())                          // if (cells[R][C].isEmpty())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Узнаём, кто победил (чей знак)
        public char GetVictor()
        {
            int CX = 0, CO = 0;

            for (int R = 0; R < RowCount; ++R)
            {
                for (int C = 0; C < ColumnCount; ++C)
                {
                    if (Cells[R, C].GetMark() == 'X')
                    {
                        ++CX;
                    }
                    if (Cells[R, C].GetMark() == 'O')
                    {
                        ++CO;
                    }
                }
            }

            if (CX > CO)
            {
                return 'X';
            }
            else if (CO > CX)
            {
                return 'O';
            }
            else
            {
                return ' ';
            }
        }

        // Геттер для количества строк
        public int GetRowCount()
        {
            return RowCount;
        }

        // Геттер для количества столбцов
        public int GetColumnCount()
        {
            return ColumnCount;
        }
        
        // Получаем клетку на персесечении указанных строки и столбца
        public Cell GetCell(int Row, int Column)
        {
            return Cells[Row, Column];
        }

        // Узнаём знак игрока, который сейчас должен ходить
        public char GetMark()
        {
            return M;
        }

        // Строковое представление игрового поля
        public override string ToString()          // string ToString()
        {
            string s = "";
            for (int R = 0; R < RowCount; ++R)
            {
                for (int C = 0; C < ColumnCount; ++C)
                {
                    s += R + "," + C + ": " + Cells[R, C].ToString() + Environment.NewLine;        //   s += R + "," + C + ": " + Cells[R][C].ToString() + "\n";   
                }
            }
            return s;
        }
    }
}
