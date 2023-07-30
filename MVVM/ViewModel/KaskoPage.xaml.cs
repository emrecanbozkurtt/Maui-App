using System.ComponentModel;

namespace InsuranceApp.MVVM.ViewModel;

public partial class KaskoPage : ContentPage
{

    private string _policyOwner;
    private string _policyName;
    private string _tanzimTarihi;
    private string _vadeTarihi;
    private string _primTutari;
    private string _teminatlar;

    public KaskoPage()
    {
        InitializeComponent();

        PolicyOwner = " ";
        PolicyName= " ";
        TanzimTarihi = " ";
        VadeTarihleri = " ";
        PrimTutari = " ";
        Teminatlar = " ";

    }
 

    public string PolicyOwner
    {
            get => _policyOwner;
            set
            {
                if (_policyOwner != value)
                {
                _policyOwner = value;
                    OnPropertyChanged(nameof(PolicyOwner));
                }
            }
        }
    public string PolicyName
    {
        get => _policyName;
        set
        {
            if (_policyName != value)
            {
                _policyName = value;
                OnPropertyChanged(nameof(PolicyName));
            }
        }
    }
    public string TanzimTarihi
        {
            get => _tanzimTarihi;
            set
            {
                if (_tanzimTarihi != value)
                {
                    _tanzimTarihi = value;
                    OnPropertyChanged(nameof(TanzimTarihi));
                }
            }
        }

        public string VadeTarihleri
        {
            get => _vadeTarihi;
            set
            {
                if (_vadeTarihi != value)
                {
                    _vadeTarihi = value;
                    OnPropertyChanged(nameof(VadeTarihleri));
                }
            }
        }

        public string PrimTutari
        {
            get => _primTutari;
            set
            {
                if (_primTutari != value)
                {
                    _primTutari = value;
                    OnPropertyChanged(nameof(PrimTutari));
                }
            }
        }

        public string Teminatlar
        {
            get => _teminatlar;
            set
            {
                if (_teminatlar != value)
                {
                    _teminatlar = value;
                    OnPropertyChanged(nameof(Teminatlar));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
