using System;
using System.Windows.Forms;

namespace PowerPoint
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
            var model = new PowerPointModel();
            var presentationModel = new PresentationModel(model);
            Application.Run(new Form1(presentationModel));
        }
    }
}
