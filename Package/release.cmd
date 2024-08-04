del "*.nupkg"
"..\..\oqtane.framework-5.0.2\oqtane.package\nuget.exe" pack Registration.Module.moodule.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework-5.0.2\Oqtane.Server\Packages\" /Y

