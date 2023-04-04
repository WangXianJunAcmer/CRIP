<script setup lang='ts'>
import { onMounted, ref } from 'vue'
import { ElTable } from 'element-plus'
import {

  Delete,

} from '@element-plus/icons-vue'
import Order from './order.vue'
import { cartStore, useTestStore } from '../../store';
import { cartitem } from '../../api/types/type';
import router from '../../router';


import { ElMessage, ElMessageBox } from 'element-plus'
import type { Action } from 'element-plus'

const open = () => {

}


interface Drugscart {
  id: string,
  goodsId: string,
  cartId: string,
  orderId: string,
  title: string,
  price: number

}

const username = ref('');

onMounted(async () => {
  const name = useTestStore();
  username.value = name.username
  const cartlist = cartStore();
  await cartlist.GetAllCartItems();
  console.log(cartlist.cart)
  tableDatalist.value = cartlist.cart
  console.log(tableDatalist.value)

});



const tableDatalist = ref<cartitem[]>([])
//回到主页面
const toHome = () => {
  router.push("/Main")
}




const toggleAllSelection = () => {
  const table = multipleTableRef.value
  if (table) {
    const selected = multipleSelection.value
    if (selected.length) {

      toggleSelection(selected)

    } else {

      table.toggleAllSelection()
    }
  }
}



const multipleTableRef = ref<InstanceType<typeof ElTable>>()
const multipleSelection = ref<Drugscart[]>([])
const toggleSelection = (rows?: Drugscart[]) => {
  if (rows) {
    rows.forEach((row) => {
      // TODO: improvement typing when refactor table
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      // @ts-expect-error
      multipleTableRef.value!.toggleRowSelection(row, undefined)
    })
  } else {
    multipleTableRef.value!.clearSelection()
  }
}
const handleSelectionChange = (val: Drugscart[]) => {
  multipleSelection.value = val
  //选择好的行值
  console.log("选择好的行值", multipleSelection.value);
}
//批量删除
const SelectDelet = async () => {
  const selected = multipleSelection.value
  console.log("selectaaaaaaa", selected)
  // 将row.id组成一个字符串数组
  const idList = selected.map((item: { id: { toString: () => any; }; }) => item.id.toString());
  console.log("selectaaaaaaa", idList)
  if (selected.length) {
    // selected.forEach((row) => {
    //   const index = tableDatalist.value.indexOf(row)
    //   console.log(" const index = tableDatalist.value.indexOf(row)",index)

    //   if (index !== -1) {
    //     const cartlist = cartStore();
    //     console.log("idddddd",row.id)
    //   cartlist.removeFromCart(row.id)
    //    // tableDatalist.value.splice(index, 1)
    //   }
    // })
    //最后调用 toggleSelection 函数清空被选中的行数据
    const piliangdelet = cartStore();
    await piliangdelet.removeMultipleFromCart(idList);
    toggleSelection()

    await piliangdelet.GetAllCartItems();
    console.log(piliangdelet.cart)
    tableDatalist.value = piliangdelet.cart
  }
}


//删除某行
const handleDelete = async (index: number, row: Drugscart) => {

  //tableDatalist.value.splice(index, 1)

  const cartlist = cartStore();
  await cartlist.removeFromCart(row.id)
  await cartlist.GetAllCartItems();
  console.log(cartlist.cart)
  tableDatalist.value = cartlist.cart
  console.log("index", index, row.id)
}
// 批量下单
const Selectcheckout = async () => {

  ElMessageBox.confirm(
    '确定继续下单是吗？',
   
    {
      confirmButtonText: 'OK',
      cancelButtonText: 'Cancel',
      
    }
  )
    .then(async() => {

      const selected = multipleSelection.value
      console.log("selectaaaaaaa", selected)
      // 将row.id组成一个字符串数组
      const idList = selected.map((item: { id: { toString: () => any; }; }) => item.id.toString());
      console.log("selectaaaaaaa", idList)
      const piliangcheckout = cartStore();
      if (selected.length) {
        if (selected.length === tableDatalist.value.length) {
          await Allcheckout();

        }

        else {

          await piliangcheckout.checkoutMultipleFromCart(idList);

        }


        await piliangcheckout.GetAllCartItems();
        console.log(piliangcheckout.cart)
        tableDatalist.value = piliangcheckout.cart
        toggleSelection()

      }
      
      ElMessage({
          
        type: 'success',
        message: '下单成功',
      })
    })
    .catch(() => {
      ElMessage({
        type: 'info',
        message: '取消下单',
      })
    })



}
//全部下单
const Allcheckout = async () => {



  const piliangcheckout = cartStore();


  await piliangcheckout.checkoutAllFromcart();



}

