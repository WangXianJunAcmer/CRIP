import { defineStore } from "pinia";
import { Deletebatchitem, Deletesingleitem, Getfromcart, batchCheckout, checkoutAll } from "../api/shop";
import { Names } from "./store-name";
interface CartItem {
  id: string,
  goodsId: string,
  cartId: string,
  orderId: string,
  title: string,
  price: number,

}

// 用户信息
export const useTestStore = defineStore(Names.User,
  {
    //pinia里面必须是箭头函数才返回对象
    state: () => {
      return {
        role: '',
        token: '',
        username: ''
      }
    },
    //类似计算的 有缓存
    getters: {

    },
    //类似methods 提交state
    actions: {

      setName(role: string, token: string,) {
        this.role = role
        this.token = token


      },
      setUSERmessage(username: string) {
        this.username = username
      }


    }


  })

// 购物车内容
export const cartStore = defineStore(Names.Cart,

  {

    state: () => ({
      cart: [] as CartItem[],
     
    }),
    actions: {
      //获得全部购物车内容
      async GetAllCartItems() {
        try {
          const response = await Getfromcart();
          // console.log("try")
          // console.log("res", response)
          // console.log(response.data)
          // console.log("是否为数组",Array.isArray(response.data));
          const data = response.data as Array<any>;
          const cartItems: CartItem[] = (data).map((item: any) => {
            return {
              id: item.id,
              goodsId: item.goodsId,
              cartId: item.cartId,
              orderId: item.orderId,
              title: item.title,
              price: item.price,
            };
          });
          this.cart = cartItems;
          console.log("aaaaaaaa", this.cart)
        } catch (error) {
          console.error(error);
        }
      },
      //加入到购物车
      addToCart(item: CartItem) {
        this.cart.push({ ...item });
        // console.log( "tianjia",this.cart)
      },
      // 从购物车中删除商品
      async removeFromCart(id: string) {
        // const index = this.cart.findIndex((cartItem) => cartItem.id === id);
        // if (index >= 0) {
        //   // 从本地购物车中删除商品
        //   this.cart.splice(index, 1);
        //   console.log("删除的index是！！！！！！！！！",index)

        //   try {
        //     // 向后端发送请求，更新购物车
        //     const response =
        await Deletesingleitem(id).then
          (response => {
            console.log(response);
          }).catch(error => console.error(error));


      },
      //批量删除
      async removeMultipleFromCart(ids: string[]) {
        // 遍历需要删除的id数组，从购物车中找到对应的商品并删除
        console.log(ids);


        // 向后端发送请求，更新购物车
        await Deletebatchitem(ids).then(response => {

          console.log(response)

        }


        )
          .catch(error => console.error(error));
      },
      //批量下单
      async checkoutMultipleFromCart(ids: string[]) {
        // 遍历需要删除的id数组，从购物车中找到对应的商品并删除
        console.log(ids);

         
        // 向后端发送请求，更新购物车
        await batchCheckout(ids).then(response => {

          console.log(response)

        }


        )
          .catch(error => console.error(error));
      },
      //全部下单
      async checkoutAllFromcart() {



        // 向后端发送请求，更新购物车
        await checkoutAll().then(response => {

          console.log(response)

        }


        )
          .catch(error => console.error(error));
      },
      //清空
      clearCart() {
        this.cart = [];
      },
    },
  })

