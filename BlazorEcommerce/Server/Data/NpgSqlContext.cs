using Shared;

namespace BlazorEcommerce.Server.Data
{
    public class NpgSqlContext : DataContext
    {
        public NpgSqlContext(IConfiguration configuration) : base(configuration) { AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
