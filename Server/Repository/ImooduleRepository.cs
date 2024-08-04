using System.Collections.Generic;
using Registration.Module.moodule.Models;

namespace Registration.Module.moodule.Repository
{
    public interface ImooduleRepository
    {
        IEnumerable<Models.moodule> Getmoodules(int ModuleId);
        Models.moodule Getmoodule(int mooduleId);
        Models.moodule Getmoodule(int mooduleId, bool tracking);
        Models.moodule Addmoodule(Models.moodule moodule);
        Models.moodule Updatemoodule(Models.moodule moodule);
        void Deletemoodule(int mooduleId);
    }
}
