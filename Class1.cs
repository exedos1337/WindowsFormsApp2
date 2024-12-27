using System;
using System.Windows.Forms;
using WindowsFormsApp2;


namespace WindowsFormsApplication4
{
    static class Program
    {
        
        [STAThread]
        static void Main(string[]Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
