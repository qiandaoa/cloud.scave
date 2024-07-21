import Layout from '../components/Layout.vue'
import { MailOutlined, LaptopOutlined ,IdcardOutlined, ApartmentOutlined, HomeOutlined,SettingOutlined,UserOutlined,CreditCardOutlined  } from '@ant-design/icons-vue';
import{h} from 'vue'
export const routes = [
    {
        path: '/',
        component: Layout,
        meta: { title: '首页', icon: ()=>h(HomeOutlined) },
        children: [
            {
                path: '/desktop',
                component: () => import('../views/desktop.vue'),
                meta: { title: '工作台',icon: ()=>h(CreditCardOutlined) }
            },
            {
                path: '/dashboard',
                component: () => import('../views/dashboard.vue'),
                meta: { title: '仪表盘',icon: ()=>h(LaptopOutlined)}
            }
        ]
    },
    {
        path: '/system',
        component: Layout,
        meta: { title: '系统管理', icon: ()=>h(SettingOutlined) },
        children: [
            {
                path: '/user',
                component: () => import('../views/user.vue'),
                meta: { title: '用户管理',icon: ()=>h(UserOutlined)},
                children:[
                    {
                    path:'/detail',
                    component:()=>import('../views/about.vue'),
                    meta:{title:'用户详情',icon: ()=>h(MailOutlined)}
                    }
                    
                ]
            },
            {
                path: '/role',
                component: () => import('../views/role.vue'),
                meta: { title: '角色管理',icon: ()=>h(IdcardOutlined)}
            },
        
            {
                path: '/permission',
                component: () => import('../views/permission.vue'),
                meta: { title: '权限管理',icon: ()=>h(ApartmentOutlined) }
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
        meta: { title: '登录', hide: true }
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