using Newtonsoft.Json;

namespace InsuranceApp.MVVM.Model;

[Serializable]
class PolicyDto
{
    [JsonProperty(PropertyName = "id")]
    public int PolicyId { get; set; }

    [JsonProperty(PropertyName = "owner")]
    public string PolicyOwner { get; set; }
    
    [JsonProperty(PropertyName = "signDate")]
    public string SignDate { get; set; }

    [JsonProperty(PropertyName = "installmentCount")]
    public int InstallmentCount { get; set; }

    [JsonProperty(PropertyName = "installmentDates")]
    public string[] InstallmentDates { get; set; }

    [JsonProperty(PropertyName = "premiumAmount")]
    public double PremiumAmount { get; set; }

    [JsonProperty(PropertyName = "guarantees")]
    public Asset[] Guarantees { get; set; }

    [JsonProperty(PropertyName = "insuredAsset")]
    public Asset InsuredAsset { get; set; }

    [JsonProperty(PropertyName = "insuredAssetId")]
    public int InsuredAssetId { get; set; }

    [JsonProperty(PropertyName = "unpaidDebt")]
    public double UnpaidDebt { get; set; }
}

