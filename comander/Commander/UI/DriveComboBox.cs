using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Commander.UI
{
    public partial class DriveComboBox : ComboBox
    {

        public DriveComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDown;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            DriveItem item = Items[e.Index] as DriveItem;

            e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top, 16, 16);

            Color color = e.ForeColor;

            if (!item.Ready)
                color = Color.DarkRed;

            e.Graphics.DrawString(item.Name, e.Font, new
                    SolidBrush(color), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);

            base.OnDrawItem(e);
        }

        public class DriveItem
        {
            public string Name { get; set; }
            public Image Image { get; set; }
            public bool Ready { get; set; }

            public DriveItem(string name, Image img, bool ready = true)
            {
                Name = name;
                Image = img;
                Ready = ready;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
