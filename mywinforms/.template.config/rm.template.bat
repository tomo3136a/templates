@echo off
pushd %~dp0..

dotnet new uninstall
dotnet new uninstall .

popd
pause
