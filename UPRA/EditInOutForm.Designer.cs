namespace UPRA
{
    partial class EditInOutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxVars = new ComboBox();
            comboBoxPorts = new ComboBox();
            labelVar = new Label();
            labelPort = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            buttonCancel = new Button();
            buttonSave = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxVars
            // 
            comboBoxVars.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVars.FormattingEnabled = true;
            comboBoxVars.Location = new Point(6, 58);
            comboBoxVars.Name = "comboBoxVars";
            comboBoxVars.Size = new Size(473, 28);
            comboBoxVars.TabIndex = 0;
            // 
            // comboBoxPorts
            // 
            comboBoxPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPorts.FormattingEnabled = true;
            comboBoxPorts.Location = new Point(6, 134);
            comboBoxPorts.Name = "comboBoxPorts";
            comboBoxPorts.Size = new Size(473, 28);
            comboBoxPorts.TabIndex = 1;
            // 
            // labelVar
            // 
            labelVar.AutoSize = true;
            labelVar.Location = new Point(6, 35);
            labelVar.Name = "labelVar";
            labelVar.Size = new Size(209, 20);
            labelVar.TabIndex = 2;
            labelVar.Text = "Наименование переменной";
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(6, 111);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(130, 20);
            labelPort.TabIndex = 3;
            labelPort.Text = "Выбранный порт";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(labelPort);
            groupBox1.Controls.Add(labelVar);
            groupBox1.Controls.Add(comboBoxPorts);
            groupBox1.Controls.Add(comboBoxVars);
            groupBox1.Location = new Point(2, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(495, 172);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выберите нужный порт для переменной";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 95);
            label1.Name = "label1";
            label1.Size = new Size(19, 20);
            label1.TabIndex = 4;
            label1.Text = "=";
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(238, 190);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(116, 34);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(365, 190);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(116, 34);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // EditInOutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 235);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Controls.Add(groupBox1);
            Name = "EditInOutForm";
            Text = "UPRA";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxVars;
        private ComboBox comboBoxPorts;
        private Label labelVar;
        private Label labelPort;
        private GroupBox groupBox1;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label1;
    }
}