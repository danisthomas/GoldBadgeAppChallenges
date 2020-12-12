using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan_Respository
{
   
    public class CarsRepository
    {
        private List<Cars> _listOfCars = new List<Cars>();

        //Create

        public void AddCarToList (Cars vehicle)
        {
            _listOfCars.Add(vehicle);
        }

        //Read
        public List<Cars> ViewListOfAllCars()
        {
            return _listOfCars;
        }
        //Udpate
        public bool UpdateListOfCarsByModel(string model)
        {
            Cars vehicle = GetListOfAllCars
        }


        //Delete

        //Helper
        public Cars GetListOfAllCars()
        {

        }

    }
}
