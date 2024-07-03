namespace PopupMAUI
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MDAxQDMyMzYyZTMwMmUzME15SStrK3luTlZQUjlrNkdEbXBPQzZRY2VudHlRNDlLdFZhQXNPcWV5NUE9");

            InitializeComponent();

            MainPage = new NavigationPage(new MoviesPage());
        }
    }
}
