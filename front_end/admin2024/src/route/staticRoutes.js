import Layout from '../components/Layout.vue'
import { MailOutlined, CalendarOutlined, AppstoreOutlined,  } from '@ant-design/icons-vue';
export const routes = [
    {
        path: '/',
        component: Layout,
        meta: { title: '首页', icon: '' },
        children: [
            {
                path: '/desktop',
                component: () => import('../views/desktop.vue'),
                meta: { title: '工作台', icon:'AppstoreOutlined'}
            },
            {
                path: '/dashboard',
                component: () => import('../views/dashboard.vue'),
                meta: { title: '仪表盘', icon:' AppstoreOutlined'}
            }
        ]
    },
    {
        path: '/system',
        component: Layout,
        meta: { title: '系统管理', icon: 'AppstoreOutlined' },
        children: [
            {
                path: '/user',
                component: () => import('../views/user.vue'),
                meta: { title: '用户管理',inco:'CalendarOutlined'},
                children:[
                    {
                    path:'/detail',
                    component:()=>import('../views/about.vue'),
                    meta:{title:'用户详情'}
                    },
                    {
                        path:'/ss',
                        component:()=>import('../views/ss.vue'),
                        meta:{title:'ss'}
                        }
                ]
            },
            {
                path: '/role',
                component: () => import('../views/role.vue'),
                meta: { title: '角色管理',icon:'AppstoreOutlined'}
            },
        
            {
                path: '/permission',
                component: () => import('../views/permission.vue'),
                meta: { title: '权限管理',icon:'MailOutlined' }
            },
            {
                path: '/userinfo',
                component: () => import("../views/userinfo.vue"),
                meta: { title: '用户个人信息', hide: true }
            },
            
      

]   },
    {
        path: '/login',
        component: () => import("../views/login.vue"),
        meta: { title: '登录', hide: false }
    },
    {
        path: '/:pathMatch(.*)*',
        component: () => import("../views/ex404.vue"),
        meta: { title: 'notFound', hide: true }
    },
   {
        path: '/register',
        component: () => import("../views/register.vue"),
        meta: { title: '注册', hide: true }
   }
]