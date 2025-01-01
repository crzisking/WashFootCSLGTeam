using Microsoft.Extensions.Configuration;
using SqlSugar;
using System.IO;

namespace XJDD.Repository
{
    /// <summary>
    /// 静态数据库连接类
    /// </summary>
    public static class StaticConnect
    {
        /// <summary>
        /// 获取 PostgreSQL 数据库连接
        /// </summary>
        /// <returns>SqlSugarScope 对象</returns>
        public static SqlSugarScope GetPostgreSqlConnection()
        {
            // 加载配置文件
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 获取连接字符串
            var connectionString = configuration.GetConnectionString("PostgreSql:DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("未找到 PostgreSQL 的连接字符串，请检查配置文件。");
            }

            // 创建并返回 SqlSugarScope 实例
            return new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DbType.PostgreSQL,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute // 从实体特性中读取主键自增列信息
            });
        }
    }
}