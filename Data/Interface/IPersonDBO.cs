using Microsoft.EntityFrameworkCore;
using TICS.Models;

namespace TICS.Data
{
    public abstract class IPersonDBO
    {
        public abstract Person GetPerson(int id);


        private bool CheckPasswordForAuth(string passwordHash)
        {
            return false;
        }

        
    }
}
