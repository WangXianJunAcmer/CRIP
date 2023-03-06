namespace CRIP.Dtos.GoodsDtos
{
    public class GoodsDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 商品名 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public LinkDto Link { get; set; }
    }
}
