using System.Collections.Generic;
using System.Threading.Tasks;
using Registration.Module.moodule.Models;

namespace Registration.Module.moodule.Services
{
    public interface ImooduleService 
    {
        Task<List<Models.moodule>> GetmoodulesAsync(int ModuleId);

        Task<Models.moodule> GetmooduleAsync(int mooduleId, int ModuleId);

        Task<Models.moodule> AddmooduleAsync(Models.moodule moodule);

        Task<Models.moodule> UpdatemooduleAsync(Models.moodule moodule);

        Task DeletemooduleAsync(int mooduleId, int ModuleId);
    }
}
