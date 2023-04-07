<script setup lang='ts'>
import { onMounted, reactive, ref, watch } from 'vue';
import router from '../../router';
import Doctor from './doctor.vue';
import { IlistDoctor } from '../../api/types/type';
import { getDoctor } from '../../api/common';
import {useTestStore  } from '../../store';



onMounted(()=>{
    const preloader = document.querySelector("[data-preloader]")  as HTMLElement;
    window.addEventListener("load", function () {
      preloader.classList.add("loaded");
      document.body.classList.add("loaded");
    });


     
/**
 * add event on element
 */
 const addEventOnElem = (elem: Element | NodeListOf<Element> | Window, type: string, callback: () => void) => {
  if (elem instanceof NodeList || elem instanceof Element) {
    if (elem instanceof NodeList) {
      for (let i = 0; i < elem.length; i++) {
        elem[i].addEventListener(type, callback);
      }
    } else {
      elem.addEventListener(type, callback);
    }
  } else {
    elem.addEventListener(type, callback);
  }
};



/**
 * active header & back top btn when window scroll down to 100px
 */
const header = document.querySelector("[data-header]") as HTMLElement;
const backTopBtn = document.querySelector("[data-back-top-btn]") as HTMLElement;
console.log(document.querySelector("[data-header]"));

console.log(backTopBtn);
const activeElemOnScroll = () => {
  if (window.scrollY > 100) {
    header.classList.add("active");
    backTopBtn.classList.add("active");
  } else {
    header.classList.remove("active");
    backTopBtn.classList.remove("active");
  }
};

addEventOnElem(window, "scroll", activeElemOnScroll);




/**
 * SCROLL REVEAL
 */
 const revealElements = document.querySelectorAll("[data-reveal]") 

const revealElementOnScroll =  ()=> {
  for (let i = 0, len = revealElements.length; i < len; i++) {
    if (revealElements[i].getBoundingClientRect().top < window.innerHeight / 1.15) {
      revealElements[i].classList.add("revealed");
    } else {
      revealElements[i].classList.remove("revealed");
    }
  }
}

window.addEventListener("scroll", revealElementOnScroll);

window.addEventListener("load", revealElementOnScroll);

})

//回到主页面
const toHome=()=>{
  router.push("/Main")
}

//请求keyword
const doctorname=ref('');
 

const question = ref('')
const answer = ref('Questions usually contain a question mark. ;-)')
// 可以直接侦听一个 ref
watch(doctorname, async () => {
 console.log(doctorname.value)
})

//传入的参数
const listParams = reactive({
  keyword: '',
  OrderBy:'price',
  Desc: true,
  PageNumber: 1,
  PageSize: 8,

})
//点击查找医生
const finddoctor=async(listParams: IlistDoctor )=>{
listParams.keyword=doctorname.value;

const data = await getDoctor(listParams)
console.log(data.data.data);

const doctorstore=useTestStore ();
doctorstore.doctorList=data.data.data
console.log("store",doctorstore.doctorList);
router.push("/search")
  
}






</script>


