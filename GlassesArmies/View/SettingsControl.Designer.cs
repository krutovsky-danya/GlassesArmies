using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GlassesArmies.View;
using Control = System.Windows.Forms.Control;
using Orientation = System.Windows.Forms.Orientation;

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
            this.Font = new Font(FontFamily.GenericSerif, 10);
            this._layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.settings = new System.Windows.Forms.TableLayoutPanel();
            this.back = new MainMenuButton("Back");
            this.back.TextAlign = ContentAlignment.MiddleCenter;
            this.back.Click += (sender, args) => this._controller.ChangeState(Controller.State.Back);
            this.SuspendLayout();
            // 
            // _layoutPanel
            // 
            this._layoutPanel.ColumnCount = 3;
            this._layoutPanel.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._layoutPanel.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._layoutPanel.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
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
            this._layoutPanel.Controls.Add(this.back, 2, 2);
            this._layoutPanel.Size = new System.Drawing.Size(720, 480);
            this._layoutPanel.TabIndex = 0;
            // 
            // settings
            // 
            this.settings.AutoSize = true;
            this.settings.Dock = DockStyle.Fill;
            this.settings.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.settings.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
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
        private GlassesArmies.MainMenuButton back;

        private void ConfigureSettings()
        {
            this.musicVolumeLabel = new SettingsLabel("Music Volume");
            this.musicVolumeTrackBar = new SettingsSlider();
            
            this.soundsVolumeLabel = new SettingsLabel("Sounds Volume");
            this.soundsVolumeTrackBar = new SettingsSlider();
            
            this.resolutionLabel = new SettingsLabel("Resolution");
            // this.resolutionSwitcher = new SettingsSwitcher<Resolution>(new Resolution(3, 4),
            //    new Resolution(720, 480),
            //    new Resolution(1080, 920));
            
            this.fullScreenLabel = new SettingsLabel("Full Screen");
            this.fullScreenSwitcher = new SettingsSwitcher<string>(new[] {"OFF", "ON"}, new Action[]
            {
                this._controller.OffFullScreen,
                this._controller.SetFullScreen
            });
            
            var BorderLessLabel = new SettingsLabel("Borderless");
            var BorderlessSwitcher = new SettingsSwitcher<string>(new[] {"OFF", "ON"}, new Action[]
            {
                this._controller.BackBorders,
                this._controller.SetBorderLess
            });

            var rowContent = new List<Tuple<SettingsLabel, Control>>
            {
                Tuple.Create<SettingsLabel, Control>(this.musicVolumeLabel, this.musicVolumeTrackBar),
                Tuple.Create<SettingsLabel, Control>(this.soundsVolumeLabel, this.soundsVolumeTrackBar),
                // Tuple.Create<SettingsLabel, Control>(this.resolutionLabel, this.resolutionSwitcher),
                Tuple.Create<SettingsLabel, Control>(this.fullScreenLabel, this.fullScreenSwitcher),
                Tuple.Create<SettingsLabel, Control>(BorderLessLabel, BorderlessSwitcher)
            };

            for (int i = 0; i < rowContent.Count; i++)
            {
                this.settings.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
                this.settings.Controls.Add(rowContent[i].Item1, 0, i);
                this.settings.Controls.Add(rowContent[i].Item2, 1, i);
            }
            this.settings.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
            
            this.ChangeControls = new Label();
            this.ChangeControls.Text = "Change Controls";
            this.ChangeControls.Dock = DockStyle.Fill;
            this.ChangeControls.TextAlign = ContentAlignment.MiddleCenter;
            //this.ChangeControls.BackColor = Color.Gray;
            //this.settings.Controls.Add(this.ChangeControls, 0, 4);
            this.settings.SetColumnSpan(this.ChangeControls, 2);
            
            //this.soundsVolumeLabel.BackColor = Color.Navy;
            //this.musicVolumeLabel.BackColor = Color.Peru;
        }

        private GlassesArmies.SettingsLabel musicVolumeLabel;
        private GlassesArmies.SettingsSlider musicVolumeTrackBar;
        private GlassesArmies.SettingsLabel soundsVolumeLabel;
        private GlassesArmies.SettingsSlider soundsVolumeTrackBar;
        private GlassesArmies.SettingsLabel resolutionLabel;
        //private SettingsSwitcher<Resolution> resolutionSwitcher;
        private GlassesArmies.SettingsLabel fullScreenLabel;
        private SettingsSwitcher<string> fullScreenSwitcher;
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