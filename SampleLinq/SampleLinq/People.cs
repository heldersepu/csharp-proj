using System.Collections.Generic;
using System.Linq;
using System;

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
                return this.Where(x => Unique.Contains(x.Id));
        }
        }

        public IEnumerable<Person> Duplicates
        {
            get
            {
                /** Return a list of duplicates  **/
                return this.Where(x => !Unique.Contains(x.Id));
        }
        }

        /** Return a list of unique ids based on Fname & Lname **/
        private IEnumerable<Guid> Unique
        {
            get
            {
                return this.GroupBy(x => new { x.Fname, x.Lname } )
                    .Select(x => x.Min(e => e.Id));
            }

        }
    }
}
