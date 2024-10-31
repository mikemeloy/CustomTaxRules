namespace Nop.Plugin.Tax.CustomRules.Enums
{
    public enum GeoPrecision
    {
        NotFound,
        State,
        City,
        PostalCode,
        Street,
        Exact
    }

    public enum TaxJurisdiction
    {
        State,
        County,
        City,
        Local
    }

    public enum TimeZoneOffset
    {
        Eastern,
        Central,
        Mountain,
        Pacific,
        Alaska,
        Hawaii
    }

    public enum ErrorCode
    {
        NoError,
        System,
        Format,
        StreetNotFound,
        CityNotFound,
        Ambiguous,
        CorruptedInstall,
        ExpiredData,
        DoesNotExist
    }
}

