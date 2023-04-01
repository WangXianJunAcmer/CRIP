<template>
  <div class="preloader" data-preloader>
    <div class="circle"></div>
  </div>
  <header class="header" data-header>
    <div class="container">
      <a href="#" class="logo">
        <img
          src="../../assets/images/logo.svg"
          width="146"
          height="56"
          alt="Doclab home"
        />
      </a>
      <button @click="search" class="main-btn1" style="color: white">
        Search
      </button>
      <input
        type="text"
        v-model="searchText"
        @input="handleInput"
        placeholder="Search"
        ref="searchInput"
      />

      <button @click="goToMain" class="main-btn" width="146" height="56">
        主 页
      </button>
    </div>
  </header>

  <main>
    <article>
      <!-- 
        - #HERO
      -->

      <section class="section hero" aria-label="home">
        <div class="container">
          <div class="hero-content">
            <h1>
              Find Nearest <br />
              Doctor.
            </h1>

            <div class="hero-card">
              <p>Search doctors. clinics. hospitals</p>

              <div class="wrapper"></div>
            </div>
          </div>
          <figure class="hero-banner">
            <img
              src="../../assets/images/hero-banners.png"
              width="506 "
              height="480"
              loading="eager"
              alt="hero banners"
            />
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
              <div class="service-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-1.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <h3>Psychiatry</h3>

                <button
                  class="btn-circle"
                  aria-label="read more about psychiatry"
                >
                  <ion-icon name="arrow-forward" aria-hidden="true"></ion-icon>
                </button>
              </div>
            </li>

            <li>
              <div class="service-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-2.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <h3>Gynecology</h3>

                <button
                  class="btn-circle"
                  aria-label="read more about Gynecology"
                >
                  <ion-icon name="arrow-forward" aria-hidden="true"></ion-icon>
                </button>
              </div>
            </li>

            <li>
              <div class="service-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-3.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <h3>Pulmonology</h3>

                <button
                  class="btn-circle"
                  aria-label="read more about Pulmonology"
                >
                  <ion-icon name="arrow-forward" aria-hidden="true"></ion-icon>
                </button>
              </div>
            </li>

            <li>
              <div class="service-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-4.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <h3>Orthopedics</h3>

                <button
                  class="btn-circle"
                  aria-label="read more about Orthopedics"
                >
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
            <p>About Us</p>

            <h2 class="sss">Experienced Workers</h2>

            <p>
              Aliquam faucibus, odio nec commodo aliquam, neque felis placerat
              dui, a porta ante lectus dapibus est. Aliquam
            </p>

            <ul class="tab-list">
              <li>
                <button class="tab-btn">Vision</button>
              </li>

              <li>
                <button class="tab-btn">Mission</button>
              </li>

              <li>
                <button class="tab-btn">Strategy</button>
              </li>
            </ul>

            <p class="tab-text">
              Aliquam faucibus, odio nec commodo aliquam, neque felis placerat
              dui, a porta ante lectus dapibus est. Aliquam a bibendum mi, sed
              condimentum
            </p>

            <div class="wrapper">
              <ul class="about-list">
                <li class="about-item">
                  <ion-icon name="checkmark-circle-outline"></ion-icon>

                  <span>Sonsectetur adipisicing elit</span>
                </li>

                <li class="about-item">
                  <ion-icon name="checkmark-circle-outline"></ion-icon>

                  <span>Exercitation ullamco laboris</span>
                </li>

                <li class="about-item">
                  <ion-icon name="checkmark-circle-outline"></ion-icon>

                  <span>Eiusmod tempor incididunt</span>
                </li>

                <li class="about-item">
                  <ion-icon name="checkmark-circle-outline"></ion-icon>

                  <span>Aolore magna aliqua</span>
                </li>
              </ul>
            </div>
          </div>

          <figure class="about-banner">
            <img
              src="../../assets/images/about-banner.png"
              width="490"
              height="678"
              loading="lazy"
              alt="about banner"
            />
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
              <p class="csa">Doctors Listig</p>

              <h2 class="aaa">Browse by specialist</h2>
            </li>

            <li>
              <div class="listing-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-1.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <div>
                  <h3 class="headline-sm card-title">Psychiatry</h3>

                  <p class="card-text">Porta velit</p>
                </div>
              </div>
            </li>

            <li>
              <div class="listing-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-2.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <div>
                  <h3 class="headline-sm card-title">Gynecology</h3>

                  <p class="card-text">Mattis augue</p>
                </div>
              </div>
            </li>

            <li>
              <div class="listing-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-4.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <div>
                  <h3 class="headline-sm card-title">Pulmonology</h3>

                  <p class="card-text">Mauris laoreet</p>
                </div>
              </div>
            </li>

            <li>
              <div class="listing-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-5.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <div>
                  <h3 class="headline-sm card-title">Orthopedics</h3>

                  <p class="card-text">Convallis vulputate</p>
                </div>
              </div>
            </li>

            <li>
              <div class="listing-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-6.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <div>
                  <h3 class="headline-sm card-title">Pediatrics</h3>

                  <p class="card-text">Posuere maecenas</p>
                </div>
              </div>
            </li>

            <li>
              <div class="listing-card">
                <div class="card-icon">
                  <img
                    src="../../assets/images/icon-7.png"
                    width="71"
                    height="71"
                    loading="lazy"
                    alt="icon"
                  />
                </div>

                <div>
                  <h3 class="headline-sm card-title">Osteology</h3>

                  <p class="card-text">Nisi nullam</p>
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
          <ul class="grid-list">
            <li>
              <div class="blog-card has-before has-after">
                <div class="meta-wrapper">
                  <div class="card-meta">
                    <ion-icon name="person-outline"></ion-icon>

                    <span class="span">By Admin</span>
                  </div>

                  <div class="card-meta">
                    <ion-icon name="folder-outline"></ion-icon>

                    <span class="span">Specialist</span>
                  </div>
                </div>

                <h3 class="wee">
                  Could intermittent fasting reduce breast cancer
                </h3>

                <p class="card-text">1</p>

                <a href="#" class="btn-text title-lg">Read More</a>
              </div>
            </li>

            <li>
              <div class="blog-card has-before has-after">
                <div class="meta-wrapper">
                  <div class="card-meta">
                    <ion-icon name="person-outline"></ion-icon>

                    <span class="span">By Admin</span>
                  </div>

                  <div class="card-meta">
                    <ion-icon name="folder-outline"></ion-icon>

                    <span class="span">Specialist</span>
                  </div>
                </div>

                <h3 class="wee">
                  Give children more autonomy during the pandemic
                </h3>
                <p class="card-text">2</p>

                <a class="btn-text title-lg">Read More</a>
              </div>
            </li>

            <li>
              <div class="blog-card has-before has-after">
                <div class="meta-wrapper">
                  <div class="card-meta">
                    <ion-icon name="person-outline"></ion-icon>

                    <span class="span">By Admin</span>
                  </div>

                  <div class="card-meta">
                    <ion-icon name="folder-outline"></ion-icon>

                    <span class="span">Specialist</span>
                  </div>
                </div>

                <h3 class="wee">
                  How do binge eating and drinking impact the liver?
                </h3>
                <p class="card-text">3</p>
                <a href="#" class="btn-text title-lg">Read More</a>
              </div>
            </li>
          </ul>
        </div>
      </section>
    </article>
  </main>
