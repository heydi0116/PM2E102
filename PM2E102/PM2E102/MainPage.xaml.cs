using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using PM2E102.Archivos;


namespace PM2E102
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ubicacion();

        }

        async private void ubicacion()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    lblLat.Text = location.Latitude.ToString();
                    lblLon.Text = location.Longitude.ToString();             
                }
            }
            catch (FeatureNotSupportedException fnsEx){}
            catch (FeatureNotEnabledException fneEx){}
            catch (PermissionException pEx){}
            catch (Exception ex){}

        }

        private void AgregarFoto_Clicked(object sender, EventArgs e)
        {

        }

        private void TomarFoto_Clicked(object sender, EventArgs e)
        {

        }

        private void Galeria_Clicked(object sender, EventArgs e)
        {

        }

        private void Agregar_Clicked(object sender, EventArgs e)
        {

        }

        private void Lista_Clicked(object sender, EventArgs e)
        {

        }

        private void Eliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
