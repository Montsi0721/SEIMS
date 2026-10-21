using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SEIMS.UI.Controls
{
    /// <summary>Dashboard summary card (Total Items, Low Stock, ...).</summary>
    public class StatCard : Control
    {
        [Category("SEIMS")] public string Caption { get { return _caption; } set { _caption = value; Invalidate(); } }
        private string _caption;
        [Category("SEIMS")] public string Value { get { return _value; } set { _value = value; Invalidate(); } }
        private string _value;
        [Category("SEIMS")] public string Subtitle { get { return _subtitle; } set { _subtitle = value; Invalidate(); } }
        private string _subtitle;
        [Category("SEIMS")] public string Glyph { get { return _glyph; } set { _glyph = value; Invalidate(); } }
        private string _glyph;
        [Category("SEIMS")] public Color FillColor { get { return _fillColor; } set { _fillColor = value; Invalidate(); } }
        private Color _fillColor;
        [Category("SEIMS")] public Color BorderColor { get { return _borderColor; } set { _borderColor = value; Invalidate(); } }
        private Color _borderColor;
        [Category("SEIMS")] public Color IconColor { get { return _iconColor; } set { _iconColor = value; Invalidate(); } }
        private Color _iconColor;
        [Category("SEIMS")] public Color IconBack { get { return _iconBack; } set { _iconBack = value; Invalidate(); } }
        private Color _iconBack;

        public StatCard()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Theme.Bg;
            Caption = ""; Value = "0"; Subtitle = ""; Glyph = "";
            FillColor = Theme.Panel; BorderColor = Theme.Border; IconColor = Theme.Text; IconBack = Theme.Panel2;
        }

        public void SetValue(string value)
        {
            Value = value;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = Theme.RoundedPath(r, 10))
            using (var fill = new SolidBrush(FillColor))
            using (var pen = new Pen(BorderColor))
            {
                g.FillPath(fill, path);
                g.DrawPath(pen, path);
            }

            int d = Theme.Scale(this, 68);
            Rectangle circle = new Rectangle(Theme.Scale(this, 22), (Height - d) / 2, d, d);
            using (var b = new SolidBrush(IconBack)) g.FillEllipse(b, circle);
            TextRenderer.DrawText(g, Glyph, Theme.IconL, circle, IconColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

            int x = circle.Right + Theme.Scale(this, 16);
            TextRenderer.DrawText(g, Caption, Theme.Body, new Point(x, Theme.Scale(this, 24)), Theme.Text, TextFormatFlags.NoPadding);
            TextRenderer.DrawText(g, Value, Theme.Big, new Point(x, Theme.Scale(this, 44)), Theme.Text, TextFormatFlags.NoPadding);
            TextRenderer.DrawText(g, Subtitle, Theme.Small, new Point(x, Theme.Scale(this, 92)), Theme.Muted, TextFormatFlags.NoPadding);
        }
    }
}
