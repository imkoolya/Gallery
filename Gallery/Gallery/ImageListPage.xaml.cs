using System.Collections.ObjectModel;
using System.IO;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Gallery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageListPage : ContentPage
    {
        private ObservableCollection<ImageItem> images = new ObservableCollection<ImageItem>();
        private ImageItem selectedImage;

        public ImageListPage()
        {
            InitializeComponent();
            LoadImages();
            ImageListView.ItemsSource = images;
        }

        private void LoadImages()
        {
            var picturesPath = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath, "Screenshots");

            var files = Directory.GetFiles(picturesPath, "*.jpg");

            foreach (var file in files)
            {
                images.Add(new ImageItem { Source = file, Name = Path.GetFileName(file) });
            }
        }

        private void OnImageSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedImage = e.SelectedItem as ImageItem;
        }

        private async void OnOpenButtonClicked(object sender, EventArgs e)
        {
            if (selectedImage != null)
            {
                await Navigation.PushAsync(new ImageDetailPage(selectedImage));
            }
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (selectedImage != null)
            {
                var filePath = selectedImage.Source;
                File.Delete(filePath); // удаляем файл
                images.Remove(selectedImage); // удаляем элемент из списка
            }
        }
    }

    public class ImageItem
    {
        public string Source { get; set; }
        public string Name { get; set; }
        public string DateTaken { get; internal set; }
    }
}