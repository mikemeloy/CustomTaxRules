using FluentMigrator;
using Nop.Data.Mapping;
using Nop.Data.Migrations;

namespace Nop.Plugin.Tax.CustomRules.Data
{
    [NopMigration("2024/01/01 12:00:00:0000000", "Tax.CustomRules base schema", MigrationProcessType.Update)]
    public class SchemaUpdate : MigrationBase
    {
        public override void Up()
        {
            Alter.Table(NameCompatibilityManager.GetTableName(typeof(AddressLookupDetails)))
                    .AddColumn(nameof(AddressLookupDetails.CreatedBy))
                    .AsFixedLengthString(50);

            Alter.Table(NameCompatibilityManager.GetTableName(typeof(AddressLookupDetails)))
                    .AddColumn(nameof(AddressLookupDetails.CreatedDate))
                    .AsDateTime2()
                    .WithDefaultValue(DateTime.UtcNow);
        }

        public override void Down() { }
    }
}
