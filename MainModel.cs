using Commander.Controlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Commander.Models
{
    public class MainModel : IModel
    {
        public IControler Controler { get; private set; }

        public List<DriveInfo> Drives { get; private set; }

        public int[] SelectedDrive { get; set; }
        public DirectoryInfo[] CurrentPath { get; set; }
        public Dictionary<string, FileSystemInfo>[] CurrentItems { get; set; }
        public int[] NestingLevel { get; set; }
        public bool IncludeDirUp { get; set; }

        public int ActiveSpace { get; set; }

        public MainModel(IControler controler)
        {
            Controler = controler;

            Drives = new List<DriveInfo>();

            SelectedDrive = new int[2];
            CurrentItems = new Dictionary<string, FileSystemInfo>[2];
            NestingLevel = new int[2];
            CurrentPath = new DirectoryInfo[2];

            SelectedDrive[Space.Local] = 0;
            CurrentItems[Space.Local] = new Dictionary<string, FileSystemInfo>();
            NestingLevel[Space.Local] = 0;

            SelectedDrive[Space.Global] = 0;
            CurrentItems[Space.Global] = new Dictionary<string, FileSystemInfo>();
            NestingLevel[Space.Global] = 0;

            IncludeDirUp = false;

            ActiveSpace = Space.Local;
        }

        public void LoadDrives()
        {
            Drives = new List<DriveInfo>();
            Drives.AddRange(DriveInfo.GetDrives());
        }

        public string[][] LoadFoldersInCurrentPath(int space, bool ShowHidden = false)
        {
            List<string[]> folders = new List<string[]>();

            IncludeDirUp = IncludeDirUp && CurrentPath[space].Parent != null;
            if (IncludeDirUp)
            {
                DirectoryInfo parent = CurrentPath[space].Parent;
                string[] dirString = new string[5];
                dirString[0] = "[..]";
                dirString[1] = "";
                dirString[2] = "<DIR>";
                dirString[3] = parent.LastAccessTime.ToString();
                dirString[4] = parent.FullName;

                folders.Add(dirString);
            }

            foreach (DirectoryInfo dir in CurrentPath[space].GetDirectories())
            {
                bool hidden = (dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                if (!hidden || (hidden && ShowHidden))
                {
                    string[] dirString = new string[5];
                    dirString[0] = string.Format("[{0}]", dir.Name);
                    dirString[1] = "";
                    dirString[2] = "<DIR>";
                    dirString[3] = dir.LastAccessTime.ToString();
                    dirString[4] = dir.FullName;

                    CurrentItems[space].Add(dir.FullName, dir);
                    folders.Add(dirString);
                }
            }

            return folders.ToArray<string[]>();
        }

        public string[][] LoadFilesInCurrentPath(int space, bool ShowHidden = false)
        {
            List<string[]> files = new List<string[]>();

            foreach (FileInfo file in CurrentPath[space].GetFiles())
            {
                bool hidden = (file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                if (!hidden || (hidden && ShowHidden))
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.Name);
                    string ext = file.Extension;

                    if(fileName.Length == 0)
                    {
                        fileName = ext;
                        ext = "";
                    }
                    else if(ext.Length > 0)
                    {
                        ext = ext.Remove(0, 1);
                    }

                    string[] fileString = new string[5];
                    fileString[0] = fileName;
                    fileString[1] = ext;
                    fileString[2] = BytesToNormal(file.Length);
                    fileString[3] = file.LastAccessTime.ToString();
                    fileString[4] = file.FullName;

                    CurrentItems[space].Add(file.FullName, file);
                    files.Add(fileString);
                }
            }

            return files.ToArray<string[]>();
        }

        public void SelectDrive(int space, int drive, bool CurrentPathToRoot = true)
        {
            if (drive < 0 && drive > Drives.Count) return;

            SelectedDrive[space] = drive;

            if (CurrentPathToRoot)
                SetCurrentPathToRoot(space);
        }
    
        public DriveInfo GetSelectedDrive(int space)
        {
            return Drives[SelectedDrive[space]];
        } 

        public bool DriveIsReady(int space, int drive)
        {
            if (drive < 0 && drive > Drives.Count) return false;
            return Drives[drive].IsReady;
        }
        public void SetCurrentPathToRoot(int space)
        {
            CurrentPath[space] = Drives[SelectedDrive[space]].RootDirectory;
        }

        public DirectoryInfo GetCurrentPath(int space)
        {
            return CurrentPath[space];
        }

        public void ClearSpaceList(int space)
        {
            CurrentItems[space].Clear();
        }

        private string BytesToNormal(long bb)
        {
            char[] prefixs = new char[] { 'k', 'M', 'G', 'T' };
            char prefix = '@';
            long nb = bb;

            for (int i = 0; i < prefixs.Length; i++)
            {
                if (nb > 1024)
                {
                    nb /= 1024;
                    prefix = prefixs[i];
                }
            }

            if (prefix != '@')
                return string.Format("{0} {1}B", nb, prefix);
            else
                return string.Format("{0} B", nb);
        }

        public void CreateFolder(int space, string name)
        {
            string newPath = Path.Combine(CurrentPath[space].FullName, name);
            DirectoryInfo newDir = new DirectoryInfo(newPath);
            newDir.Create();
        }

        public void CreateFile(int space, string fileName)
        {
            string newPath = Path.Combine(CurrentPath[space].FullName, fileName);
            File.Create(newPath);
        }

        public void Rename(string path, string newName)
        {
            string dir = Path.GetDirectoryName(path);
            File.Move(path, Path.Combine(dir, newName));
        }
    }
}
