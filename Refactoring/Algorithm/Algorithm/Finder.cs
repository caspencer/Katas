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
                    // don't compare person to itself
                    if (person1 == person2) continue;

                    var result = FindResult.Compare(person1, person2);

                    if (furthest == null || result.AgeDifference > furthest.AgeDifference)
                        furthest = result;

                    if (closest == null || result.AgeDifference < closest.AgeDifference)
                        closest = result;

                    resultCount++;
                }
            }

            if (resultCount < 1)
                return new FindResult();
            
            return (findType == FindType.ClosestInAge) ? closest : furthest;
        }
    }
}