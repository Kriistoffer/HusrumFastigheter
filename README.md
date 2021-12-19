# HusrumFastigheter
An API that create logs of every single door being opened (or attempted to) in an apartment building.

## Prerequisites
Make sure you've installed the following before trying to run the project:
- Visual Studio 2022
- .NET 6.0

## How to run the project
1. Clone the project to a local folder of your choice using "git clone https://VKOKR@dev.azure.com/VKOKR/HusrumFastigheter/_git/HusrumFastigheter" in your Command Prompt.
2. Open the project using Visual Studio 2022.
3. Create a new migration by using "Add-Migration 'nameOfYourMigration'" in Packet Manager Console.
4. Update your local database by using "Update-Database" in Packet Manager Console.
5. Your local database has now been created. Run the project once to seed the database with our current data.
6. Once running you'll have access to all the API endpoints through swagger -- try out the API!