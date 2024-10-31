using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.ItemDiscount.Models;
public record ConfigurationModel : BaseNopModel
{
    [NopResourceDisplayName("Plugins.CustomRules.Configuration.Fields.TimeToLive")]
    public int TimeToLive { get; set; }
    [NopResourceDisplayName("Plugins.CustomRules.Configuration.Fields.Endpoint")]
    public string Endpoint { get; set; }
}
