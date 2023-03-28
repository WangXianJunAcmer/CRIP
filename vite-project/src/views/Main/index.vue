

<template>
  <!-- 
    - #HEADER
  -->

  <header class="header" data-header>
    <div class="container">

      <a href="#" class="logo">
        <img src="../../assets/images/智慧医疗.svg" width="60" height="50" alt=" home">
      </a>
    
      <h1>医者行天下</h1>
      <nav class="navbar" data-navbar>
        <ul class="navbar-list">

          <li class="navbar-item">
            <a href="#home" class="navbar-link" data-nav-link>首页</a>
          </li>

          <li class="navbar-item">
            <a href="#about" class="navbar-link" data-nav-link>关于</a>
          </li>

          <li class="navbar-item">
            <a href="#measures" class="navbar-link" data-nav-link>预约挂号</a>
          </li>
          <li class="navbar-item">
            <a href="#doctor" class="navbar-link" data-nav-link>在线就医</a>
          </li>

          <li class="navbar-item">
            <a href="#blog" class="navbar-link" data-nav-link>用户交流社区</a>
          </li>

          <li class="navbar-item">
            <a href="#drugshop" class="navbar-link" data-nav-link>药物购买</a>
          </li>

          <li class="navbar-item">
            <a href="#contact" class="navbar-link" data-nav-link>联系我们</a>
          </li>

        </ul>
      </nav>

      <button class="nav-toggle-btn" aria-label="toggle menu" data-nav-toggler>
        <ion-icon name="menu-outline" aria-hidden="true" class="menu"></ion-icon>
        <ion-icon name="close-outline" aria-hidden="true" class="close"></ion-icon>
      </button>
     <RouterLink  to="/login" class="btn btn-primary"
 style="text-decoration:none; color: white;" >
 点击登录
</RouterLink>




    </div>
  </header>





  <main>
    <article>

      <!-- 
        - #HERO
      -->

      <section class="section hero has-bg-image" id="home" 
aria-label="home">
        <div class="container">

          <div class="hero-content">

            <h1 class="h1 hero-title">新冠肺炎感染人数</h1>

            <p class="hero-text">
        全球统计
            </p>

            <data class="counter" value="960708">960708</data>

            <ul class="hero-list">

              <li class="hero-list-item yellow">
              现有人数 <span class="span">799571</span>
              </li>

              <li class="hero-list-item green">
                康复人数 <span class="span">302826</span>
              </li>

              <li class="hero-list-item red">
                死亡人数 <span class="span">52558</span>
              </li>

            </ul>

            <a href="#" class="btn btn-primary">看医生</a>

          </div>

          <figure class="hero-banner">

            <div ref="chartContainer" style="width: 100%; height: 500px;"></div>
           
          </figure>

        </div>
      </section>





      <!-- 
        - #关于
      -->

      <section class="section about" id="about" aria-labelledby="about-label-1">
        <div class="container">

          <figure class="hero-banner">

             <img src="../../assets/images/hero-banner.png" width="400" height="400" alt="corona virus" class="w-100">
          </figure>

          <div class="about-content">

            <p class="about-subtitle" id="about-label-1">新型冠状病毒</p>

            <h2 class="h2 section-title">新冠简介</h2>

            <p class="section-text text">
              新型冠状病毒，是指先前尚未在人类中发现的冠状病毒，由这一病毒导致的疾病正式命名为2019冠状病毒病（Corona Virus Disease 2019,COVID-19）。
            </p>

            <ul class="about-list">

              <li class="about-item">
                <figure class="item-img img-holder" style="--width: 80; --height: 80;">
                  <img src="../../assets/imagesabout-1-1.jpg" width="80" height="80" loading="lazy" alt="Human Contact">
                </figure>

                <div class="item-content">
                  <h3 class="h4 item-title">传播方式</h3>

                  <p class="item-text text">
                    新型冠状病毒是通过呼吸道飞沫和接触等方式进行传播。而最为我们所知的病例多可以追踪到与确诊的病例有过近距离密切接触的情况。
                  </p>
                </div>
              </li>

              <li class="about-item">
                <figure class="item-img img-holder" style="--width: 80; --height: 80;">
                  <img src="../../assets/imagesabout-1-2.jpg" width="80" height="80" loading="lazy" alt="Air Transmission">
                </figure>

                <div class="item-content">
                  <h3 class="h4 item-title">易感人群</h3>

                  <p class="item-text text">
                  各个年龄段的人都可能被感染，被感染的主要是成年人，其中老年人和体弱多病的人似乎更容易被感染。
