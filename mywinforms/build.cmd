@echo off
pushd %~dp0
set PS=powershell.exe
set OPT=-Sta -NonInteractive -NoProfile -NoLogo -ExecutionPolicy RemoteSigned
%PS% %OPT% ./tool/%~n0.ps1 %*
popd
