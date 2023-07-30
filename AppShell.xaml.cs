using InsuranceApp.MVVM.ViewModel;

namespace InsuranceApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(UserEntryViewModel), typeof(UserEntryViewModel));
        Routing.RegisterRoute(nameof(UserProfileViewModel), typeof(UserProfileViewModel));
		Routing.RegisterRoute(nameof(KaskoPage),typeof(KaskoPage));
	}
}
