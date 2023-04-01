<script setup lang='ts'>
import { onMounted, reactive, ref, watch } from 'vue';
import { getUserSimplifyMessage } from './../../api/common'
import { getData } from './../../api/drug'
import { IlistParams } from "../../api/types/type";
import {Drugs } from "../../api/types/type";
import Itemdetails from './item-detail.vue'
import { useTestStore } from '../../store';
import { use } from 'echarts';
import router from '../../router';


//分页
// 改变页码的方法
const handleCurrentChange = (page: number) => {
  listParams.PageNumber = page
  loadList(listParams)
}
//每页大小改变的事件
const handleSizeChange = (size: number) => {
  listParams.PageSize = size
  listParams.PageNumber = 1
  loadList(listParams)
}

// namechange
const NameChange=(value:string)=>{

listParams.OrderBy=value
console.log(listParams.OrderBy)
finddrug ()
}



onMounted(() => {

getusermessage()
loadList(listParams)

//  loadList("wsn")

}) 
//查询药品
const state = ref('')
const restaurants = ref<RestaurantItem[]>([])
  const usermessage = ref('')
const listcount = ref(0)
const listDrugMessage = ref<Drugs[]>([])
interface RestaurantItem {
  id: string;
 value: string;
  price: number;
  info: string;
  quantity: number;
  link: {
    href: string | null;
    rel: string;
    method: string;
  };

}
interface herdermessage {
  currentPage: number
  nextPageLink: string
  pageSize: number
  previousPageLink: string
  totalCount: number
  totalPages: number
}

const listParams = reactive({
  keyword: '',
  OrderBy:'price',
  Desc: true,
  PageNumber: 1,
  PageSize: 8,

})

const querySearch = (queryString: string, cb: any) => {
  console.log(queryString)
const results = queryString
  ? restaurants.value.filter(createFilter(queryString))
  : restaurants.value
console.log("result----" + results)
// call callback function to return suggestions
cb(results)
}
const createFilter = (queryString: string) => {
return (restaurant: RestaurantItem) => {
  return (
    restaurant.value.toLowerCase().indexOf(queryString.toLowerCase()) === 0

  )
}

}

watch(state, async () => {
  let datalist = ref<RestaurantItem[]>([])
 console.log( state.value)
  if (state.value.length != 0) {
    listParams.keyword = state.value
    const getvalue = await getData(listParams)



    datalist.value = getvalue.goodss.map((item: { id: any;  name: any; price: any; link: any; }) => {
      return {
        id: item.id,
      
        value: item.name,
        price: item.price,
        link: item.link
      }

    })

  }
  restaurants.value = datalist.value



})

const handleSelect = (item: RestaurantItem) => {
  console.log("item---------" + item)
}



const loadList = async (listParams: IlistParams) => {

const data = await getData(listParams)

const headermess: herdermessage = JSON.parse(data.headers['x-pagination'])

listcount.value = headermess.totalCount


listDrugMessage.value = data.goodss

}

const finddrug = () => {

listParams.keyword = state.value
loadList(listParams)
}

const toCart=()=>{
  router.push("/cart")
}



// 获取用户的用户名

const getusermessage = () => {

const user=useTestStore()
usermessage.value = user.username
console.log("姓名",usermessage.value)


}
</script>


<template>


  <!-- 
    - #HEADER
  -->

  <header class="header" data-header>
    <div class="container">

      <a href="#" class="logo">
        <img src="../../assets/images/智慧医疗.svg" width="132" height="27" alt="shoppie home">
      </a>
      <div 
      style="display: flex;">

        <el-autocomplete   
        v-model="state"         :fetch-suggestions="querySearch" :trigger-on-focus="true"  clearable
        @select="finddrug"
      placeholder="药品查询"
     
     
     >
     <template #prefix>
<el-icon  >
 <Search />
