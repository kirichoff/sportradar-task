# Scoreboard Lib

branch coverage ![](coveragereport/badge_branchcoverage.svg)

method coverage ![](coveragereport/badge_methodcoverage.svg)

[Tests Summary](coveragereport/SummaryGithub.md)

## for restoring nuget packages
```shell
nuget restore
```

## for unit tests run
```shell
dotnet test
```

## to generate new coverage test report

report generator instalation 

```shell
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.2.1

dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools --version 5.2.1

dotnet new tool-manifest
dotnet tool install dotnet-reportgenerator-globaltool --version 5.2.1
```
coverlet coverage
```shell
dotnet test --collect:"XPlat Code Coverage"   
```
report generating
```shell
dotnet reportgenerator -reports:./src/Scoreboard.Test/TestResults/0efa3298-07c8-4320-8e45-65de80724f21/coverage.cobertura.xml -targetdir:coveragereport -reporttypes:"MarkdownSummaryGithub;Badges"  
```

