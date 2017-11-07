using System.Collections.Generic;

namespace UnQliteApp
{
    public class Data
    {
        static Parent SampleParent(int id)
        {
            var p = new Parent { Id = id, Data = "Parent" };
            for (int i = 0; i < 10; i++)
                p.Children.Add(new Child { Id = i, Data = $"Child {i}" });
            return p;
        }
    }

    public class Child
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }

    public class Parent
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public List<Child> Children { get; set; }

        public Parent()
        {
            Children = new List<Child>();
        }
    }
}
