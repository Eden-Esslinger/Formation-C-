using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serie_4


{
    public static class BracketsControl
    {
        public static bool BracketsControls(string sentence)
        {
            string opening = "{[(";
            string closing = "}])";

            List<char> opening_brackets = new List<char> { };
            List<char> closing_brackets = new List<char> { };

            if (sentence.Count() == 0)
            { return true; }

            foreach (char i in sentence)
            {
                if ((opening + closing).Contains(i))
                {
                    if (opening.Contains(i) is true)
                    {
                        opening_brackets.Add(i);
                    }
                    else
                    {
                        closing_brackets.Add(i);
                        if (opening_brackets.Count == 0)
                        {
                            return false;
                        }
                        char required_prev_opening = opening.ElementAt(closing.LastIndexOf(i));
                          
                        if (required_prev_opening != (char)opening_brackets.Last())
                        {
                            return false;
                        }
                        opening_brackets.RemoveAt(opening_brackets.Count - 1);
                        closing_brackets.RemoveAt(closing_brackets.Count - 1);
                    }
                }
            }
            if (opening_brackets.Count != 0 || closing_brackets.Count != 0)
            {
                return false;
            }
            return true;
        }
    }
}