儿童和孕产妇是新型冠状病毒感染的肺炎的易感染人群。
                  </p>
                </div>
              </li>

              <li class="about-item">
                <figure class="item-img img-holder" style="--width: 80; --height: 80;">
                  <img src="../../assets/imagesabout-1-3.jpg" width="80" height="80" loading="lazy"
                    alt="Contaminated Objects">
                </figure>

                <div class="item-content">
                  <h3 class="h4 item-title">主要症状</h3>

                  <p class="item-text text">
                    病毒感染者会出现程度不同的症状，有的只是发烧或轻微咳嗽，有的会发展为肺炎，有的则更为严重甚至死亡。新冠肺炎的症状主要是干咳、发烧、乏力为主。</p>
                </div>
              </li>

            </ul>

          </div>

        </div>
      </section>












  
   <!-- 
        - #医生
      -->

      <section class="section doctor has-doctbg" id="doctor" 
        aria-labelledby="doctor-label">
        <div class="container">

          <h2 class="h2 section-title" id="doctor-label">问医生</h2>

          <p class="section-text text">
     
          </p>

          <ul class="grid-list">

            <li>
              <div class="doctor-card">

                <figure class="card-banner img-holder" style="--width: 350; --height: 360;">
                  <img src="../../assets/images/1v1专属服务.png" width="350" height="360" loading="lazy"
                    alt="Dorothy M. Nickell profile" class="img-cover">
                </figure>

                 <div class="card-content">
                  <h3 class="h4 card-title">秒问专家</h3>

                  <p class="card-text text">专家急速接诊</p>

             
                </div>

              </div>
            </li>

            <li>
              <div class="doctor-card">

                <figure class="card-banner img-holder" style="--width: 350; --height: 360;">
                  <img src="../../assets/images/专家问诊.png" width="350" height="360" loading="lazy"
                    alt="Billie R. Courtney profile" class="img-cover">
                </figure>

                <div class="card-content">

                  <h3 class="h4 card-title">专家问诊</h3>

                  <p class="card-text text">全国知名良医</p>

             
                </div>
              </div>
            </li>

            <li>
              <div class="doctor-card">

                <figure class="card-banner img-holder" style="--width: 350; --height: 360;">
                  <img src="../../assets/images/用药咨询.png" width="350" height="360" loading="lazy"
                    alt="Courtney A. Smith profile" class="img-cover">
                </figure>

                <div class="card-content">
                  <h3 class="h4 card-title">用药咨询</h3>

                  <p class="card-text text">药师指南用药</p>
             
                </div>

              </div>
            </li>

          </ul>

        </div>
      </section>



      <!-- 
        - #论坛
      -->

      <section class="section blog" id="blog" aria-labelledby="blog-lable">
        <div class="container">

          <h2 class="h2 section-title" id="blog-label">Our Most Popular Blog</h2>

          <p class="section-text text">
            Dynamically formulate fully tested catalysts for change via focused methods of empowerment Assertively
            extend
            alternative synergy and extensive web services.
          </p>

          <ul class="grid-list">

            <li>
              <div class="blog-card">

                <figure class="card-banner img-holder" style="--width: 370; --height: 280;">
                  <img src="../../assets/images/blog-1.jpg" width="370" height="280" loading="lazy"
                    alt="Conulting Reporting Qouncil Arei Not Could More..." class="img-cover">
                </figure>

                <div class="card-content">

                  <h3 class="h4">
                    <a href="#" class="card-title">
                      Conulting Reporting Qouncil Arei Not Could More...
                    </a>
                  </h3>

                  <div class="card-meta">

                    <div class="wrapper">
                      <ion-icon name="calendar-outline" aria-hidden="true"></ion-icon>

                      <time class="meta-text" datetime="2022-07-12">July 12, 2022</time>
                    </div>

                    <div class="wrapper">
                      <ion-icon name="person-outline" aria-hidden="true"></ion-icon>

                      <p class="meta-text">John Doe</p>
                    </div>

                  </div>

                  <p class="card-text text">
                    Pluoresntly customize pranci an plcentered customer service anding strategic amerials Interacvely
                    cordinate performe
                  </p>

                </div>

                <div class="card-footer">
                  <a href="#" class="btn-link">Read More</a>
                </div>

              </div>
            </li>

            <li>
              <div class="blog-card">

                <figure class="card-banner img-holder" style="--width: 370; --height: 280;">
                  <img src="../../assets/images/blog-2.jpg" width="370" height="280" loading="lazy"
                    alt="Financial Reporting Qouncil What Could More..." class="img-cover">
                </figure>

                <div class="card-content">

                  <h3 class="h4">
                    <a href="#" class="card-title">
                      Financial Reporting Qouncil What Could More...
                    </a>
                  </h3>

                  <div class="card-meta">

                    <div class="wrapper">
                      <ion-icon name="calendar-outline" aria-hidden="true"></ion-icon>

                      <time class="meta-text" datetime="2022-07-12">July 12, 2022</time>
                    </div>

                    <div class="wrapper">
                      <ion-icon name="person-outline" aria-hidden="true"></ion-icon>

                      <p class="meta-text">John Doe</p>
                    </div>

                  </div>

                  <p class="card-text text">
                    Pluoresntly customize pranci an plcentered customer service anding strategic amerials Interacvely
                    cordinate performe
                  </p>

                </div>

                <div class="card-footer">
                  <a href="#" class="btn-link">Read More</a>
                </div>

              </div>
            </li>

            <li>
              <div class="blog-card">

                <figure class="card-banner img-holder" style="--width: 370; --height: 280;">
                  <img src="../../assets/images/blog-3.jpg" width="370" height="280" loading="lazy"
                    alt="Consulting Reporting Qounc Arei Could More..." class="img-cover">
                </figure>

                <div class="card-content">

                  <h3 class="h4">
                    <a href="#" class="card-title">
                      Consulting Reporting Qounc Arei Could More...
                    </a>
                  </h3>

                  <div class="card-meta">

                    <div class="wrapper">
                      <ion-icon name="calendar-outline" aria-hidden="true"></ion-icon>

                      <time class="meta-text" datetime="2022-07-12">July 12, 2022</time>
                    </div>

                    <div class="wrapper">
                      <ion-icon name="person-outline" aria-hidden="true"></ion-icon>

                      <p class="meta-text">John Doe</p>
                    </div>

                  </div>

                  <p class="card-text text">
                    Pluoresntly customize pranci an plcentered customer service anding strategic amerials Interacvely
                    cordinate performe
                  </p>

                </div>

                <div class="card-footer">
                  <a href="#" class="btn-link">Read More</a>
                </div>

              </div>
            </li>

          </ul>

        </div>
      </section>

    </article>
  </main>







  <!-- 
    - #FOOTER
  -->

  <footer class="footer has-bg-image"  id="contact" style="background-image: url('../.../../assets/images/footer-bg.jpg')">
    <div class="container">

  
      <div class="footer-bottom">
        <p class="copyright">
          &copy; 2020 All Rights Reserved. Developed by codewithsadee
        </p>
      </div>

    </div>
  </footer>





  <!-- 
    - #BACK TO TOP
  -->

  <a href="#top" class="back-top-btn" aria-label="back to top" data-back-top-btn>
    <ion-icon name="arrow-up-outline" aria-hidden="true"></ion-icon>
  </a>





  <!-- 
    - custom js link
  -->