<template>

 
    <div class="preloader" data-preloader>
    
    </div>
  <!-- 
    - #HEADER
  -->

  <header class="header" data-header>
    <div class="container">

        <el-icon :size="35" @click="toHome" style="cursor: pointer;"><House /></el-icon>

 
  
      <a href="#" class="btn has-before title-md">预约挂号</a>
    
   
    </div>
  </header>

  
  <main>
    <article>

      <!-- 11
        - #HERO
      -->

      <section class="section hero has-bg-image" aria-label="home">
        <div class="container">

          <div class="hero-content">

            <p class="hero-subtitle has-before" data-reveal="left">Welcome To Doclab</p>

            <h1 class="headline-lg hero-title" data-reveal="left">
              寻找 附近<br>
              医生.
            </h1>

            <div class="hero-card" data-reveal="left">

              <p class="title-lg card-text">
                搜索医生 诊所 医院等
              </p>

              <div class="wrapper">

                <div class="input-wrapper title-lg">
                  <input type="text" name="location" placeholder="Locations" 
                  v-model="doctorname"
                  class="input-field">

                  <ion-icon name="location"></ion-icon>
                </div>

                <button class="btn has-before"
                @click="finddoctor(listParams)"
                >
                  <ion-icon name="search"></ion-icon>

                  <span class="span title-md">寻找</span>

                </button>

              </div>

            </div>

          </div>

          <figure class="hero-banner" data-reveal="right">
            <img src="../../assets/hero-banners.png" width="590" height="517" loading="eager" alt="hero banner"
              class="w-100">
          </figure>

        </div>
      </section>





      <!-- 
        - #SERVICE
      -->

      <section class="service" aria-label="service">
        <div class="container">

          <ul class="service-list">

            <li>
              <div class="service-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-1.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <h3 class="headline-sm card-title">
                  <a href="#">精神病科</a>
                </h3>

                <p class="card-text">
                  帮助患者恢复正常的生活和社会活动。
                </p>

                <button class="btn-circle" aria-label="read more about psychiatry">
                  <ion-icon name="arrow-forward" aria-hidden="true"></ion-icon>
                </button>

              </div>
            </li>

            <li>
              <div class="service-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-2.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <h3 class="headline-sm card-title">
                  <a href="#">妇科</a>
                </h3>

                <p class="card-text">
                  预防、诊断和治疗与女性生殖健康有关的疾病和问题。
                </p>

                <button class="btn-circle" aria-label="read more about Gynecology">
                  <ion-icon name="arrow-forward" aria-hidden="true"></ion-icon>
                </button>

              </div>
            </li>

            <li>
              <div class="service-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-3.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <h3 class="headline-sm card-title">
                  <a href="#">肺病科</a>
                </h3>

                <p class="card-text">
                  专注于研究和治疗与肺部相关的疾病。
                </p>

                <button class="btn-circle" aria-label="read more about Pulmonology">
                  <ion-icon name="arrow-forward" aria-hidden="true"></ion-icon>
                </button>

              </div>
            </li>

            <li>
              <div class="service-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-4.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <h3 class="headline-sm card-title">
                  <a href="#">骨科</a>
                </h3>

                <p class="card-text">
                  致力于研究和治疗与骨骼、关节和肌肉相关的疾病和损伤
                </p>

                <button class="btn-circle" aria-label="read more about Orthopedics">
                  <ion-icon name="arrow-forward" aria-hidden="true"></ion-icon>
                </button>

              </div>
            </li>

          </ul>

        </div>
      </section>





      <!-- 
        - #ABOUT
      -->

      <section class="section about" aria-labelledby="about-label">
        <div class="container">

          <div class="about-content">

            <p class="section-subtitle title-lg has-after" id="about-label" data-reveal="left">有关我们</p>

            <h2 class="headline-md" data-reveal="left">经验丰富的工作人员</h2>

            <p class="section-text" data-reveal="left">
              为患者及其家属提供最为满意的服务。
            </p>

            <ul class="tab-list" data-reveal="left">

              <li>
                <button class="tab-btn active">愿景</button>
              </li>

              <li>
                <button class="tab-btn">使命</button>
              </li>

              <li>
                <button class="tab-btn">策略</button>
              </li>

            </ul>

            <p class="tab-text" data-reveal="left">
              我们希望能够看到每个患者都拥有一个充满希望的未来。我们希望患者不再受疾病的困扰，不再受疼痛的折磨，能够做自己喜欢的事情，并和家人、朋友一起度过美好的时光。
              我们望能够成为患者身边的支持者和帮助者，让他们感受到医疗团队的关怀和支持。我们会用尽全力，让患者不再感到孤单和无助，让他们对治疗充满信心和希望
            </p>

            <br>
            <div class="wrapper">

              <ul class="about-list">

                <li class="about-item" data-reveal="left">
                  <ion-icon name="checkmark-circle-outline"></ion-icon>

                  <span class="span">当你的健康遇到波折，<br></span>
                </li>

                <li class="about-item" data-reveal="left">
                  <ion-icon name="checkmark-circle-outline"></ion-icon>

                  <span class="span">我祝福你早日康复与健康。</span>
                </li>

                <li class="about-item" data-reveal="left">
                  <ion-icon name="checkmark-circle-outline"></ion-icon>

                  <span class="span">让阳光继续照耀你的脸庞</span>
                </li>

                <li class="about-item" data-reveal="left">
                  <ion-icon name="checkmark-circle-outline"></ion-icon>

                  <span class="span">在微笑中度过每个明天。</span>
                </li>

              </ul>

            </div>

          </div>

          <figure class="about-banner" data-reveal="right">
            <img src="../../assets/images/about-banner.png" width="554" height="678" loading="lazy" alt="about banner"
              class="w-100">
          </figure>

        </div>
      </section>






      <!-- 
        - #LISTING
      -->

      <section class="section listing" aria-labelledby="listing-label">
        <div class="container">

          <ul class="grid-list">

            <li>
              <p class="section-subtitle title-lg" id="listing-label" data-reveal="left">医生团队</p>

              <h2 class="headline-md" data-reveal="left">最为专业的医生团队</h2>
            </li>

            <li>
              <div class="listing-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-1.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <div>
                  <h3 class="headline-sm card-title">精神病科</h3>

                  <p class="card-text">陈述医生</p>
                </div>

              </div>
            </li>

            <li>
              <div class="listing-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-2.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <div>
                  <h3 class="headline-sm card-title">妇科</h3>

                  <p class="card-text">王淼淼医生</p>
                </div>

              </div>
            </li>

            <li>
              <div class="listing-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-4.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <div>
                  <h3 class="headline-sm card-title">肺病科</h3>

                  <p class="card-text">张毅医生</p>
                </div>

              </div>
            </li>

            <li>
              <div class="listing-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-5.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <div>
                  <h3 class="headline-sm card-title">骨科</h3>

                  <p class="card-text">孙择斯医生</p>
                </div>

              </div>
            </li>

            <li>
              <div class="listing-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-6.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <div>
                  <h3 class="headline-sm card-title">儿科</h3>

                  <p class="card-text">王忝医生</p>
                </div>

              </div>
            </li>

            <li>
              <div class="listing-card" data-reveal="bottom">

                <div class="card-icon">
                  <img src="../../assets/images/icon-7.png" width="71" height="71" loading="lazy" alt="icon">
                </div>

                <div>
                  <h3 class="headline-sm card-title">流感</h3>

                  <p class="card-text">李留医生</p>
                </div>

              </div>
            </li>

          </ul>

        </div>
      </section>





      <!-- 
        - #BLOG
      -->

      <section class="section blog" aria-labelledby="blog-label">
        <div class="container">

          <p class="section-subtitle title-lg text-center" id="blog-label" data-reveal="bottom">
            新闻 & 文章
          </p>

          <h2 class="section-title headline-md text-center" data-reveal="bottom">最新文章</h2>

          <ul class="grid-list">

            <li>
              <div class="blog-card has-before has-after" data-reveal="bottom">

                <div class="meta-wrapper">

                  <div class="card-meta">
                    <ion-icon name="person-outline"></ion-icon>

                    <span class="span">李留</span>
                  </div>

                  <div class="card-meta">
                    <ion-icon name="folder-outline"></ion-icon>

                    <span class="span">专家组</span>
                  </div>

                </div>

                <h3 class="headline-sm card-title">如何有效预防流感</h3>

                <time class="title-sm date" datetime="2022-01-28">11月3日, 2022</time>

                <p class="card-text">
                  预防流感的最佳方法是接种流感疫苗，这可以帮助身体建立免疫力，预防感染。此外，保持良好的个人卫生习惯，如勤洗手、避免接触病毒和在公共场合戴口罩等，也可以有效预防感染。

