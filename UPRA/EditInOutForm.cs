using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPRA
{
    public partial class EditInOutForm : Form
    {
        List<string> vars;
        List<string> ports;
        public EditInOutForm(List<string> vars, List<string> ports)
        {
            InitializeComponent();
            this.vars = vars;
            this.ports = ports;

            for (int i = 0; i < vars.Count; i++)
            {
                comboBoxVars.Items.Add(vars[i]);
            }
            for (int i = 0; i < ports.Count; i++)
            {
                comboBoxPorts.Items.Add(ports[i]);
            }
        }
        public EditInOutForm(List<string> vars, List<string> ports, (string, string) pair)
        {
            InitializeComponent();
            this.vars = vars;
            this.ports = ports;

            for (int i = 0; i < vars.Count; i++)
            {
                comboBoxVars.Items.Add(vars[i]);
            }
            for (int i = 0; i < ports.Count; i++)
            {
                comboBoxPorts.Items.Add(ports[i]);
            }
            comboBoxVars.Text = pair.Item1;
            comboBoxPorts.Text = pair.Item2;
        }

        public (string, string) getResult()
        {
            return (comboBoxVars.Text, comboBoxPorts.Text);
        
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxVars.Text == "" || comboBoxPorts.Text == "") 
            {
                MessageBox.Show("Имеются пустные поля", "Предупреждение");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
