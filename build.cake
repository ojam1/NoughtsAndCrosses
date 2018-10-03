var target = Argument("target", "Default");

Task("Default")
.IsDependentOn("Run-Tests");

Task("Run-Tests")
.IsDependentOn("Build")
    .Does(() => {
        DotNetCoreTest("./NoughtsAndCrosses.Tests/NoughtsAndCrosses.Tests.csproj");
    });

Task("Build")
    .Does(() => {
        DotNetCoreBuild("./NoughtsAndCrosses/NoughtsAndCrosses.csproj");
    });


RunTarget(target);