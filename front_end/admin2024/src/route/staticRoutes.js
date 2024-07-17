import Layout from '../components/Layout.vue'
import { MailOutlined, CalendarOutlined, AppstoreOutlined, SettingOutlined } from '@ant-design/icons-vue';
export const routes = [
    {
        path: '/',
        component: Layout,
        meta: { title: '首页', icon: '' },
        children: [
            {
                path: '/desktop',
                component: () => import('../views/desktop.vue'),
                meta: { title: '工作台', icon:'SettingOutlined'}
            },
            {
                path: '/dashboard',
                component: () => import('../views/dashboard.vue'),
                meta: { title: '仪表盘', icon: 'SettingOutlined' }
            }
        ]
    },
    {
        path: '/system',
        component: Layout,
        meta: { title: '系统管理', icon: SettingOutlined },
        children: [
            {
                path: '/system/user',
                component: () => import('../views/user.vue'),
                meta: { title: '用户管理' },
                // children:[
                //     {
                //     path:'/system/user/detail',
                //     component:()=>import('../views/about.vue'),
                //     meta:{title:'用户详情'}
                //     }
                // ]
            },
            {
                path: '/system/role',
                component: () => import('../views/role.vue'),
                meta: { title: '角色管理' }
            },
            {
                path: '/system/permission',
                component: () => import('../views/permission.vue'),
                meta: { title: '权限管理' }
            },
        ]

    },
    {
        path: '/login',
        component: () => import("../views/login.vue"),
        meta: { title: '登录', hide: true }
    },
    {
        path: '/:pathMatch(.*)*',
        component: () => import("../views/ex404.vue"),
        meta: { title: 'notFound', hide: true }
    }
]