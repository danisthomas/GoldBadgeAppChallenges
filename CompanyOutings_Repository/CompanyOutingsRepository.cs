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

        public List<double> GetListOfOutingsRunningTotal()
        {
            List<IOutings> listOfOutings = GetListOfOutings();
            List<double> listOfGolfOutings = new List<double>();
            List<double> listOfBowlOutings = new List<double>();
            List<double> listOfAmuseOutings = new List<double>();
            List<double> listOfConcertOutings = new List<double>();
            List<double> ListOfAllCosts = new List<double>();
            foreach (IOutings outings in listOfOutings)
            {
                if (outings.TypeOfOuting == OutingType.Golf)
                {
                    double cost = outings.CostPerEvent();
                    listOfGolfOutings.Add(cost);
                    double sum1 = listOfGolfOutings.Sum();
                    ListOfAllCosts.Add(sum1);


                }

                if (outings.TypeOfOuting == OutingType.Bowling)
                {
                    double cost = outings.CostPerEvent();
                    listOfBowlOutings.Add(cost);
                    double sum1 = listOfBowlOutings.Sum();
                    ListOfAllCosts.Add(sum1);
                }

                if (outings.TypeOfOuting == OutingType.AmusePark)
                {
                    double cost = outings.CostPerEvent();
                    listOfAmuseOutings.Add(cost);
                    double sum1 = listOfAmuseOutings.Sum();
                    ListOfAllCosts.Add(sum1);
                }

                if (outings.TypeOfOuting == OutingType.Concert)
                {
                    double cost = outings.CostPerEvent();
                    listOfConcertOutings.Add(cost);
                    double sum1 = listOfConcertOutings.Sum();
                    ListOfAllCosts.Add(sum1);
                }
            }
            return ListOfAllCosts;


        }
        public List<double> GetListOfGolfOutingsRunningTotal()
        {
            List<IOutings> listOfOutings = GetListOfOutings();
            List<double> listOfGolfOutings = new List<double>();
           
           
            foreach (IOutings outings in listOfOutings)
            {
                if (outings.TypeOfOuting == OutingType.Golf)
                {
                    double cost = outings.CostPerEvent();
                    listOfGolfOutings.Add(cost);
                    double sum1 = listOfGolfOutings.Sum();
                }
                
            }
            return listOfGolfOutings;
        }
        public List<double> GetListOfBowlOutingsRunningTotal()
        {
            List<IOutings> listOfOutings = GetListOfOutings();
            List<double> listOfBowlOutings = new List<double>();


            foreach (IOutings outings in listOfOutings)
            {
                if (outings.TypeOfOuting == OutingType.Golf)
                {
                    double cost = outings.CostPerEvent();
                    listOfBowlOutings.Add(cost);
                    double sum1 = listOfBowlOutings.Sum();
                }

            }
            return listOfBowlOutings;
        }
        public List<double> GetListOfAmueOutingsRunningTotal()
        {
            List<IOutings> listOfOutings = GetListOfOutings();
            List<double> listOfAmuseOutings = new List<double>();


            foreach (IOutings outings in listOfOutings)
            {
                if (outings.TypeOfOuting == OutingType.Golf)
                {
                    double cost = outings.CostPerEvent();
                    listOfAmuseOutings.Add(cost);
                    double sum1 = listOfAmuseOutings.Sum();
                }

            }
            return listOfAmuseOutings;
        }
        public List<double> GetListOfConcertOutingsRunningTotal()
        {
            List<IOutings> listOfOutings = GetListOfOutings();
            List<double> listOfConcertOutings = new List<double>();


            foreach (IOutings outings in listOfOutings)
            {
                if (outings.TypeOfOuting == OutingType.Golf)
                {
                    double cost = outings.CostPerEvent();
                    listOfConcertOutings.Add(cost);
                    double sum1 = listOfConcertOutings.Sum();
                }

            }
            return listOfConcertOutings;
        }
    }
}
