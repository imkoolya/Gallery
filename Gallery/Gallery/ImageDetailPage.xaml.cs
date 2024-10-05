using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDetailPage : ContentPage
    {
        public ImageDetailPage(ImageItem imageItem)
        {
            InitializeComponent();
            BindingContext = imageItem;
            imageItem.DateTaken = GetDateTaken(imageItem.Source);
        }

        private string GetDateTaken(string filePath)
        {
            return "Дата съёмки: " + DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}