namespace api.Services.Common;

public sealed class Response<T>
{
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
}

public sealed class Response
{

}