</template>






<script setup lang='ts'>
import { onMounted, Ref, ref } from 'vue';
import * as echarts from 'echarts';
import 'echarts/lib/chart/bar';
import 'echarts/lib/component/tooltip';
import 'echarts/lib/component/title';
import 'echarts/lib/component/legend';
import 'echarts/lib/component/toolbox';


const drawChart = (container: HTMLElement) => {
  const chart = echarts.init(container);
   // 模拟数据
   const fluData = [1000, 1200, 1500, 1800, 2000, 2300, 2800, 3500, 4200, 5000, 6000, 8000];
      const covidData = [9000, 50, 200, 1000, 3000, 8000, 15000, 18000, 20000, 18000, 15000, 12000];
  const option = {
    title: {
      text: '每月流感和新冠病例数',
      left: 'center',
    },
    tooltip: {
      trigger: 'axis',
    },
    legend: {
          data: ['流感', '新冠'],
          top: 'bottom',
        },
        xAxis: {
          type: 'category',
          data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
         
            
        },
        yAxis: {
          type: 'value',
          splitLine: {
            lineStyle: {
              type: 'dashed',
            },
          },
        },
        series: [
          {
            name: '流感',
            type: 'line',
            data: fluData,
            color: 'blue',
          },
          {
            name: '新冠',
            type: 'line',
            data: covidData,
            color: 'red',
          },
        ],
      };
  chart.setOption(option);
};

