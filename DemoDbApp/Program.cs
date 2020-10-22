
using MyDbContext;
using MyDbContext.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;


namespace DemoDbApp
{

    [Command(Name ="search",Description ="Searches and counts the events in given radius from origin point")]
    [Subcommand(typeof(SearchAll))]
    [Subcommand(typeof(SearchItem))]
    [HelpOption("--help")]
    class Program
    {
        public static void Main(string[] args)
        {
            CommandLineApplication.Execute<Program>(args);
        }
    }

}
