import { createApp, toRaw } from 'vue'
import App from './App.vue'
import router from './router'
import { createPinia, PiniaPluginContext } from 'pinia'


// 全局引入图标
import * as ElIcons from '@element-plus/icons'








type Options = {
    key?: string
}

const _piniaKey_: string = 'wsn'

//这是将实例存到Local storage里面方法 
const setStorage = (key: string, value: any) => {
    //JSON.stringify() 方法用于将 JavaScript 值转换为 JSON 字符串。
    // JSON.stringify({x: 5, y: 6});
    // "{"x":5,"y":6}"
    localStorage.setItem(key, JSON.stringify(value))
}


const getStorage = (key: string) => {
    return localStorage.getItem(key) ? JSON.parse(localStorage.getItem(key) as string) : {}
}

// export const DeletStorage=(key: string)=>{
//     localStorage.removeItem(key)
// }

const piniaPlugin = (options: Options) => {

    //函数柯里化
    return (context: PiniaPluginContext) => {
        //将store解构出来
        const { store } = context


        store.$subscribe(() => {
            console.log('change')
            setStorage(`${options?.key ?? _piniaKey_}-${store.$id}`, toRaw(store.$state))
            // console.log(store.$state)
        })


        /*
         //将容器里面的数据导出来 
        */
        const data = getStorage(`${options?.key ?? _piniaKey_}-${store.$id}`)

        console.log(data)
        // 再返回store
        return {

            //结构
            ...data,

        }


        console.log("输出\n")
        console.log(store, 'context')
    }

}

const store = createPinia()

store.use(piniaPlugin(
    {
        key: 'wsnnnnn'
    }
))


const app = createApp(App)
for (const name in ElIcons) {
    app.component(name, (ElIcons as any)[name])
}


app.use(router).use(store).mount('#app')