</el-icon>
</template>
   </el-autocomplete>
   <el-button
   @click="finddrug"
   type="primary"
   size="large"
   style=" height: 58px;
   width: 100px;
    margin-left: 12px;"  plain>查询</el-button>
    </div>

  
      <nav class="navbar" data-navbar>
     
        
        <button  @click="toCart" class="cart-btn">
          <ion-icon name="bag" aria-hidden="true"></ion-icon>

          <span class="span">购物车</span>
        </button>

        <a href="#" class="btn"> {{ usermessage }}</a>
      </nav>

      <button class="nav-open-btn" aria-label="toggle menu" data-nav-toggler>
        <ion-icon name="menu-outline" aria-hidden="true"></ion-icon>
      </button>

    </div>
  </header>

<main>
    <article>

  



  




      <!-- 
        - #FEATURE
      -->

      <section class="section feature" aria-label="feature-label"
      style="
        display: flex;
  flex-direction: column;
  align-items: center;
      "
      >
        
        <Itemdetails :list="listDrugMessage" />
        <el-pagination :page-sizes="[4, 8, 12]" :small=false background
            layout="total, sizes, prev, pager, next, jumper" :total="listcount" style="margin-top:25px;
            font-size: 35px;"
            v-model:currentPage="listParams.PageNumber" v-model:page-size="listParams.PageSize"
            @size-change="handleSizeChange" @current-change="handleCurrentChange" />
      </section>


      
  




    </article>
  </main>






</template>


<style >
/*-----------------------------------*\
  #style.css
\*-----------------------------------*/

/**
 * copyright 2022 codewithsadee
 */





/*-----------------------------------*\
  #CUSTOM PROPERTY
\*-----------------------------------*/

:root {

/**
 * COLORS
 */

/* backgorund color */
--bg-white: hsla(0, 0%, 100%, 1);
--bg-gainsboro: hsla(154, 10%, 86%, 1);
--bg-wild-blue-yonder: hsla(227, 39%, 75%, 1);
--bg-orange-crayola: hsla(18, 97%, 62%, 1);
--bg-roman-silver-alpha-30: hsla(210, 9%, 57%, 0.3);

/* text color */
--text-orange-crayola: hsla(18, 97%, 62%, 1);
--text-blue-crayola: hsla(216, 98%, 52%, 1);
--text-eerie-black: hsla(210, 11%, 15%, 1);
--text-eerie-black-2: hsla(0, 0%, 7%, 1);
--text-black: hsla(270, 100%, 0%, 1);

/* border color */
--border-eerie-black: hsla(0, 0%, 7%, 1);

/**
 * TYPOGRAPHY
 */

/* font family */
--fontFamily-inter: 'Inter', sans-serif;
--fontFamily-clashDisplay: 'ClashDisplay', cursive;

/* font size */
--fontSize-1: 6.2rem;
--fontSize-2: 4.4rem;
--fontSize-3: 3.8rem;
--fontSize-4: 3.4rem;
--fontSize-5: 3rem;
--fontSize-6: 2.5rem;
--fontSize-7: 2rem;
--fontSize-8: 1.8rem;
--fontSize-9: 1.4rem;
--fontSize-10: 2.4rem;
--fontSize-11: 1.2rem;

/* font weight */
--weight-semiBold: 600;

/**
 * BOX SHADOW
 */

--shadow-1: 0 4px 6px hsla(256, 100%, 9%, 0.1);
--shadow-2: 4px 4px 0px hsla(0, 0%, 7%, 1);
--shadow-3: 2px 2px 0px hsla(0, 0%, 7%, 1);

/**
 * BORDER RADIUS
 */

--radius-circle: 50%;

/**
 * TRANSITION
 */

--transition-1: 250ms ease;
--transition-2: 500ms ease;

}





/*-----------------------------------*\
#RESET
\*-----------------------------------*/

*,
*::before,
*::after {
margin: 0;
padding: 0;
box-sizing: border-box;
}

li { list-style: none; }

a,
img,
span,
input,
button,
ion-icon { display: block; }

a {
color: inherit;
text-decoration: none;
}

img { height: auto; }

input,
button {
background: none;
border: none;
font: inherit;
}

input { width: 100%; }

button { cursor: pointer; }

address { font-style: normal; }

