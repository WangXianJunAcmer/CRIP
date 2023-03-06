namespace CRIP.Common
{
    public class PagesResponse
    {

        public int code { get; set; }
        public string? msg { get; set; }
        public string? error { get; set; }
        public dynamic? data { get; set; }


        public void Success(dynamic data, string msg = "")
        {
            code = 200;
            this.msg = msg;
            this.data = data;
        }
        public void Success(string msg = "")
        {
            code = 200;
            this.msg = msg;
            data = data;
        }
        public void BadRequest(string error = "")
        {
            code = 400;
            this.error = error;
        }
        public void NotFound(string error = "")
        {
            code = 404;
            this.error = error;
        }

    }

}
