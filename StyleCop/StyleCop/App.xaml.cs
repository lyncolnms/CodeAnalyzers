using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace StyleCop {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new MainPage();

            string test = "test";
            var test=1234;
        }

        protected override void OnStart() {
            // Handle when your app starts

            var test = 2;
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