const chartContainer: Ref<HTMLElement | null> = ref(null);

onMounted(() => {
  const container = chartContainer.value!;
  drawChart(container);
});



/**
 * add event on element
 */

 const addEventOnElem = function (elem: HTMLElement | NodeList, type: string, callback: EventListenerOrEventListenerObject) {
  if (elem instanceof NodeList) {
    for (let i = 0; i < elem.length; i++) {
      elem[i].addEventListener(type, callback);
    }
  } else {
    elem.addEventListener(type, callback);
  }
}


</script>





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
 * colors
 */

--medium-spring-green: hsl(156, 100%, 50%);
--red-orange-creyola: hsl(0, 100%, 68%);
--caribbean-green: hsl(160, 98%, 39%);
--oxford-blue_50: hsla(222, 47%, 11%, 1);
--oxford-blue_70: hsla(213, 86%, 16%, 0.7);
--prussian-blue: hsl(210, 100%, 20%);
--oxford-blue: hsl(213, 86%, 16%);
--orange-peel: hsl(37, 100%, 50%);
--cultured_20: hsla(206, 23%, 94%, 0.2);
--winter-sky: hsl(341, 100%, 60%);
--light-gray: hsl(0, 0%, 80%);
--malachite: hsl(120, 70%, 59%);
--indigo-dye: hsl(213, 81%, 25%);
--dim-gray: hsl(0, 0%, 41%);
--black_20: hsla(0, 0%, 0%, 0.2);
--silver: hsl(0, 0%, 76%);
--black: hsl(0, 0%, 0%);
--white: hsl(0, 0%, 100%);

/**
 * typography
 */

--ff-roboto: "Roboto", sans-serif;

--fs-1: 3rem;
--fs-2: 2.4rem;
--fs-3: 2rem;
--fs-4: 1.8rem;
--fs-5: 1.5rem;
--fs-6: 1.4rem;

--fw-500: 500;
--fw-700: 700;

/**
 * spacing
 */

--section-padding: 100px;

/**
 * shadow
 */

--shadow-1: 0 0 10px hsla(0, 0%, 0%, 0.1);
--shadow-2: 0 5px 10px hsla(0, 0%, 100%, 0.2);
--shadow-3: 0 0 24px hsla(341, 100%, 60%, 0.3);

/**
 * border radius
 */

--radius-circle: 50%;
--radius-pill: 200px;
--radius-6: 6px;

/**
 * transition
 */

--transition-1: 0.25s ease;
--transition-2: 0.5s ease;
--cubic-out: cubic-bezier(0.33, 0.85, 0.4, 0.96);

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
button,
ion-icon { display: block; }

a {
color: inherit;
text-decoration: none;
}

img { height: auto; }

button {
background: none;
border: none;
font: inherit;
cursor: pointer;
}

ion-icon { pointer-events: none; }

address { font-style: normal; }

html {
font-family: var(--ff-roboto);
font-size: 10px;
scroll-behavior: smooth;
}

body {
background-color: var(--oxford-blue);
color: var(--white);
font-size: 1.6rem;
line-height: 1.5;
overflow-x: hidden;
}

body.active { overflow-y: hidden; }

:focus-visible { outline-offset: 4px; }

::-webkit-scrollbar { width: 10px; }

::-webkit-scrollbar-track { background-color: hsl(0, 0%, 98%); }

::-webkit-scrollbar-thumb { background-color: hsl(0, 0%, 80%); }

::-webkit-scrollbar-thumb:hover { background-color: hsl(0, 0%, 70%); }





/*-----------------------------------*\
#REUSED STYLE
\*-----------------------------------*/

.container { padding-inline: 15px; }

.section { padding-block: var(--section-padding); }

.has-bg-image {
background-repeat: no-repeat;
background-position: center;
background-size: cover;
background-image: url(../../assets/images/hero-bg.png)
}

.h1,
.h2,
.h3,
.h4 { line-height: 1.4; }

