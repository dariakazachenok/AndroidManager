using System.Collections.Generic;
using System.Linq;

namespace AndroidManager.Web
{
    public class AssingTaskAndroidService
    {
        private readonly DatabaseContext databaseContex;

        public AssingTaskAndroidService(DatabaseContext databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public List<AssingTaskAndroid> GetAllAssingTaskAndroids()
        {
            return databaseContex.AssingTaskAndroids.ToList();
        }
    }
}
