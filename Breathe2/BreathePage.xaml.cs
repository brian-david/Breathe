using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Breathe2
{
    public partial class BreathePage : ContentPage
    {
        bool animate;

        public BreathePage()
        {
            InitializeComponent();
            animate = true;
            StartBreathing();
        }

        protected void BreathBtnClicked(object sender, EventArgs e)
        {
            StartBreathing();
        }

        private async void StartBreathing()
        {
            
            //var backgroundAnimation = new Animation(callback: v => BackgroundColor = Color.FromHsla(v, 1, 0.5), start: 0, end: 1);
            //backgroundAnimation.Commit(this, "Animation", 16, 4000, Easing.Linear, (v, c) => BackgroundColor = Color.Default);
            while (animate)
            {
                
                await BreathIn();
                await BreathOut();
            }
        }

        protected async void BackBtn_Clicked(object sender, EventArgs e)
        {
            animate = false;
            await Navigation.PopAsync();
        }

        private  Task BreathIn()
        {
            this.ColorTo(Color.FromRgb(43, 192, 228), Color.FromRgb(234, 236, 198), c => BackgroundColor = c, 4000);
            BackgroundColor = Color.Default;
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            var kerningContract = new Animation(v => breatherLabel.Kerning = (float)v, 2, 40);
            kerningContract.Commit((Xamarin.Forms.IAnimatable)this, "kerningExpandAnimation", 0, 4000, Easing.SinInOut, (finalValue, cancelled) => taskCompletionSource.SetResult(cancelled));
            Vibration.Vibrate(TimeSpan.FromSeconds(4));
            Console.WriteLine("BREATHING IN");
            return taskCompletionSource.Task;
        }

        private Task BreathOut()
        {
            this.ColorTo(Color.FromRgb(234, 236, 198), Color.FromRgb(43, 192, 228), c => BackgroundColor = c, 4000);
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            var kerningContract = new Animation(v => breatherLabel.Kerning = (float)v, 40, 2);
            kerningContract.Commit((Xamarin.Forms.IAnimatable)this, "kerningExpandAnimation", 0, 4000, Easing.SinInOut, (finalValue, cancelled) => taskCompletionSource.SetResult(cancelled));
            Console.WriteLine("BREATHING OUT");
            return taskCompletionSource.Task;
        }
    }
}
