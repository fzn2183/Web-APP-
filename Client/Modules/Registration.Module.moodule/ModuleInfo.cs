using Oqtane.Models;
using Oqtane.Modules;

namespace Registration.Module.moodule
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "moodule",
            Description = "List of employees",
            Version = "1.0.0",
            ServerManagerType = "Registration.Module.moodule.Manager.mooduleManager, Registration.Module.moodule.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "Registration.Module.moodule.Shared.Oqtane",
            PackageName = "Registration.Module.moodule" 
        };
    }
}
