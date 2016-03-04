using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreLinqStuff
{
    class Program
    {
        class City
        {
            public string Name { get; set; }
            public int StateKey { get; set; }
        }


        static void Main(string[] args)
        {
            // very simple A_grades is a subset of grades filtered by Where clause
            /*
            int[] grades = { 70, 85, 95, 50, 55, 60, 100 };

            int[] A_grades = grades.Where(x => x > 90).ToArray();

            foreach(var grade in A_grades)
            {
                Console.WriteLine(grade);
            }
            */



            Dictionary<int, string> states = new Dictionary<int, string>();
            states.Add(27, "Florida");
            states.Add(42, "Washington");

            Dictionary<int, City> cities = new Dictionary<int, City>();
            cities.Add(1, new City { Name = "Tampa", StateKey = 27 });
            cities.Add(2, new City { Name = "Lakeland", StateKey = 27 });
            cities.Add(3, new City { Name = "Spokane", StateKey = 42 });
            cities.Add(4, new City { Name = "Seattle", StateKey = 42 });

            // using Where clause and Lambda expression
            Console.WriteLine("Cities in Florida:");
            foreach (var city in cities.Where(x => x.Value.StateKey == 27))
            {
                Console.WriteLine(city.Value.Name);
            }



            // using a Join in LINQ
            var innerJoinQuery =
                from a in states
                join b in cities on a.Key equals b.Value.StateKey
                select new { State = a.Value, UCity = b.Value.Name };


            Console.WriteLine("States and their cities:");
            foreach (var row in innerJoinQuery)
            {
                Console.WriteLine("{0}:{1}", row.State, row.UCity);
            }


            Console.ReadKey(true);
        }
    }
}
