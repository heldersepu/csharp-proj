using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleLinq
{
    class People : List<Person>
    {
        /** USE LINQ for the following 2 Methods **/

        public People Originals()
        {
            /** Return a list of unique based on Fname & Lname **/
            return this;
        }

        public People Duplicates()
        {
            /** Return a list of duplicates **/
            return this;
        }
    }
}
