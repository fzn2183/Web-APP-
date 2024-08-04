using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Registration.Module.moodule.Models;

namespace Registration.Module.moodule.Repository
{
    public class mooduleRepository : ImooduleRepository, ITransientService
    {
        private readonly mooduleContext _db;

        public mooduleRepository(mooduleContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.moodule> Getmoodules(int ModuleId)
        {
            return _db.moodule.Where(item => item.ModuleId == ModuleId);
        }

        public Models.moodule Getmoodule(int mooduleId)
        {
            return Getmoodule(mooduleId, true);
        }

        public Models.moodule Getmoodule(int mooduleId, bool tracking)
        {
            if (tracking)
            {
                return _db.moodule.Find(mooduleId);
            }
            else
            {
                return _db.moodule.AsNoTracking().FirstOrDefault(item => item.mooduleId == mooduleId);
            }
        }

        public Models.moodule Addmoodule(Models.moodule moodule)
        {
            _db.moodule.Add(moodule);
            _db.SaveChanges();
            return moodule;
        }

        public Models.moodule Updatemoodule(Models.moodule moodule)
        {
            _db.Entry(moodule).State = EntityState.Modified;
            _db.SaveChanges();
            return moodule;
        }

        public void Deletemoodule(int mooduleId)
        {
            Models.moodule moodule = _db.moodule.Find(mooduleId);
            _db.moodule.Remove(moodule);
            _db.SaveChanges();
        }
    }
}