如果您患有流感，请及时就医并遵循医生的建议进行治疗。
                </p>

                <a href="#" class="btn-text title-lg">更多...</a>

              </div>
            </li>

            <li>
              <div class="blog-card has-before has-after" data-reveal="bottom">

                <div class="meta-wrapper">

                  <div class="card-meta">
                    <ion-icon name="person-outline"></ion-icon>

                    <span class="span">李医生</span>
                  </div>

                  <div class="card-meta">
                    <ion-icon name="folder-outline"></ion-icon>

                    <span class="span">专家组</span>
                  </div>

                </div>

                <h3 class="headline-sm card-title">体检应该重视起来</h3>

                <time class="title-sm date" datetime="2022-01-28">12月5日, 2022</time>

                <p class="card-text">
                  体检是指通过一系列的检查和测试，了解个人的身体状况、发现疾病和疾病的早期征兆，为保持身体健康和预防疾病提供重要的信息和建议。定期进行体检是非常重要的。
                  体检可以帮助我们及早发现潜在的健康问题，通过调整饮食和生活方式，以及及时进行治疗来预防疾病的发生。
                </p>

                <a href="#" class="btn-text title-lg">更多...</a>

              </div>
            </li>

            <li>
              <div class="blog-card has-before has-after" data-reveal="bottom">

                <div class="meta-wrapper">

                  <div class="card-meta">
                    <ion-icon name="person-outline"></ion-icon>

                    <span class="span">张三</span>
                  </div>

                  <div class="card-meta">
                    <ion-icon name="folder-outline"></ion-icon>

                    <span class="span">朋友</span>
                  </div>

                </div>

                <h3 class="headline-sm card-title">如何提高免疫力</h3>

                <time class="title-sm date" datetime="2022-01-28">4月3日, 2023</time>

                <p class="card-text">
                  拥有一个强大的免疫系统对于我们的身体健康至关重要。
                  <br>健康饮食：饮食对于免疫系统的功能非常重要。<br>
                  足够睡眠：睡眠对于免疫系统的功能也至关重要。<br>
                  .....
      
                </p>

                <a href="#" class="btn-text title-lg">更多...</a>

              </div>
            </li>

          </ul>

        </div>
      </section>

    </article>
  </main>
   <!-- 
    - #BACK TO TOP
  -->
 
  <a href="#top"  name="arrow-up-outline" aria-hidden="true"  class="back-top-btn" aria-label="back to top" data-back-top-btn>
    <ArrowUpBold  style="width: 1em; height: 1em; margin-right: 1px ;    border-radius:50%"  />
  </a>

