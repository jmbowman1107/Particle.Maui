using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Particle.Maui.Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Demo1 : ContentPage
    {
        public Demo1()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MyParticleCanvas.IsRunning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MyParticleCanvas.IsRunning = false;
        }
    }
}