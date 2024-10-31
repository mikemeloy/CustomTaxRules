using Nop.Plugin.Tax.CustomRules.Enums;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Models
{
    internal class AddressResponse : IAddressResponse
    {
        public ErrorCode ErrorCode { get; set; }
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
        public GeoPrecision GeoPrecision { get; set; }
        public int TimeZoneOffset { get; set; }
        public bool DstObserved { get; set; }
        public int PlaceFP { get; set; }
        public string CityMunicipality { get; set; }
        public decimal SalesTaxRate { get; set; }
        public TaxJurisdiction SalesTaxJurisdiction { get; set; }
    }
}
