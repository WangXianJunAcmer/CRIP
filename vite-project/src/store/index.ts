import { defineStore } from "pinia";
import { Names } from "./store-name";
export const useTestStore=defineStore(Names.User,
    {
        //pinia里面必须是箭头函数才返回对象
        state:()=>{
            return{
                name:'',
                token:''
            }
        },
        //类似计算的 有缓存
        getters:{

        },
        //类似methods 提交state
        actions:{
          
            setName(user:string,token:string)
            {
                this.name=user
                this.token=token
            }


        }
        

    })