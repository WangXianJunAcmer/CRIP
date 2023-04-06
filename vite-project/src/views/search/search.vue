<template>
  <div class="display-flex">
    <el-table
      :data="tableData"
      border
      style="width: 35%; margin-top: 50px; margin-left: 100px"
    >
      <el-table-column prop="name" label="姓名" width="180" />
      <el-table-column prop="email" label="联系方式" width="180" />
      <el-table-column label=" " width="120">
        <template #default="{ row }">
          <el-button>{{ row.tag }}</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-input
      v-model="textarea"
      :rows="15"
      type="textarea"
      placeholder="您好，想咨询什么信息？"
      style="width: 30%; margin-left: 120px; margin-top: 40px"
    />
    <el-button
      type="primary"
      style="margin-top: 327px; margin-left: 30px"
      plain
      @click="goToConsult"
      >发送</el-button
    >
  </div>
</template>
<script lang="ts" setup>
import { ref } from "vue";
import router from "../../router";
import { defineComponent } from "vue";
import { RouteLocationRaw, useRouter } from "vue-router";

const textarea = ref("");

const tableData = [
  {
    email: "QWE@QQ.COM",
    name: "QWE",
    tag: "咨询",
  },
  {
    email: "ASD@QQ.COM",
    name: "ASD",
    tag: "咨询",
  },
  {
    email: "AXC@QQ.COM",
    name: "AXC",
    tag: "咨询",
  },
  {
    email: "ZZZ@QQ.COM",
    name: "ZZZ",
    tag: "咨询",
  },
];

const goToConsult = () => {
  const location: RouteLocationRaw = {
    path: "../consult",
  };
  router.push(location);
};
</script>
<style lang="scss" scoped>
.display-flex {
  display: flex;
}
</style>
