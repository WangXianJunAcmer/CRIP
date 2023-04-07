<script setup lang='ts'>
import { PropType, onMounted, ref, watchEffect } from 'vue'
import { ElDrawer, ElMessage, ElMessageBox, ElTable } from 'element-plus'
import { OrderItem, cartitem } from '../../api/types/type';
import { Getfromorder, Penment } from '../../api/shop';
import { cartStore } from '../../store'
import { watch } from 'fs';
import { createStructuralDirectiveTransform } from '@vue/compiler-core';
const parentBorder = ref(false)
const childBorder = ref(false)
const tishi = ref("支付")
onMounted(async () => {

  getdata()

  table.value = false;
})

const multipleTableRef = ref<InstanceType<typeof ElTable>>()

//支付
const zhifu = (orderId: string) => {


  ElMessageBox.confirm(
    '确定支付吗？',

    {
      confirmButtonText: 'OK',
      cancelButtonText: 'Cancel',

    }
  )
    .then(async () => {

      console.log("getdataorderid", orderId);
      const data = Penment(orderId).then(
        (response) => {
          console.log(response)
          getdata();
        }
      ).catch(error => {
        alert("已支付")
      })
      ElMessage({

        type: 'success',
        message: '支付成功',
      })
    })
    .catch(() => {
      ElMessage({
        type: 'info',
        message: '取消支付',
      })
    })










}



const table = ref(false)
const griddata = ref<OrderItem[]>([])


const getdata = async () => {
  table.value = true;
  const data = await Getfromorder()
  console.log("data", data);
  const orderdetail = cartStore();
  orderdetail.order = data.data;
  griddata.value = data.data;
  console.log("store---------", orderdetail.order)
}
</script>


<template>
  <button @click="getdata()" style="background:none; border: none;font: inherit; color: white; margin-left:10px;"
    class="cart-btn">
    我的订单
  </button>
  <el-drawer v-model="table" title="I have a nested table inside!" direction="rtl" size="60%">
    <template #header="{ close, titleId, titleClass }">
      <h1 :id="titleId" :class="titleClass" style="    font-size: 4rem;">我的订单</h1>

    </template>
    <el-table :data="griddata" style="background: white;">

      <el-table-column type="expand">
        <template #default="props">
          <div m="4">
            <el-table-column label="orderid" prop="orderId" />
            <el-table :data="props.row.orderLineItems" :border="childBorder">
              <el-table-column label="商品名称" prop="title" />
              <el-table-column label="价格" prop="price" />




            </el-table>
          </div>
        </template>
      </el-table-column>
      <el-table-column label="下单号" prop="orderLineItems[0].orderId" />
      <el-table-column label="下单时间" prop="createDateUTC" />
      <el-table-column label="下单地址" prop="user.address" />
      <el-table-column label="state" prop="state" />


      <el-table-column label="操作">
        <template #default={row}>
          <el-button v-if="row.state == 2" disabled>{{ '已支付' }}</el-button>
          <el-button v-else-if="row.state == 0" @click="zhifu(row.orderLineItems[0].orderId)">{{ '支付' }}</el-button>
          <el-button v-else-if="row.state == 4" @click="zhifu(row.orderLineItems[0].orderId)" disabled>{{ '已取消'
          }}</el-button>
          <el-button size="small" type="danger">删除</el-button>

        </template>
      </el-table-column>
    </el-table>
  </el-drawer>
</template>


<style lang='scss' scoped>
::v-deep .el-icon svg {
  color: white;
}
</style>