using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyHeart_Map_Builder.ConsoleTextUtility
{
    public static class Debug
    {
        private static RichTextBox ConsoleBox;

        public static void IntilizeDebugOutput(ref RichTextBox box)
        {
            ConsoleBox = box;
        }

        public static void ClearDebugOutput()
        {

        }

        public static void WriteLine(string message)
        {
            ConsoleBox.AppendText(message);
        }
    }
}
