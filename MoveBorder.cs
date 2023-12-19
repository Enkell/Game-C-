using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koridorchiki
{

/*

class MoveBorder : Move
{
private:

    Border* b;

public:

    MoveBorder(int Row, int Column, Border b) : Move(Row, Column)
    {
        this->b = &b;
    }

    Border GetBorder()
    {
        return *b;
    }
};

*/

  // Ход - закрашивание границы клетки
    public class MoveBorder : Move
    {
        private Border B;

        // Конструктор. Принимает номер строки, столбца и тип границы
        public MoveBorder(int Row, int Column, Border B) : base (Row, Column)
        {
            this.B = B;
        }

        // Геттер для типа границы
        public Border GetBorder()
        {
            return B;
        }
    }
}
