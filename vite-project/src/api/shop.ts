
import requestCart from "../utils/cart";
import { useTestStore } from '../store';
import { cartitem } from "./types/type";

// 加入到购物车

export const Addtocart =(id:string)=>{
    
  const getthename=useTestStore();
    return requestCart<
    {

       id:string,
       goodsId:string,
       cartId:string,
       orderId:string,
       title:string,
       price:number

        
    }
  
    >(
    {
        method:'Post',
        url:'/api/Cart',
        headers:{
            Authorization: `Bearer ${getthename.token}`,
            'Content-Type':'application/json' 
        },
        data:id
    })
}
// get到购物车内容


export const Getfromcart =()=>{
    
  const getthename=useTestStore();
    return requestCart<
    {
  

        
    }
  
    >(
    {
        method:'get',
        url:'/api/Cart',
        headers:{
            Authorization: `Bearer ${getthename.token}`,
            accept: '*/*'
        },
        
    })
}
//删除单个药品
export const Deletesingleitem=(id:string)=>{
  const getthename=useTestStore();
    return requestCart({
        method:'delete',
        url:'/api/Cart',
        headers:{
            Authorization: `Bearer ${getthename.token}`,
            'Content-Type':'application/json' ,
           

        },
        data: {
          id: id
      }
        
    })

}

 //批量删除
 export const Deletebatchitem = (itemIds: string[]) => {
  const getthename=useTestStore();
    const params = itemIds.map(id => `ItemIDs=${id}`).join('&');
    return requestCart({
      method: 'delete',
      url: `/api/Cart/item/${itemIds}?${params}`,
      headers: {
        Authorization: `Bearer ${getthename.token}`,
        'Content-Type': 'application/json'
      }
    });
  }
// 批量下单
export const batchCheckout = (itemIds: string[]) => {
  const getthename=useTestStore();
  const params = itemIds.map(id => `ItemIDs=${id}`).join('&');
    return requestCart({
      method: 'post',
      url: `/api/Cart/BatchCheckout?${params}`,
      headers: {
        Authorization: `Bearer ${getthename.token}`,
        'Content-Type': 'application/json' 
      }
    });
  }

// 全部下单
export const checkoutAll = () => {
  const getthename=useTestStore();
    return requestCart({
      method: 'post',
      url: '/api/Cart/Checkout',
      headers: {
        Authorization: `Bearer ${getthename.token}`,
        'Content-Type': 'application/json',
      },
    });
  };

 