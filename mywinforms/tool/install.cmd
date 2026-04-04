@echo off
pushd %~dp0
set INST=c:\opt\bin
pushd ..\..
for /f %%i in ("%CD%") do set APP=%%~ni
popd

echo installing...
if exist ..\bin\%APP%.exe (
  if not exist %INST% mkdir %INST% 
  copy ..\bin\%APP%.exe %INST%
)
set TOOL=%INST%\..\tool
if exist ..\tool (
  for /f %%i in (..\tool\install_*) do (
    if not exist %TOOL% mkdir %TOOL%
    copy /y %%i %TOOL%\%APP%_%%~nxi
  )  
)

popd
pause
