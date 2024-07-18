import { createRouter, createWebHistory } from 'vue-router'
import { routes } from './staticRoutes'

export const router = createRouter({
    history: createWebHistory(),
    routes
})
// 登录路由导航 等待引入
// router.beforeEach((to,from,next)=>{
//     if(to.path==='/login'){
//         next();
//         return
//     }
// })

// // 从store中获取用户状态，例如登录状态或token
// const userInfo = localStorage.getItem('userInfo')

// if(!userInfo){
//     next('/login')
// }else{
//     next()
// }
// export default router