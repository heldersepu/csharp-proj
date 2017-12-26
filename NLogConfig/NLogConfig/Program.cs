using NLog;
using NLog.Targets;
using NLog.Config;

namespace NLogConfig
{
    static class CustomLoggingConfigurations
    {
        const string NEWLINE_LAYOUT = @"Logger: ${logger}${newline}Message: ${message}${newline}${exception:format=tostring}";
        const string DATETIME_LAYOUT = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
        const string SIMPLE_LAYOUT = @"${message}";        

        public static void AddConsole(this LoggingConfiguration config, LogLevel min, LogLevel max)
        {
            var t = new ColoredConsoleTarget
            {
                Layout = DATETIME_LAYOUT
            };
            config.AddTarget("console", t);
            config.LoggingRules.Add(new LoggingRule("*", min, max, t));
        }

        public static void AddTxtFile(this LoggingConfiguration config, LogLevel min, LogLevel max)
        {
            var t = new FileTarget
            {
                FileName = "${basedir}/file.txt",
                Layout = SIMPLE_LAYOUT
            };
            config.AddTarget("file", t);
            config.LoggingRules.Add(new LoggingRule("*", min, max, t));
        }

        public static void AddEventLog(this LoggingConfiguration config, LogLevel min, LogLevel max)
        {
            var t = new EventLogTarget
            {
                Log = "Application",
                MachineName = ".",
                //Source = "ApplicationName",
                Layout = NEWLINE_LAYOUT
            };
            config.AddTarget("eventlog", t);
            config.LoggingRules.Add(new LoggingRule("*", min, max, t));
        }

        public static void AddDatabase(this LoggingConfiguration config, LogLevel min, LogLevel max, string ConnString)
        {
            var t = new DatabaseTarget
            {
                KeepConnection = true,
                DBProvider = "sqlserver",
                ConnectionString = ConnString,
                CommandText = @"EXEC [dbo].[p_error_log]
                                        @Logger = '${logger}',
		                                @Message = '${message}-${exception:format=tostring}' ",
            };
            config.AddTarget("database", t);
            config.LoggingRules.Add(new LoggingRule("*", min, max, t));
        }

        public static void AddDebugger(this LoggingConfiguration config)
        {
            var t = new DebuggerTarget();
            config.AddTarget("debugger", t);
            config.AddRuleForAllLevels(t);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            config.AddEventLog(LogLevel.Trace, LogLevel.Error);
            config.AddConsole(LogLevel.Trace, LogLevel.Error);
            config.AddTxtFile(LogLevel.Trace, LogLevel.Error);
            config.AddDebugger();
            LogManager.Configuration = config;

            var logger = LogManager.GetLogger("Example");
            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("fatal log message");

            System.Console.WriteLine();
            foreach (var item in LogLevel.AllLevels)
                System.Console.WriteLine($"{item.Ordinal} {item.Name}");
            System.Console.ReadKey();
        }
    }
}
