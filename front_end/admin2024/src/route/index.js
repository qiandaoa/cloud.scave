import { createRouter, createWebHistory } from 'vue-router'
import { routes } from './staticRoutes'

export const router = createRouter({
    history: createWebHistory(),
    routes
})
router.beforeEach((to, from, next) => {
    // 从store中获取用户状态，例如登录状态或token
    const token = localStorage.getItem('token');
    const username=localStorage.getItem('username');
    // console.log('username:', username);
    
    // console.log('token:', token); // 添加调试语句

    // 如果用户尝试访问登录页面，直接放行
    if (to.path === '/login') {
        next();
        return;
    }
    if(to.path==='/register'){
        next();
        return
    }
    // 如果用户未登录，重定向到登录页面
    if (!token) {
        next('/login');
    } else {
        // 如果用户已登录，允许访问
        next();
    }
    
})
export default router