ion-icon { pointer-events: none; }

html {
font-family: var(--fontFamily-inter);
font-size: 10px;
scroll-behavior: smooth;
}

body {

color: var(--text-eerie-black-2);
font-size: 1.6rem;
line-height: 1.5;
}





/*-----------------------------------*\
#REUSED STYLE
\*-----------------------------------*/

.container { padding-inline: 16px; }

.shape {
display: none;
position: absolute;
}

.title {
font-family: var( 'ClashDisplay', cursive);
font-weight: var(--weight-semiBold);
line-height: 1.2;
}

.h1 { font-size: var(--fontSize-2); }

.h2 { font-size: var(--fontSize-3); }

.h3 { font-size: var(--fontSize-5); }

.h4 { font-size: var(--fontSize-6); }

.btn {
background-color: var(--bg-white);
display: flex;
align-items: center;
max-width: max-content;
min-width: max-content;
padding: 15px 30px;
border: 2px solid var(--border-eerie-black);
box-shadow: var(--shadow-2);
font-weight: var(--weight-semiBold);
transition: var(--transition-1);
}

.btn:is(:hover, :focus-visible) { box-shadow: none; }

.btn-primary,
.btn-secondary {
gap: 5px;
text-transform: uppercase;
}

:is(.btn-primary, .btn-secondary) ion-icon {
font-size: 2rem;
transform: rotate(-45deg);
}

.btn-primary:is(:hover, :focus-visible) { color: var(--text-orange-crayola); }

.btn-secondary { background-color: var(--bg-orange-crayola); }

.img-holder {
aspect-ratio: var(--width) / var(--height);
background-color: var(--bg-gainsboro);
overflow: hidden;
}

.img-cover {
width: 100%;
height: 100%;
object-fit: cover;
}

.section { padding-block: 75px; }

.text-center { text-align: center; }

.section-title { margin-block-end: 45px;
margin-block-start: 150px; }

.product-btn {
position: absolute;
top: 50%;
left: 50%;
transform: translate(-50%, -50%);
font-size: var(--fontSize-9);
gap: 8px;
opacity: 0;
}

.product-btn ion-icon { font-size: 1.4rem; }

.product-card:is(:hover, :focus-within) .product-btn { opacity: 1; }

.product-card .card-banner { position: relative; }

.product-card .card-content { margin-block-start: 30px; }

.product-card .card-title:is(:hover, :focus-visible) { text-decoration: underline; }

.product-card .price {
color: var(--text-orange-crayola);
font-family: var(--fontFamily-clashDisplay);
font-size: var(--fontSize-7);
font-weight: var(--weight-semiBold);
margin-block-start: 10px;
}

.has-scrollbar {
display: flex;
align-items: center;
gap: 40px;
scroll-snap-type: inline mandatory;
overflow-x: auto;
}

.has-scrollbar::-webkit-scrollbar { display: none; }

.scrollbar-item {
min-width: 100%;
scroll-snap-align: start;
}

.has-bg-image {
background-repeat: no-repeat;
background-size: cover;
background-position: center;
}





/*-----------------------------------*\
#HEADER
\*-----------------------------------*/

.navbar .btn { display: none; }

.header {
position: fixed;
top: 0;
left: 0;
width: 100%;
padding-block: 25px;
z-index: 4;
}

.header.active {
background-color: var(--bg-white);
box-shadow: var(--shadow-1);
}

.header .container {
display: flex;
justify-content: space-between;
align-items: center;
}

.nav-open-btn { font-size: 3.5rem; }

.navbar {
position: absolute;
top: 85px;
left: 0;
right: 0;
background-color: var(--bg-white);
max-height: 0;
overflow: hidden;
visibility: hidden;
transition: var(--transition-2);
}

.navbar.active {
max-height: 310px;
visibility: visible;
}

.navbar-list { padding-block-start: 15px; }

.navbar-link,
.cart-btn .span {
font-weight: var(--weight-semiBold);
text-transform: uppercase;
}

.navbar-link { padding: 10px 20px; }

