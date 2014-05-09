using System;
using System.Collections.Generic;
using System.Text;

namespace Countries
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World(
                new []{
                    new Country("USA", new []{
                            new State("Florida", new []{
                                new City("Jacksonville", 823316),
                                new City("Miami", 408568),
                                new City("Tampa", 335709),
                            }),
                            new State("Georgia", new []{
                                new City("Atlanta", 443775),
                                new City("Augusta", 198413),
                                new City("Columbus", 197872),
                            }),
                            new State("California", new []{
                                new City("Los Angeles", 3792621),
                                new City("San Diego", 1301617),
                                new City("Santa Clara", 945942),
                            })
                        }),
                    new Country("ITALY", new []{
                            new State("Friuly", new []{
                                new City("Pordenone", 297699),
                                new City("Udine",     528246),
                                new City("Gorizia",   140681),
                            }),
                            new State("Sicily", new Entity[]{
                                new City("Palermo", 1224778),
                                new City("Catania", 1035665),
                                new District("Messina", 646871),
                            }),
                            new State("Lazio", new Entity[] {
                                new City("Roma", 3761067),
                                new City("Frosinone", 479559),
                                new District("Latina", 476282),
                            })
                        }),
                    new Country("MEXICO", new []{
                            new State("Sonora", new []{
                                new City("Hermosillo", 778000),
                                new City("Ciudad Obregon", 324800),
                                new City("Nogales", 232100)
                            }),
                            new State("Jalisco", new []{
                                new City("Guadalajara", 1500800),
                                new City("Zapopan", 1202900),
                            }),
                            new State("Chihuahua", new []{
                                new City("Chihuahua", 887600),
                                new City("Delicias", 129500),
                            })
                        }),
                    new Country("CANADA", new []{
                            new State("Alberta", new []{
                                new City("Calgary", 1096833),
                                new City("Edmonton", 812201),
                            }),
                            new State("Ontario", new []{
                                new City("Toronto", 2615060),
                                new City("Ottawa", 883391),
                            }),
                            new State("Quebec", new []{
                                new City("Montreal", 1717767),
                                new City("Laval", 417304),
                            })
                        }) 
                }
            );

            Console.WriteLine("WorldPopulation");
            Console.WriteLine(world.WorldPopulation());
            Console.WriteLine("");
            world.AllEntities();
            Console.ReadLine();

        }        
    }

    


}
