using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _personList;

        public Finder(List<Person> personList)
        {
            _personList = personList;
        }

        public FindResult Find(FindType findType)
        {
            int resultCount = 0;
            FindResult closest = null;
            FindResult furthest = null;
            
            foreach (var person1 in _personList)
            {
                foreach (var person2 in _personList)
                {
                    if (person1 == person2) continue;

                    var r = new FindResult();

                    if (person1.BirthDate < person2.BirthDate)
                    {
                        r.Person1 = person1;
                        r.Person2 = person2;
                    }
                    else
                    {
                        r.Person1 = person2;
                        r.Person2 = person1;
                    }

                    r.AgeDifference = r.Person2.BirthDate - r.Person1.BirthDate;

                    if (furthest == null || r.AgeDifference > furthest.AgeDifference)
                        furthest = r;

                    if (closest == null || r.AgeDifference < closest.AgeDifference)
                        closest = r;

                    resultCount++;
                }
            }

            if (resultCount < 1)
                return new FindResult();
            
            return (findType == FindType.ClosestInAge) ? closest : furthest;
        }
    }
}