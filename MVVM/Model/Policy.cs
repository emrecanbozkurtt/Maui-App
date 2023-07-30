namespace InsuranceApp.MVVM.Model;

public class Policy : ContentPage
{
	public int PolicyId { get; set; }
	public string PolicyNumber { get; set; }
	public string PolicyName { get; set; }

    public string PolicyOwner { get; set; }
    
    public string _tanzimTarihi { get; set; }

    public string _vadeTarihleri { get; set; }
    public string _primTutari { get; set; }
    public string _teminatlar { get; set; }
    public string ImagePath { get; set; }

}