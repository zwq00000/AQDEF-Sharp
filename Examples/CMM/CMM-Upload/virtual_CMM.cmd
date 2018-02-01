rem 
@echo off
cls
set /a maxloops=15
set /a loopcounter=0
set /a samplefilecounter=0
set /a delay=60
set SAMPLEFILENAME=1Measurement.QFQ
set OUTPUTFILENAME=sample_file.dfq
PUSHD %~dp0

Title Create max. %maxloops% sample *.dfq files for Q-DAS O-QIS (MCA/CMM-Reporting)

:start4loop
if %loopcounter% == %maxloops% goto the_end
cls
echo.
echo break with Ctrl+C
echo.
echo loops:%loopcounter%
set /a loopcounter=%loopcounter%+1
echo.
echo samplefiles:%samplefilecounter%
echo.
rem check if the old file is processed
if exist %OUTPUTFILENAME% goto end4loop
Create1File %SAMPLEFILENAME% %OUTPUTFILENAME% 1
set /a samplefilecounter=%samplefilecounter%+1

:end4loop

rem ping is used for delaying the loop // -n 61 = 60 seconds
rem 
ping -n %delay% localhost > nul
goto start4loop
rem pause

:the_end
echo done
pause