<template>
  <div style="display: grid; place-items: center; height: 100vh;">
    <div class="login-page">


      <el-form :rules="rules" :model="form"
      ref="ruleFormRef"    
   >
        <h1> 登陆</h1>
       <el-form-item prop="email"   
       :rules="[
        {
          required: true,
          message: '请输入邮箱',
          trigger: 'blur',
        },
        {
          type: 'email',
          message: '请输入正确的邮箱',
          trigger: ['blur', 'change'],
        },
      ]"
       >
        <el-input placeholder="请输入您的邮箱" clearable  v-model="form.email"></el-input>
      </el-form-item>
       <el-form-item prop="password"  
       :rules="{
        required: true,
        message: '请输入你的密码,密码必须包含大小写数字',
        trigger: 'blur',
      }"
       >
        <el-input
                        placeholder="请输入密码"
                        show-password
                        
                        v-model="form.password"
                    ></el-input>
      </el-form-item>

    
      </el-form>
      <div class="bt">
        <button @click="submitForm(ruleFormRef)">
          登录
        </button>
        <button>
          <RouterLink to="/Reg" style="text-decoration:none; color: black;"> 注册</RouterLink>
        </button>
       

      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
//命名式路由模式

import { useRouter } from 'vue-router'



import { ref } from 'vue'
import { getUserSimplifyMessage, postLogin } from '../../api/common';
import {  FormInstance } from 'element-plus'
import { useTestStore } from '../../store';
//实现路由的跳转
const router = useRouter()

const form = ref(
  {
    email: '',
    password: '',

  }
)

const rules = ref(
    {
       
        region: [
    {
      required: true,
      message: '选择城市',
      trigger: 'change',
    },
  ],

    }
)


const ruleFormRef = ref<FormInstance>()


const emailErrorMsg=ref('')
const passwordErrorMsg=ref('')


const submitForm = async (formE1:FormInstance | undefined) => {
 if(!formE1) return
 await formE1.validate(async(valid,fields)=>{
if(valid)

{
  const logindata = await postLogin(form.value);
  console.log(logindata);

// 登录成功后跳转到 Main 页面
console.log(logindata.data.role);
if (logindata.data.role == "OrdinaryUser")
{
  getUserSimplifyMessage()

  router.push("/Main");
}
 

else
  router.push("/doctor");
}
else {

console.log('error submit!', fields)
}
 })
      }
 




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
:v-deep.el-input__inner
{

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
 .el-form{
    width: 90%;

}
.el-input{
  height: 51px;
}
::v-deep .el-input__wrapper {
  background-color: #f2f2f2;
  color: #555;
}

</style>