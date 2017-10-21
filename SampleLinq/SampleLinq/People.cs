using System.Collections.Generic;
using System.Linq;

namespace SampleLinq
{
    class People : List<Person>
    {
        /** USE LINQ for the following 2 Methods **/

        public IEnumerable<Person> Originals
        {
            get
            {
                /** Return a list of unique  **/
                return this.GroupBy(x => new { x.Fname, x.Lname }).Select(x => x.First());

            }
        }

        public IEnumerable<Person> Duplicates
        {
            get
            {
                /** Return a list of duplicates  **/
                return this.Except(Originals);
            }
        }
    }
}
