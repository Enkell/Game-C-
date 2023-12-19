using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koridorchiki
{
/*
class MoveChar : Move
{
private:
    
char C;

public:
  
    MoveChar(int Row, int Column, char C) : Move(Row, Column)
    {
        this->C = C;
    }

   char GetMark()
    {
        return C;
    }
};
*/

    // Ход - простановка знака
    public class MoveChar : Move
    {
        private char C;

        // Конструктор. Принимает номер строки, столбца и собственно знак игрока
        public MoveChar(int Row, int Column, char C) : base(Row, Column)
        {
            this.C = C;
        }

        // Геттер для знака игрока
        public char GetMark()
        {
            return C;
        }
    }
}
