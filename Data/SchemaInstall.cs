using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;

namespace Nop.Plugin.Tax.CustomRules.Data;

[NopMigration("2024/01/01 12:00:00:0000001", "Tax.CustomRules base schema", MigrationProcessType.Installation)]
public class SchemaInstall : AutoReversingMigration
{
    public override void Up()
    {
        Create.TableFor<AddressVerificationDetail>();
        Create.TableFor<AddressLookupUsageStatistic>();
    }
}

