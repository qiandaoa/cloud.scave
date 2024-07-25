<template>
  <!-- 侧边栏Logo与菜单组件 -->
  <div class="logo" :class="{'logo-collapsed': isCollapsed}" @click.stop>
    <!-- Logo图片 -->
    <img class="logo-png" :class="{ 'logo-png-collapsed': isCollapsed }" :src="logoSrc" alt="logo">
    <!-- Logo文字 -->
    <span class="logo-text" v-if="!isSiderCollapsed">{{ logotext }}</span>
  </div>
  <!-- Ant Design的内联模式菜单 -->
  <a-menu mode="inline" v-model:selectedKeys="selectKeys" :theme="theme" :items="menuArr" @click="handleMenuClick">
    <!-- 自定义菜单项模板 -->
    <template #item="{ item }">
      <a-menu-item :key="item.key">
        <!-- 菜单项标题 -->
        <span>{{ item.meta.title }}</span>
      </a-menu-item>
    </template>
  </a-menu>
</template>

<script setup>
import { ref, onMounted, onUnmounted, watch } from 'vue';
import { useRouterStore } from '../store/router';
import { storeToRefs } from 'pinia';
import { MailOutlined, CalendarOutlined, AppstoreOutlined, SettingOutlined } from '@ant-design/icons-vue';

// 定义组件属性，用于接收侧边栏折叠状态
defineProps({
  isSiderCollapsed: {
    type: Boolean,
    default: false,
  },
});

// 响应式引用，用于判断窗口大小是否小于等于768px
const isCollapsed = ref(window.innerWidth <= 768);
// Logo文本
let logotext = ref('云朵Admin');

// 窗口尺寸改变时的处理函数
const handleResize = () => {
  isCollapsed.value = window.innerWidth <= 768;
};

// 组件挂载时，监听窗口尺寸变化
onMounted(() => {
 
});

// 组件卸载时，移除窗口尺寸变化的监听
onUnmounted(() => {
  window.removeEventListener('resize', handleResize);
});

// 引入路由状态管理器
const routerStore = useRouterStore();
// 从状态管理器中引用菜单数组和活动键
const { menuArr, activeKey } = storeToRefs(routerStore);
// 主题设置
const theme = ref('dark');
// 选中键的响应式数组
const selectKeys = ref([activeKey.value]);

// Logo图片源
const logoSrc = ref('/remove.photos-removed-background (1).png');



// 菜单点击事件处理器
const handleMenuClick = ({ key }) => {
  routerStore.changeActiveRoute(key);
  activeKey.value = key;
};

// 监听活动键的变化，同步选中键
watch(activeKey, () => {
  selectKeys.value = [activeKey.value];
});



</script>

<style scoped>
/* Logo容器样式 */
.logo {
  display: flex;
  align-items: center;
  padding: var(--padding-medium);
  background-color: var(--secondary-color);
  position: relative;
  z-index: 1;
  margin-bottom: var(--margin-small);
}

/* Logo图片样式 */
.logo img {
  max-width: 100%;
  max-height: 100%;
  object-fit: contain;
  transition: all var(--transition-duration);
}

/* 默认Logo图片样式 */
.logo-png {
  width: 80px;
  background-color: rgb(0, 21, 41);
}

/* 折叠状态下的Logo图片样式 */
.logo-png-collapsed {
  width: var(--logo-size-collapsed);
  opacity: 0.8;
}

/* Logo文字样式 */
.logo-text{
  color: pink;
}

/* Logo文字与图片之间的间距 */
.logo .logo-text {
  margin-left: 10px;
  transition: all 0.3s ease
}

/* 折叠状态下隐藏Logo文字 */
.logo-collapsed .logo-text {
  display: none;
}

/* 响应式设计，屏幕宽度小于等于768px时的Logo大小 */
@media (max-width: 768px) {
  :root {
    --logo-size-collapsed: 40px;
  }
}

/* 过渡动画持续时间 */
:root {
  --transition-duration: 0.3s;
}
</style>