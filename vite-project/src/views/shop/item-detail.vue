<script setup lang='ts'>
import { computed, ref } from 'vue';
import { Addtocart } from '../../api/shop';
import { cartitem, Drugs } from '../../api/types/type';
import { cartStore } from '../../store';


defineProps<{


list:Drugs[]

}>()

//加入购物车事件
const addToCart=(id:string)=>{
  Addtocart(id).then(response => {
      console.log(response);
      // 处理添加购物车成功后的逻辑
      console.log(response.data.id)
    const cartlist = cartStore();
    const cartItem: cartitem = {
 ...response.data,

};
 console.log(cartItem)
 console.log("添加到")
    cartlist.addToCart(cartItem)
    console.log(cartlist.cart)






      
    })
    .catch(error => {
      console.log(error);
      // 处理添加购物车失败后的逻辑
    })
 

}



</script>


<template>
  <div class="container" >

<h2 class="h2 section-title title text-center" id="feature-label">药品</h2>

<ul class="feature-list"  >

  <li v-for="item in list">
    <div class="product-card text-center">

      <div class="card-banner">

        <figure class="product-banner img-holder" style="--width: 448; --height: 470;">
          <img :src="item.url" width="448" height="470" loading="lazy"
            alt="Acne Baseball Cap" class="img-cover">
        </figure>
      
        <a href="#" class="btn product-btn"   @click.prevent="addToCart(item.id)" >
          <ion-icon name="bag" aria-hidden="true"></ion-icon>
       
          <span class="span">加入购物车</span>
        </a>

      </div>

      <div class="card-content">
        <h4 class="h3 title">
          <a href="#" class="card-title">{{ item.name }}</a>
        </h4>
        <span >{{ item.info }}</span>
        <span class="price">{{ item.price }}元</span>
        
      </div>

    </div>
  </li>


</ul>

<a href="#" class="btn btn-secondary">View All Products</a>

</div>

</template>


<style lang='scss' scoped>

</style>