.h1 { font-size: var(--fs-2); }

.h4 { font-size: var(--fs-4); }

.btn {
font-size: var(--fs-6);
font-weight: var(--fw-700);
text-transform: uppercase;
max-width: max-content;
border: 2px solid var(--white);
padding: 18px 25px;
border-radius: var(--radius-pill);
transition: var(--transition-1);
}

.btn-primary:is(:hover, :focus) { box-shadow: var(--shadow-2); }

.w-100 { width: 80%; }

.text { font-size: var(--fs-5); }

.img-holder {
aspect-ratio: var(--width) / var(--height);
background-color: var(--light-gray);
overflow: hidden;
}

.section-text { margin-block: 15px 35px; }

.grid-list {
display: grid;
gap: 30px;
}

.img-cover {
width: 100%;
height: 100%;
object-fit: cover;
transition: var(--transition-2);
}





/*-----------------------------------*\
#HEADER
\*-----------------------------------*/

.header .btn { display: none; }

.header {
background-color: var(--oxford-blue);
position: absolute;
top: 0;
left: 0;
width: 100%;
padding-block: 12px;
box-shadow: var(--shadow-1);
z-index: 4;
}

.header.active {
position: fixed;
animation: slideInTop 0.5s ease forwards;
}

@keyframes slideInTop {
0% { transform: translateY(-100%); }
100% { transform: translateY(0); }
}

.header .container {
display: flex;
justify-content: space-between;
align-items: center;
}

.nav-toggle-btn {
color: var(--white);
font-size: 35px;
}

.nav-toggle-btn.active .menu,
.nav-toggle-btn .close { display: none; }

.nav-toggle-btn .menu,
.nav-toggle-btn.active .close { display: block; }

.navbar {
position: absolute;
top: 74px;
left: -350px;
width: 100%;
max-width: 350px;
height: 100vh;
background-color: var(--oxford-blue);
padding: 20px;
transition: 0.25s var(--cubic-out);
visibility: hidden;
}

.navbar.active {
visibility: visible;
transform: translateX(350px);
transition-duration: 0.5s;
}

.navbar-item:not(:last-child) { border-block-end: 1px solid var(--black_20); }

.navbar-link {
padding-block: 10px;
transition: var(--transition-1);
}

.navbar-link:is(:hover, :focus) { color: var(--winter-sky); }





/*-----------------------------------*\
#HERO
\*-----------------------------------*/

.hero { padding-block-start: calc(var(--section-padding) + 75px); }

.hero .container {
display: grid;
gap: 20px;
}

.hero-text {
font-size: var(--fs-3);
font-weight: var(--fw-500);
margin-block: 8px;
}

.hero .counter {
color: var(--medium-spring-green);
font-size: var(--fs-2);
font-weight: var(--fw-700);
}

.hero-list { margin-block: 8px 20px; }

.hero-list-item {
position: relative;
display: flex;
justify-content: space-between;
align-items: center;
font-size: var(--fs-4);
padding-inline-start: 20px;
padding-block: 8px;
}

.hero-list-item::before {
content: "";
position: absolute;
left: 0;
top: 50%;
width: 10px;
height: 10px;
transform: translateY(-50%);
border-radius: var(--radius-circle);
}

.hero-list-item.yellow::before { background-color: var(--orange-peel); }

.hero-list-item.green::before { background-color: var(--malachite); }

.hero-list-item.red::before { background-color: var(--red-orange-creyola); }

/* infinite以使动画无限重复 */
.hero-banner .w-100 { animation: rotate 20s linear infinite; }

@keyframes rotate {
0% { transform: rotate(0); }
100% { transform: rotate(360deg); }
}





/*-----------------------------------*\
#ABOUT
\*-----------------------------------*/

.about .container {
display: grid;
gap: 30px;
}

.about-subtitle {
font-size: var(--fs-4);
color: var(--medium-spring-green);
}

.about .section-text { margin-block: 8px 15px; }

.about-list { margin-block-start: 30px; }

.about-item {
display: flex;
align-items: flex-start;
gap: 15px;
padding-block: 15px;
}

.about .item-img {
flex-shrink: 0;
border-radius: var(--radius-circle);
}

.about .item-title { margin-block-end: 5px; }





/*-----------------------------------*\
#SERVICE
\*-----------------------------------*/

