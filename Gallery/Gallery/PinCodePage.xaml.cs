using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinCodePage : ContentPage
    {
        public PinCodePage()
        {
            InitializeComponent();
            CheckIfPinIsSet();
        }

        private async void CheckIfPinIsSet()
        {
            var enteredPin = PinEntry.Text;
            var storedPin = Preferences.Get("pin", null);
            if (storedPin != null)
            {
                if (enteredPin == storedPin)
                {
                    Navigation.PushAsync(new ImageListPage());
                }
            }
        }

        private async void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            var enteredPin = PinEntry.Text;
            var storedPin = Preferences.Get("pin", null);

            if (storedPin == null)
            {
                Preferences.Set("pin", enteredPin);
                await Navigation.PushAsync(new ImageListPage());
            }
            else if (enteredPin == storedPin)
            {
                await Navigation.PushAsync(new ImageListPage());
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный PIN-код", "OK");
            }
        }
    }
}