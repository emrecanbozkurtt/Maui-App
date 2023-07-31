
using Newtonsoft.Json;

namespace InsuranceApp.MVVM.Model;

[Serializable]
public class Asset

{

    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonProperty(PropertyName = "value")]
    public int Value { get; set; }
}
