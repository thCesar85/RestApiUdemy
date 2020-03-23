using RestApiUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiUdemy.Services

{
    public  interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> Findall();
        Person Update(Person person);
        void Delete(long id);



    }
}
