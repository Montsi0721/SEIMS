using System.ComponentModel;

namespace SEIMS.UI.Controls
{
    /// <summary>Two-column "label : value" list used on the Item Details panel.</summary>
    public class KeyValueList : Control
    {
        private List<KeyValuePair<string, string>> _pairs = new List<KeyValuePair<string, string>>();

        [Category("SEIMS"), DefaultValue(28)]
        public int RowHeight { get; set; }

        public KeyValueList()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Theme.Panel;
            RowHeight = 28;
        }

        public void SetPairs(List<KeyValuePair<string, string>> pairs)
        {
            _pairs = pairs ?? new List<KeyValuePair<string, string>>();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            int rowHeight = Theme.Scale(this, RowHeight);
            int valueX = Theme.Scale(this, 130);
            for (int i = 0; i < _pairs.Count; i++)
            {
                int y = i * rowHeight;
                TextRenderer.DrawText(e.Graphics, _pairs[i].Key + ":", Theme.Body,
                    new Rectangle(0, y, valueX, rowHeight), Theme.Text,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);
                TextRenderer.DrawText(e.Graphics, _pairs[i].Value, Theme.Body,
                    new Rectangle(valueX, y, Math.Max(10, Width - valueX), rowHeight), Theme.Text,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);
            }
        }
    }
}
