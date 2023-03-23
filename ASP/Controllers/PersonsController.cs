using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class PersonsController : Controller
    {
        List<Person> persons = new List<Person>()
        {
            new Person(){ Id = 1, FirstName = "Jan", LastName = "Kowalski" },
            new Person(){ Id = 2, FirstName = "Adam", LastName = "Nowak" }
        };
        public IActionResult Index()
        {
            return View(persons);
        }
        public IActionResult Details(int id)
        {
            var result = persons.FirstOrDefault(r => r.Id == id);
            return View(result);
        }
        public IActionResult Edit(int id)
        {
            var result = persons.FirstOrDefault(r => r.Id == id);
            return View(result);
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
