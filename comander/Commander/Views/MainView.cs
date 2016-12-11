using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Commander.Controlers;
using Commander.Properties;
using Commander.Views;
using Commander.UI;
using Commander.Dialogs;

namespace Commander
{
    public partial class MainView : Form, IView
    {

        public const int IMAGE_UNDO = 0;
        public const int IMAGE_DIR = 1;
        public const int IMAGE_DOC = 2;
        public const int IMAGE_DIR_HIDDEN = 3;
        public const int IMAGE_ARCHIVE_ZIP = 4;

        public MainControler Controler { get; private set; }

        private ListView[] SpaceList { get; set; }
        private TextBox[] CurrentPathText { get; set; }
        private Label[] DriveInfoLabel { get;set; }
        private DriveComboBox[] DrivesComboBox { get; set; }
        private SpaceListMenu[] SpaceContextMenu { get; set; }
        private ImageList icons;

        public MainView(IControler controler)
        {
            InitializeComponent();

            Controler = controler as MainControler;
            SpaceList = new ListView[2];
            CurrentPathText = new TextBox[2];
            DriveInfoLabel = new Label[2];
            DrivesComboBox = new DriveComboBox[2];
            SpaceContextMenu = new SpaceListMenu[2]; 

            icons = new ImageList();
            icons.Images.AddRange(new Image[] { Resources.Undo, Resources.Folder, Resources.File, Resources.Folder_Hidden, Resources.Archive_ZIP });
            icons.ImageSize = new Size(16, 16);

            localSpaceList.SmallImageList = icons;
            globalSpaceList.SmallImageList = icons;

            SpaceList[Space.Local] = localSpaceList;
            SpaceList[Space.Global] = globalSpaceList;

            CurrentPathText[Space.Local] = currentLocalPath;
            CurrentPathText[Space.Global] = currentGlobalPath;

            DriveInfoLabel[Space.Local] = localDiscInfo;
            DriveInfoLabel[Space.Global] = globalDiscInfo;

            DrivesComboBox[Space.Local] = localDiscComboBox;
            DrivesComboBox[Space.Global] = globalDiscComboBox;

            SpaceContextMenu[Space.Local] = new SpaceListMenu(Controler, Space.Local);
            SpaceContextMenu[Space.Global] = new SpaceListMenu(Controler, Space.Global);

            SpaceList[Space.Local].ContextMenuStrip = SpaceContextMenu[Space.Local];
            SpaceList[Space.Global].ContextMenuStrip = SpaceContextMenu[Space.Global];

            SpaceList[Space.Local].Tag = Space.Local;
            SpaceList[Space.Global].Tag = Space.Global;

            btnPreview.Text = Resources.Btn_Text_Preview;
            btnEdit.Text = Resources.Btn_Text_Edit;
            btnCopy.Text = Resources.Btn_Text_Copy;
            btnMove.Text = Resources.Btn_Text_Move;
            btnCreateDir.Text = Resources.Btn_Text_CreateDir;
            btnDelete.Text = Resources.Btn_Text_Delete;
            btnExit.Text = Resources.Btn_Text_Exit;

            localShowHidden.Tag = Space.Local;
            globalShowHidden.Tag = Space.Global;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Controler.OnFormLoad();
        }

        public void ClearDrives(int space)
        {
            switch(space)
            {
                case Space.Local:
                    localDiscComboBox.Items.Clear();
                    break;
                case Space.Global:
                    globalDiscComboBox.Items.Clear();
                    break;
            }
        }
        public void SetDrives(int space, List<DriveInfo> drives)
        {
            foreach(DriveInfo drive in drives)
            {
                Image driveImage = Resources.Drive;

                switch (drive.DriveType)
                {
                    case DriveType.Network:
                        driveImage = Resources.Drive_Network;
                        break;
                    case DriveType.CDRom:
                        driveImage = Resources.Drive_CD;
                        break;
                    case DriveType.Removable:
                        driveImage = Resources.Drive_USB;
                        break;
                }

                if (drive.RootDirectory.FullName.Equals(Path.GetPathRoot(Environment.SystemDirectory)))
                    driveImage = Resources.DriveOS;

                DrivesComboBox[space].Items.Add(new DriveComboBox.DriveItem(drive.Name, driveImage, drive.IsReady));
            }
        }
        public void SelectDrive(int space, int drive)
        {
            if (drive < 0) return;
            if (space == Space.Local && drive < localDiscComboBox.Items.Count)
                localDiscComboBox.SelectedIndex = drive;
            else if (space == Space.Global && drive < globalDiscComboBox.Items.Count)
                globalDiscComboBox.SelectedIndex = drive;
        }
        public void SetDriveInfo(int space, string info)
        {
            DriveInfoLabel[space].Text = info;
        }

