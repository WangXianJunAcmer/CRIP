import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import AutoImport from 'unplugin-auto-import/vite'
import path from "path"
import Components from 'unplugin-vue-components/vite'
import { ElementPlusResolver } from 'unplugin-vue-components/resolvers'


// https://vitejs.dev/config/
export default defineConfig({
 //设置端口号 之前是3000 我现在改成3001
 server:{
  port:3002,
  proxy: {
    // 字符串简写写法
    // '/foo': 'http://localhost:4567',
    // 选项写 
    '/api': {


      //目标地址
      target: 'https://localhost:7191',
         // 这里新增一个配置
      secure: false,
         // 新增结束

      changeOrigin: true,
      // rewrite: (path) => path.replace(/^\/api/, '')
    },
   
    // 使用 proxy 实例
    
  }
  
},
    //让node下的api接受ts环境 vite添加别名
    resolve:{
      alias:{
        "@":path.resolve(__dirname,"src"),
        "com":path.resolve(__dirname,"src/components")
      }
    },
  plugins: [
    vue(),
    // ...
    AutoImport({
      resolvers: [ElementPlusResolver()],
    }),
    Components({
      resolvers: [ElementPlusResolver()],
    }),
  ],})