</template>
<script lang="ts">
import { defineComponent, onMounted, onBeforeUnmount } from "vue";
import { useRouter } from "vue-router";

const addEventOnElements = function (
  elements: NodeListOf<Element>,
  eventType: string,
  callback: EventListenerOrEventListenerObject
) {
  for (let i = 0, len = elements.length; i < len; i++) {
    elements[i].addEventListener(eventType, callback);
  }
};

export default defineComponent({
  data() {
    return {
      searchText: "",
    };
  },
  methods: {
    search(): void {
      const searchText = (this.$refs.searchInput as HTMLInputElement).value;
      window.location.href = `https://www.baidu.com/s?wd=${searchText}`;
    },
  },
  setup() {
    const preloader = document.querySelector<HTMLElement>("[data-preloader]");

    const handleWindowLoad = () => {
      preloader?.classList.add("loaded");
      document.body.classList.add("loaded");
    };

    onMounted(() => {
      window.addEventListener("load", handleWindowLoad);
    });

    onBeforeUnmount(() => {
      window.removeEventListener("load", handleWindowLoad);
    });

    const navbar = document.querySelector<HTMLElement>("[data-navbar]");
    const navTogglers =
      document.querySelectorAll<HTMLElement>("[data-nav-toggler]");
    const overlay = document.querySelector<HTMLElement>("[data-overlay]");

    const toggleNav = function () {
      navbar?.classList.toggle("active");
      overlay?.classList.toggle("active");
      document.body.classList.toggle("nav-active");
    };

    addEventOnElements(navTogglers, "click", toggleNav);

    const revealElements =
      document.querySelectorAll<HTMLElement>("[data-reveal]");

    const revealElementOnScroll = function () {
      for (let i = 0, len = revealElements.length; i < len; i++) {
        if (
          revealElements[i].getBoundingClientRect().top <
          window.innerHeight / 1.15
        ) {
          revealElements[i].classList.add("revealed");
        } else {
          revealElements[i].classList.remove("revealed");
        }
      }
    };

    window.addEventListener("scroll", revealElementOnScroll);

    onBeforeUnmount(() => {
      window.removeEventListener("scroll", revealElementOnScroll);
    });

    // 在此定义 goToMain 方法
    const router = useRouter();

    function goToMain() {
      router.push({ path: "../Main" });
    }

    return {
      goToMain,
    };
  },
});
</script>
<style lang="scss" scoped>
:root {
  /**
 * colors
 */

  --rich-black-fogra-29: hsl(222, 44%, 8%);
  --middle-blue-green_40: hsla(174, 64%, 71%, 0.4);
  --midnight-green: hsl(186, 100%, 19%);
  --midnight-green_a25: hsla(186, 100%, 19%, 0.25);
  --independece: hsl(236, 14%, 39%);
  --verdigris: hsl(182, 100%, 35%);
  --ming: hsl(186, 72%, 24%);
  --space-cadet: hsla(226, 45%, 24%);
  --eerie-black: hsl(0, 0%, 13%);
  --alice-blue: hsl(187, 25%, 94%);
  --gray-web: hsl(0, 0%, 50%);
  --gainsboro: hsl(0, 0%, 87%);
  --white: hsl(0, 0%, 100%);
  --white_a20: hsla(0, 0%, 100%, 0.2);
  --white_a10: hsla(0, 0%, 100%, 0.1);
  --black: hsl(0, 0%, 0%);

  /**
 * typography
 */

  --ff-oswald: "Oswald", sans-serif;
  --ff-rubik: "Rubik", sans-serif;

  --headline-lg: 5rem;
  --headline-md: 3rem;
  --headline-sm: 2rem;
  --title-lg: 1.8rem;
  --title-md: 1.5rem;
  --title-sm: 1.4rem;

  --fw-500: 500;
  --fw-700: 700;

  /**
 * spacing
 */

  --section-padding: 120px;

  /**
 * box shadow
 */

  --shadow-1: 0px 2px 20px hsla(209, 36%, 72%, 0.2);
  --shadow-2: 0 4px 16px hsla(0, 0%, 0%, 0.06);

  /**
 * border radius
 */

  --radius-circle: 50%;
  --radius-12: 12px;
  --radius-6: 6px;
  --radius-4: 4px;

  /**
 * transition
 */

  --transition-1: 0.25s ease;
  --transition-2: 0.5s ease;
  --transition-3: 1s ease;
  --cubic-in: cubic-bezier(0.51, 0.03, 0.64, 0.28);
  --cubic-out: cubic-bezier(0.05, 0.83, 0.52, 0.97);
}
*,
*::before,
*::after {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

li {
  list-style: none;
  display: inline;
}

a {
  color: inherit;
  text-decoration: none;
}

img {
  height: auto;
}

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

button {
  cursor: pointer;
}

ion-icon {
  pointer-events: none;
}

address {
  font-style: normal;
}

html {
  font-size: 10px;
  font-family: var(--ff-rubik);
  scroll-behavior: smooth;
}
body {
  background-color: var(--white);
  font-size: 1.6rem;
  color: var(--independece);
  line-height: 1.8;
  overflow: hidden;
}

body.loaded {
  overflow-y: hidden;
}

body.nav-active {
  overflow: hidden;
}

.preloader {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100vh;
  background-color: var(--verdigris);
  display: grid;
  place-items: center;
  z-index: 6;
  transition: var(--transition-1);
}

.preloader.loaded {
  visibility: visible;
  opacity: 0;
}

.preloader .circle {
  width: 50px;
  height: 50px;
  border: 4px solid var(--white);
  border-radius: var(--radius-circle);
  border-block-start-color: transparent;
  animation: rotate360 1s ease infinite;
}

@keyframes rotate360 {
  0% {
    transform: rotate(0);
  }
  100% {
    transform: rotate(1turn);
  }
}

/*-----------------------------------*\
  #HEADER
\*-----------------------------------*/

.header .btn {
  display: none;
}

.header {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  padding-block: 16px;
  z-index: 8;
}

.header.active {
  position: fixed;
  background-color: var(--rich-black-fogra-29);
  animation: headerActive 0.5s ease forwards;
}

@keyframes headerActive {
  0% {
    transform: translateY(-100%);
  }
  100% {
    transform: translateY(0);
  }
}

.header .container {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.nav-open-btn {
  color: var(--white);
  font-size: 4rem;
}

.navbar,
.overlay {
  position: fixed;
  top: 0;
  width: 100%;
  height: 100vh;
}

.overlay {
  right: -100%;
  background-color: var(--black);
  opacity: 0.3;
  visibility: visible;
  transition: var(--transition-2);
  z-index: 2;
}

.overlay.active {
  transform: translateX(-100%);
  visibility: visible;
}
.hero-banner {
  display: right;
}

.hero {
  background-color: var(--midnight-green);
  --section-padding: 200px;
  background-repeat: no-repeat;
  background-size: cover;
}

.hero-card {
  background-color: var(--white);
  border-radius: var(--radius-12);
  padding: 20px;
}

.hero-card .card-text {
  color: var(--eerie-black);
  border-block-end: 1px solid var(--midnight-green_a25);
  padding-block-end: 12px;
  margin-block-end: 14px;
}

.hero-card .input-wrapper {
  position: relative;
}

.hero-card .input-field {
  color: var(--eerie-black);
  border-block-end: 1px solid var(--gainsboro);
  padding-inline-end: 18px;
}

.hero-card .input-wrapper ion-icon {
  position: absolute;
  top: 50%;
  right: 0;
  transform: translateY(-50%);
  color: var(--verdigris);
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
  border-radius: var(--radius-12);
  margin-block-start: -60px;
  background-color: var(--white);
  box-shadow: var(--shadow-1);
}

.service-card {
  text-align: center;
}

.service-card .card-icon,
.btn-circle {
  max-width: max-content;
  margin-inline: auto;
}

.service-card .card-icon {
  margin-block-end: 25px;
  float: left;
}

.service-card .card-text {
  margin-block: 20px 15px;
  float: left;
}

.service-card .btn-circle {
  color: var(--verdigris);
  font-size: 2rem;
  padding: 18px;
  border-radius: var(--radius-circle);
  box-shadow: var(--shadow-2);
  transition: var(--transition-1);
}

.service-card .btn-circle:is(:hover, :focus-visible) {
  background-color: var(--verdigris);
  color: var(--white);
}

/*-----------------------------------*\
  #ABOUT
\*-----------------------------------*/

.about {
  padding-block-end: 0;
}

.about .container {
  display: grid;
  grid-gap: 20px;
}

.about .section-text {
  margin-block: 20px 35px;
}

.tab-list {
  display: flex;
  flex-wrap: wrap;
  gap: 5px 15px;
  margin: auto;
}

.tab-btn {
  background-color: var(--alice-blue);
  color: var(--midnight-green);
  padding: 7px 30px;
  border-radius: var(--radius-6);
  font-weight: var(--fw-700);
}

.tab-btn.active {
  background-color: var(--verdigris);
  color: var(--white);
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
  color: var(--verdigris);
  font-size: 2rem;
  flex-shrink: 0;
}

/*-----------------------------------*\
  #LISTING
\*-----------------------------------*/

.listing {
  background-color: var(--alice-blue);
}

.listing-card {
  padding: 10px 30px;
  display: flex;
  gap: 20px;
  border: 2px solid var(--middle-blue-green_40);
  border-radius: var(--radius-12);
  transition: var(--transition-1);
}

.listing-card:is(:hover, :focus-visible) {
  border-color: var(--verdigris);
}

.listing-card .card-title {
  margin-block-end: 5px;
  font-family: var(--ff-oswald);
}

/*-----------------------------------*\
  #BLOG
\*-----------------------------------*/

.blog .section-title {
  margin-block-end: 60px;
}

.blog-card {
  padding: 50px 36px;
  border-radius: var(--radius-12);
  border: 2px solid var(--alice-blue);
  background-image: url("../../assets/images/hero-bgs.jpg");
  background-repeat: no-repeat;
  background-position: center;
  background-size: cover;
  overflow: visible;
}

.blog-card::before,
.blog-card::after {
  inset: 0;
  z-index: -1;
  transition: var(--transition-3);
}

.blog-card::before {
  background-color: var(--midnight-green);
  opacity: 0.9;
}

.blog-card::after {
  background-color: var(--white);
}

.blog-card:is(:hover, :focus-within)::after {
  transform: translateY(100%);
}

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

.blog-card .card-meta ion-icon {
  font-size: 1.8rem;
}

.blog-card .card-meta:first-child .span {
  text-transform: uppercase;
}
.blog-card .date {
  color: var(--space-cadet);
  font-weight: var(--fw-700);
  text-transform: uppercase;
  opacity: 0.5;
  margin-block: 16px;
}

.blog-card .btn-text {
  color: var(--verdigris);
  margin-block-start: 12px;
}

.blog-card :is(.card-meta, .card-title, .date, .card-text, .btn-text) {
  transition: var(--transition-2);
}

.blog-card:is(:hover, :focus-within)
  :is(.card-meta, .card-title, .date, .card-text, .btn-text) {
  color: var(--white);
}
.contact-item {
  display: flex;
  align-items: flex-start;
  gap: 12px;
  margin-block-start: 12px;
}

.contact-item .item-icon {
  font-size: 4rem;
}

.contact-link {
  display: inline;
  transition: var(--transition-1);
}

.contact-link:is(:hover, :focus-visible) {
  color: var(--verdigris);
}

.active {
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
    z-index: 11;
    margin-inline: auto;
  }

  /**
   * HEADER
   */

  .header .btn {
    display: block;
  }

  .nav-open-btn {
    margin-inline-start: auto;
  }

  .header .container {
    gap: 40px;
  }

  /**
   * HERO
   */

  .hero .wrapper {
    display: flex;
    gap: 16px;
  }

  .hero-card .input-wrapper {
    flex-grow: 1;
  }

  .hero-card .input-field {
    height: 100%;
  }

  .hero-card .btn {
    width: max-content;
    margin-block-start: 0;
  }

  /**
   * SERVICE
   */

  .service-list {
    grid-template-columns: 1fr 1fr;
  }

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

  .listing .grid-list {
    grid-template-columns: 1fr 1fr;
  }

  .listing .grid-list > li:first-child {
    grid-column: 1 / 3;
  }

  /**
   * FOOTER
   */

  .footer-top {
    grid-template-columns: 1fr 1fr;
  }

  .footer-brand {
    grid-column: 1 / 3;
  }
}

/**
 * responsive for large than 992px screen
 */

@media (min-width: 992px) {
  /**
   * REUSED STYLE
   */

  .container {
    max-width: 940px;
  }

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

  .service-list {
    grid-template-columns: repeat(4, 1fr);
  }

  /**
   * ABOUT
   */

  .about .container {
    grid-template-columns: 1fr 0.8fr;
    align-items: flex-end;
  }

  .about-content {
    padding-block-end: var(--section-padding);
  }

  .about-banner {
    margin-inline-end: -80px;
  }

  /**
   * BLOG
   */

  .blog .grid-list {
    grid-template-columns: 1fr 1fr;
    float: left;
  }
}

/**
 * responsive for large than 1200px screen
 */

@media (min-width: 1200px) {
  /**
   * REUSED STYLE
   */

  .container {
    max-width: 1200px;
  }

  /**
   * HEADER
   */

  .header {
    padding-block: 24px;
  }

  .nav-open-btn,
  .overlay,
  .navbar-top,
  .navbar .social-list {
    display: none;
  }

  .navbar,
  .navbar.active,
  .navbar-list {
    all: unset;
    display: block;
  }

  .navbar {
    margin-inline-start: auto;
  }

  .navbar-list {
    display: flex;
    gap: 8px;
  }

  .navbar-link {
    --title-md: 1.8rem;
    font-weight: var(--fw-500);
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

  .listing .grid-list {
    grid-template-columns: repeat(4, 1fr);
  }

  /**
   * BLOG
   */

  .blog .grid-list {
    grid-template-columns: repeat(3, 1fr);
  }

  /**
   * FOOTER
   */

  .footer-top {
    grid-template-columns: repeat(4, 1fr);
  }

  .footer-brand {
    grid-column: 1 / 5;
    padding: 28px 56px;
    display: grid;
    grid-template-columns: 0.3fr 1fr;
    align-items: center;
  }

  .contact-item {
    margin-block-start: 0;
  }
}
.main-btn {
  background-color: #12917c;
  color: #fff;
  padding: 10px;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s;
  width: 10%;
  margin-top: -100px;
  z-index: 10;
}
.main-btn1 {
  background-color: #e6a312;
  color: #fff;
  padding: 10px;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  transition: background-color 0.3s;
  width: 10%;
  margin-top: -100px;
  z-index: 10;
}
.container img {
  margin-bottom: 50px;
}
.container input {
  border: medium solid rgb(244, 239, 239);
  width: 550px;
  border-width: 5px;
  margin-bottom: 100px;
  margin-right: 50px;
  color: #f6faf4;
}
.container li {
  font-size: 16px;
  float: left;
}
.hero-content h1 {
  font-size: 58px;
  margin-top: 100px;
}
.hero-card p,
span,
button {
  float: left;
  margin-top: 60px;
}
.card-icon img {
  margin-top: 40px;
}
.service-card p,
h3 {
  margin-top: 50px;
}
.headline-sm card-title {
  margin-top: 50px;
}
.tab-text {
  margin-bottom: 65px;
}
.about-item span {
  margin-top: 10px;
}
.about-content h2 {
  margin-bottom: 50px;
}
.sss {
  font-size: 48px;
}
.grid-list li p,
h2 {
  margin-top: 70px;
}
.aaa {
  font-size: 35px;
}
.wee {
  font-size: 13px;
  font-weight: bold;
}
.csa {
  margin-top: 70px;
}
.card-meta span,
h3,
a {
  display: flex;
  float: left;
  flex-wrap: wrap;
  margin-bottom: 30px;
}
.span .btn-text title-lg .card-text {
  list-style: none;
  float: left;
}
</style>
