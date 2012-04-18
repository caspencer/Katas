using System;

namespace Algorithm
{
    public class FindResult
    {
        public Person OlderPerson { get; set; }
        public Person YoungerPerson { get; set; }
        public TimeSpan AgeDifference { get; set; }
    }
}