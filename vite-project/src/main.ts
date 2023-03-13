import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
createApp(App).use(router).mount('#app')
// 全局引入图标
import * as ElIcons from '@element-plus/icons'
const app = createApp(App)
for (const name in ElIcons) {
    app.component(name, (ElIcons as any)[name])
}

app.use(router).mount('#app')


