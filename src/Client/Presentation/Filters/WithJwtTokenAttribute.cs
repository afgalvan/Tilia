using System;
using System.Threading.Tasks;
using ArxOne.MrAdvice.Advice;

namespace Presentation.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WithJwtTokenAttribute : Attribute, IMethodAsyncAdvice
    {
        public async Task Advise(MethodAsyncAdviceContext context)
        {
            context.Arguments[^1] = App.AccessToken;
            await context.ProceedAsync();
        }
    }
}
