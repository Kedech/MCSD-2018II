namespace WebServerProj
{
    public interface ICustomBuilder
    {
        string Build(object data);
        string PageNotFound(object msg);
    }
}