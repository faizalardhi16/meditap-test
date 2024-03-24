# How to Run this Application ?

First Step, make sure you have to install .NET 8. You can using this command for check dotnet version :

`dotnet --version`

After running this command, you can see version of .net you installed.

Then, you can clone this repository from branch master. Or, if you on branch Main, you can checkout to Master first.

After that, please running `dotnet restore` command to install all package for this apps.

After installing all package, you must run `dotnet ef database update` to create sqlite database. make sure, you have installed dotnet ef tools. And version must greater than 8.0.0

You can check version of your dotnet ef tools on this command `dotnet ef --version`

Final step, you can run `dotnet run` to running this application.

And you can test the API with swagger UI on http://localhost:5216/swagger/index.html.

Just enjoy the Apps 🍻