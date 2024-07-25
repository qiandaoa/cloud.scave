import { createApp } from 'vue';
import App from './App.vue';
import axios from 'axios';

// 以下完整引入antdv
import antdv from 'ant-design-vue';
import 'ant-design-vue/dist/reset.css';

// 引入路由模块
import { router } from './route';

import { pinia } from './store';


// 使用App组件创建vue实例
let app = createApp(App);


// 使用路由中间件、antdv组件库
app.use(pinia).use(router).use(antdv).mount('#app');
