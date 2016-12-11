using System;
using System.Windows.Forms;

namespace Commander.Dialogs
{
    public partial class RenameDialog : Form
    {

        public string NewName { get; private set; }

        public RenameDialog(string name)
        {
            InitializeComponent();

            tbName.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Nazwa nie może być pusta", "Podaj nazwę jeszcze raz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
            NewName = tbName.Text;
            Dispose();
        }
    }
}
