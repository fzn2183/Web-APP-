using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using Registration.Module.moodule.Repository;

namespace Registration.Module.moodule.Manager
{
    public class mooduleManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly ImooduleRepository _mooduleRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public mooduleManager(ImooduleRepository mooduleRepository, IDBContextDependencies DBContextDependencies)
        {
            _mooduleRepository = mooduleRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new mooduleContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new mooduleContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.moodule> moodules = _mooduleRepository.Getmoodules(module.ModuleId).ToList();
            if (moodules != null)
            {
                content = JsonSerializer.Serialize(moodules);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.moodule> moodules = null;
            if (!string.IsNullOrEmpty(content))
            {
                moodules = JsonSerializer.Deserialize<List<Models.moodule>>(content);
            }
            if (moodules != null)
            {
                foreach(var moodule in moodules)
                {
                    _mooduleRepository.Addmoodule(new Models.moodule { ModuleId = module.ModuleId, Name = moodule.Name });
                }
            }
        }
    }
}
