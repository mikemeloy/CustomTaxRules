using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Extensions;

public static class AddressResponseExtensions
{
    public static AddressVerificationDetail ToEntity(this IAddressResponse addressResponse)
    {
        return new()
        {
            ErrorCode = (int)addressResponse.ErrorCode,
            ErrorMessage = addressResponse.ErrorMessage,
            AddressLine1 = addressResponse.AddressLine1,
            AddressLine2 = addressResponse.AddressLine2,
            Number = addressResponse.Number,
            PreDir = addressResponse.PreDir,
            Street = addressResponse.Street,
            Suffix = addressResponse.Suffix,
            PostDir = addressResponse.PostDir,
            Sec = addressResponse.Sec,
            SecNumber = addressResponse.SecNumber,
            SecValidated = addressResponse.SecValidated,
            City = addressResponse.City,
            State = addressResponse.State,
            Zip = addressResponse.Zip,
            Zip4 = addressResponse.Zip4,
            UspsCarrierRoute = addressResponse.UspsCarrierRoute,
            County = addressResponse.County,
            StateFP = addressResponse.StateFP,
            CountyFP = addressResponse.CountyFP,
            CensusTract = addressResponse.CensusTract,
            CensusBlock = addressResponse.CensusBlock,
            Latitude = addressResponse.Latitude,
            Longitude = addressResponse.Longitude,
            GeoPrecision = (int)addressResponse.GeoPrecision,
            TimeZoneOffset = addressResponse.TimeZoneOffset,
            DstObserved = addressResponse.DstObserved,
            PlaceFP = addressResponse.PlaceFP,
            CityMunicipality = addressResponse.CityMunicipality,
            SalesTaxRate = addressResponse.SalesTaxRate,
            SalesTaxJurisdiction = (int)addressResponse.SalesTaxJurisdiction
        };

    }
}

