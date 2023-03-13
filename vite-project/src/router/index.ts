import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";


const routes:Array<RouteRecordRaw> = [

    {
        //地址和component是必传的
        path:'/Main',
        name:'Main',
        component:()=>import('../views/Main/index.vue'),    
    },
]



const router = createRouter (
    {
        history:createWebHistory(),
        routes:routes
    }
)
export default router