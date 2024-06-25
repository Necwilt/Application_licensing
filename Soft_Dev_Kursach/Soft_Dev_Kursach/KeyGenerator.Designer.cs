namespace Soft_Dev_Kursach
{
    partial class KeyGenerator
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
            FileListBox = new ListBox();
            panel1 = new Panel();
            textBoxDecryptedData = new RichTextBox();
            buttonDecrypt = new Button();
            label1 = new Label();
            label2 = new Label();
            functionNameListBox = new ListBox();
            CheckKey = new Button();
            textBox2 = new TextBox();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            buttonGenerateKey = new Button();
            textBox1 = new TextBox();
            panel2 = new Panel();
            label4 = new Label();
            textBoxJson = new RichTextBox();
            textBoxFilePath = new TextBox();
            groupBox2 = new GroupBox();
            SumOfSquares = new RadioButton();
            MultiplyAddHash = new RadioButton();
            BitwiseShifts = new RadioButton();
            label3 = new Label();
            groupBox1 = new GroupBox();
            radioButtonMotherboard = new RadioButton();
            radioButtonStorage = new RadioButton();
            radioButtonProcessor = new RadioButton();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // FileListBox
            // 
            FileListBox.FormattingEnabled = true;
            FileListBox.ItemHeight = 20;
            FileListBox.Location = new Point(1, 58);
            FileListBox.Name = "FileListBox";
            FileListBox.Size = new Size(313, 124);
            FileListBox.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBoxDecryptedData);
            panel1.Controls.Add(buttonDecrypt);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(functionNameListBox);
            panel1.Controls.Add(FileListBox);
            panel1.Controls.Add(CheckKey);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(315, 660);
            panel1.TabIndex = 10;
            // 
            // textBoxDecryptedData
            // 
            textBoxDecryptedData.Location = new Point(-1, 454);
            textBoxDecryptedData.Name = "textBoxDecryptedData";
            textBoxDecryptedData.Size = new Size(314, 148);
            textBoxDecryptedData.TabIndex = 12;
            textBoxDecryptedData.Text = "";
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Location = new Point(64, 611);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(185, 36);
            buttonDecrypt.TabIndex = 18;
            buttonDecrypt.Text = "Расшифровать данные";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += buttonDecrypt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 35);
            label1.Name = "label1";
            label1.Size = new Size(157, 20);
            label1.TabIndex = 15;
            label1.Text = "Найденные плагины:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 185);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 14;
            label2.Text = "Имена функций:";
            // 
            // functionNameListBox
            // 
            functionNameListBox.FormattingEnabled = true;
            functionNameListBox.ItemHeight = 20;
            functionNameListBox.Location = new Point(-1, 208);
            functionNameListBox.Name = "functionNameListBox";
            functionNameListBox.Size = new Size(314, 124);
            functionNameListBox.TabIndex = 10;
            // 
            // CheckKey
            // 
            CheckKey.Location = new Point(64, 412);
            CheckKey.Name = "CheckKey";
            CheckKey.Size = new Size(185, 36);
            CheckKey.TabIndex = 9;
            CheckKey.Text = "Проверить ключ";
            CheckKey.UseVisualStyleBackColor = true;
            CheckKey.Click += CheckKey_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(42, 370);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(229, 27);
            textBox2.TabIndex = 7;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(313, 28);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(163, 24);
            toolStripMenuItem1.Text = "Описание плагинов";
            // 
            // buttonGenerateKey
            // 
            buttonGenerateKey.Location = new Point(284, 597);
            buttonGenerateKey.Name = "buttonGenerateKey";
            buttonGenerateKey.Size = new Size(212, 37);
            buttonGenerateKey.TabIndex = 8;
            buttonGenerateKey.Text = "Сгенерировать ключ";
            buttonGenerateKey.UseVisualStyleBackColor = true;
            buttonGenerateKey.Click += buttonGenerateKey_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(122, 552);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(534, 27);
            textBox1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBoxJson);
            panel2.Controls.Add(textBoxFilePath);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(buttonGenerateKey);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(315, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(763, 660);
            panel2.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 326);
            label4.Name = "label4";
            label4.Size = new Size(178, 20);
            label4.TabIndex = 6;
            label4.Text = "Путь сохранения файла:";
            // 
            // textBoxJson
            // 
            textBoxJson.Location = new Point(425, 349);
            textBoxJson.Name = "textBoxJson";
            textBoxJson.Size = new Size(288, 148);
            textBoxJson.TabIndex = 7;
            textBoxJson.Text = "";
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(49, 349);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.PlaceholderText = "Местоположение файла";
            textBoxFilePath.Size = new Size(281, 27);
            textBoxFilePath.TabIndex = 5;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(SumOfSquares);
            groupBox2.Controls.Add(MultiplyAddHash);
            groupBox2.Controls.Add(BitwiseShifts);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 160);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(763, 155);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Метод хеширования:";
            // 
            // SumOfSquares
            // 
            SumOfSquares.AutoSize = true;
            SumOfSquares.Location = new Point(21, 117);
            SumOfSquares.Name = "SumOfSquares";
            SumOfSquares.Size = new Size(224, 24);
            SumOfSquares.TabIndex = 2;
            SumOfSquares.TabStop = true;
            SumOfSquares.Text = "Сумма квадратов символов";
            SumOfSquares.UseVisualStyleBackColor = true;
            SumOfSquares.CheckedChanged += SumOfSquares_CheckedChanged;
            // 
            // MultiplyAddHash
            // 
            MultiplyAddHash.AutoSize = true;
            MultiplyAddHash.Location = new Point(21, 76);
            MultiplyAddHash.Name = "MultiplyAddHash";
            MultiplyAddHash.Size = new Size(286, 24);
            MultiplyAddHash.TabIndex = 1;
            MultiplyAddHash.TabStop = true;
            MultiplyAddHash.Text = "Произведение на число + сложение";
            MultiplyAddHash.UseVisualStyleBackColor = true;
            MultiplyAddHash.CheckedChanged += MultiplyAddHash_CheckedChanged;
            // 
            // BitwiseShifts
            // 
            BitwiseShifts.AutoSize = true;
            BitwiseShifts.Location = new Point(21, 35);
            BitwiseShifts.Name = "BitwiseShifts";
            BitwiseShifts.Size = new Size(161, 24);
            BitwiseShifts.TabIndex = 0;
            BitwiseShifts.TabStop = true;
            BitwiseShifts.Text = "Побитовые сдвиги";
            BitwiseShifts.UseVisualStyleBackColor = true;
            BitwiseShifts.CheckedChanged += BitwiseShifts_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(425, 326);
            label3.Name = "label3";
            label3.Size = new Size(231, 20);
            label3.TabIndex = 4;
            label3.Text = "Данные для добавления в ключ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonMotherboard);
            groupBox1.Controls.Add(radioButtonStorage);
            groupBox1.Controls.Add(radioButtonProcessor);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(763, 160);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "На основе чего формировать лицензионный ключ:";
            // 
            // radioButtonMotherboard
            // 
            radioButtonMotherboard.AutoSize = true;
            radioButtonMotherboard.Location = new Point(21, 120);
            radioButtonMotherboard.Name = "radioButtonMotherboard";
            radioButtonMotherboard.Size = new Size(187, 24);
            radioButtonMotherboard.TabIndex = 2;
            radioButtonMotherboard.TabStop = true;
            radioButtonMotherboard.Text = "ID материнской платы";
            radioButtonMotherboard.UseVisualStyleBackColor = true;
            radioButtonMotherboard.CheckedChanged += radioButtonMotherboard_CheckedChanged;
            // 
            // radioButtonStorage
            // 
            radioButtonStorage.AutoSize = true;
            radioButtonStorage.Location = new Point(21, 78);
            radioButtonStorage.Name = "radioButtonStorage";
            radioButtonStorage.Size = new Size(365, 24);
            radioButtonStorage.TabIndex = 1;
            radioButtonStorage.TabStop = true;
            radioButtonStorage.Text = "ID твердотельного накопителя / жесткого диска";
            radioButtonStorage.UseVisualStyleBackColor = true;
            radioButtonStorage.CheckedChanged += radioButtonStorage_CheckedChanged;
            // 
            // radioButtonProcessor
            // 
            radioButtonProcessor.AutoSize = true;
            radioButtonProcessor.Location = new Point(21, 36);
            radioButtonProcessor.Name = "radioButtonProcessor";
            radioButtonProcessor.Size = new Size(133, 24);
            radioButtonProcessor.TabIndex = 0;
            radioButtonProcessor.TabStop = true;
            radioButtonProcessor.Text = "ID процессора";
            radioButtonProcessor.UseVisualStyleBackColor = true;
            radioButtonProcessor.CheckedChanged += radioButtonProcessor_CheckedChanged;
            // 
            // KeyGenerator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 660);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "KeyGenerator";
            Text = "KeyGenerator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox FileListBox;
        private Panel panel1;
        private Button CheckKey;
        private Button buttonGenerateKey;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel2;
        private ListBox functionNameListBox;
        private GroupBox groupBox1;
        private RadioButton radioButtonMotherboard;
        private RadioButton radioButtonStorage;
        private RadioButton radioButtonProcessor;
        private GroupBox groupBox2;
        private RadioButton SumOfSquares;
        private RadioButton MultiplyAddHash;
        private RadioButton BitwiseShifts;
        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private Label label3;
        private TextBox textBoxJsonj;
        private TextBox textBoxFilePath;
        private Label label4;
        private Button buttonDecrypt;
        private RichTextBox textBoxDecryptedData;
        private RichTextBox textBoxJson;
    }
}