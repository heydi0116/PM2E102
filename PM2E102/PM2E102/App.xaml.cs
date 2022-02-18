using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E102.Archivos;
using System.IO;

namespace PM2E102
{
    public partial class App : Application
    {
        static baseDatos basedatos;

        public static baseDatos BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new baseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmpleDB.db3"));
                }
                return basedatos;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
