using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupportTemplates
{
    static class Program
    {
        public static SplashScreen splashScreen = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //show splash
            Thread splashThread = new Thread(new ThreadStart(
                delegate
                {
                    splashScreen = new SplashScreen();
                    Application.Run(splashScreen);
                }
                ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            //run form - time taking operation
            Form1 mainForm = new Form1();
            mainForm.Load += new EventHandler(mainForm_Load);
            Application.Run(mainForm);

            //Application.Run(new Form1());  // Original code before splash screen

        }

        // show splash continued
        static void mainForm_Load(object sender, EventArgs e)
        {
            //close splash
            if (splashScreen == null)
            {
                return;
            }

            splashScreen.Invoke(new Action(splashScreen.Close));
            splashScreen.Dispose();
            splashScreen = null;
        }

    }
}
