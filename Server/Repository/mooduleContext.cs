using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace Registration.Module.moodule.Repository
{
    public class mooduleContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.moodule> moodule { get; set; }

        public mooduleContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.moodule>().ToTable(ActiveDatabase.RewriteName("Registrationmoodule"));
        }
    }
}
