import Layout from '../components/Layout.vue'
import { MailOutlined, LaptopOutlined, IdcardOutlined, ApartmentOutlined, DatabaseOutlined,HomeOutlined,TeamOutlined, SettingOutlined, UserOutlined, CreditCardOutlined } from '@ant-design/icons-vue';
import { h } from 'vue'
import axios from 'axios';
import axiosInstance from '../store/axiosInstance.js';
const permissionList = {
    
    desktop:['list'],// 工作台
    dashboard:['list'],//仪表盘
    detail:['新增用户','修改用户','删除用户',],// 普通用户管理
    role:['修改角色','删除角色','新增角色'],// 角色管理
    permission:['修改权限','删除权限','新增权限'],// 权限管理
    userrole:['修改用户角色','删除用户角色','新增用户角色'],// 用户角色管理
    userinfo:['list','编辑个人信息'],// 个人
    
  }


export const routes = [
    {
        path: '/',
        component: Layout,
        meta: { title: '首页', icon: () => h(HomeOutlined) },
        children: [
            {
                path: '/desktop',
                name: 'desktop',
                component: () => import('../views/desktop.vue'),
                meta: { title: '工作台', icon: () => h(CreditCardOutlined),Permissions:permissionList.desktop }
            },
            {
                path: '/dashboard',
                name: 'dashboard',
                component: () => import('../views/dashboard.vue'),
                meta: { title: '仪表盘', icon: () => h(LaptopOutlined),Permissions:permissionList.dashboard }
            }
        ]
    },
    {
        path: '/system',
        component: Layout,
       
        meta: { title: '系统管理',  icon: () => h(SettingOutlined) },
        children: [
            {
                path: '/user',
                name: 'user',
                component: () => import('../views/user.vue'),
                meta: { title: '用户管理', icon: () => h(UserOutlined) },
                children: [
                    {
                        path: '/detail',
                        name: 'detail',
                        component: () => import('../views/about.vue'),
                        meta: { title: '用户详情', icon: () => h(MailOutlined) ,Permissions:permissionList.detail}
                    }

                ]
            },
            {
                path: '/role',
                name: 'role',
                component: () => import('../views/role.vue'),
                meta: { title: '角色管理',icon: () => h(IdcardOutlined),Permissions:permissionList.role }
            },

            {
                path: '/permission',
                name: 'permission',
                component: () => import('../views/permission.vue'),
                meta: { title: '权限管理', icon: () => h(ApartmentOutlined) ,Permissions:permissionList.permission}
            },
            {
                path: '/userrole',
                name: 'userrole',
                component: () => import('../views/userrole.vue'),
                meta: { title: '用户角色', icon: () => h(ApartmentOutlined),Permissions:permissionList.userrole }
            },
            {
                path: '/menu',
                name: 'menu',
                component: () => import('../views/menu.vue'),
                meta: { title: '菜单管理', icon: () => h(DatabaseOutlined ) }
            },
            {
                path: '/userinfo',
                name: 'userinfo',
                component: () => import("../views/userinfo.vue"),
                meta: { title: '用户个人信息', hide: true,Permissions:permissionList.userinfo }
            },
            {
                path: '/about',
                name: 'about',
                component: () => import("../views/about.vue"),
                meta: { title: '关于我们',  icon: () => h(TeamOutlined)}
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
    },
    {
        path: '/register',
        component: () => import("../views/register.vue"),
        meta: { title: '注册', hide: true }
    }
]
