import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import { useTestStore } from "../store";

const routes: Array<RouteRecordRaw> = [
  {
    //地址和component是必传的
    path: "/Main",
    name: "Main",
    component: () => import("../views/Main/index.vue"),
  },
  {
    //地址和component是必传的
    path: "/test",
    name: "test",
    component: () => import("../views/test.vue"),
  },

  {
    path: "/login",
    name: "Login",
    component: () => import("@/views/login/Login.vue"),
  },
  {
    path: "/Reg",
    name: "Reg",
    component: () => import("@/views/login/register.vue"),
  },

  {
    path: "/shop",
    name: "shop",

    component: () => import("@/views/shop/index.vue"),
  },
  {
    path: "/cart",
    name: "cart",
    meta: { requiresAuth: true },
    component: () => import("@/views/shopcart/index.vue"),
  },
  {
    path: "/search",
    name: "search",
    component: () => import("@/views/search/search.vue"),
  },
  {
    path: "/consult",
    name: "consult",
    component: () => import("@/views/consult/index.vue"),
  },
  {
    path: "/doctor",
    name: "doctor",
    component: () => import("@/views/consult/doctor.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

router.beforeEach((to, from) => {
  // 而不是去检查每条路由记录

  // to.matched.some(record => record.meta.requiresAuth)
  // 这里需要空的
  const Test = useTestStore();
  const { role } = Test;
  // console.log('name is')
  // console.log(name)
  if (to.meta.requiresAuth && !role) {
    // console.log('to.meta.requiresAuth')
    // console.log(useTestStore.name+'name!!!!!!11')
    // 此路由需要授权，请检查是否已登录
    // 如果没有，则重定向到登录页面
    return {
      path: "/login",
      // 保存我们所在的位置，以便以后再来

      query: { redirect: to.fullPath },
    };
  }
});
export default router;
