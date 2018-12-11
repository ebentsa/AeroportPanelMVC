using AeroportBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AeroportBusinessLogic.Models
{
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }

        [Display(Name = "Номер рейса")]
        public string PassFlNumber { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Только Буквы")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Фамилия")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Только Буквы")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Национальность")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Только Буквы")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Номер Паспорта")]
        [StringLength(8, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 8 символов")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Только Цифры и Буквы")]
        public string Passport { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Пол")]
        public PassSex Sex { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Класс")]
        public FlightClass FlClass { get; set; }

        public int? FlightId { get; set; }
        public Flight Flights { get; set; }


    }
}