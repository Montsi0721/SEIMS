namespace SEIMS.UI.Controls
{
    /// <summary>DataGridView that already has the dark SEIMS look. Add columns in the designer as usual.</summary>
    public class DarkGrid : DataGridView
    {
        public DarkGrid()
        {
            DoubleBuffered = true;
            Theme.StyleGrid(this);
        }
    }
}