</template>


<style lang='scss' scoped>
/*-----------------------------------*\
  #main.css
\*-----------------------------------*/

/**
 * copyright 2022 codewithsadee
 */



/*-----------------------------------*\
  #CUSTOM PROPERTY
\*-----------------------------------*/






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
time,
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

input {
width: 100%;
outline: none;
}

button { cursor: pointer; }

ion-icon { pointer-events: none; }

address { font-style: normal; }

html {
font-size: 10px;
font-family:  'Rubik', sans-serif;;
scroll-behavior: smooth;
}

body {
background-color: white;
font-size: 1.6rem;
color: hsl(236, 14%, 39%);
line-height: 1.8;
overflow: hidden;
}

body.loaded { overflow-y: visible; }

body.nav-active { overflow: hidden; }





/*-----------------------------------*\
#REUSED STYLE
\*-----------------------------------*/

.container { padding-inline: 16px; }

.headline-lg {
font-size: 5rem;
color: white;
font-weight:  500;
line-height: 1.2;
}

.headline-md {
font-size:  5rem;
font-weight: 700;
}

.headline-lg,
.headline-md { font-family: 'Oswald', sans-serif; }

.headline-md,
.headline-sm { line-height: 1.3; }

.headline-md,
.headline-sm { color: var(--midnight-green); }

.headline-sm { font-size: 2rem; }

.title-lg { font-size: 1.8rem; }

.title-md { font-size: 1.5rem; }

.title-sm { font-size: 1.4rem; }

.social-list { display: flex; }

.section { padding-block: 120px; }

.has-before,
.has-after {
position: relative;
z-index: 1;
}

.has-before::before,
.has-after::after {
content: "";
position: absolute;
}

.btn {
background-color:  hsl(182, 100%, 35%);
color: white;
font-weight: 700;
padding: 12px 36px;
display: flex;
align-items: center;
gap: 8px;
border-radius: 6px;
overflow: hidden;
}

.btn::before {
top: 0;
left: -100%;
width: 100%;
height: 100%;
background-color:  hsl(0, 0%, 13%);;
border-radius: 6px;
transition: 0.5s ease;
z-index: -1;
}

.btn:is(:hover, :focus-visible)::before { transform: translateX(100%); }

.w-100 { width: 100%; }

.grid-list {
display: grid;
gap: 40px 28px;
}

.text-center { text-align: center; }

[data-reveal] {
opacity: 0;
transition: 0.5s ease;
}

