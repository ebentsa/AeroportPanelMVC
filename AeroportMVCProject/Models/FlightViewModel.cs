using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AeroportBusinessLogic.Enums;

namespace AeroportMVCProject.Models
{
    public class FlightCreateUpdateModel
    {
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "ВылетИлиПрилет")]
        public bool DepartureOrArrival { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Номер")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 6 символов")]
        public string FlightNum { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Время")]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime Flightdate { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Город")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Только Буквы")]
        public string FlightCity { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Авиалинии")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string FlightAirline { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Терминал")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 5 символов")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string FlightTerminal { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Статус")]
        public FlightStatusEnum FlightStat { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Гейт")]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 12 символов")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Только Буквы")]
        public string FlightGate { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Цена (Б/К)")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Только Цифры")]
        public float BusinessPrice { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Цена (Е/К)")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Только Цифры")]
        public float EconomPrice { get; set; }
    }

    public class FlightCustomerShortModel
    {
        [Display(Name = "Номер")]
        public string FlightNum { get; set; }

        [Display(Name = "Время")]
        public DateTime Flightdate { get; set; }

        [Display(Name = "Город")]
        public string FlightCity { get; set; }

        [Display(Name = "Авиалинии")]
        public string FlightAirline { get; set; }

        [Display(Name = "Терминал")]
        public string FlightTerminal { get; set; }

        [Display(Name = "Статус")]
        public FlightStatusEnum FlightStat { get; set; }
    }

    public class FlightCustomerFullModel
    {

        [Display(Name = "ВылетИлиПрилет")]
        public bool DepartureOrArrival { get; set; }

        [Display(Name = "Номер")]
        public string FlightNum { get; set; }

        [Display(Name = "Время")]
        public DateTime Flightdate { get; set; }

        [Display(Name = "Город")]
        public string FlightCity { get; set; }

        [Display(Name = "Авиалинии")]
        public string FlightAirline { get; set; }

        [Display(Name = "Терминал")]
        public string FlightTerminal { get; set; }

        [Display(Name = "Статус")]
        public FlightStatusEnum FlightStat { get; set; }

        [Display(Name = "Гейт")]
        public string FlightGate { get; set; }

        [Display(Name = "Цена (Б/К)")]
        public float BusinessPrice { get; set; }

        [Display(Name = "Цена (Е/К)")]
        public float EconomPrice { get; set; }
    }

}