namespace Nop.Plugin.Tax.CustomRules.Interfaces;

internal interface IAddressRequest
{
    string Street { get; set; }
    string CityStateZip { get; set; }
    string UserKey { get; set; }
}

