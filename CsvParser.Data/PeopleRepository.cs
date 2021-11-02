using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CsvParser.Data
{
   public class PeopleRepository
    {
        private readonly string _connectionString;

        public PeopleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(List<Person> people)
        {
            using var context = new PersonContext(_connectionString);
            context.People.AddRange(people);
            context.SaveChanges();
        }

        public List<Person> GetPeople()
        {
            using var context = new PersonContext(_connectionString);
            return context.People.ToList();
        }

        public void Delete()
        {
            using var context = new PersonContext(_connectionString);
            context.Database.ExecuteSqlRaw("Delete FROM People");
        }
    }
}
