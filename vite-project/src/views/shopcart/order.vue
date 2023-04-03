<script setup lang='ts'>
import { onMounted, ref, watchEffect } from 'vue'
import { ElDrawer} from 'element-plus'
import { OrderItem } from '../../api/types/type';
import { Getfromorder } from '../../api/shop';

onMounted(async ()=>{
   
    getdata()
   

  })
    





const table = ref(false)
const griddata=ref<OrderItem[]>([])
const gridData = [
  {
    date: '2016-05-02',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-04',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-01',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },
  {
    date: '2016-05-03',
    name: 'Peter Parker',
    price:30
  },

]

const getdata=async()=>{
    const data= await Getfromorder()
    console.log(data);
    griddata.value=data.data;

    console.log(griddata.value)
    }
</script>


<template>
<button 
@click="table = true"
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
      <el-table-column property="createDateUTC" label="下单时间" width="150" />
      <el-table-column property="id" label="名字" width="200" />
      <el-table-column property="userId" label="价格" />
    </el-table>
  </el-drawer>
</template>


<style lang='scss' scoped>

</style>