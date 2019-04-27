var _target = Argument("target", "Default");

/* T4Config Build script */
//*****************************************
// Variables

var _configuration = Argument("configuration", "Release");
var _version = "1.0.5";
var _project = "T4Config";

var _srcDir = "./src/";
var _projectDir = _srcDir + "T4Config/";
var _buildDir = "./build/";
var _packgeOutput = _buildDir + "nuget/";

var _buildMsg = @" 
_________  ___   ___  ________  ________  ________   ________ ___  ________     
|\___   ___\\  \ |\  \|\   ____\|\   __  \|\   ___  \|\  _____\\  \|\   ____\    
\|___ \  \_\ \  \\_\  \ \  \___|\ \  \|\  \ \  \\ \  \ \  \__/\ \  \ \  \___|    
     \ \  \ \ \______  \ \  \    \ \  \\\  \ \  \\ \  \ \   __\\ \  \ \  \  ___  
      \ \  \ \|_____|\  \ \  \____\ \  \\\  \ \  \\ \  \ \  \_| \ \  \ \  \|\  \ 
       \ \__\       \ \__\ \_______\ \_______\ \__\\ \__\ \__\   \ \__\ \_______\
        \|__|        \|__|\|_______|\|_______|\|__| \|__|\|__|    \|__|\|_______|";




//*****************************************
// Setup & Teardown
Setup(ctx => {
    Information(_buildMsg);
});
Teardown(ctx => {
    Information("T4Config Build Completed!");
});
//*****************************************

//*****************************************
// Clean 
Task("clean")
    .Does(() =>
    {
        if (DirectoryExists(_buildDir))
        {
            DeleteDirectory(_buildDir, new DeleteDirectorySettings { Recursive = true, Force = true});
        }
        CreateDirectory(_buildDir);
    });
//*****************************************

//*****************************************
// Build

//*****************************************

//*****************************************
// Pack & Publish
Task("pack")
    .IsDependentOn("clean")
    .Does(() => {

        var nuGetPackSettings   = new NuGetPackSettings {
            Id                      = "T4Config",
            Version                 = _version,
            Title                   = "The tile of the package",
            Authors                 = new[] {"Ryan Anders"},
            Description             = "Configuration class generator for app.config and web.config appsettings and connectionStrings.",
            Summary                 = "This package contains a T4 template which read the appsettings and connections strings from your app/web config files and generates and interface and concrete implementation using lazy loading to reach into config manager to grab setting values.",
            ProjectUrl              = new Uri("https://github.com/ryanande/T4Config"),
            Copyright               = "Buzzuti 2019",
            Tags                    = new [] {"T4", "Configuration", "appsettings", "connectionString", "Build"},
            LicenseUrl              = new Uri("https://github.com/ryanande/T4Config/blob/master/LICENSE.md"),
            RequireLicenseAcceptance= false,
            Symbols                 = false,
            NoPackageAnalysis       = true,
            Files                   = new [] {
                                                new NuSpecContent {Source = "Configurations.tt", Target = "content"},
                                                new NuSpecContent {Source = "install.ps1", Target = "tools"},
                                            },
            BasePath                = _projectDir,
            OutputDirectory         = _packgeOutput
        };

        if(!DirectoryExists(_packgeOutput))
        {
            CreateDirectory(_packgeOutput);
        }

        NuGetPack(nuGetPackSettings);
    });

Task("push")
    .IsDependentOn("pack")
    .Does(() => {
         // Get the path to the package.
        var package = _packgeOutput + _project + "." + _version + ".nupkg";

        // Push the package.
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package/",
            ApiKey = "oy2pb2m53pxccu652lsq2stfzj3xequubnuzxbrsr774wq"
        });
    });
//*****************************************


RunTarget(_target);