using Commander.Modules;
using System;
using System.Text;
using System.Windows.Forms;

namespace Commander.Views
{
    public partial class PreviewView : Form
    {

        private string FileName { get; set; }

        private Encoding[] encodings;

        public PreviewView(string file)
        {
            InitializeComponent();

            FileName = file;
            encodings = new Encoding[] { Encoding.ASCII, Encoding.Unicode, Encoding.UTF7, Encoding.UTF8, Encoding.UTF32 };

            Text = FileName + " - Preview";

            ToolStripMenuItem itm = (ToolStripMenuItem) kodowanieToolStripMenuItem.DropDownItems.Add("ASCII");
            itm.Checked = true;
            itm.CheckOnClick = true;
            itm.Click += new EventHandler(Item_Checked);

            itm = (ToolStripMenuItem)kodowanieToolStripMenuItem.DropDownItems.Add("Unicode");
            itm.Checked = false;
            itm.CheckOnClick = true;
            itm.Click += new EventHandler(Item_Checked);

            itm = (ToolStripMenuItem)kodowanieToolStripMenuItem.DropDownItems.Add("UTF-7");
            itm.Checked = false;
            itm.CheckOnClick = true;
            itm.Click += new EventHandler(Item_Checked);

            itm = (ToolStripMenuItem)kodowanieToolStripMenuItem.DropDownItems.Add("UTF-8");
            itm.Checked = false;
            itm.CheckOnClick = true;
            itm.Click += new EventHandler(Item_Checked);

            itm = (ToolStripMenuItem)kodowanieToolStripMenuItem.DropDownItems.Add("UTF-32");
            itm.Checked = false;
            itm.CheckOnClick = true;
            itm.Click += new EventHandler(Item_Checked);
        }

        private void Item_Checked(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            int index = kodowanieToolStripMenuItem.DropDownItems.IndexOf(itm);

            foreach (ToolStripMenuItem i in kodowanieToolStripMenuItem.DropDownItems)
                if(i != itm)
                    i.Checked = false;

            textBox1.Text = PreviewModule.ReadFileHexView(FileName, encodings[index]);
        }

        private void PreviewView_Load(object sender, EventArgs e)
        {
            textBox1.Text = PreviewModule.ReadFileHexView(FileName, Encoding.ASCII);
        }
    }
}
