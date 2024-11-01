using Nop.Plugin.Tax.CustomRules.Enums;

namespace Nop.Plugin.Tax.CustomRules.Interfaces;

public interface IAddressResponse
{
    ErrorCode ErrorCode { get; set; }
    string ErrorMessage { get; set; }
    string AddressLine1 { get; set; }
    string AddressLine2 { get; set; }
    string Number { get; set; }
    string PreDir { get; set; }
    string Street { get; set; }
    string Suffix { get; set; }
    string PostDir { get; set; }
    string Sec { get; set; }
    string SecNumber { get; set; }
    string SecValidated { get; set; }
    string City { get; set; }
    string State { get; set; }
    string Zip { get; set; }
    string Zip4 { get; set; }
    string UspsCarrierRoute { get; set; }
    string County { get; set; }
    string StateFP { get; set; }
    string CountyFP { get; set; }
    string CensusTract { get; set; }
    string CensusBlock { get; set; }
    decimal Latitude { get; set; }
    decimal Longitude { get; set; }
    GeoPrecision GeoPrecision { get; set; }
    int TimeZoneOffset { get; set; }
    bool DstObserved { get; set; }
    int PlaceFP { get; set; }
    string CityMunicipality { get; set; }
    decimal SalesTaxRate { get; set; }
    TaxJurisdiction SalesTaxJurisdiction { get; set; }
}

