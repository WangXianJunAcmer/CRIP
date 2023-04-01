<template>
<div
style="display: grid; place-items: center; height: 100vh;"

>
  <div class="login-page" >
            

            <form :model="form">
    <h1> 登陆</h1>

             
<input placeholder="请输入用户" type="text"  v-model="form.email" >
    

<input placeholder="请输入密码" type="password"  v-model="form.password">
    



</form>   
<div class="bt">
 



 <button  @click="submitForm()">
     登录
 </button>


 <RouterLink  to="/Reg"
 style="text-decoration:none; color: black;" >  注册</RouterLink>

 </div>
   </div>
</div>
    
    
   
</template>

<script lang="ts" setup>
//命名式路由模式

import { useRouter } from 'vue-router'



import {ref} from 'vue'
import { postLogin } from '../../api/common';
//实现路由的跳转
const router = useRouter()

const form = ref(
    {
        email: '',
        password: ''
    }
)


const submitForm = async () => {
   
  try {
    const logindata = await postLogin(form.value);
    console.log(logindata);
    // 登录成功后跳转到 Main 页面
    console.log(logindata.data.role);
    if(logindata.data.role=="OrdinaryUser")
      router.push("/Main");
      else
      router.push("/shop");
  
  } catch (error) {
    console.error(error);
  }
};
</script>
<style  scoped>



.login-page {
    /* flex-direction: column; 设置弹性盒子的主轴方向为垂直方向。
align-items: center; 将弹性盒子的子元素在交叉轴上居中对齐。
justify-content: center; 将弹性盒子的子元素在主轴方向上居中对齐。 */
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 30px;
    background-color: #fff;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.2);
    border-radius: 5px;
    /*max-width: 400px; 设置登录页面元素的最大宽度为 400px，以便在更大的屏幕上保持适当的比例。 
    width: 100%; 设置登录页面元素的宽度为 100%，以确保它可以铺满其父元素（一般是 <body> 元素）的宽度。*/
    max-width: 400px;
    width: 100%;
}

 h1 {
    font-size: 30px;
    margin-bottom: 20px;
    color: #333;
    text-align: center;
}
input{
    padding: 10px;
      border: none;
      border-radius: 5px;
      width: 100%;
      margin-bottom: 20px;
      font-size: 16px;
      background-color: #f2f2f2;
      color: #555;
}
.bt{
    width: 80%;
    display: flex;
    justify-content: space-between;
    
}
button{
    background-color: #47525b;
      color: #fff;
      padding: 10px;
      border: none;
      border-radius: 5px;
      font-size: 16px;
      cursor: pointer;
      transition: background-color 0.3s; 
      width: 35%;
}
button:hover{
    
      background-color: #1ba4a6;
    
}
</style>