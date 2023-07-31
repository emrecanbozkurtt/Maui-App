using InsuranceApp.MVVM.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;

namespace InsuranceApp.MVVM.ViewModel;


public partial class KaskoPage : ContentPage
{

    private string _policyOwner;
    private string _policyName;
    private string _tanzimTarihi;
    private string[] _vadeTarihleri;
    private string _primTutari;
    private Asset[] _teminatlar;
    private string _policyNumber;

    public string PolicyOwner
    {
        get => _policyOwner;
        set
        {
            _policyOwner = value;
            OnPropertyChanged(nameof(PolicyOwner));

        }
    }

    public string PolicyName
    {
        get => _policyName;
        set
        {
            _policyName = value;
            OnPropertyChanged(nameof(PolicyName));
        }
    }

    public string PolicyNumber
    {
        get => _policyNumber;
        set
        {
            _policyNumber = value;
            OnPropertyChanged(nameof(PolicyNumber));

        }
    }

    public string TanzimTarihi
    {
        get => _tanzimTarihi;
        set
        {
            _tanzimTarihi = value;
            OnPropertyChanged(nameof(TanzimTarihi));
        }
    }

    public string[] VadeTarihleri
    {
        get => _vadeTarihleri;
        set
        {
            _vadeTarihleri = value;
            OnPropertyChanged(nameof(VadeTarihleri));
        }
    }

    public string PrimTutari
    {
        get => _primTutari;
        set
        {
            _primTutari = value;
            OnPropertyChanged(nameof(PrimTutari));
        }
    }

    public Asset[] Teminatlar
    {
        get => _teminatlar;
        set
        {
            _teminatlar = value;
            OnPropertyChanged(nameof(Teminatlar));
        }
    }



    public KaskoPage()
    {
        InitializeComponent();

        LabelPolicyOwner.BindingContext = this;
        LabelPolicyOwner.SetBinding(Label.TextProperty, nameof(PolicyOwner));

        LabelPolicyName.BindingContext = this;
        LabelPolicyName.SetBinding(Label.TextProperty, nameof(PolicyName));

        LabelPolicyNumber.BindingContext = this;
        LabelPolicyNumber.SetBinding(Label.TextProperty, nameof(PolicyNumber));

        LabelTanzimTarihi.BindingContext = this;
        LabelTanzimTarihi.SetBinding(Label.TextProperty, nameof(TanzimTarihi));

        ListVadeTarihleri.BindingContext = this;
        ListVadeTarihleri.SetBinding(ItemsView.ItemsSourceProperty, nameof(VadeTarihleri));

        LabelPrimTutari.BindingContext = this;
        LabelPrimTutari.SetBinding(Label.TextProperty, nameof(PrimTutari));

        ListTeminatlar.BindingContext = this;
        ListTeminatlar.SetBinding(ItemsView.ItemsSourceProperty, nameof(Teminatlar));

        InitDefault();

        try
        {
            _ = Task.Run(() => InitWithRequest());
        }
        catch (Exception ex) { Console.WriteLine(ex.ToString()); }


    }

    public void InitDefault()
    {
        PolicyOwner = "";
        PolicyName = "";
        TanzimTarihi = "";
        VadeTarihleri = new string[] { "" };
        PrimTutari = "";
        Teminatlar = new[] { new Asset { Name = "", Value = 0 } };
    }

    public async Task<int> InitWithRequest()
    {
        HttpClient client = new HttpClient();

        string url = GlobalVariables.serverAdress + "/api/insurence/vehicle-assurance/";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
        };

        HttpResponseMessage response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Status code error");
            return 1;
        }

        string responseStr = await response.Content.ReadAsStringAsync();

        PolicyDto policy = JsonConvert.DeserializeObject<PolicyDto>(JObject.Parse(responseStr)["testPolicy"].ToString());


        PolicyOwner = policy.PolicyOwner;
        PolicyName = "Kasko";
        PolicyNumber = policy.PolicyId.ToString();
        TanzimTarihi = policy.SignDate;
        VadeTarihleri = policy.InstallmentDates;
        PrimTutari = policy.PremiumAmount.ToString();
        Teminatlar = policy.Guarantees;

        return 0;
    }

}
