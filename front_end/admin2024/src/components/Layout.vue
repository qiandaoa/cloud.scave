<template>
    <a-layout>
      <a-layout-sider :collapsed="isSiderCollapsed" style="height: auto;">
        <div class="sider-content">
          <SildeMenu :isSiderCollapsed="isSiderCollapsed" />
        </div>
      </a-layout-sider>
      <a-layout>
        <div class="headerstyle">
            <a-button type="" class="collapse-button" @click="toggleSiderCollapse">
              <MenuUnfoldOutlined v-if="isSiderCollapsed" style="font-size: 20px; color: black;" />
              <MenuFoldOutlined style="font-size: 20px; color: black;" v-else />
            </a-button>
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
  
  let isSiderCollapsed = ref(false); // 控制 sider 折叠状态
  
  // 动态调整contentStyle的paddingLeft
//   watch(isSiderCollapsed, (newVal) => {
//     if (newVal) {
//       contentStyle.paddingLeft = '80px'; // 侧边栏折叠时的左侧填充
//     } else {
//       contentStyle.paddingLeft = '240px'; // 侧边栏展开时的左侧填充
//     }
//   });
  
  const toggleSiderCollapse = () => {
    isSiderCollapsed.value = !isSiderCollapsed.value;
  };
  
  </script>
  
  <style scoped>
  #components-layout-demo-custom-trigger .trigger {
    font-size: 18px;
    line-height: 64px;
    padding: 0 24px;
    cursor: pointer;
    transition: color 0.3s;
  }
  
  #components-layout-demo-custom-trigger .trigger:hover {
    color: wheat;
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
    margin-left: 16px; /* 调整按钮与头部之间的距离 */
  position: absolute;
  top: 16px; /* 调整按钮与头部之间的距离 */
  /* right: 16px; 调整按钮与头部之间的距离 */
  width: 40px;
  height: 40px;
  border: none; /* 移除默认边框 */
  outline: none; /* 避免点击或聚焦时出现边框 */
  /* background-color: transparent; */
  box-shadow: none;
  }
  
  .headerstyle {
    height: 100px;
  }
  </style>