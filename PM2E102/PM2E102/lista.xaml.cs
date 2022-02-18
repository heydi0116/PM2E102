using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E102
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lista : ContentPage
    {
        public lista()
        {
            InitializeComponent();
        }


       

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaEmpleados.ItemsSource = await App.BaseDatos.listaempleados();
        }

        private async void ListaEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            String sexResult = await DisplayActionSheet("¿Qué desea hacer? ", "Cancelar", null, "Ver Registro", "Geolocalización");


            switch (sexResult)
            {
                case "Ver Registro":
                    Archivos.cLugares item = (Archivos.cLugares)e.Item;
                    var newpage = new MainPage();
                    newpage.BindingContext = item;
                    await Navigation.PushAsync(newpage);
                    break;

                case "Geolocalización":

                    Archivos.cLugares item2 = (Archivos.cLugares)e.Item;
                    var newpage2 = new mp();
                    newpage2.BindingContext = item2;
                    await Navigation.PushAsync(newpage2);
                    
                    break;
               default:
                    break;
            }
            
        }

    }
}