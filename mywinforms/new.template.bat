@echo off
pushd %~dp0

for /d %%i in (_*) do rmdir /q /s %%i
dotnet new install . --force

popd
pause
