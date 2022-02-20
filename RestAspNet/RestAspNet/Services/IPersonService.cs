using RestAspNet.Model;
using System.Collections.Generic;

namespace RestAspNet.Services
{
    public interface IPersonService
    {
        Person FindById(long id);
        List<Person> FindAll();
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
