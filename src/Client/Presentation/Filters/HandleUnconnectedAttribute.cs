using System;
using System.Threading.Tasks;
using ArxOne.MrAdvice.Advice;
using Newtonsoft.Json;

namespace Presentation.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HandleUnconnectedAttribute : Attribute, IMethodAsyncAdvice
    {
        public async Task Advise(MethodAsyncAdviceContext context)
        {
            try
            {
                await context.ProceedAsync();
            }
            catch (Exception e) when (e is JsonReaderException or InvalidOperationException)
            {
                context.ReturnValue = Task.FromResult(new object[] {"Sin conexión con el servidor"});
            }
        }
    }
}
