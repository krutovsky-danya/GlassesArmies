﻿using System.Windows.Forms;
using GlassesArmies.View;

namespace GlassesArmies
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var controller = new Controller();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(controller));
        }
    }
}