using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerrithewDemo.Models
{
    public class Map
    {
        public string Name { get; set; }
        public double CenterLatitude { get; set; }
        public double CenterLongitude { get; set; }
        public int Zoom { get; set; }

        // Tile layer properties
        public string TileUrlTemplate { get; set; }
        public string[] TileSubdomains { get; set; }
        public string TileAttribution { get; set; }

        // Markers collection
        public IEnumerable<Marker> Markers { get; set; }
    }
}