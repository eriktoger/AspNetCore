My repo for https://www.udemy.com/course/asp-net-core-true-ultimate-guide-real-project


## Get debugger to work in VS-code
- Install C# Dev kit
- Change launch.json to point to current
- Go to debug and choose C# ... and select the name that you chose in launch.json

## Change default solution in settings.json:
{
    "dotnet.defaultSolution": "ModelValidation/ModelValidationsExample.sln"
}
// and also add the .csproj to the sln like: dotnet sln add DIExample/DIExample.csproj 
// and run the project

### Creating the project from command line without VS:
- mkdir DependcyInjection && cd DependcyInjection
- dotnet new sln -n DIExample
- dotnet new classlib -n Services
- mkdir DIExample && cd DIExample
- dotnet new web
- dotnet sln add DIExample/DIExample.csproj 
- dotnet aspnet-codegenerator --project . controller  -name "HomeController" -outDir "Controllers"
- Change  "dotnet.defaultSolution": "ModelValidation/ModelValidationsExample.sln" to  "dotnet.defaultSolution": "DependecyInjection/DIExample.sln"
- dotnet add reference ../Services/Services.csproj 
- dotnet mkdir Test && cd Test
- dotnet new xunit 
- cd .. # back to the solution
- dotnet sln add Test/Test.csproj # Run tests with dotnet test --filter TEST-NAME or dotnet test -l "console;verbosity=normal"