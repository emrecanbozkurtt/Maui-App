using InsuranceApp.MVVM.Model;
using InsuranceApp.Services;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace InsuranceApp.MVVM.ViewModel;

public partial class UserEntryViewModel : ContentPage
{
    readonly ILoginRepository _loginRepository = new LoginService();
    readonly ILoginRepository userServer = new LoginService();

    public UserEntryViewModel()
    {
        InitializeComponent();
        Title = "UserEntryViewModel";

    }
    private async void Login_Clicked(object sender, EventArgs e)

    {
        await Navigation.PushAsync(new UserProfileViewModel());
       
        try
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await DisplayAlert("Hatal� giri�", "L�tfen kullan�c� ad�n�z� veya �ifrenizi giriniz", "Tamam");
                return;
            }

            User user = await userServer.Login(Username, Password);



            if (user == null)
            {
                await DisplayAlert("Hatal� giri�", "Kullan�c� ad� veya �ifre yanl��", "Tamam");
                return;

            }
            else
            {
                await Navigation.PushAsync(new UserProfileViewModel());
                await DisplayAlert("Giri�", "Ba�ar�l� bir �ekilde girildi", "Tamam");
            }



        }catch (Exception ex)
        {
            await DisplayAlert("Hatal� giri�",ex.Message, "Tamam");
        }
       
    }

}
