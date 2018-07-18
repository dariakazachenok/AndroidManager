using System.Linq;

namespace AndroidManager.Web
{
    public class UserService
    {
        private readonly DatabaseContext databaseContex;

        public UserService(DatabaseContext databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public Operator GetByCredentials(string email, string password)
        {
            return databaseContex
                                 .Operators
                                 .FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
