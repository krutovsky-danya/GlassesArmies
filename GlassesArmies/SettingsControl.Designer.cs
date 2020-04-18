using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;
using Orientation = System.Windows.Forms.Orientation;
using UserControl = System.Windows.Forms.UserControl;

namespace GlassesArmies
{
    partial class SettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.settings = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // _layoutPanel
            // 
            this._layoutPanel.ColumnCount = 3;
            this._layoutPanel.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.21854F));
            this._layoutPanel.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.36111F));
            this._layoutPanel.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.55556F));
            this._layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._layoutPanel.Location = new System.Drawing.Point(0, 0);
            this._layoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._layoutPanel.Name = "_layoutPanel";
            this._layoutPanel.RowCount = 3;
            this._layoutPanel.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.41406F));
            this._layoutPanel.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.32031F));
            this._layoutPanel.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.07031F));
            
            this._layoutPanel.Controls.Add(this.settings, 1, 1);
            this._layoutPanel.Size = new System.Drawing.Size(720, 480);
            this._layoutPanel.TabIndex = 0;
            // 
            // settings
            // 
            this.settings.AutoSize = true;
            this.settings.Dock = DockStyle.Fill;
            this.settings.ColumnCount = 2;
            this.settings.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.settings.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            ConfigureSettings();
            this.settings.Location = new System.Drawing.Point(0, 0);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(200, 100);
            this.settings.TabIndex = 0;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this._layoutPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(720, 480);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _layoutPanel;
        private System.Windows.Forms.TableLayoutPanel settings;

        private void ConfigureSettings()
        {
            this.settings.RowCount = 5;
            this.musicVolumeLabel = new SettingsLabel("Music Volume");
            this.settings.Controls.Add(musicVolumeLabel, 0, 0);
            
            this.musicVolumeTrackBar = new SettingsSlider();
            this.settings.Controls.Add(musicVolumeTrackBar, 1, 0);
            
            this.soundsVolumeLabel = new SettingsLabel("Sounds Volume");
            this.settings.Controls.Add(soundsVolumeLabel, 0, 1);
            
            this.soundsVolumeTrackBar = new SettingsSlider();
            this.settings.Controls.Add(soundsVolumeTrackBar, 1, 1);
            
            this.resolutionLabel = new SettingsLabel("Resolution");
            this.settings.Controls.Add(resolutionLabel, 0, 2);
            
            this.resolutionSwitcher = new SettingsSwitcher<Resolution>(new Resolution(3, 4),
                new Resolution(720, 480),
                new Resolution(1080, 920));
            this.settings.Controls.Add(resolutionSwitcher, 1, 2);
            
            this.fullScreanLabel = new SettingsLabel("Full Screan");
            this.settings.Controls.Add(this.fullScreanLabel, 0, 3);
            
            this.fullScreanSwitcher = new SettingsSwitcher<string>("OFF", "ON");
            this.settings.Controls.Add(this.fullScreanSwitcher, 1, 3);
            
            this.ChangeControls = new Label();
            this.ChangeControls.Text = "Change Controls";
            this.ChangeControls.Dock = DockStyle.Fill;
            this.ChangeControls.TextAlign = ContentAlignment.MiddleCenter;
            //this.ChangeControls.BackColor = Color.Gray;
            this.settings.Controls.Add(this.ChangeControls, 0, 4);
            this.settings.SetColumnSpan(this.ChangeControls, 2);
            
            //this.soundsVolumeLabel.BackColor = Color.Navy;
            // this.musicVolumeLabel.BackColor = Color.Peru;
        }

        private GlassesArmies.SettingsLabel musicVolumeLabel;
        private GlassesArmies.SettingsSlider musicVolumeTrackBar;
        private GlassesArmies.SettingsLabel soundsVolumeLabel;
        private GlassesArmies.SettingsSlider soundsVolumeTrackBar;
        private GlassesArmies.SettingsLabel resolutionLabel;
        private GlassesArmies.SettingsSwitcher<Resolution> resolutionSwitcher;
        private GlassesArmies.SettingsLabel fullScreanLabel;
        private GlassesArmies.SettingsSwitcher<string> fullScreanSwitcher;
        private System.Windows.Forms.Label ChangeControls;
    }
    
    public class SettingsLabel : System.Windows.Forms.Label
    {
        public SettingsLabel(string text)
        {
            this.Text = text;
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.AutoSize = true;
            this.Dock = DockStyle.Fill;
            this.TextAlign = ContentAlignment.MiddleRight;
        }
    }

    public class SettingsSlider : System.Windows.Forms.TrackBar
    {
        public SettingsSlider()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.Maximum = 100;
            this.Minimum = 0;
            this.Orientation = Orientation.Horizontal;
            this.AutoSize = true;
            this.Dock = DockStyle.Fill;
            this.SmallChange = 1;
            this.TickFrequency = 5;
            this.Value = 70;
        }
    }

    public class SettingsSwitcher<T> : UserControl
    {
        private List<T> options;
        private int index = 0;
        private Label left;
        private Label text;
        private Label right;

        public T Valur => options[index];
        
        public SettingsSwitcher(params T[] list)
        {
            options = new List<T>(list);
            if (options.Count == 0)
                throw new InvalidEnumArgumentException();
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            left = new Label {Text = "< "};
            text = new Label {Text = options[index].ToString()};
            right = new Label {Text = " >"};
            left.TextAlign = ContentAlignment.MiddleRight;
            text.TextAlign = ContentAlignment.MiddleCenter;
            right.TextAlign = ContentAlignment.MiddleLeft;
            left.Click += SwitchLeft;
            text.Click += SwitchRight;
            right.Click += SwitchRight;
            left.Dock = DockStyle.Right;
            text.Dock = DockStyle.Fill;
            right.Dock = DockStyle.Left;
            var layout = new TableLayoutPanel();
            layout.ColumnCount = 3;
            for (var i = 0; i < 3; i++)
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.RowCount = 1;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.Controls.Add(left, 0, 0);
            layout.Controls.Add(text, 1, 0);
            layout.Controls.Add(right, 2, 0);
            layout.AutoSize = true;
            layout.Dock = DockStyle.Fill;
            this.Controls.Add(layout);
            this.Dock = DockStyle.Fill;
            this.AutoSize = true;
        }

        private void SwitchLeft(object sender, EventArgs eventArgs)
        {
            index = (options.Count + index - 1) % options.Count;
            text.Text = options[index].ToString();
        }

        private void SwitchRight(object sender, EventArgs eventArgs)
        {
            index = (index + 1) % options.Count;
            text.Text = options[index].ToString();
        }
    }

    public class Resolution
    {
        public readonly int height;
        public readonly int width;
        
        public Resolution(int height, int widht)
        {
            this.height = height;
            this.width = widht;
        }

        public override string ToString()
        {
            return $"{height}x{width}";
        }
    }
}