[data-reveal].revealed { opacity: 1; }

[data-reveal="bottom"] { transform: translateY(50px); }

[data-reveal="bottom"].revealed { transform: translateY(0); }

[data-reveal="left"] { transform: translateX(-50px); }

[data-reveal="right"] { transform: translateX(50px); }

[data-reveal="left"].revealed,
[data-reveal="right"].revealed { transform: translateX(0); }





/*-----------------------------------*\
#PRELOADER
\*-----------------------------------*/

.preloader {
position: fixed;
top: 0;
left: 0;
width: 100%;
height: 100vh;

display: grid;
place-items: center;

transition: 0.25s ease;
}

.preloader.loaded {
visibility: hidden;
opacity: 0;
}

.preloader .circle {
width: 50px;
height: 50px;
border: 4px solid white;
border-radius: 50%;
border-block-start-color: transparent;
animation: rotate360 1s ease infinite;
}

@keyframes rotate360 {
0% { transform: rotate(0); }
100% { transform: rotate(1turn); }
}





/*-----------------------------------*\
#HEADER
\*-----------------------------------*/

.has-bg-image {
background-repeat: no-repeat;
background-position: center;
background-size: cover;
background-image: url(../../assets/images/hero-bg.png)
}
.header .btn { display: none; }

.header {
position: absolute;
top: 0;
left: 0;
width: 100%;
padding-block: 16px;
z-index: 4;
background: rgba(23, 28, 38, 0.2);
}

.header.active {
position: fixed;
animation: headerActive 0.5s ease forwards;
}

@keyframes headerActive {
0% { transform: translateY(-100%); }
100% { transform: translateY(0); }
}

.header .container {
display: flex;
justify-content: space-between;
align-items: center;
}

.nav-open-btn {
color: white;
font-size: 4rem;
}

.navbar,
.overlay {
position: fixed;
top: 0;
width: 100%;
height: 100vh;
}

.navbar {
right: -300px;
max-width: 300px;

z-index: 3;
transition: 0.25s cubic-bezier(0.51, 0.03, 0.64, 0.28);
visibility: hidden;
}

.navbar.active {
transform: translateX(-300px);
visibility: visible;
transition: 0.5s  cubic-bezier(0.05, 0.83, 0.52, 0.97);
}

.navbar-top {
position: relative;
padding-inline: 25px;
padding-block: 55px 100px;
}

.nav-close-btn {
position: absolute;
top: 15px;
right: 20px;
color: white;
font-size: 2.8rem;
}

.navbar-list {
margin-block-end: 30px;
border-block-end: 1px solid hsla(0, 0%, 100%, 0.1);
}

.navbar-item { border-block-start: 1px solid hsla(0, 0%, 100%, 0.1); }

.navbar-link {
color: white;
text-transform: uppercase;
padding: 10px 24px;
}

.social-list {
justify-content: center;
gap: 20px;
color: white;
font-size: 1.8rem;
}

.overlay {
right: -100%;
background-color: black;
opacity: 0.3;
visibility: hidden;
transition: 0.5s ease;
z-index: 2;
}

.overlay.active {
transform: translateX(-100%);
visibility: visible;
}





/*-----------------------------------*\
#HERO
\*-----------------------------------*/

.hero-banner { display: none; }

.hero {
background-color:rgb(47, 84, 120);
--section-padding: 200px;
background-repeat: no-repeat;
background-size: cover;
}

.hero-subtitle {
color: white;
font-weight: 500;
padding-inline-start: 80px;
}

.hero-subtitle::before {
top: 50%;
left: 0;
width: 60px;
height: 1px;
background-color: white;
}

.hero-title { margin-block: 20px 30px; }

.hero-card {
background-color: white;
border-radius: 12px;
padding: 20px;
}

.hero-card .card-text {
color:  hsl(0, 0%, 13%);;
border-block-end: 1px solid  hsla(174, 64%, 71%, 0.4);
padding-block-end: 12px;
margin-block-end: 14px;
}

.hero-card .input-wrapper { position: relative; }

.hero-card .input-field {
color:  hsl(0, 0%, 13%);;
border-block-end: 1px solid  hsl(0, 0%, 87%);
padding-inline-end: 18px;
}

