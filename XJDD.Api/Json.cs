namespace XJDD.Api;
//后端返回的json数据
public class Json
{
    public int code;
    public string msg;
    public object data;
    public Json(int code, string msg, object data)
    {
        this.code = code;
        this.msg = msg;
        this.data = data;
    }
}