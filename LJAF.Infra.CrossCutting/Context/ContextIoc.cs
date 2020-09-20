using LJAF.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LJAF.Infra.CrossCutting.Context
{
    public static class ContextIoc
    {
        public static void Add(IServiceCollection services, string connection)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<LjafContext>(options =>
                {
                    options.UseSqlServer(connection);
                });
        }
    }
}
