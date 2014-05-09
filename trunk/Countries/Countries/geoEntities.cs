using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Countries
{
    abstract class Entity
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        int _population = 0;
        public int Population
        {
            get{ return _population; }
        }

        public Entity(string Name, int Population)
        {
            this._name = Name;
            this._population = Population;
        }

        public Entity(string Name, Entity[] Entities)
        {
            this._name = Name;
            foreach (Entity entity in Entities)
                _population += entity.Population;
        }
    }


    class City : Entity
    {
        public City(string name, int population) : base(name, population) { }
    }

    class District : Entity
    {
        public District(string name, int population) : base(name, population) { }
    }

    class State : Entity
    {
        public State(string name, Entity[] entities) : base(name, entities) { }
    }

    class Country : Entity
    {
        public Country(string name, Entity[] entities) : base(name, entities) { }
    }


    class World
    {
        Country[] Countries;
        public World(Country[] countries)
        {
            this.Countries = countries;
        }

        public int WorldPopulation()
        {
            int pop = 0;
            foreach (Country country in Countries)
                pop += country.Population;
            return pop;
        }

        public void AllEntities()
        {
            Console.WriteLine("");
        }

    }
}
