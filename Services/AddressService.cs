using AddressLookup;
using AddressLookup.Interfaces;
using Nop.Data;
using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<AddressLookupDetails> _addressLookupRepository;
        private readonly HttpClient _httpClient;
        public AddressService(HttpClient httpClient, IRepository<AddressLookupDetails> addressLookupRepository)
        {
            _httpClient = httpClient;
            _addressLookupRepository = addressLookupRepository;
        }

        public async Task<IAddressResponse> GetAddressInfoAsync(string addressOne, string addressTwo)
        {
            var address = await AddressSearchFactory.Init(_httpClient)
                                            .SetAddressOne(addressOne)
                                            .SetAddressTwo(addressTwo)
                                            .Validate()
                                            .GetAddress();

            return address;
        }

        public async Task<bool> SaveAddressDetailsAsync()
        {
            await _addressLookupRepository.InsertAsync(new AddressLookupDetails()
            {
                AddressLine1 = "3408 NW Pink Hill Circle",
                AddressLine2 = "Blue Springs, MO 64015",
                CreatedBy = "Mike",
                CreatedDate = DateTime.UtcNow,
            });
            return true;
        }
    }
}
