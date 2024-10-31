namespace Nop.Plugin.Tax.CustomRules.Interfaces
{
    public interface IStepInit
    {
        IStepAddressStreet SetStreet(string street);
    }
    /// <summary>
    /// First line of address e.g: 111 main st.
    /// </summary>
    public interface IStepAddressStreet
    {
        IStepAddressCityStateZip SetCityStateZip(string cityStateZip);
    }
    /// <summary>
    /// Second line of address e.g: Kansas City, MO
    /// </summary>
    public interface IStepAddressCityStateZip
    {
        IUserKeyStep SetUserKey(string userKey);
        IValidateStep Validate();
    }
    /// <summary>
    /// Optional: Pass in a user key for the YAddress API
    /// </summary>
    public interface IUserKeyStep
    {
        IValidateStep Validate();
    }
    public interface IValidateStep
    {
        public bool IsValid { get; }
        Task<IAddressResponse> GetAddress();
    }
}
