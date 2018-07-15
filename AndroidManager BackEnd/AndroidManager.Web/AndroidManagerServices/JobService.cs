using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AndroidManager.Web
{
    public class JobService
    {
        private readonly DatabaseContext databaseContex;

        public JobService(DatabaseContext databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public List<Job> GetAllJobs()
        {
            return databaseContex.Jobs.Include("AndroidJobs.Android").ToList();
        }

        public List<Job> GetJobsByIds(List<int> ids)
        {
            return databaseContex.Jobs.Where(x => ids.Contains(x.Id.Value)).ToList();
        }

        public List<Job> GetNotComplitedJobs()
        {
            return databaseContex.Jobs.Where(x => x.ComplexityLevel > 0).ToList();
        }

        public Job GetJobById(int id)
        {
            return databaseContex.Jobs.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Job job)
        {
            databaseContex.Jobs.Add(job);
            databaseContex.SaveChanges();
        }

        public void Edit(Job job)
        {
            databaseContex.Entry(job).State = EntityState.Modified;

            databaseContex.SaveChanges();
        }

        public void Remove(int id)
        {
            var job = databaseContex.Jobs.FirstOrDefault(x => x.Id == id);
            databaseContex.Jobs.Remove(job);
            databaseContex.SaveChanges();
        }
    }
}
