using System;
using System.Windows.Forms;

namespace Commander.Dialogs
{
    public partial class NewItemDialog : Form
    {

        public string Name { get; private set; }

        public NewItemDialog()
        {
            InitializeComponent();
        }

        public NewItemDialog(string title)
        {
            InitializeComponent();

            Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(folderName.Text))
            {
                MessageBox.Show("Nazwa nie może być pusta", "Podaj nazwę jeszcze raz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
            Name = folderName.Text;
            Dispose();
        }
    }
}
