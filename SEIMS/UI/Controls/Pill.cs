using System.Drawing.Drawing2D;
using SEIMS.Models;

namespace SEIMS.UI.Controls
{
    /// <summary>Small rounded label ("In Stock", "Perishable"...).</summary>
    public class Pill : Control
    {
        public Color FillColor { get; set; }
        public Color BorderColor { get; set; }

        public Pill()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Font = Theme.SmallBold;
            BackColor = Theme.Panel;
            Margin = new Padding(0, 0, 8, 0);
            SetTint(Theme.GreenDark, Theme.GreenBorder, Theme.GreenText);
        }

        public void SetTint(Color fill, Color border, Color text)
        {
            FillColor = fill;
            BorderColor = border;
            ForeColor = text;
            Invalidate();
        }

        public void SetTypeText(string text, bool perishable)
        {
            Text = text;
            if (perishable) SetTint(Theme.GreenDark, Theme.GreenBorder, Theme.GreenText);
            else SetTint(Theme.IndigoDark, Theme.IndigoBorder, Theme.Indigo);
        }

        public void SetStatus(StockStatus status, string text)
        {
            Text = text;
            switch (status)
            {
                case StockStatus.VeryLow: SetTint(Color.FromArgb(60, 14, 14), Color.FromArgb(140, 30, 30), Theme.RedText); break;
                case StockStatus.LowStock: SetTint(Theme.OrangeDark, Theme.OrangeBorder, Theme.Orange); break;
                default: SetTint(Theme.GreenDark, Theme.GreenBorder, Theme.GreenText); break;
            }
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            Size t = TextRenderer.MeasureText(Text, Font);
            return new Size(t.Width + 24, t.Height + 8);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Size = GetPreferredSize(Size.Empty);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = Theme.RoundedPath(r, Height / 2))
            using (var fill = new SolidBrush(FillColor))
            using (var pen = new Pen(BorderColor))
            {
                g.FillPath(fill, path);
                g.DrawPath(pen, path);
            }
            TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }
    }
}
