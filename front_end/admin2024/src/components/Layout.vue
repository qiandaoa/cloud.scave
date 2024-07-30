<template>
    <a-layout >
        <a-layout-sider :collapsed="isSiderCollapsed" style="height: auto;">
            <div class="sider-content">
                <a-button type="primary" class="collapse-button" @click="toggleSiderCollapse">
                    <MenuUnfoldOutlined  v-if="isSiderCollapsed" style="font-size: 20px;" />
                    <MenuFoldOutlined  style="font-size: 20px;" v-else />
                </a-button>
                <SildeMenu :isSiderCollapsed="isSiderCollapsed"></SildeMenu>
            </div>
        </a-layout-sider>
        <a-layout>
            <div class="headerstyle">
                <a-layout-header :style="headerStyle">
                    <HeaderContent></HeaderContent>
                </a-layout-header>
            </div>
            <a-layout-content :style="contentStyle">
                <router-view></router-view>
            </a-layout-content>
        </a-layout>
    </a-layout>
</template>
<script setup>
import SildeMenu from './SildeMenu.vue';
import HeaderContent from './HeaderContent.vue';
import { h, ref, reactive, watch } from 'vue'
import {
    MenuUnfoldOutlined,
    MenuFoldOutlined 
} from '@ant-design/icons-vue';
let theme = ref('dark');
let headerStyle = reactive({ background: '#fff', padding: 0 })
let contentStyle = reactive({ margin: '24px 16px', padding: '24px', background: '#fff', minHeight: '280px' })


let isSiderCollapsed = ref(false); // 控制sider折叠状态

// // 动态调整contentStyle的paddingLeft
// watch(isSiderCollapsed, (newVal) => {
//     // contentStyle.paddingLeft = '50px';

// });
const toggleSiderCollapse = () => {
    isSiderCollapsed.value = !isSiderCollapsed.value;
};

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

.sider-content {
    display: flex;
    flex-direction: column;
    height: 100vh;
    padding-top: 16px;
    /* 添加顶部填充以避免按钮与顶部边界重叠 */
}

.collapse-button {
    /* margin-bottom: 16px; */
    background-color: transparent   ;
    border: 1px solid rgb(0, 21, 41);
    /* 为按钮与菜单之间留出一些空间 */
    box-shadow: none;
}

.headerstyle {
    height: 100px;

}
</style>