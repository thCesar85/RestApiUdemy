using RestApiUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestApiUdemy.Model.Context;

namespace RestApiUdemy.Services.Implementation
{
    public class PersonServiceImpl : IPersonService
    {
        private MySqlContext _context;

        public PersonServiceImpl(MySqlContext context)
        {
            _context = context;
        }

       // private volatile int count;
        public Person Create(Person person)
        {

            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {   
                if(result != null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
                        
        }

        public List<Person> Findall()
        {
            return _context.Persons.ToList();
        }


        public Person FindById(long id)
        {
           return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {

            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }


        /*  private Person MockPersons(int i)
          {
              return new Person
              {
                  Id = IncrementAndGet(),
                  FirstName = "Person name" + i ,
                  LastName = "Persnom Lastname" + i,
                  Address =  "some adress " + i,
                  Gender = "Masculino" + i
              }; ;
          }

          private long IncrementAndGet()
          {
              return Interlocked.Increment(ref count) ;
          } */


    }



}
