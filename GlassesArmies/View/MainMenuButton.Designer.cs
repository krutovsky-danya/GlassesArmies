using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies
{
    partial class MainMenuButton
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer _components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(string text)
        {
            _components = new System.ComponentModel.Container();
            
            this._mouseOutText = text;
            this.MouseInText = "> " + text;
            this.Text = text;
            this.Anchor = AnchorStyles.Left;
            this.AutoSize = true;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Font = new Font(FontFamily.GenericSerif, 16);
            // this.BackColor = Color.Coral;
            this.MouseEnter += ActivateText;
            this.MouseLeave += DeactivateText;
        }

        #endregion
    }
}