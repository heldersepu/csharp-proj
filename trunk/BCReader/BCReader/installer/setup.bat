:: Make an installer using NSIS

@COLOR 02
:: clean up before starting
@DEL *.exe
@CD ..
@DEL *.exe
@DEL *.bak /s

@ECHO.
@ECHO.
@ECHO  CLEANING COMPLETE!   READY TO START?
@ECHO.
@PAUSE

:: Copy all the files
@MD C:\BCReader
@MD C:\BCReader\Stores
@COPY bin\Debug\BCReader.exe C:\BCReader\
@COPY installer\setup.nsi C:\BCReader\
@COPY *.xml C:\BCReader\Stores\
@DEL C:\BCReader\Stores\Microsoft*.xml
@COPY *.dll C:\BCReader\


:: Launch the NSIS setup
@COLOR 07
@SET NSIS="%ProgramFiles%\NSIS\makensis.exe"
@IF NOT EXIST %NSIS% SET NSIS="%ProgramFiles(x86)%\NSIS\makensis.exe"
CALL %NSIS% installer\setup.nsi
@ECHO.

@ECHO.
@ECHO.
@COLOR 0A
@MOVE *.exe installer
@ECHO.
@PAUSE
