using SqlSugar;

namespace XJDD.Repository.Entity;

[SugarTable("public.menu")]
public class Menu
{
    [SugarColumn(ColumnName = "id",IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }
    [SugarColumn(ColumnName = ("menuname"))]
    public  string MenuName { get; set; }
    [SugarColumn(ColumnName = "path")]
    public  string Path { get; set; }
}