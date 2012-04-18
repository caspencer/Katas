using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _p;

        public Finder(List<Person> p)
        {
            _p = p;
        }

        public F Find(FT ft)
        {
            var tr = new List<F>();

            foreach (var thing1 in _p)
            {
                foreach (var thing2 in _p)
                {
                    if (thing1 == thing2) continue;

                    var r = new F();
                    if (thing1.BirthDate < thing2.BirthDate)
                    {
                        r.P1 = thing1;
                        r.P2 = thing2;
                    }
                    else
                    {
                        r.P1 = thing2;
                        r.P2 = thing1;
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