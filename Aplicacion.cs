using Microsoft.VisualBasic.ApplicationServices;
namespace Consultor
{
    class Aplicacion : WindowsFormsApplicationBase
    {
        protected override void OnCreateSplashScreen()
        {
            base.OnCreateSplashScreen();
            //Pantalla de presentación
            this.SplashScreen = new Loading(); //Pantalla de presentación
            this.MinimumSplashScreenDisplayTime = 3000;
            this.IsSingleInstance = true;
        }
        protected override void OnCreateMainForm()
        {
            base.OnCreateMainForm();
            this.MainForm = new Form1();
            //Argumentos en la linea de ordenes
            if (this.CommandLineArgs.Count > 0)
            {
                if (this.CommandLineArgs[0] == "/max" || this.CommandLineArgs[0] == "-max")
                    this.MainForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }
    }
}
