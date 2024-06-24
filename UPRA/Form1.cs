using System.Windows.Forms;

namespace UPRA
{
    public partial class Form1 : Form
    {
        private VBOParser vboParser;
        private List<(string, string)> inputs = new List<(string, string)>();
        private List<(string, string)> outputs = new List<(string, string)>();

        private List<string> inputPorts = new List<string>();
        private List<string> outputPorts = new List<string>();

        public Form1()
        {
            InitializeComponent();
            fillportstest();
        }

        private void fillportstest()
        {
            inputPorts.Add("MY_IN0");
            inputPorts.Add("MY_IN1");
            inputPorts.Add("MY_IN2");
            inputPorts.Add("MY_IN3");
            inputPorts.Add("MY_IN4");

            outputPorts.Add("MY_OUT0");
            outputPorts.Add("MY_OUT1");
            outputPorts.Add("MY_OUT2");
            outputPorts.Add("MY_OUT3");
            outputPorts.Add("MY_OUT4");

        }

        List<(string, string)> fillinout(List<string> list)
        {
            List<(string, string)> values = new List<(string, string)>();
            for (int i = 0; i < list.Count; i++)
            {
                values.Add((list[i], ""));
            }
            return values;
        }

        private void updateListBoxes()
        {
            listBoxInputs.Items.Clear();
            listBoxOutputs.Items.Clear();
            foreach (var input in inputs)
            {
                string str = (input.Item1 + " = " + (input.Item2 == "" ? "*нет входа*" : input.Item2));
                listBoxInputs.Items.Add(str);
            }
            foreach (var output in outputs)
            {
                string str = (output.Item1 + " = " + (output.Item2 == "" ? "*нет выхода*" : output.Item2));
                listBoxOutputs.Items.Add(str);
            }
        }


        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Файлы представлений (*.vho)|*.vho|Все файлы (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxMain.Text = "";
                string selectedFileName = openFileDialog1.FileName;

                //MessageBox.Show("Выбранный файл: " + selectedFileName, "Выбран файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxFilePath.Text = selectedFileName;
                this.vboParser = new VBOParser(selectedFileName);

                //textBoxMain.Text = vboParser.fullCheck() + Environment.NewLine;
                textBoxMain.Text = "";
                this.inputs = fillinout(vboParser.getInputs());
                this.outputs = fillinout(vboParser.getOutputs());
                updateListBoxes();
                textBoxMain.Text += vboParser.genCode();

            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (textBoxMain.Text.Length > 0)
            {
                Clipboard.SetText(textBoxMain.Text);
                MessageBox.Show("Текст успешно скопирован в буфер обмена", "Успех");
            }
        }

        private void btnAddInput_Click(object sender, EventArgs e)
        {
            EditInOutForm frm = new EditInOutForm(vboParser.getInputs(), inputPorts);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                (string, string) temp = frm.getResult();
                inputs.Add(temp);
                updateListBoxes();
            }
        }

        private void btnEditInput_Click(object sender, EventArgs e)
        {

            if (listBoxInputs.SelectedItem == null)
            {
                MessageBox.Show("Не выбрано значение для редактирования", "Предупреждение");
                return;
            }
            int selectedIndex = listBoxInputs.SelectedIndex;

            EditInOutForm frm = new EditInOutForm(vboParser.getInputs(), inputPorts, inputs[selectedIndex]);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                (string, string) temp = frm.getResult();
                inputs.RemoveAt(selectedIndex);
                inputs.Insert(selectedIndex, temp);
                updateListBoxes();
            }
        }

        private void bntDeleteInput_Click(object sender, EventArgs e)
        {

            if (listBoxInputs.SelectedItem == null)
            {
                MessageBox.Show("Не выбрано значение для удаления", "Предупреждение");
                return;
            }
            int selectedIndex = listBoxInputs.SelectedIndex;
            string tempVar = inputs[selectedIndex].Item1;
            int count = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i].Item1 == tempVar) count++;
            }
            if (count > 1) inputs.RemoveAt(selectedIndex);
            else
            {
                inputs.RemoveAt(selectedIndex);
                inputs.Insert(selectedIndex, (tempVar, ""));
            }
            updateListBoxes();
        }

        private void btnAddOutput_Click(object sender, EventArgs e)
        {
            EditInOutForm frm = new EditInOutForm(vboParser.getOutputs(), outputPorts);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                (string, string) temp = frm.getResult();
                outputs.Add(temp);
                updateListBoxes();
            }
        }

        private void btnEditOutput_Click(object sender, EventArgs e)
        {
            if (listBoxOutputs.SelectedItem == null)
            {
                MessageBox.Show("Не выбрано значение для редактирования", "Предупреждение");
                return;
            }
            int selectedIndex = listBoxOutputs.SelectedIndex;

            EditInOutForm frm = new EditInOutForm(vboParser.getOutputs(), outputPorts, outputs[selectedIndex]);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                (string, string) temp = frm.getResult();
                outputs.RemoveAt(selectedIndex);
                outputs.Insert(selectedIndex, temp);
                updateListBoxes();
            }
        }

        private void btnDeleteOutput_Click(object sender, EventArgs e)
        {

            if (listBoxOutputs.SelectedItem == null)
            {
                MessageBox.Show("Не выбрано значение для удаления", "Предупреждение");
                return;
            }
            int selectedIndex = listBoxOutputs.SelectedIndex;
            string tempVar = outputs[selectedIndex].Item1;
            int count = 0;
            for (int i = 0; i < outputs.Count; i++)
            {
                if (outputs[i].Item1 == tempVar) count++;
            }
            if (count > 1) outputs.RemoveAt(selectedIndex);
            else
            {
                outputs.RemoveAt(selectedIndex);
                outputs.Insert(selectedIndex, (tempVar, ""));
            }
            updateListBoxes();
        }

        private void btnRebuild_Click(object sender, EventArgs e)
        {
            if (textBoxFilePath.Text == "")
            {
                MessageBox.Show("Не выбрать путь до файла", "Предупреждение");
                return;
            }

            textBoxMain.Text = "";
            textBoxMain.Text += vboParser.rebuildWithInOutputs(inputs, outputs);

        }
    }
}
