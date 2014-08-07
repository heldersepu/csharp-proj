CONFIGURATION FILE LOCATIONS

NLog attempts to automatically configure itself on startup, by looking for the configuration files in some standard places.

The following locations will be searched when executing a stand-alone *.exe application:
- standard application configuration file (usually applicationname.exe.config)
- applicationname.exe.nlog in application’s directory
- NLog.config in application’s directory
- NLog.dll.nlog in a directory where NLog.dll is located (only if NLog isn't installed in the GAC)
- file name pointed by the NLOG_GLOBAL_CONFIG_FILE environment variable (if defined, NLog 1.0 only - support removed in NLog 2.0)

In case of an ASP.NET application, the following files are searched:
- standard web application file web.config
- web.nlog located in the same directory as web.config
- NLog.config in application’s directory
- NLog.dll.nlog in a directory where NLog.dll is located (only if NLog isn't installed in the GAC)
- file name pointed by the NLOG_GLOBAL_CONFIG_FILE environment variable (if defined, NLog 1.0 only - support removed in NLog 2.0)

The .NET Compact Framework doesn’t recognize application configuration files (*.exe.config) nor environmental variables, so NLog only looks in these locations:
- applicationname.exe.nlog in application’s directory
- NLog.config in application’s directory
- NLog.dll.nlog in a directory where NLog.dll is located (only if NLog isn't installed in the GAC)