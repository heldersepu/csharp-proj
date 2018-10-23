using System;
using NLog;

namespace UseNLog
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Console.WriteLine("Begin");
            
            logger.Info("Begin");
            logger.Error("Bad error");
            
            try
            {
                throw new DivideByZeroException();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }

            try
            {
                raiseErr();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }

            logger.Info("End");

            Console.WriteLine("End");
            Console.ReadLine();
        }

        static void raiseErr()
        {
            throw new BadImageFormatException();
        }
    }
}
