@SET idir=F:\csharp-proj\ToTango
@SET DEVENV="C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe"

@RMDIR /S /Q %idir%\absToTango\absToTango\bin
@RMDIR /S /Q %idir%\absToTango\absToTango\obj
@RMDIR /S /Q %idir%\ToTangoXport\ToTangoXport\bin
@RMDIR /S /Q %idir%\ToTangoXport\ToTangoXport\obj

%DEVENV% %idir%\absToTango\absToTango.sln /Build
%DEVENV% %idir%\ToTangoXport\ToTangoXport.sln /Build
COPY  %idir%\absToTango\absToTango\mapping.csv %idir%\ToTangoXport\ToTangoXport\bin\Debug

@ECHO.
@DEL /F /S %idir%\*.pdb 
@PING 127.0.0.1 > nul