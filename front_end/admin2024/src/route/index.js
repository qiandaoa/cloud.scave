import { createRouter, createWebHistory } from 'vue-router'
import { routes} from './staticRoutes'

export const router = createRouter({
    history: createWebHistory(),
    routes
})
router.beforeEach((to, from, next) => {
    // 从store中获取用户状态，例如登录状态或token
    const token = localStorage.getItem('token');
    const username=localStorage.getItem('username');
    const role = localStorage.getItem('role')
    if (to.matched.some(record => record.meta.requiresAuth)) {
        // 检查用户是否已登录
        if (role) {
          // 如果用户已登录，继续执行 `checkRole` 函数
         
        } else {
          // 如果用户未登录，则重定向到登录页面
          next('/login');
        }
      } else {
        next(); // 如果不需要权限验证，直接进入页面
      }
})
export default router