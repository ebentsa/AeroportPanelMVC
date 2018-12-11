using AeroportBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AeroportBusinessLogic.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }

        public bool DepartureOrArrival { get; set; }


        public string FlightNum { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Flightdate { get; set; }


        public string FlightCity { get; set; }


        public string FlightAirline { get; set; }

        public string FlightTerminal { get; set; }


        public FlightStatusEnum FlightStat { get; set; }

        public string FlightGate { get; set; }
        
        public float BusinessPrice { get; set; }

       
        public float EconomPrice { get; set; }


        public virtual ICollection<Passenger> Passengers { get; set; }

        public Flight()
        {
            Passengers = new List<Passenger>();
        }
    }
}