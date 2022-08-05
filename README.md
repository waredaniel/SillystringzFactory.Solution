# SillyStringzFactory

#### A factory organizer helping to pair engineers with the machines they repair using a many-to-many SQL database.

#### By Daniel Ware

## Technologies Used

* C#
* Entity
* SQL
* .NET
* CSS

## Setup/Installation Requirements

* Clone repository from github
* Create an appsettings.json file in Factory directory and add the following:
  { "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=[Daniel_Ware];uid=root;pwd=[YOUR_PASSWORD];" } }
* Import daniel_ware.sql database into SQL Workbench
* Navigate to Factory directory
* Run dotnet restore
* Run dotnet ef database update
* Run dotnet run to and open web browser to http://localhost:5000 to view

## Known Bugs

* None

## License

MIT  (c) 2022

## Contact Information

Daniel Ware <waredanielb@gmail.com>