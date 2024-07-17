import Layout from '../components/Layout.vue'

export const routes = [
    {
        path: '/',
        component: Layout,
        meta: { title: '首页', icon: '' },
        children: [
            {
                path: '/dashboard',
                component: () => import('../views/dashboard.vue'),
                meta: { title: '仪表盘', icon: '' }
            }
        ]
    },
    {
        path: '/system',
        component: Layout,
        meta: { title: '系统管理', icon: '' },
        children: [
            {
                path: '/system/user',
                component: () => import('../views/user.vue'),
                meta:{title:'用户管理'}
            },
            {
                path: '/system/role',
                component: () => import('../views/role.vue'),
                meta:{title:'角色管理'}
            },
            {
                path: '/system/permission',
                component: () => import('../views/permission.vue'),
                meta:{title:'权限管理'}
            },
        ]

    },
    {
        path: '/login',
        component: () => import("../views/login.vue"),
        meta: { title: '' }
    },
    {
        path:'/:pathMatch(.*)*',
        component: () => import("../views/ex404.vue"),
        meta:{title:'notFound'}
    }
]