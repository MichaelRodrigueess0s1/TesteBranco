using Prism;
using Prism.Ioc;
using TesteBranco.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using SQLite;
using Prism.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TesteBranco
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        //static IPageDialogService PageDialogService = new PageDialogService();

         
        public App() : this(null)
        {
            
        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<ListaProfissionais>();
            containerRegistry.RegisterForNavigation<DetalheProfissional>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            //containerRegistry.RegisterInstance<IPageDialogService>(PageDialogService);            
        }
    }
}
