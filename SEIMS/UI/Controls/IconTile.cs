using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SEIMS.UI.Controls
{
    /// <summary>Rounded tile showing one Segoe MDL2 glyph (logo, item thumbnail).</summary>
    public class IconTile : Control
    {
        private string _glyph = Icons.Package;
        private Color _glyphColor = Theme.Text;
        private Color _fillColor = Theme.Panel2;
        private Color _borderColor = Theme.Border;
        private int _radius = 12;
        private float _glyphSize = 30F;

        public IconTile()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Theme.Bg;
            Size = new Size(58, 58);
        }

        [Category("SEIMS")] public string Glyph { get { return _glyph; } set { _glyph = value ?? ""; Invalidate(); } }
        [Category("SEIMS")] public Color GlyphColor { get { return _glyphColor; } set { _glyphColor = value; Invalidate(); } }
        [Category("SEIMS")] public Color FillColor { get { return _fillColor; } set { _fillColor = value; Invalidate(); } }
        [Category("SEIMS")] public Color BorderColor { get { return _borderColor; } set { _borderColor = value; Invalidate(); } }
        [Category("SEIMS"), DefaultValue(12)] public int CornerRadius { get { return _radius; } set { _radius = Math.Max(0, value); Invalidate(); } }
        [Category("SEIMS"), DefaultValue(30F)] public float GlyphSize { get { return _glyphSize; } set { _glyphSize = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            int radius = Math.Min(_radius, Math.Min(r.Width, r.Height) / 2);
            if (radius < 1) radius = 1;
            using (GraphicsPath path = Theme.RoundedPath(r, radius))
            using (var fill = new SolidBrush(_fillColor))
            using (var pen = new Pen(_borderColor))
            {
                g.FillPath(fill, path);
                g.DrawPath(pen, path);
            }

            using (var font = new Font("Segoe MDL2 Assets", _glyphSize))
            {
                TextRenderer.DrawText(g, _glyph, font, r, _glyphColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
        }
    }
}
