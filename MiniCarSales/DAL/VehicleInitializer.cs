using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MiniCarSales.Models;

namespace MiniCarSales.DAL
{
    public class VehicleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed (VehicleContext context)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleID = 10034, VehicleType = "Car", Make = "Civic", Model = "2016", SelectedBodyType = "Hatch", Doors = "4", Wheels = "4", Engine = "2.0L 4-cylinder" },
                new Vehicle { VehicleID = 10045, VehicleType = "Car", Make = "Accord", Model = "2018", SelectedBodyType = "Sedan",  Doors = "4", Wheels = "4", Engine = "2.0L 4-cylinder" }
            };
            vehicles.ForEach(s => context.Vehicles.Add(s));
            context.SaveChanges();
        }
    }
}