.hero-card .input-wrapper ion-icon {
position: absolute;
top: 50%;
right: 0;
transform: translateY(-50%);
color:  hsl(182, 100%, 35%);
}

.hero-card .btn {
width: 100%;
justify-content: center;
margin-block-start: 16px;
}





/*-----------------------------------*\
#SERVICE
\*-----------------------------------*/

.service-list {
padding-block: 60px 30px;
padding-inline: 25px;
display: grid;
gap: 30px;
border-radius: 12px;;
margin-block-start: -60px;
background-color: white;
box-shadow: 3px 29px 30px #151214;
}

.service-card { text-align: center; }

.service-card .card-icon,
.btn-circle {
max-width: max-content;
margin-inline: auto;
}

.service-card .card-icon { margin-block-end: 25px; }

.service-card .card-text { margin-block: 20px 15px; }

.service-card .btn-circle {
color: hsl(182, 100%, 35%);
font-size: 2rem;
padding: 18px;
border-radius: 50%;
box-shadow: 0 7px 16px rgb(121, 148, 169);
transition: 0.25s ease;
background-color: rgb(206, 218, 221)
}

.service-card .btn-circle:is(:hover, :focus-visible) {
background-color:  hsl(182, 100%, 35%);
color: white;
}





/*-----------------------------------*\
#ABOUT
\*-----------------------------------*/

.about { padding-block-end: 0; }

.about .container {
display: grid;
gap: 20px;
}

.about .section-text { margin-block: 20px 35px; }

.tab-list {
display: flex;
flex-wrap: wrap;
gap: 20px 15px;
}

.tab-btn {
background-color: hsl(187, 25%, 94%);
color: var(--midnight-green);
padding: 7px 30px;
border-radius: 6px;
font-weight: 700;
}

.tab-btn.active {
background-color:  hsl(182, 100%, 35%);
color: white;
}

.tab-text {
color: var(--midnight-green);
margin-block: 35px;
}

.about-item {
display: flex;
align-items: center;
gap: 10px;
margin-block-end: 10px;
}

.about-item ion-icon {
color:  hsl(182, 100%, 35%);
font-size: 2rem;
flex-shrink: 0;
}





/*-----------------------------------*\
#LISTING
\*-----------------------------------*/


.listing-card {
padding: 25px 16px;
display: flex;
gap: 20px;
border: 4px solid hsla(159, 33%, 66%, 0.4);
border-radius: 12px;
transition: 0.25s ease;
}

.listing-card:is(:hover, :focus-visible) { border-color:  hsl(182, 100%, 35%); }

.listing-card .card-title {
margin-block-end: 5px;
font-family: 'Oswald', sans-serif;
}

.listing-card .card-text { color: var(--midnight-green); }





/*-----------------------------------*\
#BLOG
\*-----------------------------------*/

.blog {
background-image: linear-gradient(to bottom, hsl(216, 38%, 54%) 60%, rgb(62, 93, 123) 60%);
padding-block-start: 0;
}

.blog .section-title { margin-block-end: 60px; }

.blog-card {
padding: 50px 36px;
border-radius: 12px;
border: 2px solid hsl(187, 25%, 94%);
background-image: url('../../assets/images/blog-card.jpg');
background-repeat: no-repeat;
background-position: center;
background-size: cover;
overflow: hidden;
}

.blog-card::before,
.blog-card::after {
inset: 0;
z-index: -1;
transition: 1s ease;
}

.blog-card::before {
background-color: var(--midnight-green);
opacity: 0.9;
}

.blog-card::after { background-color: white; }

.blog-card:is(:hover, :focus-within)::after { transform: translateY(100%); }

.blog-card .meta-wrapper {
display: flex;
flex-wrap: wrap;
gap: 5px 20px;
margin-block-end: 12px;
}

.blog-card .card-meta {
display: flex;
align-items: center;
gap: 5px;
color: var(--midnight-green);
}

.blog-card .card-meta ion-icon { font-size: 1.8rem; }

.blog-card .card-meta:first-child .span { text-transform: uppercase; }

.blog-card .date {
color: hsla(226, 45%, 24%);
font-weight: 700;
text-transform: uppercase;
opacity: 0.5;
margin-block: 16px;
}

