using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Models
{
    internal class AddressRequest : IAddressRequest
    {
        public string Street { get; set; }
        public string CityStateZip { get; set; }
        public string UserKey { get; set; }
    }
}