.service { text-align: center; }

.service-list {
display: grid;
gap: 10px;
}

.service-card {
background-color: var(--oxford-blue_50);
padding: 20px;
border-radius: var(--radius-6);
transition: var(--transition-1);
}

.service-card .card-banner {
max-width: max-content;
margin-inline: auto;
border-radius: var(--radius-circle);
}

.service-card .card-banner img { width: 95px; }

.service-card .card-title { margin-block: 20px 5px; }

.service-card :is(.card-title, .card-text) { transition: var(--transition-1); }

.service-card:hover {
background-color: var(--white);
transform: translateY(-5px);
}

.service-card:hover .card-title { color: var(--black); }

.service-card:hover .card-text { color: var(--dim-gray); }





/*-----------------------------------*\
#DOCTOR
\*-----------------------------------*/

.doctor :is(.section-title, .section-text) { text-align: center; }

.doctor-card {
background-color: var(--oxford-blue_70);
padding: 10px;
}

.doctor-card:is(:hover, :focus-within) .img-cover { transform: scale(1.05); }

.doctor-card .card-content { padding: 20px; }

.doctor-card .card-subtitle { margin-block: 5px 10px; }

.doctor-card .card-text {
border-block-start: 1px solid var(--cultured_20);
padding-block-start: 15px;
margin-block-end: 20px;
}

.doctor-card .card-item {
border: 1px solid var(--cultured_20);
display: flex;
align-items: center;
}

.doctor-card .card-item:last-child { border-block-start: none; }

.doctor-card .card-item .icon-box {
color: var(--silver);
padding: 22px;
border-inline-end: 1px solid var(--cultured_20);
}

.doctor-card .card-item .span {
margin-inline: 15px;
padding-block: 5px;
word-break: break-all;
}


.has-doctbg{
  background-repeat: no-repeat;
background-position: center;
background-size: cover;
background-image: url(../../assets/images/doct-bg.png)
}


/*-----------------------------------*\
#SAFETY
\*-----------------------------------*/

.safety .section-text { margin-block-end: 55px; }

.safety { text-align: center; }

.safety-list {
display: grid;
gap: 50px;
}

.safety-item { position: relative; }

.safety-item .item-banner {
max-width: max-content;
border-radius: var(--radius-circle);
margin-inline: auto;
margin-block-end: 20px;
}

.safety-item .number {
position: absolute;
top: -21px;
left: 50%;
transform: translateX(-50%);
background-color: var(--caribbean-green);
display: grid;
place-items: center;
width: 42px;
height: 42px;
border-radius: var(--radius-circle);
border: 3px solid var(--oxford-blue);
font-weight: var(--fw-700);
}





/*-----------------------------------*\
#BLOG
\*-----------------------------------*/

.blog { background-color: var(--indigo-dye); }

.blog :is(.section-title, .section-text) { text-align: center; }

.blog-card :is(.card-content, .card-footer) {
background-color: var(--prussian-blue);
padding: 20px;
}

.blog-card .card-title { transition: var(--transition-1); }

.blog-card .card-title:is(:hover, :focus) { color: var(--winter-sky); }

.blog-card .card-meta { margin-block: 15px; }

.blog-card .card-meta .wrapper {
display: flex;
align-items: center;
gap: 5px;
padding-block: 2px;
}

.blog-card .card-footer { border-block-start: 1px solid var(--cultured_20); }

.btn-link { font-weight: var(--fw-700); }


/*-----------------------------------*\
#SHOP
\*-----------------------------------*/

.shop :is(.section-title, .section-text) { text-align: center; }


/*-----------------------------------*\
#FOOTER
\*-----------------------------------*/

.footer-top {
display: grid;
gap: 60px;
}

.footer-list-title,
.footer-text { margin-block-end: 15px; }

.contact-item {
display: flex;
flex-wrap: wrap;
gap: 8px 10px;
}

.contact-item:not(:last-child) { margin-block-end: 15px; }

.contact-title {
font-size: var(--fs-5);
font-weight: var(--fw-700);
}

.footer-list-item {
display: flex;
align-items: center;
gap: 10px;
margin-block-start: 15px;
}

.footer-list:not(.social-list) ion-icon { font-size: 14px; }

.footer-bottom {
padding-block: 35px;
text-align: center;
border-block-start: 1px solid var(--cultured_20);
}





