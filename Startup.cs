using Exceltodb_expenseentry.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ExpenseEntryJournal.Startup))]

namespace ExpenseEntryJournal
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var tempProvider = builder.Services.BuildServiceProvider();
            var config = tempProvider.GetRequiredService<IConfiguration>();

            builder.Services.AddDbContext<DataContext>(x =>
            {
                x.UseSqlServer(config["SqlServerConnection"]
                , options => options.EnableRetryOnFailure());
            });

        }
    }
}
