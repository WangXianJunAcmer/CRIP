<script setup lang='ts'>
import { Drugs } from '../../api/types/type';


defineProps<{


list:Drugs[]

}>()
</script>


<template>
  <div class="container" >

<h2 class="h2 section-title title text-center" id="feature-label">药品</h2>

<ul class="feature-list"  >

  <li v-for="item in list">
    <div class="product-card text-center">

      <div class="card-banner">

        <figure class="product-banner img-holder" style="--width: 448; --height: 470;">
          <img src="../../assets/images/product-4.png" width="448" height="470" loading="lazy"
            alt="Acne Baseball Cap" class="img-cover">
        </figure>

        <a href="#" class="btn product-btn">
          <ion-icon name="bag" aria-hidden="true"></ion-icon>

          <span class="span">加入购物车</span>
        </a>

      </div>

      <div class="card-content">
        <h3 class="h3 title">
          <a href="#" class="card-title">{{ item.name }}</a>
        </h3>

        <span class="price">{{ item.price }}</span>
      </div>

    </div>
  </li>


</ul>

<a href="#" class="btn btn-secondary">View All Products</a>

</div>

</template>


<style lang='scss' scoped>

</style>