        public void AddFoldersToSpace(int space, string[][] folders)
        {
            bool first = true;
            foreach (string[] folder in folders)
            {
                ListViewItem itm = new ListViewItem(folder[0]);
                itm.SubItems.Add(folder[1]);
                itm.SubItems.Add(folder[2]);
                itm.SubItems.Add(folder[3]);
                //todo: o ikonie powinien decydowac model
                itm.ImageIndex = Controler.Model.NestingLevel[space]>0 && first ? IMAGE_UNDO : IMAGE_DIR;
                itm.Tag = folder[4];

                SpaceList[space].Items.Add(itm);
                first = false;
            }

            SpaceList[space].AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ResizeFirstColumn(SpaceList[space]);
        }
        public void AddFilesToSpace(int space, string[][] files)
        {
            SpaceList[space].BeginUpdate();

            foreach (string[] file in files)
            {
                ListViewItem itm = new ListViewItem(file[0]);
                itm.SubItems.Add(file[1]);
                itm.SubItems.Add(file[2]);
                itm.SubItems.Add(file[3]);

                Icon ico = Icon.ExtractAssociatedIcon(file[4]);
                icons.Images.Add(ico);
                itm.ImageIndex = icons.Images.Count - 1;

                itm.Tag = file[4];

                SpaceList[space].Items.Add(itm);
            }
            SpaceList[space].EndUpdate();

            SpaceList[space].AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ResizeFirstColumn(SpaceList[space]);
        }

        private void ResizeFirstColumn(ListView listView)
        {
            int nWidth = listView.ClientSize.Width;
            for (int i = 1; i < listView.Columns.Count; i++)
            {
                nWidth -= listView.Columns[i].Width;
                if (nWidth < 1)
                    break;
            }

            if (nWidth > 0)
                listView.Columns[0].Width = nWidth;
        }

        public void SetCurrentPath(int space, string path)
        {
            CurrentPathText[space].Text = path;
        }
        public void ClearSpaceList(int space)
        {
            SpaceList[space].Items.Clear();
        }

        private void localDiscsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool selected = Controler.OnDriveSelect(Space.Local, localDiscComboBox.SelectedIndex);
            if(!selected)
                MessageBox.Show("Dysk, który wybrałeś nie może być przeglądany.", "Nie można przyglądać wybranego dysku", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void globalDiscComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool selected = Controler.OnDriveSelect(Space.Global, globalDiscComboBox.SelectedIndex);
            if (!selected)
                MessageBox.Show("Dysk, który wybrałeś nie może być przeglądany.", "Nie można przyglądać wybranego dysku", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && localSpaceList.SelectedItems.Count == 1)
            {
                Controler.OnMouseLeftDoubleClick(Space.Local, localSpaceList.SelectedItems[0].Tag as string, localSpaceList.SelectedIndices[0]);
            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && globalSpaceList.SelectedItems.Count == 1)
            {
                Controler.OnMouseLeftDoubleClick(Space.Global, globalSpaceList.SelectedItems[0].Tag as string, globalSpaceList.SelectedIndices[0]);
            }
        }

        private void localSpaceList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string selected = (e.Item as ListViewItem).Text;

            if (selected.StartsWith("[") && selected.EndsWith("]"))
            {
                string raw = selected.Remove(0, 1);
                raw = raw.Remove(raw.Length - 1, 1);
                selected = raw;
            }

            /*
            DragDropData data = new DragDropData();
            data.Sender = localSpaceList;
            data.FullPath = 
            */

