using Commander.Controlers;
using System.Windows.Forms;
using System;
using Commander.Dialogs;
using System.IO;

namespace Commander.UI
{
    public partial class SpaceListMenu : ContextMenuStrip
    {

        private MainControler Controler { get; set; }
        private int Space { get; set; }

        public SpaceListMenu(MainControler controler, int space)
        {
            Controler = controler;
            Space = space;

            ToolStripMenuItem newFile = new ToolStripMenuItem("Utwórz nowy plik");
            newFile.Click += new EventHandler(NewFile_OnClick);
            Items.Add(newFile);

            Items.Add(new ToolStripSeparator());

            ToolStripMenuItem editName = new ToolStripMenuItem("Zmień nazwę");
            editName.Click += new EventHandler(Rename_OnClick);
            Items.Add(editName);

            Items.Add(new ToolStripSeparator());

            ToolStripMenuItem newFolder = new ToolStripMenuItem("Nowy katalog");
            newFolder.Click += new EventHandler(NewFolder_OnClick);
            Items.Add(newFolder);

            ToolStripMenuItem remove = new ToolStripMenuItem("Usuń");
            remove.Click += new EventHandler(RemoveFolder_OnClick);
            Items.Add(remove);
        }

        public void NewFolder_OnClick(object sender, EventArgs e)
        {
            NewItemDialog newFolderDialog = new NewItemDialog();
            if(newFolderDialog.ShowDialog() == DialogResult.OK)
                Controler.CreateFolder(Space, newFolderDialog.Name);
        }

        public void NewFile_OnClick(object sender, EventArgs e)
        {
            NewItemDialog newFolderDialog = new NewItemDialog("Nowy plik");
            if (newFolderDialog.ShowDialog() == DialogResult.OK)
                Controler.CreateFile(Space, newFolderDialog.Name);
        }

        public void RemoveFolder_OnClick(object sender, EventArgs e)
        {
            string[] items = Controler.View.GetSelectedItems(Space);
            if (items.Length > 0)
                Controler.Remove(items, Space);
        }

        public void Rename_OnClick(object sender, EventArgs e)
        {
            string[] items = Controler.View.GetSelectedItems(Space);
            if (items.Length == 1)
            {
                RenameDialog renameDialog = new RenameDialog(Path.GetFileName(items[0]));
                if (renameDialog.ShowDialog() == DialogResult.OK)
                    Controler.Rename(items[0], renameDialog.NewName, Space);
            }
        }
    }
}
