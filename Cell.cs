using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koridorchiki
{

/*
class Cell {

private: char M;

//////////////

public: 

    Cell(int r, int c)
    {
        M = ' ';
    }

//////////////////

};

*/
  
    // Клетка игрового поля
    public class Cell
    {
        private bool Right;    // закрашена ли правая граница
        private bool Bottom;   // закрашена ли нижняя граница
        private bool Left;     // закрашена ли левая граница
        private bool Top;    // закрашена ли верхняя граница
        private char M;    // знак в клетке

        // Конструктор. По умолчанию клетка пустая (не содержит знака)
        public Cell()
        {
            M = ' ';
        }

        // Закрашиваем правую границу
        public void SetRight()
        {
            Right = true;
        }

        // Закрашиваем нижнюю границу
        public void SetBottom()
        {
            Bottom = true;
        }

        // Закрашиваем левую границу
        public void SetLeft()
        {
            Left = true;
        }

        // Закрашиваем врхнюю границу
        public void SetTop()
        {
            Top = true;
        }

        // Узнаём, закрашена ли правая граница
        public bool IsRight()
        {
            return Right;
        }

        // Узнаём, закрашена ли нижняя граница
        public bool IsBottom()
        {
            return Bottom;
        }

        // Узнаём, закрашена ли левая граница
        public bool IsLeft()
        {
            return Left;
        }

        // Узнаём, закрашена ли верхняя граница
        public bool IsTop()
        {
            return Top;
        }

        // Узнаём, закрашены ли все границы
        public bool IsSet()
        {
            return Top && Right && Bottom && Left;
        }

        // Проставляем знак
        public void SetMark(char M)
        {
            if (this.M == ' ')
            {
                this.M = M;
            }
        }

        // Прроверяем, что клетка пуста (без знака)
        public bool IsEmpty()
        {
            return M == ' ';
        }

        // Узнаём знак клетки
        public char GetMark()
        {
            return M;
        }

        // Строковое представление клетки
        public override string ToString()
        {
            return Right + " " + Bottom + " " + Left + " " + Top + " " + M;
        }

    }
}
