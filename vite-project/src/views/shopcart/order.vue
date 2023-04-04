<script setup lang='ts'>
import { PropType, onMounted, ref, watchEffect } from 'vue'
import { ElDrawer} from 'element-plus'
import { OrderItem, cartitem } from '../../api/types/type';
import { Getfromorder } from '../../api/shop';
import {cartStore} from '../../store'
import { watch } from 'fs';
import { createStructuralDirectiveTransform } from '@vue/compiler-core';
const parentBorder = ref(false)
const childBorder = ref(false)
onMounted(async ()=>{
  
    getdata()
   
    table.value=false;
  })

 
 


const table = ref(false)
const griddata=ref<OrderItem[]>([])


const getdata=async()=>{
  table.value=true;
    const data= await Getfromorder()
    console.log(data);
    griddata.value=data.data;

    console.log(griddata.value)
    }
</script>


<template>
<button 

@click="getdata()"
style="background: none;
border: none;
font: inherit;
color: white;
margin-left: 10px;
"  class="cart-btn">
          

       我的订单
        </button>
        <el-drawer
    v-model="table"
    title="I have a nested table inside!"
    direction="rtl"
    size="40%"
  >
  <template #header="{ close, titleId, titleClass }">
      <h1 :id="titleId" :class="titleClass" style="    font-size: 4rem;">我的订单</h1>
      
    </template>
    <el-table :data="griddata" style="background: white;">
      <el-table-column type="expand">
      <template #default="props">
        <div m="4">
       
          <el-table :data="props.row. orderLineItems"  :border="childBorder">
            <el-table-column label="商品名称" prop="title" />
            <el-table-column label="价格" prop="price" />
          
    <el-table-column label="操作">
      <template #default="scope">
        <el-button size="small" 
          >支付</el-button
        >
        <el-button
          size="small"
          type="danger"
        
          >删除</el-button
        >
   
      </template>
    </el-table-column>
            
            
          </el-table>
        </div>
      </template>
    </el-table-column>
    
    <el-table-column label="下单时间" prop="createDateUTC" />
    <el-table-column label="下单地址" prop="user.address" />
    
    </el-table>
  </el-drawer>
</template>


<style lang='scss' scoped>
::v-deep .el-icon svg {
   color: white;
}

</style>