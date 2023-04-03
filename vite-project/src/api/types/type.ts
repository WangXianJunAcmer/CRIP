
export interface IlistParams{

keyword:string,
OrderBy:string,
Desc:boolean,
PageNumber:number,
PageSize:number
}
export interface userMessage{
     userName:string
      email: string
}
export interface Drugs {
    id: string;
    name: string;
    price: number;
    info: string;
    quantity: number;
    link: {
      href: string | null;
      rel: string;
      method: string;
    };
  }

export interface Header{
    "set-cookie"?: string[],
  'x-pagination':string
  }
  export interface cartitem{
    id:string,
    goodsId:string,
    cartId:string,
    orderId:string,
    title:string,
    price:number
 
  }

 export interface OrderItem{
    userId:string
      user: string,
      orderLineItems: string,
      state: number,
      createDateUTC: string
      id: string
  }
  