using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee burak = new Employee { Name = "Burak" };

            Employee fkymon = new Employee { Name = "Fkymon" };

            burak.AddSubordinate(fkymon);

            Employee fobon = new Employee { Name = "Fobon" };

            burak.AddSubordinate(fobon);

            Employee ahmet = new Employee { Name = "Ahmet" };

            fkymon.AddSubordinate(ahmet);

            Contractor ali = new Contractor { Name = "Ali" };

            fobon.AddSubordinate(ali);

            Console.WriteLine(burak.Name);
            foreach (Employee manager in burak)
            {
                Console.WriteLine("  " + manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    " + employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public string Name { get; set; }

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
