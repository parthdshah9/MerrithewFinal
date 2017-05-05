using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MerrithewDemo.Models;

namespace MerrithewDemo.Controllers
{
    public class LocationController : Controller
    {
        private MerrithewEntities db = new MerrithewEntities();
        private List<Marker> markers = new List<Marker>();
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Map()
        {
            ImportMarkers();
            var map = new Models.Map()
            {
                Name = "MyMap",
                CenterLatitude = 30.268107,
                CenterLongitude = -97.744821,
                Zoom = 3,
                TileUrlTemplate = "http://#= subdomain #.tile.openstreetmap.org/#= zoom #/#= x #/#= y #.png",
                TileSubdomains = new string[] { "a", "b", "c"},
                TileAttribution = "&copy; <a href='http://osm.org/copyright'>OpenStreetMap contributors</a>",
                Markers = markers
                
            };
            
            return View(map);
        }

        public ActionResult locations_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<location> locations = db.locations;
            DataSourceResult result = locations.ToDataSourceResult(request, location => new
            {
                id = location.id,
                type_code = location.type_code,
                type_desc = location.type_desc,
                code = location.code,
                description = location.description,
                name = location.name,
                address = location.address,
                phone = location.phone,
                notes = location.notes,
                latitude = location.latitude,
                longitude = location.longitude
            });

            return Json(result);
        }

        private void ImportMarkers()
        {
            foreach (location loc in db.locations)
            {
                markers.Add(new Marker(double.Parse(loc.latitude), double.Parse(loc.longitude), loc.name));
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
