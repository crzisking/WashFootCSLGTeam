namespace XJDD.Api;
//后端返回的json数据11
public class Json(int code, string msg, object data)
{
    public int Code { get; } = code;
    public string Msg { get; } = msg;
    public object Data { get; } = data;
}