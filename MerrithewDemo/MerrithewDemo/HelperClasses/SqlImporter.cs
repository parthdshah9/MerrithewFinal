using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MerrithewDemo.Models;
using System.Data.Entity.Validation;

namespace MerrithewDemo.HelperClasses
{
    public class SqlImporter
    {

        public static void ImportToSql()
        {
            TextReader textReader = File.OpenText(@"C:\Users\Parth\Documents\visual studio 2015\Projects\MerrithewFinal\MerrithewDemo\MerrithewDemo\locations.csv");
            var csv = new CsvReader(textReader);
            csv.Configuration.RegisterClassMap(new LocationMap());
            var records = csv.GetRecords<location>().ToList();

            location loctn = new location();
            var context = new MerrithewEntities();
            foreach (var item in records)
            {
                context.locations.Add(item);
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        HttpContext.Current.Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}