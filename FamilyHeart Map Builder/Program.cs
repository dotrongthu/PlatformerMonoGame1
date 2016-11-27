using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FamilyHeart_Map_Builder.FormBuilder;

namespace FamilyHeart_Map_Builder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Builder builder = new Builder())
            {
                Application.Run(builder);
            }
        }
    }
}
