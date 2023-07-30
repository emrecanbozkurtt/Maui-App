using InsuranceApp.MVVM.ViewModel;

namespace InsuranceApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new UserEntryViewModel());
		
	}
}
