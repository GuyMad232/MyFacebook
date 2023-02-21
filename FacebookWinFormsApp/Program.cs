using System;
using System.Windows.Forms;
using FacebookWrapper;

// $G$ THE-001 (-10) Grade: 90 on patterns selection / accuracy in implementation / description / document / diagrams (50%) (see comments in document).
// $G$ CSS-999 (-10) Coding Standards and StyleCop errors.

namespace BasicFacebookFeatures
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Clipboard.SetText("design.patterns20cc");
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(StaticFormFactory.CreateFormFactory(nameof(FormMain)));
        }
    }
}