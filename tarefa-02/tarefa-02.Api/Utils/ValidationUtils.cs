using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tarefa_02.Utils
{
    public static class ValidationUtils
    {
        public static IEnumerable<ValidationResult> Validate(object obj)
        {
            var validationResult = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            Validator.TryValidateObject(obj, context, validationResult);
            return validationResult;
        }
    }
}
