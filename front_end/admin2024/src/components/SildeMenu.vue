<template>
    <a-menu mode="inline" v-model:selectedKeys="selectKeys" :theme="theme" :items="menuArr" @click="handleMenuClick" />
</template>
<script setup>
import { ref } from 'vue'
import { useRouterStore } from '../store/router'
import { storeToRefs } from 'pinia'
/*
    一.实现点击菜单跳转页面的几种办法
        1.给菜单项中放入<route-link>
        2.菜单的 点击事件绑定方法，使用路由跳转的方式来完成跳转页面

*/
let routerStore = useRouterStore();
let { menuArr,selectKeys } = storeToRefs(routerStore)
let theme = ref('dark');


function handleMenuClick({ key }) {
    routerStore.changeActiveRoute(key);
}

</script>