/*-----------------------------------*\
#BACK TO TOP
\*-----------------------------------*/

.back-top-btn {
position: fixed;
bottom: 10px;
right: 20px;
background-color: var(--winter-sky);
font-size: 18px;
padding: 12px;
border-radius: var(--radius-circle);
opacity: 0;
visibility: hidden;
transition: var(--transition-1);
z-index: 4;
}

.back-top-btn.active {
opacity: 1;
visibility: visible;
transform: translateY(-10px);
}





/*-----------------------------------*\
#MEDIA QUERIES
\*-----------------------------------*/

/**
* responsive for large than 575px screen
*/

@media (min-width: 575px) {

/**
 * CUSTOM PROPERTY
 */

:root {

  /**
   * typography
   */

  --fs-2: 3.6rem;
  --fs-3: 2.4rem;

}



/**
 * REUSED STYLE
 */

.container {
  max-width: 540px;
  width: 100%;
  margin-inline: auto;
}

.h2 { font-size: var(--fs-1); }

.h4 { --fs-4: 2rem; }

.text { font-size: unset; }



/**
 * HERO
 */

.hero-list { max-width: 275px; }



/**
 * SAFETY, FOOTER
 */

.safety-list,
.footer-top { grid-template-columns: 1fr 1fr; }

}





/**
* responsive for large than 768px screen
*/

@media (min-width: 768px) {

/**
 * REUSED STYLE
 */

.container { max-width: 720px; }

.grid-list { grid-template-columns: 1fr 1fr; }



/**
 * HERO
 */

.hero .container {
  grid-template-columns: 1fr 1fr;
  align-items: center;
}



/**
 * ABOUT
 */

.about-banner { max-width: max-content; }



/**
 * SERVICE
 */

.service-list { grid-template-columns: 1fr 1fr; }

}





/**
* responsive for large than 992px screen
*/

@media (min-width: 992px) {

/**
 * CUSTOM PROPERTY
 */

:root {

  /**
   * typography
   */

  --fs-2: 6rem;

}



/**
 * REUSED STYLE
 */

.container { max-width: 960px; }

.grid-list { grid-template-columns: 1fr 1fr; }

.section-text {
  max-width: 70ch;
  margin-inline: auto;
}



/**
 * HEADER
 */

.nav-toggle-btn { display: none; }

.header {
  background-color: transparent;
  box-shadow: none;
  padding-block: 20px;
}

.header.active {
  background-color: var(--oxford-blue);
  box-shadow: var(--shadow-1);
}

.navbar,
.navbar.active {
  all: unset;
  display: block;
}

.navbar-list {
  display: flex;
  gap: 40px;
}

.navbar-item:not(:last-child) { border: none; }

.header .btn {
  display: block;
  padding-inline: 40px;
}

.header .btn:is(:hover, :focus) { box-shadow: var(--shadow-3); }



/**
 * ABOUT
 */

.about .container {
  grid-template-columns: 1fr 1fr;
  align-items: center;
}

.about-banner.order-1 { order: 1; }



/**
 * SERVICE
 */

.service-card {
  display: flex;
  align-items: flex-start;
  text-align: left;
  gap: 10px;
  padding: 30px;
}

.service-card .card-banner { flex-shrink: 0; }

.service-card .card-title { margin-block: 0 10px; }



/**
 * SAFETY
 */

.safety-list { grid-template-columns: repeat(3, 1fr); }



/**
 * FOOTER
 */

.footer-top { grid-template-columns: 1fr 0.5fr 0.5fr 0.75fr; }

}





/**
* responsive for large than 1200px screen
*/

@media (min-width: 1200px) {

/**
 * CUSTOM PROPERTY
 */

:root {

  /**
   * typography
   */

  --fs-1: 3.6rem;

}



/**
 * REUSED STYLE
 */

.container { max-width: 1200px; }

.section-text {
  max-width: 75ch;
  margin-block-end: 60px;
}

.grid-list { grid-template-columns: repeat(3, 1fr); }



/**
 * HEADER
 */

.navbar { margin-inline: auto 40px; }



/**
 * HERO
 */

.hero .counter { --fs-2: 8rem; }



/**
 * SAFETY
 */

.safety .section-text { margin-block-end: 80px; }

.safety-list { grid-template-columns: repeat(4, 1fr); }

}

</style>