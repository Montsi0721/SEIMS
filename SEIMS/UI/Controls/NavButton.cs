using System.ComponentModel;

namespace SEIMS.UI.Controls
{
    /// <summary>Sidebar navigation entry (icon + caption + optional chevron).</summary>
    public class NavButton : Control
    {
        private bool _hover;
        private bool _selected;
        private bool _expanded;

        [Category("SEIMS")] public string Glyph { get { return _glyph; } set { _glyph = value; Invalidate(); } }
        private string _glyph;
        [Category("SEIMS")] public string Caption { get { return _caption; } set { _caption = value; Invalidate(); } }
        private string _caption;
        [Category("SEIMS"), DefaultValue(false)] public bool IsChild { get { return _isChild; } set { _isChild = value; Invalidate(); } }
        private bool _isChild;
        [Category("SEIMS"), DefaultValue(false)] public bool Expandable { get { return _expandable; } set { _expandable = value; Invalidate(); } }
        private bool _expandable;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; Invalidate(); }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Expanded
        {
            get { return _expanded; }
            set { _expanded = value; Invalidate(); }
        }

        public NavButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Cursor = Cursors.Hand;
            Height = 44;
            BackColor = Theme.Sidebar;
            Glyph = "";
            Caption = "";
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color back = _selected ? Theme.Selected : (_hover ? Theme.Hover : Theme.Sidebar);
            g.Clear(back);

            if (_selected)
            {
                using (var accent = new SolidBrush(Theme.Accent))
                    g.FillRectangle(accent, 0, 0, Theme.Scale(this, 3), Height);
            }

            int textX = Theme.Scale(this, IsChild ? 72 : 62);
            if (!IsChild && Glyph.Length > 0)
            {
                TextRenderer.DrawText(g, Glyph, Theme.IconM, new Rectangle(Theme.Scale(this, 18), 0, Theme.Scale(this, 32), Height),
                    _selected ? Theme.Accent : Theme.Text,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }

            TextRenderer.DrawText(g, Caption, IsChild ? Theme.NavChild : Theme.Nav,
                new Rectangle(textX, 0, Width - textX - Theme.Scale(this, 40), Height),
                IsChild && !_selected ? Theme.Muted : Theme.Text,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);

            if (Expandable)
            {
                TextRenderer.DrawText(g, _expanded ? Icons.ChevronUp : Icons.ChevronDown, Theme.IconS,
                    new Rectangle(Width - Theme.Scale(this, 40), 0, Theme.Scale(this, 28), Height), Theme.Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
        }
    }
}
