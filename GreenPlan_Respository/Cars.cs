using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan_Respository
{
    public enum Fuel
    {
        Electric = 1,
        Gas,
        Hybrid

    }
    public class Cars
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int DoorNumber { get; set; }
        public bool FourWheelDrive { get; set; }
        public bool AutoTransmission { get; set; }
        public string Color { get; set; }

        public Fuel FuelType { get; set; }
        

        public Cars() { }
        public Cars (string make, string model, int doorNumber, bool fourWheelDrive, bool autoTransmission, string color, Fuel fuelType)
        {
            make = Make;
            model = Model;
            fourWheelDrive = FourWheelDrive;
            autoTransmission = AutoTransmission;
            color = Color;
            fuelType = FuelType;

        }

        
       
    }


}
