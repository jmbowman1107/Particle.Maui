using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Particle.Maui.Sample.Demo2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Demo2 : ContentPage
    {
        public Demo2()
        {
            InitializeComponent();
            MyParticleCanvas.FallingParticleGenerator = new LogoParticleGenerator();
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