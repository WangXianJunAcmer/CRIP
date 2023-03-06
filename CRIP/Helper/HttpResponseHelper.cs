namespace CRIP.Helper
{
    public class HttpResponseHelper
    {

        public void SetHeader(string Name, string value, HttpResponse Response)
        {
            Response.Headers.Add(Name, value);
            Response.Headers["access-control-expose-headers"] = Name;
        }
    }

}
