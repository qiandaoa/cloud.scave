<template>
    <a-layout>
        <a-layout-sider>
            <SildeMenu>888888888888</SildeMenu>
        </a-layout-sider>
        <a-layout>
            <a-layout-header :style="headerStyle">
                <HeaderContent></HeaderContent>
            </a-layout-header>
            <a-layout-content :style="contentStyle">
                <router-view></router-view>
            </a-layout-content>
        </a-layout>
    </a-layout>
</template>
<script setup>
import SildeMenu from './SildeMenu.vue';
import HeaderContent from './HeaderContent.vue';
import { h, ref, reactive } from 'vue'
import {
    MailOutlined,
    CalendarOutlined,
    AppstoreOutlined,
    SettingOutlined,
} from '@ant-design/icons-vue';
let theme = ref('dark');
let headerStyle = reactive({ background: '#fff', padding: 0 })
let contentStyle = reactive({ margin: '24px 16px', padding: '24px', background: '#fff', minHeight: '280px' })

let item = reactive([
    {
        key: 1,
        label: '菜单1',
        title: '单单1',
        icon: () => h(MailOutlined)

    },
    {
        key: 2,
        label: '菜单2',
        title: '单单2',
        icon: () => h(SettingOutlined),
        children: [
            {
                key: '2-1',
                label: '菜单2-1',
                title: '菜单2-1'

            },
            {
                key: '2-2',
                label: '菜单2-2',
                title: '菜单2-2'

            },
            {
                key: '2-3',
                label: '菜单2-3',
                title: '菜单2-3'

            },
            {
                key: '2-4',
                label: '菜单2-4',
                title: '菜单2-4'

            },
        ]
    },
    {
        key: 3,
        label: '菜单3',
        title: '单单3',
        icon: () => h(CalendarOutlined),
    },
])

</script>
<style>
#components-layout-demo-custom-trigger .trigger {
    font-size: 18px;
    line-height: 64px;
    padding: 0 24px;
    cursor: pointer;
    transition: color 0.3s;
}

#components-layout-demo-custom-trigger .trigger:hover {
    color: #1890ff;
}

#components-layout-demo-custom-trigger .logo {
    height: 32px;
    background: rgba(255, 255, 255, 0.3);
    margin: 16px;
}

.site-layout .site-layout-background {
    background: #fff;
}

.ant-layout-sider {
    height: 100vh;
}
</style>