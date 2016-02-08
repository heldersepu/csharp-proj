using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using RandTest.Models;

namespace RandTest.Controllers
{
    public class DemoController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<Question> Get()
        {
            var response = new List<Question>();
            try
            {
                using (var context = new DbModel())
                {
                    context.Tests.Add(
                        new Test {
                            Name = "Rustici Software",
                            Questions = new List<Question> {
                                new Question {
                                    Detail = "What can you find in Rustici Software's office?",
                                    SingleAnswer = false,
                                    Choices = new List<Choice> {
                                        new Choice { Detail = "Dart Board",                 Answer = true},
                                        new Choice { Detail = "Ping Pong Table",            Answer = true},
                                        new Choice { Detail = "Cubicles",                   Answer = false},
                                        new Choice { Detail = "Laptops with dual monitors", Answer = true},
                                        new Choice { Detail = "TPS reports, ummm yeah",     Answer = false},
                                    }
                                },
                                new Question {
                                    Detail = "All of Rustici Software employees are expected to work no more than ____ hours per week.",
                                    SingleAnswer = true,
                                    Choices = new List<Choice> {
                                        new Choice { Detail = "80", Answer = false},
                                        new Choice { Detail = "40", Answer = true},
                                        new Choice { Detail = "50", Answer = false},
                                        new Choice { Detail = "60", Answer = false},
                                    }
                                },
                                new Question {
                                    Detail = "The end users of Rustici Software's products number in the _________",
                                    SingleAnswer = true,
                                    Choices = new List<Choice> {
                                        new Choice { Detail = "Tens",       Answer = false},
                                        new Choice { Detail = "Hundreds",   Answer = false},
                                        new Choice { Detail = "Thousands",  Answer = false},
                                        new Choice { Detail = "Millions",   Answer = true},
                                        new Choice { Detail = "Billions",   Answer = false},
                                    }
                                },
                                new Question {
                                    Detail = "Rustici Software is a (choose all that apply):",
                                    SingleAnswer = false,
                                    Choices = new List<Choice> {
                                        new Choice { Detail = "Great place to work",                            Answer = true},
                                        new Choice { Detail = "Respected leader in its field",                  Answer = true},
                                        new Choice { Detail = "Place where people don't matter, just results",  Answer = false},
                                    }
                                },
                                new Question {
                                    Detail = "Tim likes to wear:",
                                    SingleAnswer = true,
                                    Choices = new List<Choice> {
                                        new Choice { Detail = "Capri pants",            Answer = false},
                                        new Choice { Detail = "Goth attire",            Answer = false},
                                        new Choice { Detail = "Sport coat",             Answer = false},
                                        new Choice { Detail = "T-shirt and shorts",     Answer = true},
                                    }
                                }
                            }
                        }
                    );
                    context.SaveChanges();
                    response = context.Questions.AsNoTracking().ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return response;
        }
    }
}
