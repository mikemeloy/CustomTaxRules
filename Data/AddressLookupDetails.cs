using Nop.Core;

namespace Nop.Plugin.Tax.CustomRules.Data;

public class AddressVerificationDetail : BaseEntity
{
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string Number { get; set; }
    public string PreDir { get; set; }
    public string Street { get; set; }
    public string Suffix { get; set; }
    public string PostDir { get; set; }
    public string Sec { get; set; }
    public string SecNumber { get; set; }
    public string SecValidated { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Zip4 { get; set; }
    public string UspsCarrierRoute { get; set; }
    public string County { get; set; }
    public string StateFP { get; set; }
    public string CountyFP { get; set; }
    public string CensusTract { get; set; }
    public string CensusBlock { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int GeoPrecision { get; set; }
    public int TimeZoneOffset { get; set; }
    public bool DstObserved { get; set; }
    public int PlaceFP { get; set; }
    public string CityMunicipality { get; set; }
    public decimal SalesTaxRate { get; set; }
    public int SalesTaxJurisdiction { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}

