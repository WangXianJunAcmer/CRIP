import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";


const routes: Array<RouteRecordRaw> = [

    {
        //地址和component是必传的
        path: '/Main',
        name: 'Main',
        component: () => import('../views/Main/index.vue'),
    },
    {
        //地址和component是必传的
        path: '/test',
        name: 'test',
        component: () => import('../views/test.vue'),
    },


    {
        path: '/login',
        name: 'Login',
        component: () => import('@/views/login/Login.vue'),

    },
    {
        path: '/Reg',
        name: 'Reg',
        component: () => import('@/views/login/register.vue'),

    },

    {
        path: '/shop',
        name: 'shop',
        component: () => import('@/views/shop/index.vue'),

    },
    {
        path: '/cart',
        name: 'cart',
        component: () => import('@/views/shopcart/index.vue'),

    },
    {
        path: "/consult",
        name: "consult",
        component: () => import("@/views/consult/index.vue"),
      },
    



]



const router = createRouter(
    {
        history: createWebHistory(),
        routes: routes
    }
)
export default router