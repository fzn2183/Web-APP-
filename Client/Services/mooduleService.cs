using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Registration.Module.moodule.Models;

namespace Registration.Module.moodule.Services
{
    public class mooduleService : ServiceBase, ImooduleService, IService
    {
        public mooduleService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("moodule");

        public async Task<List<Models.moodule>> GetmoodulesAsync(int ModuleId)
        {
            List<Models.moodule> moodules = await GetJsonAsync<List<Models.moodule>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.moodule>().ToList());
            return moodules.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.moodule> GetmooduleAsync(int mooduleId, int ModuleId)
        {
            return await GetJsonAsync<Models.moodule>(CreateAuthorizationPolicyUrl($"{Apiurl}/{mooduleId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.moodule> AddmooduleAsync(Models.moodule moodule)
        {
            return await PostJsonAsync<Models.moodule>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, moodule.ModuleId), moodule);
        }

        public async Task<Models.moodule> UpdatemooduleAsync(Models.moodule moodule)
        {
            return await PutJsonAsync<Models.moodule>(CreateAuthorizationPolicyUrl($"{Apiurl}/{moodule.mooduleId}", EntityNames.Module, moodule.ModuleId), moodule);
        }

        public async Task DeletemooduleAsync(int mooduleId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{mooduleId}", EntityNames.Module, ModuleId));
        }
    }
}
