using System.ComponentModel;

namespace SEIMS.UI.Controls
{
    /// <summary>Panel with a 1px card border. Use it for every "card" in the dark design.</summary>
    public class CardPanel : Panel
    {
        private Color _borderColor = Theme.Border;

        public CardPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Theme.Panel;
        }

        [Category("SEIMS")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(_borderColor))
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }
}
