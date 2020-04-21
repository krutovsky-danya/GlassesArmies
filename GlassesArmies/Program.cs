using System.Windows.Forms;
using System;
using System.Collections.Generic;

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
    
    public static class EnumerableExtension
    {
        public static void For<T>(this IEnumerable<T> sequence, Action<T, int> action)
        {
            var i = 0;
            foreach (var element in sequence)
            {
                action(element, i++);
            }
        }
    }
}