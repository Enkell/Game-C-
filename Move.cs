using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koridorchiki
{

/*
class Move
{
private:

int Row, Column;

public:

Move(int Row, int Column)
    {
        this->Row = Row;
        this->Column = Column;
    }

    int GetRow()
    {
        return Row;
    }

    int GetColumn()
    {
        return Column;
    }

};
*/

    // Абстрактный класс "Ход"
    public abstract class Move
    {
        private int Row, Column;

        // Конструктор. Принимает номер строки и столбца
        public Move(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
        }

        // Геттер для номера строки
        public int GetRow()
        {
            return Row;
        }

        // Геттер для номера столбца
        public int GetColumn()
        {
            return Column;
        }

    }
}