</script>


<template>
  <header>

    <el-icon :size="35" @click="toHome" style="cursor: pointer;">
      <House />
    </el-icon>
    <Order  />
  </header>
  <main style="display: flex;">
    <div class="left">
      <div class="user-info">
        <img src="avatar.png" alt="avatar">
        <span>{{ username }}</span>
      </div>
    </div>
    <div class="right">
      <div class="item-drug">

        <el-table :show-header="false" ref="multipleTableRef" :data="tableDatalist" style=" width: 90%;    margin-top: 30px;
      height: 80%;
     " @selection-change="handleSelectionChange" row-class-name="table-row">
          <el-table-column type="selection" width="55" />

          <el-table-column property="title" />
          <el-table-column property="price"  show-overflow-tooltip />
          <el-table-column align="right" width="120">
            <template #header></template>
            <template #default="scope">
              <el-button size="small" type="danger" @click="handleDelete(scope.$index, scope.row)">
                Delete
              </el-button>
            </template>
          </el-table-column>

          <!-- 将全选按钮放置在表格的最后一列 -->

        </el-table>

        <div style=" margin-top: 20px;
      width: 70%;
      display: flex;
      justify-content: space-around;
  
    ">
          <div> <el-button @click="toggleAllSelection">全选</el-button>

            <el-button type="danger" @click="SelectDelet" :icon="Delete" circle />
          </div>


          <el-button type="primary" @click="Selectcheckout">下单</el-button>

        </div>


      </div>

    </div>






  </main>
</template>


<style lang='scss' scoped>
header {
  display: flex;
  justify-content: start;
  align-items: center;
  height: 50px;
  padding: 10px 20px;

  /* box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); */

  border-bottom: 4px dashed #8B4C4C;
}

.left {
  width: 12%;

  padding: 20px;
  display: flex;
  justify-content: flex-end;


  .user-info {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;

    width: 140px;
    height: 180px;
    border: 3px solid black;
    border-radius: 45px 45px 42px 42px;
    box-shadow: 0px 0px 10px 1px #09090A;

    img {
      border-radius: 5px 5px 5px 5px;
      border: 1px solid black;
      box-shadow: 0px 0px 5px 1px #D0B497;
      width: 90px;
      height: 90px;
      background-color: #EF9F46;
    }

    span {
      font-size: 20px;
      color: white;
      margin-top: 10px;
    }
  }
}

.right {
  width: 88%;
  /* padding: 17px; */
  box-sizing: content-box;
  /* padding-top: 30px; */
  margin-top: 85px;
  padding-right: 81px;

  .item-drug {
    background-color: #AB7E50;
    height: calc(100vh - 175px);
    border: 2px solid black;
    border-radius: 25px 25px 25px 25px;
    box-shadow: 0px 0px 8px 2px #333;

    display: flex;
    flex-direction: column;
    align-items: center;


  }
}


::v-deep .el-table--border .el-table__inner-wrapper::after,
.el-table--border::after,
.el-table--border::before {


  background-color: #AB7E50;


}

::v-deep .el-table--enable-row-hover .el-table__body tr:hover>td.el-table__cell {
  background-color: #46628d;
}

::v-deep .el-table__inner-wrapper::before {
  background-color: #AB7E50;
}

::v-deep .el-table__border-left-patch {
  background-color: #AB7E50;
}


::v-deep .el-table {
  border: none;
  background-color: #AB7E50;

  .el-table__body {
    color: white;
    border-spacing: 0px 10px;

    // border-collapse: collapse;
    tr {
      height: 75px;
      background-color: #7a4d4d;
      border: 2px solid black !important;

      td {
        border: none;
      }
    }
  }

}
</style>