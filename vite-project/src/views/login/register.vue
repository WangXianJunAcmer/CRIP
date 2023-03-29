<template>
    <div class="reg-page">

        <form :model="form">

            <h1> 注册</h1>


            <input placeholder="请输入用户名" type="text" v-model="form.username">
            <input placeholder="请输入邮箱" type="text" v-model="form.email">


            <input placeholder="请输入密码" type="password" v-model="form.password">
            <input placeholder="请再次输入密码" type="password" v-model="form.confirmPassword">
            <div>
                <input type="text"  placeholder="验证码" style="width:50%" 
                v-model="form.code"
                >

                <el-button 
                :type="message.type" 
                :disabled="message.isDisabled"
                 class="sendEmailButton" style="float:right; height: 40px;
                                             "

@click="SendEmailToRegister()"
                   >{{message.tips}}</el-button>
            </div>




        </form>




        <button   style="width: 95%;"
        @click="submitForm()">

            注册
        </button>
        <RouterLink to="/Login" style="text-decoration:none; ">已有账号，返回登录 </RouterLink>




    </div>
</template>


<script setup lang='ts'>
import { reactive, ref } from 'vue'
import { postToRegister, Register } from '../../api/common';


//表单里的属性
const form = ref(
    {
        username:'',
        email: '',
        password: '',
        confirmPassword: '',
        code: '',
    }

)


//实现验证码倒计时的方法
const SendEmailToRegister = async () => {
   
  
                  /***
                   * 发送验证码，当满足表单校验时才可以触动按钮
                   */
                  console.log("发送验证码")
                  const Registerdata = postToRegister(form.value)
                  console.log(Registerdata)
             
                  message.display = true; //起初
                  message.isDisabled = true;
                  message.type = "info";
                  let interval = window.setInterval(function () {
                         
                        message.tips = "" + message.number + "秒后重新发送";
                        --message.number;
                        if (message.number < 0) {
                              message.tips = "重新发送";
                              message.number = 60;
                              message.isDisabled = false;
                              window.clearInterval(interval);
                              message.type = "primary";
                        }
                  }, 1000);




}

//验证码里的对象属性
const message = reactive({
      tips: '获取验证码',
      number: 60,
      display: false,
      isDisabled: false,
      type: "primary"
})


//注册
const submitForm = async () => {

   



                 
                  const logindata = Register(form.value)
                  console.log('submit!')
                  console.log(logindata)
     
        
        
     
}

</script>


<style  scoped>
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
    background-color: #f9f9f9;
}

.reg-page {
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

input {
    padding: 10px;
    border: none;
    border-radius: 5px;
    width: 100%;
    margin-bottom: 20px;
    font-size: 16px;
    background-color: #f2f2f2;
    color: #555;
}

.bt {
    width: 80%;
    display: flex;
    justify-content: space-between;

}

button {
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

button:hover {

    background-color: #1ba4a6;

}
</style>