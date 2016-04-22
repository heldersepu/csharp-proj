using System.Collections.Generic;
using System.Linq;

namespace SampleLinq
{
    class People : List<Person>
    {
        /** USE LINQ for the following 2 Methods **/

        public dynamic Originals()
        {
            /** Return a list of unique based on Fname & Lname **/
            return from e in this where (Unique.Contains(e.Id)) select e;
        }

        public dynamic Duplicates()
        {
            /** Return a list of duplicates (based on Originals) **/
            return from e in this where (!Unique.Contains(e.Id)) select e;
        }

        private dynamic Unique
        {
            get
            {
                return
                    (
                        from e in this
                        group e by new {e.Fname, e.Lname}
                        into ed
                        select ed.Min(x => x.Id)
                    ).ToList();
            }

        }
    }
}
