using System.ComponentModel;

namespace SEIMS.UI.Controls
{
    public enum ButtonKind { Primary, Secondary, Ghost, Danger }

    /// <summary>
    /// Flat dark button. Drag it from the Toolbox and pick a look with the <see cref="Kind"/> property
    /// (Primary = blue, Secondary = dark, Ghost = outlined, Danger = red outline).
    /// </summary>
    public class ThemedButton : Button
    {
        private ButtonKind _kind = ButtonKind.Secondary;

        public ThemedButton()
        {
            FlatStyle = FlatStyle.Flat;
            Font = Theme.BodyBold;
            Cursor = Cursors.Hand;
            UseVisualStyleBackColor = false;
            ApplyKind();
        }

        [Category("SEIMS"), DefaultValue(ButtonKind.Secondary)]
        public ButtonKind Kind
        {
            get { return _kind; }
            set { _kind = value; ApplyKind(); }
        }

        // colours come from Kind, so they are not shown or saved separately
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            ApplyKind();
        }

        private void ApplyKind()
        {
            Color back, fore, border;
            switch (_kind)
            {
                case ButtonKind.Primary: back = Theme.Accent; fore = Color.White; border = Theme.Accent; break;
                case ButtonKind.Ghost: back = Theme.Panel; fore = Theme.Text; border = Color.FromArgb(80, 92, 108); break;
                case ButtonKind.Danger: back = Theme.Panel; fore = Color.FromArgb(239, 68, 68); border = Color.FromArgb(180, 40, 40); break;
                default: back = Theme.Panel2; fore = Theme.Text; border = Theme.Border; break;
            }
            if (!Enabled) fore = Theme.Muted;

            base.BackColor = back;
            base.ForeColor = fore;
            FlatAppearance.BorderSize = 1;
            FlatAppearance.BorderColor = border;
            FlatAppearance.MouseOverBackColor = Theme.Lighten(back, 16);
            FlatAppearance.MouseDownBackColor = Theme.Lighten(back, 8);
        }
    }
}
