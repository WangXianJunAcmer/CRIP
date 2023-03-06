namespace CRIP.ResourceParameters
{
    public class PaginationResourceParamaters
    {
        private int _pageSize = 10;
        private int _pageMaxSize = 100;
        private int _pageNumber = 1;
        //页数
        public int PageNumber {
            get
            {
                return _pageNumber;
            }
            set
            {
                if(value >= 1)
                {
                    _pageNumber = value;
                }
            }
        } 
        //每页数据量
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if(value>=1&&value<_pageMaxSize)
                {
                    _pageSize = value;
                }
            }
        }
    }
}
