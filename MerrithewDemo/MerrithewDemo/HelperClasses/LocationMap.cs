using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper;
using CsvHelper.Configuration;
using MerrithewDemo.Models;

namespace MerrithewDemo.HelperClasses
{
    public sealed class LocationMap : CsvClassMap<location>
    {
        public LocationMap()
        {
            AutoMap();
            Map(m => m.id).Ignore();
        }
    }
}