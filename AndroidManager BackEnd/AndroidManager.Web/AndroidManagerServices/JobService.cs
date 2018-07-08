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
                return databaseContex.Jobs.ToList();
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
