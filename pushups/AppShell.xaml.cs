namespace pushups
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.PushupPage), typeof(Views.PushupPage));
        }
    }
}
