using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeroportBusinessLogic.Interfaces;

namespace AeroportBusinessLogic.ValidationMethods
{
    public class DataValidation : IValidation
    {

        public string StringValidation(string data)
        {
            var newString = data.ToUpper();
            return newString;
        }

        public int IntConvert(string data)
        {
             int.TryParse(data, out int intData);
            return intData;
        }
    }
}
