using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoDbApp
{
    [HelpOption("--help")]
    class SearchItem
    {
        [Required]
        [Option("--id", Description = "The id of the event")]
        public long EventId { get; set; }

        public void OnExecute()
        {
            using (var db = new MyDbContext.DbContext())
            {
                //// CRUD - READ
                var watch = new System.Diagnostics.Stopwatch();

                watch.Start();
                var events = db.Events.Find(EventId);
                Console.WriteLine($"Event detail : ID={events.EventId}, Name={events.Eventname}, Longitude={events.Longitude}, Latitude={events.Latitude}");
                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            }

        }
    }
}
