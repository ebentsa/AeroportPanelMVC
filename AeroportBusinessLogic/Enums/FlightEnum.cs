using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic.Enums
{
    public enum FlightStatusEnum
    {
        
        [Display(Name = "CHECK-IN")]
        CheckIn,

        [Display(Name = "GATE CLOSED")]
        GateClosed,

        [Display(Name = "ARRIVED")]
        Arrived,

        [Display(Name = "DEPARTED AT")]
        DepartedAt,

        [Display(Name = "UNKNOWN")]
        Unknown,

        [Display(Name = "CANCELED")]
        Canceled,

        [Display(Name = "EXPECTED AT")]
        ExpectedAt,

        [Display(Name = "DELAYED")]
        Delayed,

        [Display(Name = "IN FLIGHT")]
        InFlight

    }

    public enum FlightClass
    {
        [Display(Name = "BUSINESS")]
        Business,

        [Display(Name = "ECONOM")]
        Econom

    }

    public enum PassSex
    {
        [Display(Name = "WOMAN")]
        Woman,

        [Display(Name = "MAN")]
        Man,

        [Display(Name = "NON DEFINED")]
        NonDefined

    }



}
