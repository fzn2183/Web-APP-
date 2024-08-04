using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace Registration.Module.moodule.Migrations.EntityBuilders
{
    public class mooduleEntityBuilder : AuditableBaseEntityBuilder<mooduleEntityBuilder>
    {
        private const string _entityTableName = "Registrationmoodule";
        private readonly PrimaryKey<mooduleEntityBuilder> _primaryKey = new("PK_Registrationmoodule", x => x.mooduleId);
        private readonly ForeignKey<mooduleEntityBuilder> _moduleForeignKey = new("FK_Registrationmoodule_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public mooduleEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override mooduleEntityBuilder BuildTable(ColumnsBuilder table)
        {
            mooduleId = AddAutoIncrementColumn(table,"mooduleId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> mooduleId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
