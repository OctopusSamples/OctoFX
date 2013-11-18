using System.Web.Mvc;
using OctoFX.Core.Model;

namespace OctoFX.TradingWebsite
{
    public class CurrencyBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return (Currency)bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
        }
    }
}