            localSpaceList.DoDragDrop(localSpaceList.SelectedItems, DragDropEffects.All);
        }

        private void globalSpaceList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            globalSpaceList.DoDragDrop(globalSpaceList.SelectedItems, DragDropEffects.All);
        }

        private void SpaceList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
            {
                if((ModifierKeys & Keys.Alt) == Keys.Alt)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void SpaceList_DragDrop(object sender, DragEventArgs e)
        {
            ListView owner = sender as ListView;
            object data = e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
            ListView.SelectedListViewItemCollection items = (ListView.SelectedListViewItemCollection) data;

            foreach (ListViewItem item in items)
            {
                if(e.Effect == DragDropEffects.Copy)
                {
                    FileAttributes info = File.GetAttributes(item.Tag as string);
                    if ((info & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        Controler.DirectoryCopy(item.Tag as string, Controler.Model.CurrentPath[(int)owner.Tag].FullName);
                        Controler.RefreshSpaceList((int)owner.Tag, Controler.Model.CurrentPath[(int)owner.Tag]);
                    }
                    else
                    {
                        File.Copy(item.Tag as string, Path.Combine(Controler.Model.GetSelectedDrive((int)owner.Tag).Name, Controler.Model.CurrentPath[(int)owner.Tag].Name, Path.GetFileName(item.Tag as string)));
                        Controler.RefreshSpaceList((int)owner.Tag, Controler.Model.CurrentPath[(int)owner.Tag]);
                    }
                }
                else if (e.Effect == DragDropEffects.Move)
                {
                    FileAttributes info = File.GetAttributes(item.Tag as string);
                    if ((info & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        Directory.Move(item.Tag as string, Controler.Model.CurrentPath[(int)owner.Tag].FullName);
                        Controler.RefreshSpaceList((int)owner.Tag, Controler.Model.CurrentPath[(int)owner.Tag]);
                    }
                    else
                    {
                        File.Move(item.Tag as string, Path.Combine(Controler.Model.GetSelectedDrive((int)owner.Tag).Name, Controler.Model.CurrentPath[(int)owner.Tag].Name, Path.GetFileName(item.Tag as string)));
                        Controler.RefreshSpaceList((int)owner.Tag, Controler.Model.CurrentPath[(int)owner.Tag]);
                    }
                }
            }
        }

        public string[] GetSelectedItems(int space)
        {
            List<string> selected = new List<string>();

            foreach (ListViewItem itm in SpaceList[space].SelectedItems)
                selected.Add(itm.Tag as string);

            return selected.ToArray();
        }

        public class DragDropData
        {
            public ListView Sender { get; set; }
            public string FullPath { get; set; }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Controler.RefreshSpaceList(Space.Local, Controler.Model.CurrentPath[Space.Local]);
            Controler.RefreshSpaceList(Space.Global, Controler.Model.CurrentPath[Space.Global]);
        }

        private void SpaceList_Enter(object sender, EventArgs e)
        {
            int space = (int)((ListView)sender).Tag;

            if (Controler.Model.ActiveSpace != space)
                Controler.Model.ActiveSpace = space;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection sele = SpaceList[Controler.Model.ActiveSpace].SelectedItems;
            if (sele.Count == 1)
            {
                ListViewItem itm = sele[0];
                string filename = itm.Tag as string;

                if(!File.GetAttributes(filename).HasFlag(FileAttributes.Directory))
                {
                    PreviewView preview = new PreviewView(filename);
                    preview.Show();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreateDir_Click(object sender, EventArgs e)
        {
            int space = Controler.Model.ActiveSpace;
            NewItemDialog newFolderDialog = new NewItemDialog();
            if (newFolderDialog.ShowDialog() == DialogResult.OK)
                Controler.CreateFolder(space, newFolderDialog.Name);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int space = Controler.Model.ActiveSpace;
            string[] items = Controler.View.GetSelectedItems(space);
            if (items.Length > 0)
                Controler.Remove(items, space);
        }

        private void ShowHidden_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int space = (int)(checkbox).Tag;
            Controler.ShowHidden[space] = checkbox.Checked;
            Controler.RefreshSpaceList(space, Controler.Model.CurrentPath[space]);
        }

    }
}
