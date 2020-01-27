using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExemploWorkerAndroidForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