.cart-btn {
display: flex;
align-items: center;
gap: 4px;
padding: 25px 20px;
}





/*-----------------------------------*\
#HERO
\*-----------------------------------*/

.hero {
background-color: var(--bg-wild-blue-yonder);
padding-block: 130px 75px;
}

.hero .container {
display: grid;
gap: 50px;
}

.hero-subtitle { font-size: var(--fontSize-4); }

.hero-title { margin-block: 16px 30px; }

.hero-text {
font-size: var(--fontSize-8);
line-height: 2.1;
margin-block-end: 16px;
}

.hero-banner {
max-width: max-content;
margin-inline: auto;
}





/*-----------------------------------*\
#FEATURE
\*-----------------------------------*/

.section.feature { padding-block-start: 0; }

.feature-list {
display: grid;
gap: 60px;
margin-block-end: 60px;
}

.feature .btn { margin-inline: auto; }





/*-----------------------------------*\
#OFFER
\*-----------------------------------*/

.offer { padding-block: 100px; }

.offer-card {
background-color: var(--bg-white);
border: 2px solid var(--border-eerie-black);
box-shadow: var(--shadow-2);
padding: 80px 30px;
}

.offer-card .card-title { font-size: var(--fontSize-1); }

.offer-card .card-text {
font-size: var(--fontSize-8);
line-height: 1.8;
margin-block: 20px 45px;
}





/*-----------------------------------*\
#FOOTER
\*-----------------------------------*/

.footer {
position: relative;
background-color: var(--bg-gainsboro);
padding-block-start: 160px;
}

.footer-top {
display: grid;
gap: 30px;
font-size: var(--fontSize-8);
line-height: 1.7;
margin-block-end: 60px;
}

.footer .logo { margin-block-end: 35px; }

.social-list {
display: flex;
gap: 10px;
margin-block-start: 30px;
}

.social-link {
background-color: var(--bg-white);
width: 52px;
height: 52px;
display: grid;
place-items: center;
border-radius: var(--radius-circle);
border: 2px solid var(--border-eerie-black);
box-shadow: var(--shadow-3);
transition: var(--transition-1);
}

.social-link:is(:hover, :focus-visible) {
box-shadow: none;
color: var(--text-orange-crayola);
transform: translateY(-2px);
border-color: currentColor;
}

.footer-list-title {
font-size: var(--fontSize-10);
margin-block-end: 30px;
}

address.footer-text { margin-block-end: 15px; }

.input-field {
background-color: var(--bg-white);
box-shadow: var(--shadow-2);
padding: 15px 30px;
border: 2px solid var(--border-eerie-black);
margin-block-end: 25px;
outline: none;
transition: var(--transition-1);
}

.input-field:focus { box-shadow: none; }

.footer .btn {
font-size: 1.6rem;
padding-inline: 40px;
}

.footer-bottom .wrapper {
border-block-end: 2px solid var(--border-eerie-black);
padding-block-end: 15px;
}

.link-wrapper {
display: flex;
flex-wrap: wrap;
justify-content: center;
gap: 10px 30px;
margin-block-end: 15px;
}

.footer-bottom-link {
font-size: var(--fontSize-11);
font-weight: var(--weight-semiBold);
text-transform: uppercase;
transition: var(--transition-1);
}

.footer-bottom-link:is(:hover, :focus-visible) { color: var(--text-orange-crayola); }

.copyright {
padding-block: 30px;
font-size: var(--fontSize-8);
text-align: center;
}

.footer .shape-1 {
display: block;
top: 0;
right: 0;
}





/*-----------------------------------*\
#MEDIA QUERIES
\*-----------------------------------*/

/**
* responsive for large than 575px screen
*/

@media (min-width: 575px) {

/**
 * REUSED STYLE
 */

.container {
  max-width: 540px;
  width: 100%;
  margin-inline: auto;
}



/**
 * OFFER
 */

.offer-card { padding-inline: 50px; }

}





/**
* responsive for large than 768px screen
*/

