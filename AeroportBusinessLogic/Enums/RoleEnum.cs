using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic.Enums
{
    public enum RoleEnum
    {
        [Display(Name = "Manager")]
        Manager,

        [Display(Name = "Supervisor")]
        Supervisor,
    }
}
