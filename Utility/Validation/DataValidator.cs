using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Utility
{
   public class DataValidator
    {
        public bool Validate<TModel>(TModel model, out string errorMessage)
        {
            bool isValid = false;
            if(model==null)
            {
                errorMessage = "Null Model";
                return isValid;
            }
            errorMessage = "";
            List<ValidationResult> result = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(model);
            isValid = Validator.TryValidateObject(model, validationContext, result, true);
            if(!isValid)
            {
                foreach(ValidationResult message in result)
                {
                    errorMessage = result[0].ErrorMessage;
                }
            }
            return isValid;
        }
    }
}
