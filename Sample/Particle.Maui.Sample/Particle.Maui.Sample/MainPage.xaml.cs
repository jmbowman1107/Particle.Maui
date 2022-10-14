using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Particle.Maui.Sample
{
    public partial class MainPage : ContentPage
    {
        private const string TitleAnimationName = "TitleAnimation";

        private readonly Color[] _titleColors =
        {
            Colors.DodgerBlue,
            Colors.Gold,
            Colors.CornflowerBlue,
            Colors.PaleVioletRed,
            Colors.LawnGreen,
            Colors.LightPink,
            Colors.DarkTurquoise,
            Colors.Goldenrod,
            Colors.DarkViolet,
            Colors.Red
        };

        private uint _totalAnimationDuration = 3000;
        private Animation _parentAnimation;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _parentAnimation ??= GetTitleAnimation();
            _parentAnimation.Commit(this, TitleAnimationName, length: _totalAnimationDuration, easing: Easing.CubicOut, repeat: () => true);

            MyParticleCanvas.IsRunning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            this.AbortAnimation(TitleAnimationName);

            MyParticleCanvas.IsRunning = false;
        }

        private async void Demo1Btn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Demo1());
        }

        private async void Demo2Btn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Demo2.Demo2());
        }

        private Animation GetTitleAnimation()
        {
            var animations = new List<Animation>(_titleColors.Length);

            for (var i = 0; i < _titleColors.Length; i++)
            {
                var currentColor = _titleColors[i];
                var nextColor = _titleColors[(i + 1) % _titleColors.Length];

                animations.Add(new Animation(d =>
                    {
                        var r = currentColor.Red + (d * (nextColor.Red - currentColor.Red));
                        var g = currentColor.Green + (d * (nextColor.Green - currentColor.Green));
                        var b = currentColor.Blue + (d * (nextColor.Blue - currentColor.Blue));
                        var h = currentColor.GetHue() + (d * (nextColor.GetHue() - currentColor.GetHue()));
                        var s = currentColor.GetSaturation() + (d * (nextColor.GetSaturation() - currentColor.GetSaturation()));
                        var l = currentColor.GetLuminosity() + (d * (nextColor.GetLuminosity() - currentColor.GetLuminosity()));

                        TitleLabel.TextColor = new Color((float)r, (float)g, (float)b).WithHue((float)h).WithLuminosity((float)l).WithSaturation((float)s);
                    }
                ));
            }

            var parentAnimation = new Animation();
            var childAnimationDuration = ((float) _totalAnimationDuration) / animations.Count;
            for (var i = 0; i < animations.Count; i++)
            {
                var currentAnimation = animations[i];
                parentAnimation.Add(
                    (i * childAnimationDuration) / _totalAnimationDuration,
                    ((i + 1) * childAnimationDuration) / _totalAnimationDuration,
                    currentAnimation);
            }

            return parentAnimation;
        }
    }
}