<template>
  <router-view></router-view>
</template>
<script setup>
import { h, ref, reactive, onMounted } from 'vue'
import { useRouterStore } from './store/router'


const routerStore = useRouterStore();

onMounted(() => {
  routerStore.generatRoutes();
})

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