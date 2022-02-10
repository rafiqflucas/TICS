using TICS.Data;
using TICS.Models;

namespace TICS.Service
{
    public class PersonService : IPersonService
    {
        private PersonDBO _personDbo;

        public PersonService(PersonDBO personDbo)
        {
            _personDbo = personDbo;
        }

        public Person GetPerson(int id)
        {
            return _personDbo.GetPerson(id);
        }


    }
}
