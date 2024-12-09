using SqlSugar;

namespace XJDD.Repository.Entity;

[SugarTable("userTest")]
public class UserTest
{
    [SugarColumn(ColumnName = "user_id")]
    public string UserId { get; set; }
    [SugarColumn(ColumnName = "uid", IsPrimaryKey = true, IsIdentity = true)]
    public int Uid { get; set; }
}