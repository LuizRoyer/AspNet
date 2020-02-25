using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Aula31_Filters.Filtros
{
    public class SaudacaoFilterAttribute:ActionFilterAttribute 
    {
        // executa antes da action
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewResult result = context.Result as ViewResult;
            if(result != null)
            {
                result.ViewData["ola"] = "Ola , Filtro Saudação " + DateTime.Now.ToLongDateString();
            }
            base.OnActionExecuting(context);
        }

        // executa depois da action
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            ViewResult result = context.Result as ViewResult;
            if(result != null)
            {
                result.ViewData["adeus"] = "Tchau , Filtro SaudacaoFilter";
            }
        }
    }
}
