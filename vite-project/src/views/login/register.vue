<template>
    <div style="display: grid; place-items: center; height: 100vh;">
        <div class="reg-page">

            <el-form :model="form" style="width:90%" ref="ruleFormRef" :rules="rules">


                <h1> 注册</h1>

                <el-form-item prop="username" :rules="{
                    required: true,
                    message: '请输入用户名',
                    trigger: 'blur',
                }">
                    <input placeholder="请输入用户名" type="text" v-model="form.username">
                </el-form-item>

                <el-form-item prop="email" :rules="[
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
                ]">
                    <input placeholder="请输入邮箱" type="text" v-model="form.email">

                </el-form-item>


                <el-form-item prop="password">
                    <input placeholder="请输入密码" type="password" v-model="form.password">
                </el-form-item>
                <el-form-item prop="confirmPassword">
                    <input placeholder="请再次输入密码" type="password" v-model="form.confirmPassword">
                </el-form-item>

                <div>
                    <el-form-item prop="code">
                        <input type="text" placeholder="验证码" style="width:50%" v-model="form.code">
                        <el-button type="primary" :disabled="message.isDisabled" class="sendEmailButton" style="float:right; height: 40px; margin-left: 34px;
                                         " @click="SendEmailToRegister(ruleFormRef)">{{ message.tips }}</el-button>
                    </el-form-item>



                </div>




            </el-form>




            <button style="width: 95%;" @click="submitForm(ruleFormRef)">

                注册
            </button>
            <RouterLink to="/Login" style="text-decoration:none; ">已有账号，返回登录 </RouterLink>




        </div>
    </div>
</template>


<script setup lang='ts'>
import { reactive, ref } from 'vue'
import { postToRegister, Register } from '../../api/common';
import { FormInstance } from 'element-plus';


//表单里的属性
const form = ref(
    {
        username: '',
        email: '',
        password: '',
        confirmPassword: '',
        code: '',
    }

)



const ruleFormRef = ref<FormInstance>()
//密码格式正则表达式
const regexp = new RegExp(/(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,30}/)
//第一次输入密码的自定义校验规则
const validatePass = (rule: any, value: any, callback: any) => {

    if (!regexp.test(form.value.password))
        callback(new Error("密码要求大小写字母加数字,长度在8到30位之间"))

    callback()

}
//确认密码的自定义校验规则
const validatePass2 = (rule: any, value: any, callback: any) => {

    //首先在rules里面判断密码框是不是空的，如果是空的就说请输入相同的密码
    //       if (value === '') {
    //     callback(new Error('请输入相同密码!'))
    //   }
    //   else
    if (!regexp.test(form.value.password)) {


        callback(new Error("密码要求大小写字母加数字,长度在8到30位之间"))


    }
    else
        if (value !== form.value.password) {
            callback(new Error("请输入相同密码!"))
        }
        else {
            callback()
        }

}

//实现验证码倒计时的方法
const SendEmailToRegister = async (formEl: FormInstance | undefined) => {

    if (!formEl) return
    await formEl.validate((valid, fields) => {
        if (valid) {
            console.log("发送验证码")
            const Registerdata = postToRegister(form.value)
            console.log(Registerdata)

            message.display = true; //起初
            message.isDisabled = true;

            let interval = window.setInterval(function () {

                message.tips = "" + message.number + "秒后重新发送";
                --message.number;
                if (message.number < 0) {
                    message.tips = "重新发送";
                    message.number = 60;
                    message.isDisabled = false;
                    window.clearInterval(interval);

                }
            }, 1000);

        }
        else {
            console.log('error submit!', fields)
        }



    })



}

// 定义校验规则 ref里面放着一个对象，一个key值，key值对应的数组
const rules = reactive(
    {

        password: [
            {
                //必填项
                required: true,
                //提示语
                message: '请输入你的密码',
                //触发条件的方式
                trigger: 'blur'
            },
            {

                validator: validatePass,
                min: 8,
                max: 30,

                message: "密码必须包含8-30位以上的大小写及数字",
                trigger: 'blur'
            }
        ],
        confirmPassword: [
            {

                //必填项
                required: true,
                //提示语
                message: '请输入相同密码',
                //触发条件的方式
                trigger: 'blur'
            },
            {
                validator: validatePass2,

                trigger: 'blur'

            }
        ],
        code: [
            {
                //必填项

                required: true,
                //提示语
                message: '请输入验证码',
                //触发条件的方式
                trigger: 'blur',

            }
        ]
    }
)

//验证码里的对象属性
const message = reactive({
    tips: '获取验证码',
    number: 60,
    display: false,
    isDisabled: false,

})


//注册
const submitForm = async (formEl: FormInstance | undefined) => {
    if (!formEl) return

    await formEl.validate((valid, fields) => {
        if (valid) {



            const logindata = Register(form.value)
            console.log('submit!')
            console.log(logindata)
        }
        else {
            console.log('error submit!', fields)
        }
    }



    )
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