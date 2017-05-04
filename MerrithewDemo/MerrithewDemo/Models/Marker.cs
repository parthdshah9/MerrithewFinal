using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerrithewDemo.Models
{
    public class Marker
    {
        public Marker(double latitude, double longitude, string sname)
        {
            latlng = new double[] { latitude, longitude };
            name = sname;
        }

        public double[] latlng { get; set; }
        public string name { get; set; }
    }
}