namespace Koridorchiki
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new PaintPanel();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            domainUpDown2 = new DomainUpDown();
            domainUpDown1 = new DomainUpDown();
            label1 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(671, 544);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(domainUpDown2);
            panel2.Controls.Add(domainUpDown1);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(671, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(228, 544);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 117);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 4;
            label3.Text = "Столбцов:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 41);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 3;
            label2.Text = "Строк:";
            // 
            // domainUpDown2
            // 
            domainUpDown2.Items.Add("10");
            domainUpDown2.Items.Add("9");
            domainUpDown2.Items.Add("8");
            domainUpDown2.Items.Add("7");
            domainUpDown2.Items.Add("6");
            domainUpDown2.Items.Add("5");
            domainUpDown2.Items.Add("4");
            domainUpDown2.Items.Add("3");
            domainUpDown2.Items.Add("2");
            domainUpDown2.Items.Add("1");
            domainUpDown2.Location = new Point(125, 112);
            domainUpDown2.Margin = new Padding(3, 4, 3, 4);
            domainUpDown2.Name = "domainUpDown2";
            domainUpDown2.Size = new Size(70, 27);
            domainUpDown2.TabIndex = 2;
            domainUpDown2.Text = "3";
            domainUpDown2.TextChanged += domainUpDown_TextChanged;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Items.Add("10");
            domainUpDown1.Items.Add("9");
            domainUpDown1.Items.Add("8");
            domainUpDown1.Items.Add("7");
            domainUpDown1.Items.Add("6");
            domainUpDown1.Items.Add("5");
            domainUpDown1.Items.Add("4");
            domainUpDown1.Items.Add("3");
            domainUpDown1.Items.Add("2");
            domainUpDown1.Items.Add("1");
            domainUpDown1.Location = new Point(125, 35);
            domainUpDown1.Margin = new Padding(3, 4, 3, 4);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(70, 27);
            domainUpDown1.TabIndex = 1;
            domainUpDown1.Text = "2";
            domainUpDown1.TextChanged += domainUpDown_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(23, 253);
            label1.Name = "label1";
            label1.Size = new Size(93, 37);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 544);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Игра Коридорчики";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label1;
        private DomainUpDown domainUpDown2;
        private DomainUpDown domainUpDown1;
        private PaintPanel panel1;
        private Label label3;
        private Label label2;
    }
}