namespace Commander
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.localSpacePanel = new System.Windows.Forms.Panel();
            this.localShowHidden = new System.Windows.Forms.CheckBox();
            this.currentLocalPath = new System.Windows.Forms.TextBox();
            this.localSpaceList = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.localDiscInfo = new System.Windows.Forms.Label();
            this.globalSpacePanel = new System.Windows.Forms.Panel();
            this.currentGlobalPath = new System.Windows.Forms.TextBox();
            this.globalSpaceList = new System.Windows.Forms.ListView();
            this.globalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.globalDiscInfo = new System.Windows.Forms.Label();
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.ftpConnect = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreateDir = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.globalShowHidden = new System.Windows.Forms.CheckBox();
            this.localDiscComboBox = new Commander.UI.DriveComboBox();
            this.globalDiscComboBox = new Commander.UI.DriveComboBox();
            this.mainPanel.SuspendLayout();
            this.localSpacePanel.SuspendLayout();
            this.globalSpacePanel.SuspendLayout();
            this.topMenuPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.localSpacePanel);
            this.mainPanel.Controls.Add(this.globalSpacePanel);
            this.mainPanel.Location = new System.Drawing.Point(17, 98);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1198, 530);
            this.mainPanel.TabIndex = 2;
            // 
            // localSpacePanel
            // 
            this.localSpacePanel.Controls.Add(this.localShowHidden);
            this.localSpacePanel.Controls.Add(this.currentLocalPath);
            this.localSpacePanel.Controls.Add(this.localSpaceList);
            this.localSpacePanel.Controls.Add(this.localDiscInfo);
            this.localSpacePanel.Controls.Add(this.localDiscComboBox);
            this.localSpacePanel.Location = new System.Drawing.Point(0, 0);
            this.localSpacePanel.Margin = new System.Windows.Forms.Padding(4);
            this.localSpacePanel.Name = "localSpacePanel";
            this.localSpacePanel.Size = new System.Drawing.Size(599, 530);
            this.localSpacePanel.TabIndex = 0;
            // 
            // localShowHidden
            // 
            this.localShowHidden.AutoSize = true;
            this.localShowHidden.Location = new System.Drawing.Point(424, 8);
            this.localShowHidden.Name = "localShowHidden";
            this.localShowHidden.Size = new System.Drawing.Size(166, 23);
            this.localShowHidden.TabIndex = 4;
            this.localShowHidden.Text = "Pokazuj ukryte foldery";
            this.localShowHidden.UseVisualStyleBackColor = true;
            this.localShowHidden.CheckedChanged += new System.EventHandler(this.ShowHidden_CheckedChanged);
            // 
            // currentLocalPath
            // 
            this.currentLocalPath.Location = new System.Drawing.Point(4, 35);
            this.currentLocalPath.Name = "currentLocalPath";
            this.currentLocalPath.ReadOnly = true;
            this.currentLocalPath.Size = new System.Drawing.Size(586, 25);
            this.currentLocalPath.TabIndex = 3;
            // 
            // localSpaceList
            // 
            this.localSpaceList.AllowDrop = true;
            this.localSpaceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.ext,
            this.size,
            this.time});
            this.localSpaceList.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.localSpaceList.FullRowSelect = true;
            this.localSpaceList.Location = new System.Drawing.Point(4, 64);
            this.localSpaceList.Margin = new System.Windows.Forms.Padding(4);
            this.localSpaceList.Name = "localSpaceList";
            this.localSpaceList.Size = new System.Drawing.Size(586, 458);
            this.localSpaceList.TabIndex = 2;
            this.localSpaceList.UseCompatibleStateImageBehavior = false;
            this.localSpaceList.View = System.Windows.Forms.View.Details;
            this.localSpaceList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.localSpaceList_ItemDrag);
            this.localSpaceList.DragDrop += new System.Windows.Forms.DragEventHandler(this.SpaceList_DragDrop);
            this.localSpaceList.DragEnter += new System.Windows.Forms.DragEventHandler(this.SpaceList_DragEnter);
            this.localSpaceList.Enter += new System.EventHandler(this.SpaceList_Enter);
            this.localSpaceList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // name
            // 
            this.name.Text = "Nazwa";
            this.name.Width = 31;
            // 
            // ext
            // 
            this.ext.Text = "Rozszerzenie";
            this.ext.Width = 31;
            // 
            // size
            // 
            this.size.Text = "Rozmiar";
            this.size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.size.Width = 31;
            // 
            // time
            // 
            this.time.Text = "Czas";
            this.time.Width = 31;
            // 
            // localDiscInfo
            // 
            this.localDiscInfo.AutoSize = true;
            this.localDiscInfo.Location = new System.Drawing.Point(86, 8);
            this.localDiscInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.localDiscInfo.Name = "localDiscInfo";
            this.localDiscInfo.Size = new System.Drawing.Size(0, 19);
            this.localDiscInfo.TabIndex = 1;
            // 
            // globalSpacePanel
            // 
            this.globalSpacePanel.Controls.Add(this.globalShowHidden);
            this.globalSpacePanel.Controls.Add(this.currentGlobalPath);
            this.globalSpacePanel.Controls.Add(this.globalSpaceList);
            this.globalSpacePanel.Controls.Add(this.globalDiscInfo);
            this.globalSpacePanel.Controls.Add(this.globalDiscComboBox);
            this.globalSpacePanel.Location = new System.Drawing.Point(599, 0);
            this.globalSpacePanel.Margin = new System.Windows.Forms.Padding(4);
            this.globalSpacePanel.Name = "globalSpacePanel";
            this.globalSpacePanel.Size = new System.Drawing.Size(599, 530);
            this.globalSpacePanel.TabIndex = 1;
            // 
            // currentGlobalPath
            // 
            this.currentGlobalPath.Location = new System.Drawing.Point(4, 35);
            this.currentGlobalPath.Name = "currentGlobalPath";
            this.currentGlobalPath.ReadOnly = true;
            this.currentGlobalPath.Size = new System.Drawing.Size(586, 25);
            this.currentGlobalPath.TabIndex = 6;
            // 
            // globalSpaceList
            // 
            this.globalSpaceList.AllowDrop = true;
            this.globalSpaceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.globalName,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.globalSpaceList.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.globalSpaceList.FullRowSelect = true;
            this.globalSpaceList.HideSelection = false;
            this.globalSpaceList.Location = new System.Drawing.Point(4, 64);
            this.globalSpaceList.Margin = new System.Windows.Forms.Padding(4);
            this.globalSpaceList.Name = "globalSpaceList";
            this.globalSpaceList.Size = new System.Drawing.Size(586, 458);
            this.globalSpaceList.TabIndex = 5;
            this.globalSpaceList.UseCompatibleStateImageBehavior = false;
            this.globalSpaceList.View = System.Windows.Forms.View.Details;
            this.globalSpaceList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.globalSpaceList_ItemDrag);
            this.globalSpaceList.DragDrop += new System.Windows.Forms.DragEventHandler(this.SpaceList_DragDrop);
            this.globalSpaceList.DragEnter += new System.Windows.Forms.DragEventHandler(this.SpaceList_DragEnter);
            this.globalSpaceList.Enter += new System.EventHandler(this.SpaceList_Enter);
            this.globalSpaceList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDoubleClick);
            // 
            // globalName
            // 
            this.globalName.Text = "Nazwa";
            this.globalName.Width = 31;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Rozszerzenie";
            this.columnHeader2.Width = 31;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rozmiar";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 31;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Czas";
            this.columnHeader4.Width = 31;
            // 
            // globalDiscInfo
            // 
            this.globalDiscInfo.AutoSize = true;
            this.globalDiscInfo.Location = new System.Drawing.Point(86, 8);
            this.globalDiscInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.globalDiscInfo.Name = "globalDiscInfo";
            this.globalDiscInfo.Size = new System.Drawing.Size(0, 19);
            this.globalDiscInfo.TabIndex = 4;
            // 
            // topMenuPanel
            // 
            this.topMenuPanel.Controls.Add(this.ftpConnect);
            this.topMenuPanel.Controls.Add(this.refreshButton);
            this.topMenuPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.topMenuPanel.Location = new System.Drawing.Point(17, 31);
            this.topMenuPanel.Name = "topMenuPanel";
            this.topMenuPanel.Size = new System.Drawing.Size(1198, 60);
            this.topMenuPanel.TabIndex = 3;
            // 
            // ftpConnect
            // 
            this.ftpConnect.Image = global::Commander.Properties.Resources.Cloud_Storage_24px;
            this.ftpConnect.Location = new System.Drawing.Point(70, 0);
            this.ftpConnect.Name = "ftpConnect";
            this.ftpConnect.Size = new System.Drawing.Size(60, 60);
            this.ftpConnect.TabIndex = 1;
            this.ftpConnect.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.SystemColors.Control;
            this.refreshButton.Image = global::Commander.Properties.Resources.Refresh;
            this.refreshButton.Location = new System.Drawing.Point(4, 0);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(60, 60);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnCreateDir);
            this.panel1.Controls.Add(this.btnMove);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Location = new System.Drawing.Point(17, 636);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 31);
            this.panel1.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(1029, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(160, 25);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "{Btn_Text_Exit}";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(858, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 25);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "{Btn_Text_Delete}";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreateDir
            // 
            this.btnCreateDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCreateDir.BackColor = System.Drawing.SystemColors.Control;
            this.btnCreateDir.Location = new System.Drawing.Point(687, 3);
            this.btnCreateDir.Name = "btnCreateDir";
            this.btnCreateDir.Size = new System.Drawing.Size(165, 25);
            this.btnCreateDir.TabIndex = 4;
            this.btnCreateDir.Text = "{Btn_Text_CreateDir}";
            this.btnCreateDir.UseVisualStyleBackColor = false;
            this.btnCreateDir.Click += new System.EventHandler(this.btnCreateDir_Click);
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnMove.Enabled = false;
            this.btnMove.Location = new System.Drawing.Point(516, 3);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(165, 25);
            this.btnMove.TabIndex = 3;
            this.btnMove.Text = "{Btn_Text_Move}";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(345, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(165, 25);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "{Btn_Text_Copy}";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(174, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(165, 25);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "{Btn_Text_Edit}";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnPreview.BackColor = System.Drawing.SystemColors.Control;
            this.btnPreview.Location = new System.Drawing.Point(3, 3);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(165, 25);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "{Btn_Text_Preview}";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // globalShowHidden
            // 
            this.globalShowHidden.AutoSize = true;
            this.globalShowHidden.Location = new System.Drawing.Point(424, 8);
            this.globalShowHidden.Name = "globalShowHidden";
            this.globalShowHidden.Size = new System.Drawing.Size(166, 23);
            this.globalShowHidden.TabIndex = 7;
            this.globalShowHidden.Text = "Pokazuj ukryte foldery";
            this.globalShowHidden.UseVisualStyleBackColor = true;
            this.globalShowHidden.CheckedChanged += new System.EventHandler(this.ShowHidden_CheckedChanged);
            // 
            // localDiscComboBox
            // 
            this.localDiscComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.localDiscComboBox.FormattingEnabled = true;
            this.localDiscComboBox.Location = new System.Drawing.Point(4, 4);
            this.localDiscComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.localDiscComboBox.Name = "localDiscComboBox";
            this.localDiscComboBox.Size = new System.Drawing.Size(74, 26);
            this.localDiscComboBox.TabIndex = 0;
            this.localDiscComboBox.SelectedIndexChanged += new System.EventHandler(this.localDiscsComboBox_SelectedIndexChanged);
            // 
            // globalDiscComboBox
            // 
            this.globalDiscComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.globalDiscComboBox.FormattingEnabled = true;
            this.globalDiscComboBox.Location = new System.Drawing.Point(4, 4);
            this.globalDiscComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.globalDiscComboBox.Name = "globalDiscComboBox";
            this.globalDiscComboBox.Size = new System.Drawing.Size(74, 26);
            this.globalDiscComboBox.TabIndex = 4;
            this.globalDiscComboBox.SelectedIndexChanged += new System.EventHandler(this.globalDiscComboBox_SelectedIndexChanged);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1228, 704);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topMenuPanel);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commander";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.localSpacePanel.ResumeLayout(false);
            this.localSpacePanel.PerformLayout();
            this.globalSpacePanel.ResumeLayout(false);
            this.globalSpacePanel.PerformLayout();
            this.topMenuPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel globalSpacePanel;
        private System.Windows.Forms.Panel localSpacePanel;
        private Commander.UI.DriveComboBox localDiscComboBox;
        private System.Windows.Forms.Label localDiscInfo;
        private System.Windows.Forms.ListView localSpaceList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader ext;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.TextBox currentLocalPath;
        private System.Windows.Forms.Label globalDiscInfo;
        private System.Windows.Forms.TextBox currentGlobalPath;
        private Commander.UI.DriveComboBox globalDiscComboBox;
        private System.Windows.Forms.ListView globalSpaceList;
        private System.Windows.Forms.ColumnHeader globalName;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.CheckBox localShowHidden;
        private System.Windows.Forms.Panel topMenuPanel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreateDir;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button ftpConnect;
        private System.Windows.Forms.CheckBox globalShowHidden;
    }
}

