using RestAspNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAspNet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            //acesso a base
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }

            return people;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "PersonName" + i,
                LastName = "PersonLastName" + i,
                Gender = "Male",
                Address = "SomeAddress" + i

            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person 
            {
                Id = 1,
                FirstName = "John",
                LastName = "Johnes",
                Gender = "Male",
                Address = "John's street - SP - Brasil"

            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
