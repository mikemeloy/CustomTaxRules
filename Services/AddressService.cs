using Nop.Core.Domain.Common;
using Nop.Plugin.Tax.CustomRules.Data;
using Nop.Plugin.Tax.CustomRules.Factories;
using Nop.Plugin.Tax.CustomRules.Interfaces;

namespace Nop.Plugin.Tax.CustomRules.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressVerificationUsageRepository _addressVerificationUsageRepository;
        private readonly IAddressVerificationRepository _addressVerificationRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly HttpClient _httpClient;
        public AddressService(HttpClient httpClient, IAddressVerificationRepository addressVerificationRepository, IAddressRepository addressRepository, IAddressVerificationUsageRepository addressVerificationUsageRepository)
        {
            _httpClient = httpClient;
            _addressVerificationRepository = addressVerificationRepository;
            _addressRepository = addressRepository;
            _addressVerificationUsageRepository = addressVerificationUsageRepository;
        }

        public async Task<Address> GetAddressById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            return await _addressRepository.GetAddressById(id.Value);
        }

        public async Task<AddressVerificationDetail> GetAddressInfoAsync(string street, string postalCode, int? addressId)
        {
            var persistedRecord = await _addressVerificationRepository.GetAsync(street, postalCode);
            var verified = persistedRecord is not null;
            var addressLookup = AddressLookupFactory
                                    .Init(
                                        httpClient: _httpClient,
                                        addressVerificationUsageRepository: _addressVerificationUsageRepository
                                    )
                                    .SetStreet(street)
                                    .SetCityStateZip(postalCode)
                                    .Validate();

            if (!addressLookup.IsValid)
            {
                return new();
            }

            return
                verified
                    ? persistedRecord
                    : await FetchAndPersistIfNullAsync(addressLookup, addressId);
        }

        public async Task OnAddressChangeEvent(Address address)
        {
            var addressLookup = AddressLookupFactory
                                    .Init(
                                        httpClient: _httpClient,
                                        addressVerificationUsageRepository: _addressVerificationUsageRepository
                                    )
                                    .SetStreet(address.Address1)
                                    .SetCityStateZip(address.ZipPostalCode)
                                    .Validate();

            await FetchAndPersistIfNullAsync(addressLookup, address.Id);
        }

        private async Task<AddressVerificationDetail> FetchAndPersistIfNullAsync(IValidateStep step, int? addressId)
        {
            var apiResult = await step.GetAddress();
            var newEntity = await _addressVerificationRepository.InsertAsync(apiResult);
            await _addressRepository.UpdateAddressAsync(addressId, apiResult);

            return newEntity;
        }
    }
}
