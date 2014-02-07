@FOR %%F in (C:\SecretAgent\wwwroot\Common\BIN\*.DLL) DO @(
    AssemblyInfo.exe %%F 
)
@ECHO.
@ECHO.
@PAUSE