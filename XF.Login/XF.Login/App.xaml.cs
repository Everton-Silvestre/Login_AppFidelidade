using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Login.ViewModel;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF.Login
{
    public partial class App : Application
    {
        public static UsuarioViewModel UsuarioVM { get; set; }

        public App()
        {
            InitializeComponent();

            if (UsuarioVM == null) UsuarioVM = new UsuarioViewModel();

            MainPage = new NavigationPage(new View.LoginPage() { BindingContext = App.UsuarioVM });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
