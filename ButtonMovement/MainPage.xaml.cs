using Microsoft.Maui.Controls;
using System;

namespace ButtonMovement
{
    public partial class MainPage : ContentPage
    {
        double startX, startY;
        double startButtonX, startButtonY;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    // Sürükleme işlemi başladığında butonun orijinal konumunu kaydedin
                    startX = e.TotalX;
                    startY = e.TotalY;
                    startButtonX = movingButton.TranslationX;
                    startButtonY = movingButton.TranslationY;
                    break;

                case GestureStatus.Running:
                    // Sürükleme işlemi devam ederken butonun konumunu güncelleyin
                    double newX = startButtonX + e.TotalX - startX;
                    double newY = startButtonY + e.TotalY - startY;

                    movingButton.TranslationX = newX;
                    movingButton.TranslationY = newY;
                    break;

                case GestureStatus.Completed:
                    // Sürükleme işlemi tamamlandığında hiçbir şey yapmayın
                    break;
            }
        }

        private async void OnButtonDoubleTapped(object sender, EventArgs e)
        {
            // Butona çift tıklandığında bir uyarı gösterin
            await DisplayAlert("Tıklandı", "Butona tıkladın!", "OK");
        }
    }
}
