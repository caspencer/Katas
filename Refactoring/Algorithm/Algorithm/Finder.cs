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

        public F Find(FT ft)
        {
            var tr = new List<F>();

            foreach (var person1 in _personList)
            {
                foreach (var person2 in _personList)
                {
                    if (person1 == person2) continue;

                    var r = new F();
                    if (person1.BirthDate < person2.BirthDate)
                    {
                        r.P1 = person1;
                        r.P2 = person2;
                    }
                    else
                    {
                        r.P1 = person2;
                        r.P2 = person1;
                    }
                    r.D = r.P2.BirthDate - r.P1.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new F();
            }

            F answer = tr[0];
            foreach(var result in tr)
            {
                switch(ft)
                {
                    case FT.One:
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case FT.Two:
                        if(result.D > answer.D)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}