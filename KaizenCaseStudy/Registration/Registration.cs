using KaizenCaseStudy.Services;
using KaizenCaseStudy.Services.Abstract;

namespace KaizenCaseStudy.Registration
{
    public static class Registration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IRandomCodeGenerator, RandomCodeGenerator>();
            services.AddScoped<IBillParser, BillParser>();
        }
    }
}
