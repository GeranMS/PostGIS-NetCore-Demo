# PostGIS-NetCore-Demo
_This is an example on how to integrate and implement location search functionality with .Net Core and a PostGIS enabled PostgreSQL database._

## Installation

1. Download or clone this project and use open the .sln file.
      
## Setup

To intitialize a PostGIS enabled PostgreSQL database follow the guide posted in the docs folder linked to [here](https://github.com/GeranMS/PostGIS-NetCore-Demo/tree/master/docs).

Then configure and change your connection string to your specifications of the database in the code of DbContext.cs, as shown an example of here:
~~~c#
private string connection = "Host=localhost;Port=5433;Database=Prototype_Events;Username=postgres;Password=simplepassword";
~~~
_**Non-disclaimer**:Hardcoding your connection string in code is not best practice. This has been done for simplicity and pure to ease the creation of a demo app. When creating applications in line with best practices, the connection string should be load at run-time from app.config or app.settings._

Then change the mapping of your table name in the EventsMapping.cs file to your table name in the following line of code
~~~c#
 public EventsMapping(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Events>(t =>
            {
                t.ToTable("events");
            });
        }
~~~
## The Program CLI

The CLI was developed with the .Net Core NuGet package, [fire](https://github.com/natemcmaster/CommandLineUtils), and was used to develop a user-friendly console application.
The CLI can execute 2 commands: search-all and search-item. The former searches for any points in the database within a given radius of a given location and the latter searches for a point by their id.

## Basic Usage(search-all):

e.g If you want to search for all points within radius 20000m from point(18.865644 -33.930755), the command looks as follows:

`dotnet run search-all --lon 18.865644 --lat -33.930755 --rad 20000`

## Commands Reference

All of the commands referenced below is can be found in the program CLI by the --help command.

|Command      |Inputs               |Outputs          |Notes                                                  |
|-            |-                    |-                |-                                                      |
|search-item  |--id                 |Table entry      |Search for an entry given its id                       | 
|search-all   |--lon, --lat, --rad  |List of entries  |Search for entries given an origin point and a radius  |
