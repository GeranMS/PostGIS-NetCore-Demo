using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NetTopologySuite.Geometries;

namespace MyDbContext.Entities
{
    public class Events
    {
        public long EventId { get; set; }
        public string Eventname { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public Point Location { get; set; }

    }
}
