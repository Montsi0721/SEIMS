@echo off
REM ------------------------------------------------------------------
REM  SEIMS - compile the core classes by hand with csc.exe
REM  Double-click this file, or run it from Command Prompt.
REM ------------------------------------------------------------------
setlocal
cd /d "%~dp0"

REM 1. set up the running path so Windows can find csc.exe
set PATH=%PATH%;C:\Windows\Microsoft.NET\Framework64\v4.0.30319

echo Using compiler:
where csc
csc /version
echo.

set MODELS=..\SEIMS\Models
set CORE=%MODELS%\IStorable.cs %MODELS%\Category.cs %MODELS%\Supplier.cs %MODELS%\InventoryItem.cs %MODELS%\InventoryItem.Behavior.cs %MODELS%\PerishableItem.cs ..\SEIMS\Events\LogHandler.cs ..\SEIMS\Services\FileLogger.cs

REM 2. compile the core InventoryItem classes into a library
csc /nologo /target:library /out:InventoryItemCore.dll %CORE%
if errorlevel 1 goto failed

REM 3. compile the demo program together with the same sources into an .exe
csc /nologo /target:exe /out:ManualDemo.exe Demo.cs %CORE%
if errorlevel 1 goto failed

REM 4. run it
echo.
ManualDemo.exe
echo.
echo Log file contents:
type manual_compile.log
goto end

:failed
echo.
echo BUILD FAILED - see the compiler messages above.

:end
pause
