using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public static class ModelValidator
    {
        public static RemoteArgs Validate<TModel>(TModel model)
        {
            DataValidator dataValidator = new DataValidator();
            var result = dataValidator.Validate(model, out string errorMessage);

            if(!result)
            {
                RemoteArgs args = new RemoteArgs
                {
                    Message = errorMessage,
                    Result = false
                };
                return args;
            }

            return default;
        }
    }
}
