using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Repository
{
    public class CompanyOutingsRepository
    {
        public IOutings GolfOutings = new Golf();
        public IOutings BowlingOutings = new Bowling();
        public IOutings AmusementParkOuting = new AmusementPark();
        public IOutings ConcertOutings = new Concert();


        public List<IOutings> _listOfOutings = new List<IOutings>();


        //Create

        public void CreateNewOuting(IOutings companyOutings)
        {
            _listOfOutings.Add(companyOutings);

        }

        //Read

        public List<IOutings> GetListOfOutings()
        {
            return _listOfOutings;
        }

        
    }
}