.blog-card .btn-text {
color:  hsl(182, 100%, 35%);
margin-block-start: 12px;
}

.blog-card :is(.card-meta, .card-title, .date, .card-text, .btn-text) {
transition: 0.5s ease;
}

.blog-card:is(:hover, :focus-within) :is(.card-meta, .card-title, .date, .card-text, .btn-text) {
color: white;
}



/*-----------------------------------*\
#BACK TO TOP
\*-----------------------------------*/

.back-top-btn {
position: fixed;
bottom: 30px;
right: 30px;
background-color:  hsl(182, 100%, 35%);
color: white;
padding: 16px;
font-size: 2rem;
border-radius: 50%;
transition: 0.25s ease;
opacity: 0;
z-index: 3;
background: red;
}

.back-top-btn:is(:hover, :focus-visible) { background-color:  hsl(0, 0%, 13%);; }

.back-top-btn.active {
transform: translateY(-10px);
opacity: 1;
}





/*-----------------------------------*\
#MEDIA QUERIES
\*-----------------------------------*/

/**
* responsive for large than 768px screen
*/

@media (min-width: 768px) {

/**
 * CUSTOM PROPERTY
 */

:root {

  /**
   * typography
   */

  --headline-lg: 8rem;
  --headline-md: 4.8rem;

}



/**
 * REUSED STYLE
 */

.container {
  max-width: 750px;
  width: 100%;
  margin-inline: auto;
}



/**
 * HEADER
 */

.header .btn { display: block; }

.nav-open-btn { margin-inline-start: auto; }

.header .container { gap: 40px; }



/**
 * HERO
 */

.hero-title { line-height: 1.125; }

.hero .wrapper {
  display: flex;
  gap: 16px;
}

.hero-card .input-wrapper { flex-grow: 1; }

.hero-card .input-field { height: 100%; }

.hero-card .btn {
  width: max-content;
  margin-block-start: 0;
}



/**
 * SERVICE
 */

.service-list { grid-template-columns: 1fr 1fr; }



/**
 * ABOUT
 */

.about-list {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
}

.about-banner {
  max-width: max-content;
  margin-inline: auto;
}



/**
 * LISTING
 */

.listing .grid-list { grid-template-columns: 1fr 1fr; }

.listing .grid-list > li:first-child { grid-column: 1 / 3; }

}



/**
* responsive for large than 992px screen
*/

@media (min-width: 992px) {

/**
 * REUSED STYLE
 */

.container { max-width: 940px; }



/**
 * HERO
 */

.hero-banner {
  display: block;
  max-width: max-content;
}

.hero .container {
  display: grid;
  grid-template-columns: 1fr 1fr;
  align-items: center;
}



/**
 * SERVICE
 */

.service-list { grid-template-columns: repeat(4, 1fr); }



/**
 * ABOUT
 */

.about .container {
  grid-template-columns: 1fr 0.8fr;
  align-items: flex-end;
}

.about-content { padding-block-end: 120px; }

.about-banner { margin-inline-end: -80px; }



/**
 * BLOG
 */

.blog .grid-list { grid-template-columns: 1fr 1fr; }

}





/**
* responsive for large than 1200px screen
*/

@media (min-width: 1200px) {

/**
 * REUSED STYLE
 */

.container { max-width: 1200px; }



/**
 * HEADER
 */

.header { padding-block: 24px; }

.nav-open-btn,
.overlay,
.navbar-top,
.navbar .social-list { display: none; }

.navbar,
.navbar.active,
.navbar-list {
  all: unset;
  display: block;
}

.navbar { margin-inline-start: auto; }

.navbar-list {
  display: flex;
  gap: 8px;
}

.navbar-item { border-block-start: none; }

.navbar-link {
  --title-md: 1.8rem;
  font-weight: 500;
  padding-inline: 16px;
  text-transform: capitalize;
}



/**
 * HERO
 */

.hero .container {
  grid-template-columns: 0.8fr 1fr;
  gap: 96px;
}



/**
 * LISTING
 */

.listing .grid-list { grid-template-columns: repeat(4, 1fr); }



/**
 * BLOG
 */

.blog .grid-list { grid-template-columns: repeat(3, 1fr); }


}
 
::v-deep.el-icon svg {
    
    color: white;
}
</style>