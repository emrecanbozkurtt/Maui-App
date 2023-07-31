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
                await DisplayAlert("Hatalý giriþ", "Lütfen kullanýcý adýnýzý veya þifrenizi giriniz", "Tamam");
                return;
            }

            User user = await userServer.Login(Username, Password);



            if (user == null)
            {
                await DisplayAlert("Hatalý giriþ", "Kullanýcý adý veya þifre yanlýþ", "Tamam");
                return;

            }
            else
            {
                await Navigation.PushAsync(new UserProfileViewModel());
                await DisplayAlert("Giriþ", "Baþarýlý bir þekilde girildi", "Tamam");
            }



        }catch (Exception ex)
        {
            await DisplayAlert("Hatalý giriþ",ex.Message, "Tamam");
        }
       
    }

}
