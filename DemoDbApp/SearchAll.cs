using System;
using System.Collections.Generic;
using System.Text;
using MyDbContext;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System.Linq;

namespace DemoDbApp
{
    [HelpOption("--help")]
    class SearchAll
    {
        [Required]
        [Option("--lon",Description = "The longitude of origin location")]
        public float Longitude { get; set; }

        [Required]
        [Option("--lat", Description = "The latitude of origin location")]
        public float Latitude { get; set; }

        [Required]
        [Option("--rad", Description = "The radius in m from origin location")]
        public float Radius { get; set; }

        public void OnExecute()
        {
            using (var db = new MyDbContext.DbContext())
            {
                var watch = new System.Diagnostics.Stopwatch();

                watch.Start();
                var geometry = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var Coordinates = geometry.CreatePoint(new Coordinate(Longitude, Latitude));

                Point myLocation = new Point(Longitude, Latitude)
                {
                    SRID = 4326
                };

                // Circumference of earth
                //var Circ = 40075017;
                // Assuming Earth is a perfect sphere, the distance used in .NetTopologySuite is dist = Radius(m)*360(degrees)/Circ:
                //var dist = (Radius * 360) / Circ;
                var distance = Radius / 111139;
                var nearbyEvents = db.Events.Where(c => c.Location.Distance(myLocation) < Radius).Count();

                //foreach (Events eventEntry in nearbyEvents)
                // {
                // Console.WriteLine($"Event detail :{eventEntry.EventId},{eventEntry.Eventname},{eventEntry.Longitude},{eventEntry.Latitude}");
                //   }
                Console.WriteLine(nearbyEvents);
                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            }
        }
    }
}
