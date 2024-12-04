using System.Reflection;
using ichia.Api.Middlewares;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using SqlSugar;
using XJDD.Repository;
using XJDD.Service;

public class Program
{
    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        
        
        //数据库
        string? mysqlDB = builder.Configuration.GetSection("Mysql_ConnectionString:DefaultConnection").Value;
        string? posthreDb = builder.Configuration.GetSection("PostgreSql:DefaultConnection").Value;
        
        //注册
        builder.Services.AddSingleton<ISqlSugarClient>(s =>
        {
            SqlSugarScope Db = new SqlSugarScope(new List<ConnectionConfig>()
                {
                    new ConnectionConfig()
                    {
                        ConfigId = DataBaseEnum.dayierp,
                        DbType = DbType.MySql,
                        LanguageType = LanguageType.Chinese,
                        ConnectionString = mysqlDB,
                        IsAutoCloseConnection = true,
                        MoreSettings = new ConnMoreSettings()
                        {
                            IsWithNoLockQuery = true,
                            IsWithNoLockSubquery = true,
                            DisableWithNoLockWithTran = true,
                            DatabaseModel = DbType.MySql,
                        }
                    },
                    new ConnectionConfig()
                    {
                        ConfigId = DataBaseEnum.XJDD,
                        DbType = DbType.PostgreSQL,
                        ConnectionString = posthreDb,
                        IsAutoCloseConnection = true,
                        MoreSettings = new ConnMoreSettings()
                        {
                            IsWithNoLockQuery = true,
                            IsWithNoLockSubquery = true,
                            DisableWithNoLockWithTran = true,
                            DatabaseModel = DbType.PostgreSQL,
                        }
                    }
                },
                Db =>
                {
                    Db.GetConnectionScope(DataBaseEnum.dayierp).Aop.OnLogExecuting = (sql, p) =>
                    {
                        Console.WriteLine(sql);
                    };
                    Db.GetConnectionScope(DataBaseEnum.XJDD).Aop.OnLogExecuting = (sql, p) =>
                    {
                        Console.WriteLine(sql);
                    };
                });
            return Db;
        });

        builder.Services.AddScoped(typeof(Repository<>));
        builder.Services.AddBatchScoped(
            Assembly.Load("XJDD.Repository"),
            Assembly.Load("XJDD.Repository"));
        
        builder.Services.AddBatchScoped(
            Assembly.Load("XJDD.Service"),
            Assembly.Load("XJDD.Service"));

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver
                { NamingStrategy = new CamelCaseNamingStrategy() };
            options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        
        //注册日志
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();
        
        Log.Information("Starting webapi application");
        
        
        //addSingleton 单例模式
        builder.Host.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.File(string.Empty));
        
        
        var app = builder.Build();

        app.UseCors("CorsPolicy");
        app.UseRouting();
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        

        app.Run();

    }
}