@media (min-width: 768px) {

/**
 * CUSTOM PROPERTY
 */

:root {

  /**
   * TYPOGRAPHY
   */

  /* font size */
  --fontSize-4: 4.2rem;
  --fontSize-2: 7.8rem;
  --fontSize-3: 6.6rem;

}



/**
 * REUSED STYLE
 */

.container { max-width: 720px; }

.btn { padding: 20px 50px; }

.section { padding-block: 150px; }

.scrollbar-item { min-width: calc(50% - 20px); }

.product-btn { padding: 15px 30px; }



/**
 * HERO
 */

.hero { padding-block: 200px 130px; }

.hero-text {
  --fontSize-8: 2.2rem;
  line-height: 1.8;
}

.hero .btn { margin-block-start: 50px; }



/**
 * FEATURE
 */

.feature-list {
  grid-template-columns: 1fr 1fr;
  column-gap: 24px;
}



/**
 * OFFER
 */

.offer-card { padding-inline: 90px; }



/**
 * FOOTER
 */

.footer-top { grid-template-columns: 1fr 1fr; }

}





/**
* responsive for large than 992px screen
*/

@media (min-width: 992px) {

/**
 * REUSED STYLE
 */

.container { max-width: 960px; }



/**
 * HEADER
 */

.header { padding-block: 0; 
  background-color: rgba(0, 0, 0, 0.5);
}

.header .container { border-block-end: 2px solid var(--border-eerie-black); }

.nav-open-btn { display: none; }

.navbar,
.navbar.active {
  all: unset;
  display: flex;
  align-items: center;
}

.navbar-list {
  padding-block-start: 0;
  display: flex;
}

.cart-btn {
  border-inline-start: 2px solid var(--border-eerie-black); 
  padding-inline-start: 50px;
  margin-inline-start: 20px;
}

.header.active .container,
.header.active .cart-btn { border: none; }



/**
 * FOOTER
 */

.footer .shape-2 {
  display: block;
  bottom: 100px;
  left: 0;
}

}





/**
* responsive for large than 1200px screen
*/

@media (min-width: 1200px) {

/**
 * REUSED STYLE
 */

.container { max-width: 1140px; }

.scrollbar-item { min-width: calc(33.33% - 40px); }

.shape { display: block; }



/**
 * HEADER
 */

.cart-btn { padding-block: 35px; }

.navbar .btn {
  display: block;
  padding: 10px 25px;
  text-transform: uppercase;
  margin-inline-start: 20px;
}



/**
 * HERO
 */

.hero { position: relative; }

.hero .container {
  grid-template-columns: 1fr 1fr;
  align-items: center;
}

.hero-banner {
  position: relative;
  z-index: 1;
}

.hero .shape-1 {
  top: -140px;
  left: -120px;
  z-index: -1;
}

.hero .shape-2 {
  bottom: 0;
  left: 50%;
  transform: translateX(-50%);
}



/**
 * FEATURE
 */

.feature-list { grid-template-columns: repeat(4, 1fr); }



/**
 * OFFER
 */

.offer { padding-block: 200px; }

.offer-card { width: 40%; }



/**
 * FOOTER
 */

.footer-top {
  grid-template-columns: repeat(3, 1fr);
  margin-block-end: 160px;
}

.footer-bottom .wrapper {
  display: flex;
  justify-content: space-between;
}

.footer .shape-2 { bottom: 160px; }

.footer .shape-3 {
  left: 50%;
  bottom: 0;
  transform: translateX(-50%);
}

.copyright {
  text-align: left;
  padding-block-end: 50px;
}

}





/**
* responsive for large than 1400px screen
*/

@media (min-width: 1400px) {

/**
 * CUSTOM PROPERTY
 */

:root {

  /**
   * TYPOGRAPHY
   */

  /* font size */
  --fontSize-2: 9rem;

}



/**
 * REUSED STYLE
 */

.container { max-width: 1320px; }



/**
 * FOOTER
 */

.footer-bottom-link { font-size: 1.6rem; }

}


 .el-autocomplete  {
   
    width:500px;
}

.el-input__wrapper  {
      height: 60px;

}
</style>