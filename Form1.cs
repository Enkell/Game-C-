using System;
using System.Drawing.Printing;
using System.Runtime.Intrinsics.X86;

namespace Koridorchiki
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            panel1.SetLabel(label1);
            label1.Text = "Ход X";
            prepareMenu();
        }

       
        private void prepareMenu()
        {
            MenuStrip menu = new MenuStrip();

            Controls.Add(menu);
            ToolStripMenuItem item = new ToolStripMenuItem("Об игре");
            item.Click += new EventHandler(ClickMenuMethod);
            menu.Items.Add(item);

        }

      
        private void domainUpDown_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Rows = Int32.Parse(domainUpDown1.Text);
                int Columns = Int32.Parse(domainUpDown2.Text);
                panel1.FixBoard(Rows, Columns);

            }
            finally
            {
            }
        }

        
        private void ClickMenuMethod(object sender, EventArgs e)
        {
            MessageBox.Show("Правила игры" + Environment.NewLine
                + "Игроки по очереди проводят горизонтальные или вертикальные линии в одну клетку." + Environment.NewLine
                + "Игрок, которому удалось замкнуть линиями клетку, ставит в ней крестик (или нолик) и получает еще один ход." + Environment.NewLine
                
                + "Когда все клетки окажутся занятыми, подсчитывают, кто «захватил» больше клеток тот и победитель.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}