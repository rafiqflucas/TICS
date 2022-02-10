using Microsoft.EntityFrameworkCore;
using TICS.Models;

namespace TICS.Data
{
    public class PersonDBO: IPersonDBO
    {

        private readonly ApplicationDbContext _db;

        public DbSet<Person> Persons { get; set; }

        public PersonDBO(ApplicationDbContext db)
        {
            _db = db;
        }

        private bool CheckPasswordForAuth(string passwordHash)
        {
            
            return false;
        }

        public override Person GetPerson(int id)
        {
            //var personSql = "Select * from Person WHERE Id =" + id;
            //_db.Query<Person>().FromSql(personSql);

            return Persons.Find(new int[] { id });
        }
    }
}
