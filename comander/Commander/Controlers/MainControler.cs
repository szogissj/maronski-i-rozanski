using Commander.Models;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Commander.Controlers
{
    public class MainControler : IControler
    {
        public MainView View { get; private set; }
        public MainModel Model { get; private set; }

        public bool[] ShowHidden { get; set; }

        public MainControler()
        {
            View = new MainView(this);
            Model = new MainModel(this);

            ShowHidden = new bool[] { false, false };
        }

        public void OnFormLoad()
        {
            Model.LoadDrives();

            View.SetDrives(Space.Local, Model.Drives);
            SelectDrive(Space.Local, 0);
            SetCurrentPath(Space.Local);
            RefreshSpaceList(Space.Local, Model.CurrentPath[Space.Local]);

            View.SetDrives(Space.Global, Model.Drives);
            SelectDrive(Space.Global, 0);
            SetCurrentPath(Space.Global);
            RefreshSpaceList(Space.Global, Model.CurrentPath[Space.Global]);
        }

        public void CreateFolder(int space, string folderName)
        {
            Model.CreateFolder(space, folderName);
            RefreshSpaceList(space, Model.CurrentPath[space]);
        }

        public void CreateFile(int space, string fileName)
        {
            Model.CreateFile(space, fileName);
            RefreshSpaceList(space, Model.CurrentPath[space]);
        }

        public bool OnDriveSelect(int space, int drive)
        {
            if (TrySelectDrive(space, drive))
                RefreshSpaceList(space, Model.GetCurrentPath(space));
            else
            {
                View.SelectDrive(space, Model.SelectedDrive[space]);
                return false;
            }

            return true;
        }

        public void Remove(string path)
        {
            FileAttributes info = File.GetAttributes(path);
            if ((info & FileAttributes.Directory) == FileAttributes.Directory)
            {
                if (Directory.Exists(path))
                {
                    string[] itemsInDir = Directory.GetFileSystemEntries(path);
                    if (itemsInDir.Length == 0)
                        Directory.Delete(path);
                    else
                    {
                        foreach (string subItem in itemsInDir)
                            Remove(subItem);
                        Directory.Delete(path);
                    }
                }
            }
            else
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }
        
        public void Remove(string[] paths, int space)
        {
            StringBuilder builder = new StringBuilder();
            string text = string.Format("Czy napewno chcesz usunąć {0} wybranych plików/katalogów?", paths.Length);
            builder.AppendLine(text).AppendLine();
            for (int i = 0; i < 5 && i < paths.Length; i++)
                builder.AppendLine(Path.GetFileName(paths[i]));

            if (paths.Length > 6)
                builder.AppendLine("...");

            if (MessageBox.Show(builder.ToString(), "Commander", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveSelected(space);
            }
        }

        public void RemoveSelected(int space)
        {
            foreach(string toRm in View.GetSelectedItems(space))
                Remove(toRm);
            RefreshSpaceList(space, Model.CurrentPath[space]);
        }

        public void SelectDrive(int space, int drive)
        {
            if (drive < 0 && drive > Model.Drives.Count) return;

            Model.SelectDrive(space, drive);
            View.SelectDrive(space, drive);
        }

        public bool TrySelectDrive(int space, int drive)
        {
            if (drive < 0 && drive > Model.Drives.Count) return false;
            if (!Model.DriveIsReady(space, drive)) return false;

            Model.SelectDrive(space, drive);
            View.SelectDrive(space, drive);

            return true;
        }

        public void SetCurrentPath(int space)
        {
            View.SetCurrentPath(space, Model.CurrentPath[space].FullName);
        }

        public void RefreshSpaceList(int space, DirectoryInfo dir)
        {
            ClearSpaceList(space);

            View.SetCurrentPath(space, dir.FullName);

            Model.IncludeDirUp = Model.NestingLevel[space] > 0;

            string[][] folders = Model.LoadFoldersInCurrentPath(space, ShowHidden[space]);
            View.AddFoldersToSpace(space, folders);

            string[][] files = Model.LoadFilesInCurrentPath(space, ShowHidden[space]);
            View.AddFilesToSpace(space, files);
        }

        public void ClearSpaceList(int space)
        {
            View.ClearSpaceList(space);
            Model.ClearSpaceList(space);
        }

        public void OnMouseLeftDoubleClick(int space, string selected, int index)
        {
            FileSystemInfo info = GetSelected(space, selected);
            if(info != null)
            {
                if (info.Attributes.HasFlag(FileAttributes.Directory))
                {
                    Model.CurrentPath[space] = new DirectoryInfo(info.FullName);
                    Model.NestingLevel[space]++;

                    RefreshSpaceList(space, Model.CurrentPath[space]);
                }
                else
                {
                    Process.Start(info.FullName);
                }
            }
            else
            {
                if(Directory.Exists(selected))
                {
                    Model.CurrentPath[space] = new DirectoryInfo(selected);
                    Model.NestingLevel[space]--;

                    RefreshSpaceList(space, Model.CurrentPath[space]);
                }
            }
        }

        public FileSystemInfo GetSelected(int space, string selected)
        {
            if (Model.CurrentItems[space].ContainsKey(selected))
                return Model.CurrentItems[space][selected];
            return null;
        }

        public void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs = true)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDir);

            destDir = Path.Combine(destDir, Path.GetFileName(sourceDir));
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDir, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDir, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public void Rename(string path, string newName, int space)
        {
            Model.Rename(path, newName);
            RefreshSpaceList(space, Model.CurrentPath[space]);
        }

    }
}
