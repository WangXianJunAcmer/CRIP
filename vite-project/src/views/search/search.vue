<template>
  <div style="display: grid; place-items: center; height: 100vh;">
    <div class="display-flex" style="
    display: flex;
  justify-content: center;">
    <el-table
      :data="tabledata"
      border
      style="width: 100%; margin-top: 50px; "
    >
      <el-table-column prop="userName" label="姓名" width="180" />
      <el-table-column prop="email" label="联系方式" width="180" />
      <el-table-column label="咨询" width="120">
        <template #default="{ row }">
          <el-button @click="toquery(row.email)">咨询</el-button>
        </template>
      </el-table-column>
    </el-table>
<div  v-if="chuxian"

style=" width: 400px;
     margin-left: 22px;
    margin-top: 60px;">
  <el-input
   
      v-model="textarea"
      :rows="15"
      type="textarea"
     :placeholder="`您好${username},你想咨询什么信息？`"
      style="    width: 100%;"
    />
    <el-button
      type="primary"
     
      plain
      @click="goToConsult"
      >发送给{{ lianxi }}</el-button
    >
</div>

  </div>
  </div>
 
</template>

<script lang="ts" setup>

import { onMounted, reactive, ref } from "vue";
import router from "../../router";
import { defineComponent } from "vue";
import { RouteLocationRaw, useRouter } from "vue-router";
import { useTestStore  } from "../../store";
import { useTable } from "element-plus/es/components/table-v2/src/use-table";
import { reactify } from "@vueuse/shared";

interface Doctormessage{
  userName:string,
address:string,
email:string
}
const chuxian=ref(false)
const textarea = ref("");

const username=ref('')
const lianxi=ref('')
const tabledata=ref<Doctormessage[]>([])
const toquery=(email:string)=>{
  lianxi.value=email
chuxian.value=true;
}
const goToConsult = () => {
 
  router.push('/consult');
};


onMounted(async()=>{


  const doctorall=useTestStore()
  tabledata.value=doctorall.doctorList

username.value=doctorall.username
 
 
})
</script>
<style lang="scss" scoped>
.display-flex {
  display: flex;
  justify-content: center;
}
</style>
