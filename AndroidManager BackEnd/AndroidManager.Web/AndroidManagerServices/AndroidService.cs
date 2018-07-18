using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AndroidManager.Web
{
    public class AndroidService
    {
        private readonly DatabaseContext databaseContex;

        public AndroidService(DatabaseContext databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public List<Android> GetAllAndroids()
        {
            return databaseContex.Androids.Include("AndroidJobs.Job").ToList();
        }

        public Android GetAndroidById(int id)
        {
            return databaseContex.Androids.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Android android)
        {
            databaseContex.Androids.Add(android);
            databaseContex.SaveChanges();
        }

        public void Edit(Android android)
        {
            databaseContex.Entry(android).State = EntityState.Modified;
            databaseContex.SaveChanges();
        }

        public void Remove(int id)
        {
            var android = databaseContex.Androids.FirstOrDefault(x => x.Id == id);
            databaseContex.Androids.Remove(android);
            databaseContex.SaveChanges();
        }
    }
}
