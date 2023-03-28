import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createPinia } from 'pinia'


// 全局引入图标
import * as ElIcons from '@element-plus/icons'
const app = createApp(App)
for (const name in ElIcons) {
    app.component(name, (ElIcons as any)[name])
}

const store=createPinia();

app.use(router).use(store).mount('#app')


