using Nop.Core.Domain.Common;
using Nop.Core.Events;
using Nop.Plugin.Tax.CustomRules.Interfaces;
using Nop.Services.Events;

namespace Nop.Plugin.Tax.CustomRules.Infrastructure;

public class OnAddressChangeEventListener : IConsumer<EntityInsertedEvent<Address>>, IConsumer<EntityUpdatedEvent<Address>>, IConsumer<EntityDeletedEvent<Address>>
{
    private readonly IAddressService _addressService;
    public OnAddressChangeEventListener(IAddressService addressService)
    {
        _addressService = addressService;
    }
    public async Task HandleEventAsync(EntityInsertedEvent<Address> eventMessage)
    {
        var address = eventMessage.Entity;
        await _addressService.OnAddressChangeEvent(address);
    }

    public async Task HandleEventAsync(EntityUpdatedEvent<Address> eventMessage)
    {
        var address = eventMessage.Entity;
        await _addressService.OnAddressChangeEvent(address);
    }

    public async Task HandleEventAsync(EntityDeletedEvent<Address> eventMessage)
    {
        var address = eventMessage.Entity;
        await _addressService.OnAddressChangeEvent(address);
    }
}

