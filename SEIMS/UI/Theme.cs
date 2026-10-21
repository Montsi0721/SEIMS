using System.Drawing.Drawing2D;

namespace SEIMS.UI
{
    /// <summary>Colours, fonts and styling helpers for the dark SEIMS design.</summary>
    public static class Theme
    {
        public static readonly Color Bg = Color.FromArgb(9, 13, 18);
        public static readonly Color Sidebar = Color.FromArgb(12, 17, 23);
        public static readonly Color Panel = Color.FromArgb(15, 21, 29);
        public static readonly Color Panel2 = Color.FromArgb(21, 29, 40);
        public static readonly Color Border = Color.FromArgb(33, 44, 58);
        public static readonly Color Hover = Color.FromArgb(21, 30, 42);
        public static readonly Color Selected = Color.FromArgb(28, 39, 54);
        public static readonly Color Text = Color.FromArgb(230, 237, 243);
        public static readonly Color Muted = Color.FromArgb(139, 148, 158);
        public static readonly Color Accent = Color.FromArgb(59, 130, 246);
        public static readonly Color Green = Color.FromArgb(22, 128, 60);
        public static readonly Color GreenText = Color.FromArgb(74, 222, 128);
        public static readonly Color GreenDark = Color.FromArgb(10, 33, 23);
        public static readonly Color GreenBorder = Color.FromArgb(24, 92, 52);
        public static readonly Color Orange = Color.FromArgb(245, 158, 11);
        public static readonly Color OrangeDark = Color.FromArgb(38, 23, 10);
        public static readonly Color OrangeBorder = Color.FromArgb(112, 62, 14);
        public static readonly Color Red = Color.FromArgb(220, 38, 38);
        public static readonly Color RedText = Color.FromArgb(248, 113, 113);
        public static readonly Color IndigoDark = Color.FromArgb(20, 18, 46);
        public static readonly Color IndigoBorder = Color.FromArgb(54, 48, 112);
        public static readonly Color Indigo = Color.FromArgb(129, 140, 248);

        public static readonly Font Body = new Font("Segoe UI", 9.5F);
        public static readonly Font BodyBold = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font Small = new Font("Segoe UI", 8.5F);
        public static readonly Font SmallBold = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        public static readonly Font Nav = new Font("Segoe UI Semibold", 10.5F);
        public static readonly Font NavChild = new Font("Segoe UI", 10F);
        public static readonly Font Title = new Font("Segoe UI Semibold", 20F);
        public static readonly Font H2 = new Font("Segoe UI Semibold", 13F);
        public static readonly Font Big = new Font("Segoe UI Semibold", 24F);
        public static readonly Font IconXL = new Font("Segoe MDL2 Assets", 30F);
        public static readonly Font IconL = new Font("Segoe MDL2 Assets", 22F);
        public static readonly Font IconM = new Font("Segoe MDL2 Assets", 13F);
        public static readonly Font IconS = new Font("Segoe MDL2 Assets", 11F);

        public static int Scale(Control c, int px)
        {
            return (int)Math.Round(px * c.DeviceDpi / 96.0);
        }

        public static Color Lighten(Color c, int amount)
        {
            return Color.FromArgb(Math.Min(255, c.R + amount), Math.Min(255, c.G + amount), Math.Min(255, c.B + amount));
        }

        public static GraphicsPath RoundedPath(Rectangle r, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void StyleButton(Button b, Color back, Color fore, Color border)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = border;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.MouseOverBackColor = Lighten(back, 16);
            b.FlatAppearance.MouseDownBackColor = Lighten(back, 8);
            b.BackColor = back;
            b.ForeColor = fore;
            b.Font = BodyBold;
            b.Cursor = Cursors.Hand;
            b.UseVisualStyleBackColor = false;
        }

