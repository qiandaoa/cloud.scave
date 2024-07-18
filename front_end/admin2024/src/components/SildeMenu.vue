<template>
  <div class="logo" :class="{'logo-collapsed': isCollapsed}" @click.stop>
    <img class="logo-png" :class="{ 'logo-png-collapsed': isCollapsed }" :src="logoSrc" alt="logo">
  </div>
  <a-menu mode="inline" v-model:selectedKeys="selectKeys" :theme="theme" :items="menuArr" @click="handleMenuClick" />
</template>

<script setup>
import { ref, onMounted, onUnmounted, watch } from 'vue';
import { useRouterStore } from '../store/router';
import { storeToRefs } from 'pinia';

const isCollapsed = ref(window.innerWidth <= 768);

const handleResize = () => {
  isCollapsed.value = window.innerWidth <= 768;
};

onMounted(() => {
  window.addEventListener('resize', handleResize);
});

onUnmounted(() => {
  window.removeEventListener('resize', handleResize);
});

const routerStore = useRouterStore();
const { menuArr, activeKey } = storeToRefs(routerStore);
const theme = ref('dark');
const selectKeys = ref([activeKey.value]);

const logoSrc = ref('../../public/remove.photos-removed-background (1).png');

const handleMenuClick = ({ key }) => {
  routerStore.changeActiveRoute(key);
  activeKey.value = key;
};
watch(activeKey, () => {
  selectKeys.value = [activeKey.value];
});
</script>

<style scoped>
.logo {
  display: flex;
  align-items: center;
  padding: var(--padding-medium);
  background-color: var(--secondary-color);
  position: relative;
  z-index: 1;
  margin-bottom: var(--margin-small);
}

.logo img {
  max-width: 100%;
  max-height: 100%;
  object-fit: contain;
  transition: all var(--transition-duration);
}

.logo-png {
  width: 80px;
  background-color: rgb(0, 21, 41);
}

.logo-png-collapsed {
  width: var(--logo-size-collapsed);
  opacity: 0.8;
}

@media (max-width: 768px) {
  :root {
    --logo-size-collapsed: 40px;
  }
}
</style>