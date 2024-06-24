namespace UPRA
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
            btnChoooseFile = new Button();
            textBoxFilePath = new TextBox();
            textBoxMain = new TextBox();
            btnCopy = new Button();
            listBoxInputs = new ListBox();
            listBoxOutputs = new ListBox();
            bntDeleteInput = new Button();
            btnEditInput = new Button();
            btnAddInput = new Button();
            btnAddOutput = new Button();
            btnEditOutput = new Button();
            btnDeleteOutput = new Button();
            label1 = new Label();
            label2 = new Label();
            btnRebuild = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // btnChoooseFile
            // 
            btnChoooseFile.Location = new Point(1077, 12);
            btnChoooseFile.Name = "btnChoooseFile";
            btnChoooseFile.Size = new Size(124, 38);
            btnChoooseFile.TabIndex = 0;
            btnChoooseFile.Text = "Выбрать файл";
            btnChoooseFile.UseVisualStyleBackColor = true;
            btnChoooseFile.Click += btnChooseFile_Click;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(39, 18);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.ReadOnly = true;
            textBoxFilePath.Size = new Size(1032, 27);
            textBoxFilePath.TabIndex = 1;
            // 
            // textBoxMain
            // 
            textBoxMain.Location = new Point(34, 56);
            textBoxMain.Multiline = true;
            textBoxMain.Name = "textBoxMain";
            textBoxMain.ScrollBars = ScrollBars.Both;
            textBoxMain.Size = new Size(1167, 753);
            textBoxMain.TabIndex = 2;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(949, 815);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(123, 33);
            btnCopy.TabIndex = 3;
            btnCopy.Text = "Копировать";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // listBoxInputs
            // 
            listBoxInputs.FormattingEnabled = true;
            listBoxInputs.Location = new Point(1218, 85);
            listBoxInputs.Name = "listBoxInputs";
            listBoxInputs.Size = new Size(366, 224);
            listBoxInputs.TabIndex = 6;
            // 
            // listBoxOutputs
            // 
            listBoxOutputs.FormattingEnabled = true;
            listBoxOutputs.Location = new Point(1218, 400);
            listBoxOutputs.Name = "listBoxOutputs";
            listBoxOutputs.Size = new Size(366, 224);
            listBoxOutputs.TabIndex = 7;
            // 
            // bntDeleteInput
            // 
            bntDeleteInput.Location = new Point(1217, 315);
            bntDeleteInput.Name = "bntDeleteInput";
            bntDeleteInput.Size = new Size(119, 41);
            bntDeleteInput.TabIndex = 8;
            bntDeleteInput.Text = "Удалить";
            bntDeleteInput.UseVisualStyleBackColor = true;
            bntDeleteInput.Click += bntDeleteInput_Click;
            // 
            // btnEditInput
            // 
            btnEditInput.Location = new Point(1342, 315);
            btnEditInput.Name = "btnEditInput";
            btnEditInput.Size = new Size(119, 41);
            btnEditInput.TabIndex = 9;
            btnEditInput.Text = "Изменить";
            btnEditInput.UseVisualStyleBackColor = true;
            btnEditInput.Click += btnEditInput_Click;
            // 
            // btnAddInput
            // 
            btnAddInput.Location = new Point(1467, 315);
            btnAddInput.Name = "btnAddInput";
            btnAddInput.Size = new Size(119, 41);
            btnAddInput.TabIndex = 10;
            btnAddInput.Text = "Добавить";
            btnAddInput.UseVisualStyleBackColor = true;
            btnAddInput.Click += btnAddInput_Click;
            // 
            // btnAddOutput
            // 
            btnAddOutput.Location = new Point(1467, 630);
            btnAddOutput.Name = "btnAddOutput";
            btnAddOutput.Size = new Size(119, 41);
            btnAddOutput.TabIndex = 13;
            btnAddOutput.Text = "Добавить";
            btnAddOutput.UseVisualStyleBackColor = true;
            btnAddOutput.Click += btnAddOutput_Click;
            // 
            // btnEditOutput
            // 
            btnEditOutput.Location = new Point(1342, 630);
            btnEditOutput.Name = "btnEditOutput";
            btnEditOutput.Size = new Size(119, 41);
            btnEditOutput.TabIndex = 12;
            btnEditOutput.Text = "Изменить";
            btnEditOutput.UseVisualStyleBackColor = true;
            btnEditOutput.Click += btnEditOutput_Click;
            // 
            // btnDeleteOutput
            // 
            btnDeleteOutput.Location = new Point(1217, 630);
            btnDeleteOutput.Name = "btnDeleteOutput";
            btnDeleteOutput.Size = new Size(119, 41);
            btnDeleteOutput.TabIndex = 11;
            btnDeleteOutput.Text = "Удалить";
            btnDeleteOutput.UseVisualStyleBackColor = true;
            btnDeleteOutput.Click += btnDeleteOutput_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1218, 59);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 14;
            label1.Text = "Входы";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1218, 377);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 15;
            label2.Text = "Выходы";
            // 
            // btnRebuild
            // 
            btnRebuild.Location = new Point(1078, 815);
            btnRebuild.Name = "btnRebuild";
            btnRebuild.Size = new Size(123, 33);
            btnRebuild.TabIndex = 16;
            btnRebuild.Text = "Пересобрать";
            btnRebuild.UseVisualStyleBackColor = true;
            btnRebuild.Click += btnRebuild_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1221, 692);
            label3.Name = "label3";
            label3.Size = new Size(252, 20);
            label3.TabIndex = 17;
            label3.Text = "Задержка между итерациями в мс.";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1218, 715);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(366, 27);
            textBox1.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1596, 860);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(btnRebuild);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddOutput);
            Controls.Add(btnEditOutput);
            Controls.Add(btnDeleteOutput);
            Controls.Add(btnAddInput);
            Controls.Add(btnEditInput);
            Controls.Add(bntDeleteInput);
            Controls.Add(listBoxOutputs);
            Controls.Add(listBoxInputs);
            Controls.Add(btnCopy);
            Controls.Add(textBoxMain);
            Controls.Add(textBoxFilePath);
            Controls.Add(btnChoooseFile);
            Name = "Form1";
            Text = "UPRA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChoooseFile;
        private TextBox textBoxFilePath;
        private TextBox textBoxMain;
        private Button btnCopy;
        private ListBox listBoxInputs;
        private ListBox listBoxOutputs;
        private Button bntDeleteInput;
        private Button btnEditInput;
        private Button btnAddInput;
        private Button btnAddOutput;
        private Button btnEditOutput;
        private Button btnDeleteOutput;
        private Label label1;
        private Label label2;
        private Button btnRebuild;
        private Label label3;
        private TextBox textBox1;
    }
}
