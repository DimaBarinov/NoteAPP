namespace NoteAppUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ColorComboBox = new System.Windows.Forms.ComboBox();
            this.VisibilityCheckBox = new System.Windows.Forms.CheckBox();
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.LabelTextBox = new System.Windows.Forms.Label();
            this.LabelComboBox = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ColorComboBox
            // 
            this.ColorComboBox.FormattingEnabled = true;
            this.ColorComboBox.Location = new System.Drawing.Point(151, 70);
            this.ColorComboBox.Name = "ColorComboBox";
            this.ColorComboBox.Size = new System.Drawing.Size(85, 21);
            this.ColorComboBox.TabIndex = 0;
            this.ColorComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            // 
            // VisibilityCheckBox
            // 
            this.VisibilityCheckBox.AutoSize = true;
            this.VisibilityCheckBox.Location = new System.Drawing.Point(36, 116);
            this.VisibilityCheckBox.Name = "VisibilityCheckBox";
            this.VisibilityCheckBox.Size = new System.Drawing.Size(200, 17);
            this.VisibilityCheckBox.TabIndex = 1;
            this.VisibilityCheckBox.Text = "Сделать Color TextBox невидимым";
            this.VisibilityCheckBox.UseVisualStyleBackColor = true;
            this.VisibilityCheckBox.CheckedChanged += new System.EventHandler(this.VisibilityCheckBox_CheckedChanged);
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(151, 32);
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(85, 20);
            this.NumberTextBox.TabIndex = 2;
            this.NumberTextBox.TextChanged += new System.EventHandler(this.NumberTextBox_TextChanged);
            // 
            // LabelTextBox
            // 
            this.LabelTextBox.AutoSize = true;
            this.LabelTextBox.Location = new System.Drawing.Point(33, 35);
            this.LabelTextBox.Name = "LabelTextBox";
            this.LabelTextBox.Size = new System.Drawing.Size(111, 13);
            this.LabelTextBox.TabIndex = 3;
            this.LabelTextBox.Text = "Введите число 1-100";
            this.LabelTextBox.Click += new System.EventHandler(this.LabelTextBox_Click);
            // 
            // LabelComboBox
            // 
            this.LabelComboBox.AutoSize = true;
            this.LabelComboBox.Location = new System.Drawing.Point(33, 73);
            this.LabelComboBox.Name = "LabelComboBox";
            this.LabelComboBox.Size = new System.Drawing.Size(83, 13);
            this.LabelComboBox.TabIndex = 4;
            this.LabelComboBox.Text = "Выберите цвет";
            this.LabelComboBox.Click += new System.EventHandler(this.LabelComboBox_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LabelComboBox);
            this.Controls.Add(this.LabelTextBox);
            this.Controls.Add(this.NumberTextBox);
            this.Controls.Add(this.VisibilityCheckBox);
            this.Controls.Add(this.ColorComboBox);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox ColorComboBox;
        private System.Windows.Forms.CheckBox VisibilityCheckBox;
        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.Label LabelTextBox;
        private System.Windows.Forms.Label LabelComboBox;
        private System.Windows.Forms.Button button1;
    }
}

