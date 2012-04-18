using System;

namespace Algorithm
{
    public class FindResult
    {
        public Person OlderPerson { get; set; }
        public Person YoungerPerson { get; set; }
        public TimeSpan AgeDifference { get; set; }

        internal static FindResult Compare(Person person1, Person person2)
        {
            var result = new FindResult();

            if (person1.BirthDate < person2.BirthDate)
            {
                result.OlderPerson = person1;
                result.YoungerPerson = person2;
            }
            else
            {
                result.OlderPerson = person2;
                result.YoungerPerson = person1;
            }

            result.AgeDifference = result.YoungerPerson.BirthDate - result.OlderPerson.BirthDate;

            return result;
        }
    }
}