<template>
    <a-dropdown>
      <a class="ant-dropdown-link" @click.prevent>
        <a-space direction="vertical" :size="32">
    <a-space wrap :size="16">
      <a-avatar src="https://xsgames.co/randomusers/avatar.php?g=pixel&key=1" :size="48">
        <template #icon><UserOutlined /></template>
      </a-avatar>
      </a-space>
    </a-space>
        <DownOutlined />
      </a>
      <template #overlay>
        <a-menu>
          <a-menu-item>
            <a href="/">首页</a>
          </a-menu-item>
          <a-menu-item>
            <a href="../views/test.vue">测试</a>
          </a-menu-item>
          <a-menu-item>
            <a href="../views/about.vue">测试</a>
          </a-menu-item>
        </a-menu>
      </template>
    </a-dropdown>
  </template>
  <script>


  </script>