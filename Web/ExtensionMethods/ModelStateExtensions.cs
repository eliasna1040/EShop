using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ExtensionMethods
{
    public static class ModelStateExtensions
    {
        public static ModelStateDictionary MarkFieldsAsSkipped(this ModelStateDictionary modelState, string fieldsNotToSkip)
        {
            foreach (ModelStateEntry? item in modelState.Where(x => x.Key.Split('.')[0] != fieldsNotToSkip).Select(x => x.Value))
            {
                if (item != null)
                {
                    item.ValidationState = ModelValidationState.Skipped;
                }
            }
            return modelState;
        }

        public static ModelStateDictionary MarkFieldsAsSkipped(this ModelStateDictionary modelState, string[] fieldsToSkip)
        {
            foreach (ModelStateEntry? item in modelState.Where(x => fieldsToSkip.Contains(x.Key.Split('.')[0]) || fieldsToSkip.Contains(x.Key.Split('.')[1])).Select(x => x.Value))
            {
                if (item != null)
                {
                    item.ValidationState = ModelValidationState.Skipped;
                }
            }
            return modelState;
        }
    }
}
