namespace CRIP.Dtos
{
    public class LinkDto
    {
        public string Href { get; set; }//链接
        public string Rel { get; set; }//描述
        public string Method { get; set; }//方法类型

        public LinkDto(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
