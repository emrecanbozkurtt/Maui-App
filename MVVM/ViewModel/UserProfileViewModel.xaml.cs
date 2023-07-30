using InsuranceApp.MVVM.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace InsuranceApp.MVVM.ViewModel;
public partial class UserProfileViewModel : ContentPage
{
    public UserProfileViewModel()
    {
        InitializeComponent();
        BindingContext = this;
        LoadPolicies();
    }

  
    public ObservableCollection<Policy> Policies { get; set; }

    private void LoadPolicies()
    {
        Policies = new ObservableCollection<Policy>
            {
                new Policy { PolicyName = "Kasko", ImagePath="kasko.png"},
                new Policy { PolicyName = "Trafik", ImagePath = "trafik.jpg" },
                new Policy { PolicyName = "Konut", ImagePath = "konut.jpg" },
                new Policy { PolicyName = "Saðlýk", ImagePath = "saðlik.jpg"},
                new Policy { PolicyName = "Ferdi Kaza", ImagePath= "trafik.jpg"},
                new Policy { PolicyName = "Bireysel Emeklilik", ImagePath = "emeklilik.jpg"},
                new Policy { PolicyName = "Dask", ImagePath = "dask.png"},
                new Policy { PolicyName = "Hayat", ImagePath = "hayat.jpg"}
            };
    }

    private async void Kasko_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new KaskoPage());
    }

    private async void Trafik_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TrafikPage());
    }

    private async void Konut_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new KonutPage());
    }

    private async void Saðlýk_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SaglikPage());
    }

    private async void FerdiKaza_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FerdiKazaPage());
    }

    private async void Emeklilik_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmeklilikPage());
    }

    private async void Dask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DaskPage());
    }
    private async void Hayat_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HayatPage());
    }
}