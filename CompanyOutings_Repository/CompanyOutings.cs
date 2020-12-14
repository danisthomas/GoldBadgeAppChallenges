using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Repository
{
    public enum OutingType
    {
        Golf = 1,
        Bowling,
        AmusePark,
        Concert
    }
    public interface IOutings
    {
        double CostPerPerson { get; set; }
        int NumberOfPeople { get; set; }
        DateTime DateOfOuting { get; set; }

        double CostPerEvent();

       // double OutingCostPerEvent { get; set; }

        OutingType TypeOfOuting {get; set;}

    }

    public class Golf : IOutings
    {
        public double CostPerPerson { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime DateOfOuting { get; set; }

       // public double OutingCostPerEvent {get; set;}

        public OutingType TypeOfOuting { get; set; }
        public double CostPerEvent()
        {
            double OutingCostPerEvent = NumberOfPeople * CostPerPerson;
            return OutingCostPerEvent;
        }

    }

    public class Bowling : IOutings
    {
        public double CostPerPerson { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime DateOfOuting { get; set; }
      //  public double OutingCostPerEvent { get; set; }
        public OutingType TypeOfOuting { get; set; }
        public double CostPerEvent()
        {
            double OutingCostPerEvent = NumberOfPeople * CostPerPerson;
            return OutingCostPerEvent;
        }
    }

    public class AmusementPark : IOutings
    {
        public double CostPerPerson { get ; set; }
        public int NumberOfPeople { get ; set ; }
        public DateTime DateOfOuting { get ; set; }
     //   public double OutingCostPerEvent { get ; set ; }
        public OutingType TypeOfOuting { get; set; }
        public double CostPerEvent()
        {
            double OutingCostPerEvent = NumberOfPeople * CostPerPerson;
            return OutingCostPerEvent;
        }
    }
    public class Concert : IOutings
    {
        public double CostPerPerson { get ; set ; }
        public int NumberOfPeople { get; set ; }
        public DateTime DateOfOuting { get ; set; }
      //  public double OutingCostPerEvent { get ; set; }
        public OutingType TypeOfOuting { get; set; }
        public double CostPerEvent()
        {
            double OutingCostPerEvent = NumberOfPeople * CostPerPerson;
            return OutingCostPerEvent;
        }
    }







}



