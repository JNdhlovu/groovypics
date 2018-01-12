using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GroovyPics.Database;
using GroovyPics.Database.Entities;
using GroovyPics.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace GroovyPics
{
    public partial class GroovyPicsPage : ContentPage
    {
        private GroovyDatabase _groovyDatabase;
        public IEnumerable<ImageEntry> imageUrls { get; set; }
        public GroovyPicsPage()
        {
            InitializeComponent();
            Title = "Groovy Pics";

            _groovyDatabase = new GroovyDatabase();
            refreshView();
        }

        private void refreshView()
        {
            imageUrls = _groovyDatabase.getImages();

            if (imageUrls.Count() > 0)
            {
                ImagesListView.ItemsSource = imageUrls;
                Content = ImagesListView;
            }
            else
            {
                Content = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Children = {
                        new Label
                                {
                                    Text = "No images available, please click Camera to take a photo",
                                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                                    VerticalOptions = LayoutOptions.StartAndExpand,
                                    FontSize = 20,
                                    TextColor = Color.Blue,
                                    HorizontalTextAlignment = TextAlignment.Center
                                 }
                        }
                };
            }

        }

        private async void OnItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null; 
            ImageEntry imageEntry = (ImageEntry)e.SelectedItem;
            await Navigation.PushAsync(new CameraContentPage(imageEntry));
        }


        private async void OnCameraButtonClicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "Device camera not available", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "GroovyPics",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000
            });

            if (file == null)
                return;

            _groovyDatabase.addImage(file.Path);
            refreshView();
        }
    }
}
