using System.Linq;

namespace AndroidManager.Web
{
    public class OperatorService
    {
        private readonly DatabaseContext databaseContex;

        public OperatorService(DatabaseContext databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public Operator GetByCredentials(string email, string password)
        {
            return databaseContex
                                 .Operators
                                 .FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void Create(Operator oper)
        {
            databaseContex.Operators.Add(oper);
            databaseContex.SaveChanges();
        }
    }
}
