

<template>
  <header class="header">

    <div class="container">
      <a href="#" class="logo">
        <img width="199" height="50" src="../../assets/images/logo.svg" alt="home">
      </a>

      <nav class="navbar">
        <ul class="navbar-list">
          <li class="navbar-item">
            <a href=""> 首页</a>
          </li>
          <li class="navbar-item" > <a href="" class="navbar-link"> 首页</a></li>
          <li class="navbar-item"> <a href="" class="navbar-link"> 首页</a></li>
          <li class="navbar-item"> <a href="" class="navbar-link"> 首页</a></li>
          <li class="navbar-item"> <a href="" class="navbar-link"> 首页</a></li>
          <li class="navbar-item"> <a href="" class="navbar-link"> 首页</a></li>
          <li class="navbar-item"> <a href="" class="navbar-link">  首页</a></li>
        </ul>
      </nav>

      <button>

      </button>

      <a href="#">
        你是否需要咨询
      </a>
    </div>

  </header>
</template>






<script setup lang='ts'>

</script>





<style lang='scss' scoped>
:root {

  /**
 * colors
 */

  --medium-spring-green: hsl(156, 100%, 50%);
  --red-orange-creyola: hsl(0, 100%, 68%);
  --caribbean-green: hsl(160, 98%, 39%);
  --oxford-blue_50: hsla(213, 86%, 16%, 0.5);
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

li {
  list-style: none;
}

a,
img,
span,
button,
ion-icon {
  display: block;
}


a,
img,
span,
button,
ion-icon {
  display: block;
}

a {
  color: inherit;
  text-decoration: none;
}

img {
  height: auto;
}

button {
  background: none;
  border: none;
  font: inherit;
  cursor: pointer;
}

ion-icon {
  pointer-events: none;
}

address {
  font-style: normal;
}

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

body.active {
  overflow-y: hidden;
}

:focus-visible {
  outline-offset: 4px;
}

::-webkit-scrollbar {
  width: 10px;
}

::-webkit-scrollbar-track {
  background-color: hsl(0, 0%, 98%);
}

::-webkit-scrollbar-thumb {
  background-color: hsl(0, 0%, 80%);
}

::-webkit-scrollbar-thumb:hover {
  background-color: hsl(0, 0%, 70%);
}



/*-----------------------------------*\
  #REUSED STYLE
\*-----------------------------------*/


.h1,
.h2,
.h3,
.h4 {
  line-height: 1.4;
}

.h1 {
  font-size: var(--fs-2);
}

.h4 {
  font-size: var(--fs-4);
}

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

.btn-primary:is(:hover, :focus) {
  box-shadow: var(--shadow-2);
}

.w-100 {
  width: 100%;
}

.text {
  font-size: var(--fs-5);
}

.img-holder {
  aspect-ratio: var(--width) / var(--height);
  background-color: var(--light-gray);
  overflow: hidden;
}

.section-text {
  margin-block: 15px 35px;
}


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

.header {
 
  position: absolute;

  width: 100%;

}




.header .container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-inline: auto;

}


 

  @media (min-width: 992px) {

/**
 * CUSTOM PROPERTY
 */

.container { max-width: 960px; }




/**
 * HEADER
 */

.nav-toggle-btn { display: none; }

.navbar-list {
  display: flex;
  gap: 40px;
}
  }

  .navbar-link {
  
  transition: var(--transition-1);
}

.navbar-link:is(:hover, :focus) { color: var(--winter-sky); }


</style>