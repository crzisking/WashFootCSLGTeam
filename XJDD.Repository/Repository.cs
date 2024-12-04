using SqlSugar;

namespace XJDD.Repository;

public class Repository<T> : SimpleClient<T> where T : class, new()
{
    public ITenant itenant = null;

    public Repository(ISqlSugarClient db)
    {
        itenant = db.AsTenant();
        base.Context = db.AsTenant().GetConnectionScopeWithAttr<T>();
    }
}