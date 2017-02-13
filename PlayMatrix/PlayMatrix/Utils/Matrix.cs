using System;
using System.Collections.Generic;

namespace PlayMatrix
{
    public class Matrix : Dictionary<int, int>
    {
        static Random rnd = new Random();

        public Matrix() : base() { }
        public Matrix(int capacity) : base(capacity) { }

        public void Add()
        {
            Add(Count, PseudRand(LastValue));
        }

        public int LastValue
        {
            get
            {
                return (Count == 0) ? 0 : this[Count - 1];
            }
        }

        private int PseudRand(int last)
        {
            return last + rnd.Next(1, 9);
        }
    }
}