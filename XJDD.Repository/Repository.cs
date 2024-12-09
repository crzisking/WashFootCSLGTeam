using SqlSugar;

namespace XJDD.Repository;

public class Repository<T> : SimpleClient<T> where T : class, new()
{
    public ITenant Tenant;

    public Repository(ISqlSugarClient db)
    {
        Tenant = db.AsTenant();
        base.Context = db.AsTenant().GetConnectionScopeWithAttr<T>();
    }
}