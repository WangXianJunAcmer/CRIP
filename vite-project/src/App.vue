<script setup lang="ts">

</script>

<template>
<router-view />
</template>

<style>
* {
    /* 初始化 */
    margin: 0;
    padding: 0;
}

html {
font-family:  "Roboto", sans-serif;
font-size: 10px;
scroll-behavior: smooth;
}
body {
    margin: 0;
    padding: 0;
    /*设置 body 元素为一个网格布局容器。
      居中所有内容，包括子元素。
      元素高度设置为视窗的高度，确保整个页面铺满浏览器。
      */
    display: grid;
    place-items: center;
    height: 100vh;

    background-color: hsl(213, 61%, 28%);
color:white;
font-size: 1.6rem;
line-height: 1.5;
overflow-x: hidden;
   
}

</style>
