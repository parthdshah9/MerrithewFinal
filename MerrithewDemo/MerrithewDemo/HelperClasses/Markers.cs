using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerrithewDemo.HelperClasses
{
    public class Tooltips
    {
        public string content { get; set; }
    }

    public class Markers
    {
        public List<double> location { get; set; }
        public string shape { get; set; }
        public Tooltips tooltip { get; set; }
    }
}