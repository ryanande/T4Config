﻿@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.3.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)
 
set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)
 
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\T4Config.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false
 
mkdir Build
 
%nuget% pack "src\T4Config\T4Config.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"
