using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace Breathe2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        async void BreathBtnClicked(object s, EventArgs e)
        {
            await Navigation.PushAsync(new BreathePage());
            Console.WriteLine("Breathing started");
        }

        async void ManageBtnClicked(object s, EventArgs e)
        {
            await Navigation.PushAsync(new Techniques());
            Console.WriteLine("Breathing started");
        }

        public MainPage()
        {
            InitializeComponent();       
        }        
    }
}
