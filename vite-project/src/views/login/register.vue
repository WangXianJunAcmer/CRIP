<template>
  <div class="reg-page">
    <form :model="form">
      <h1>注册</h1>
      <input placeholder="请输入用户名" type="text" v-model="form.username" />
      <input placeholder="请输入邮箱" type="text" v-model="form.email" />
      <input placeholder="请输入密码" type="password" v-model="form.password" />
      <input
        placeholder="请确认密码"
        type="password"
        v-model="form.confirmPassword"
      />
      <input placeholder="请输入地址" type="text" v-model="form.address" />
      <div>
        <input
          type="text"
          placeholder="验证码"
          style="width: 50%"
          v-model="form.code"
        />
        <el-button
          :type="message.type"
          :disabled="message.isDisabled"
          class="sendEmailButton"
          style="float: right; height: 40px"
          @click="sendEmailToRegister"
          >{{ message.tips }}</el-button
        >
      </div>
    </form>
    <div class="bt">
      <button style="width: 95%" @click="submitForm">注册</button>
    </div>
    <RouterLink to="/Login" style="text-decoration: none"
      >已有账号，返回登录
    </RouterLink>
    <div style="color: red">
      {{ errorMessage }}
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import { useRouter } from "vue-router";
import router from "../../router";

export default defineComponent({
  data() {
    return {
      form: {
        username: "",
        email: "",
        password: "",
        confirmPassword: "",
        address: "",
        code: "",
      },
      message: {
        tips: "发送验证码",
        isDisabled: false,
        type: "primary",
      },
      countdown: 60, // 倒计时60秒
      errorMessage: "", // 校验错误信息
    };
  },
  methods: {
    validateForm() {
      if (!this.form.username) {
        this.showError("用户名不能为空");
        return false;
      }
      if (!this.form.email) {
        this.showError("邮箱不能为空");
        return false;
      } else if (!this.isEmail(this.form.email)) {
        this.showError("请输入正确的邮箱格式");
        return false;
      }
      if (!this.form.password) {
        this.showError("密码不能为空");
        return false;
      } else if (
        !/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[\s\S]{8,30}$/.test(this.form.password)
      ) {
        this.showError("密码必须包含大小写字母和数字，长度在8到30位之间");
        return false;
      }
      if (!this.form.confirmPassword) {
        this.showError("请确认密码");
        return false;
      }
      if (this.form.password !== this.form.confirmPassword) {
        this.showError("两次密码输入不一致");
        return false;
      }
      if (!this.form.address) {
        this.showError("地址不能为空");
        return false;
      }
      if (!this.form.code) {
        this.showError("验证码不能为空");
        return false;
      }
      return true;
    },
    isEmail(value: string) {
      const reg = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
      return reg.test(value);
    },
    showError(message: string) {
      this.errorMessage = message; // 设置错误信息
    },
    submitForm() {
      if (!this.validateForm()) {
        return;
      }

      // 登录成功后跳转到 Main 页面
      router.push("/Main");
      // 校验通过，进行后续操作
      // ...
    },
    sendEmailToRegister() {
      // 首字母小写
      // 发送邮件验证码
      // ...

      // 倒计时60秒
      this.message.tips = `${this.countdown}s后重试`;
      this.message.isDisabled = true;
      const timer = setInterval(() => {
        this.countdown--;
        if (this.countdown <= 0) {
          clearInterval(timer);
          this.message.tips = "发送验证码";
          this.message.isDisabled = false;
          this.countdown = 60;
        } else {
          this.message.tips = `${this.countdown}s后重试`;
        }
      }, 1000);
    },
  },
});
</script>
<style>
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