        public static void StyleInput(Control c)
        {
            c.BackColor = Panel2;
            c.ForeColor = Text;
            c.Font = Body;
            TextBox t = c as TextBox;
            if (t != null) t.BorderStyle = BorderStyle.FixedSingle;
            ComboBox cb = c as ComboBox;
            if (cb != null)
            {
                cb.FlatStyle = FlatStyle.Flat;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        public static void StyleGrid(DataGridView g)
        {
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.ReadOnly = true;
            g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.BackgroundColor = Panel;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Border;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 40;
            g.ColumnHeadersDefaultCellStyle.BackColor = Panel;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Text;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Panel;
            g.ColumnHeadersDefaultCellStyle.Font = BodyBold;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            g.DefaultCellStyle.BackColor = Panel;
            g.DefaultCellStyle.ForeColor = Text;
            g.DefaultCellStyle.SelectionBackColor = Selected;
            g.DefaultCellStyle.SelectionForeColor = Text;
            g.DefaultCellStyle.Font = Body;
            g.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            g.RowTemplate.Height = 44;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void ApplyToolStrip(ToolStrip strip)
        {
            strip.Renderer = new DarkRenderer();
            strip.BackColor = Sidebar;
            strip.ForeColor = Text;
        }
    }

    public class DarkColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected { get { return Theme.Selected; } }
        public override Color MenuItemBorder { get { return Theme.Border; } }
        public override Color MenuBorder { get { return Theme.Border; } }
        public override Color MenuItemSelectedGradientBegin { get { return Theme.Selected; } }
        public override Color MenuItemSelectedGradientEnd { get { return Theme.Selected; } }
        public override Color MenuItemPressedGradientBegin { get { return Theme.Panel2; } }
        public override Color MenuItemPressedGradientMiddle { get { return Theme.Panel2; } }
        public override Color MenuItemPressedGradientEnd { get { return Theme.Panel2; } }
        public override Color ToolStripDropDownBackground { get { return Theme.Panel; } }
        public override Color ImageMarginGradientBegin { get { return Theme.Panel; } }
        public override Color ImageMarginGradientMiddle { get { return Theme.Panel; } }
        public override Color ImageMarginGradientEnd { get { return Theme.Panel; } }
        public override Color SeparatorDark { get { return Theme.Border; } }
        public override Color SeparatorLight { get { return Theme.Border; } }
        public override Color ToolStripBorder { get { return Theme.Border; } }
        public override Color ToolStripGradientBegin { get { return Theme.Sidebar; } }
        public override Color ToolStripGradientMiddle { get { return Theme.Sidebar; } }
        public override Color ToolStripGradientEnd { get { return Theme.Sidebar; } }
        public override Color MenuStripGradientBegin { get { return Theme.Sidebar; } }
        public override Color MenuStripGradientEnd { get { return Theme.Sidebar; } }
        public override Color StatusStripGradientBegin { get { return Theme.Sidebar; } }
        public override Color StatusStripGradientEnd { get { return Theme.Sidebar; } }
        public override Color ButtonSelectedGradientBegin { get { return Theme.Selected; } }
        public override Color ButtonSelectedGradientMiddle { get { return Theme.Selected; } }
        public override Color ButtonSelectedGradientEnd { get { return Theme.Selected; } }
        public override Color ButtonSelectedBorder { get { return Theme.Border; } }
        public override Color ButtonSelectedHighlight { get { return Theme.Selected; } }
        public override Color ButtonPressedGradientBegin { get { return Theme.Panel2; } }
        public override Color ButtonPressedGradientMiddle { get { return Theme.Panel2; } }
        public override Color ButtonPressedGradientEnd { get { return Theme.Panel2; } }
        public override Color ButtonPressedBorder { get { return Theme.Border; } }
    }

    public class DarkRenderer : ToolStripProfessionalRenderer
    {
        public DarkRenderer() : base(new DarkColorTable())
        {
            RoundedEdges = false;
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Enabled ? Theme.Text : Theme.Muted;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Theme.Muted;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDown) base.OnRenderToolStripBorder(e);
        }
    }
}
