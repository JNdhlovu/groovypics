using System;
using System.Collections.Generic;
using GroovyPics.Database.Entities;
using Xamarin.Forms;

namespace GroovyPics.Views
{
    public partial class CameraContentPage : ContentPage
    {
        
        public CameraContentPage(ImageEntry imageEntry)
        {
            InitializeComponent();
            Title = imageEntry.CreatedAt.ToString("hh:mm dd MMM yyyy");
            FullScreenImage.Source = imageEntry.LocalUrl;
        }
    }
}
