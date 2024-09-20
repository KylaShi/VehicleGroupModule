using VehicleModule;
using VehicleModule.Models;

var dbcontextfactory = new EFCoreDBContextFactory();
var context = dbcontextfactory.CreateDbContext(new string[] { });

//Create
var newVehicleGroup = new VehicleGroup
{
    Name = "Car1",
    Description = "Red",
    CreatedDate = DateTime.Now.ToString()
};

context.VehicleGroups.Add(newVehicleGroup);
context.SaveChanges();

////Update
//var vehicleGroup = context.VehicleGroups.FirstOrDefault(s=>s.Name =="Good Car");
//if(vehicleGroup != null)
//{
//    vehicleGroup.Name = "Good Car Updated";
//    context.SaveChanges();
//}


////Delete
//var vehicleGroupDelete = context.VehicleGroups.FirstOrDefault(s => s.Name == "Delete Vehicle");
//if (vehicleGroupDelete != null)
//{
//    context.VehicleGroups.Remove(vehicleGroupDelete);
//    context.SaveChanges();
//}