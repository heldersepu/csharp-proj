

# Introduction #
GeoData uses Bing API to get the Latitude Longitude of a given address.

# Details #

## Accuracy fields ##
Main Screen showing new fields (Confidence, CalculationMethod)
![https://csharp-proj.googlecode.com/svn/wiki/PID773176/GeoData_2011-11-23_12-30-51.png](https://csharp-proj.googlecode.com/svn/wiki/PID773176/GeoData_2011-11-23_12-30-51.png)
<br><br><br>

<h2>Main Screen</h2>
This is the main screen as it looks the first time it opens.<br>
<img src='https://csharp-proj.googlecode.com/svn/wiki/PID773176/GeoData.png' />
<br><br><br>

<h2>Run Unattended</h2>
This allows you to run in unattended mode. It will read and write to SQL<br>
You can start this process directly from the command line or integrate in the Task Scheduler using:<br>
<b>GeoData.exe runUnattended</b><br>
<img src='https://csharp-proj.googlecode.com/svn/wiki/PID773176/GeoData_Run_Unattended.png' />
<br><br><br>

<h2>Input Menu</h2>
The first step should be to load the data, you can enter it manually or use the input menu.<br>
<img src='https://csharp-proj.googlecode.com/svn/wiki/PID773176/GeoData_input.png' />
<br><br><br>

<h2>Ready to EXECUTE</h2>
The addresses are loaded in the grid view, now you can click the EXECUTE, it might take a few seconds to update it all depends on your connection speed and how many items to process.<br>
<img src='https://csharp-proj.googlecode.com/svn/wiki/PID773176/GeoData_exec.png' />
<br><br><br>

<h2>After EXECUTE</h2>
After the execution completes the latitude and longitude will be populated; those that have no lat/lon is because we did not receive a response from the Bing Api (potentially an incorrect address)<br>
<img src='https://csharp-proj.googlecode.com/svn/wiki/PID773176/GeoData_after_exec.png' />
<br><br><br>

<h2>Output Menu</h2>
And the last step will be to save the data via output menu.<br>
<img src='https://csharp-proj.googlecode.com/svn/wiki/PID773176/GeoData_output.png' />
<br><br><br>

<h2>The config file</h2>
The relevant information is at the bottom of the <b>.config</b> file, in the appSettings section<br>
<img src='https://csharp-proj.googlecode.com/svn/wiki/PID773176/PID773176.png' />