﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Xamarin.Essentials;
using PM2E102.Archivos;


namespace PM2E102
{

    public partial class MainPage : ContentPage
    {

        String direccion;
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

        private void AgregarFoto_Clicked(object sender, EventArgs e){}

        private async void TomarFoto_Clicked(object sender, EventArgs e) {

            var takepic = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "PhotoApp",
                Name = "TEST.jpg"
            });
            direccion = takepic.Path;


            if (takepic != null)
            {
                foto.Source = ImageSource.FromStream(() => { return takepic.GetStream(); });
            }
            var Sharephoto = takepic.Path;
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Foto",
                File = new ShareFile(Sharephoto)
            });

        }
        private async  void Galeria_Clicked(object sender, EventArgs e) {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Ooops", "Error de permisos", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });
            direccion = file.Path;

            if (file != null)
            {
                foto.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                return;
            }
            var Sharephoto = file.Path;
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Foto",
                File = new ShareFile(Sharephoto)
            });





        }
        private async void Agregar_Clicked(object sender, EventArgs e) {

              if (String.IsNullOrWhiteSpace(lblCod.Text)) {
                            if (direccion == "" || String.IsNullOrEmpty(txtDes.Text))
                            {
                                await DisplayAlert("Oops", "No se puede agregar si no tiene foto y/o descripción", "OK");
                            }
                                    else
                                    {
                                        var emple = new cLugares
                                        {
                                            latitudC = lblLat.Text,
                                            longitudC = lblLon.Text,
                                            descripcionC = txtDes.Text,
                                            imageC = direccion
                                        };
                                        var resultado = await App.BaseDatos.EmpleadoGuardar(emple);
                                        if (resultado != 0)
                                        {
                                            await DisplayAlert("Aviso", "Lugar guardado!!", "OK");
                                            foto.Source = ("");
                                            direccion = "";
                                            txtDes.Text = "";
                                            ubicacion();



                                        }
                                        else
                                        {
                                            await DisplayAlert("Oops", "Error al guardar sus datos!", "OK");
                                        }
                                    }
              }
              else
              {
                   await DisplayAlert("Oops", "No se puede guardar si esta es una vista", "OK");
               }
            
        }
            

        
        private async void Lista_Clicked(object sender, EventArgs e) {
            var newpage = new lista();
            await Navigation.PushAsync(newpage);
        }
        private async void Eliminar_Clicked(object sender, EventArgs e) {

           if (String.IsNullOrEmpty(lblCod.Text))
            {
                await DisplayAlert("Oops", "No se puede actualizar si esta no es una vista", "OK");
            }
            else
            {
                var emple = new cLugares
                {
                    id = Convert.ToInt32(lblCod.Text)
                };
                var resultado = await App.BaseDatos.EmpleadoBorrar(emple);
                if (resultado != 0)
                {
                    await DisplayAlert("Aviso", "Lugar eliminado!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Ooops", "Error al eliminar estos datos", "OK");
                }

            }
        }
    }
}
