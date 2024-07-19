<template>
    <div class="user-profile">
      <a-card :bordered="false">
        <div class="user-info">
          <a-avatar shape="square" size="large" :src="userAvatar" />
          <div class="user-details">
            <h2>{{ userName }}</h2>
            <p>手机号: {{ phoneNumber }}</p>
            <p>邮箱: {{ email }}</p>
          </div>
        </div>
        <div class="action-buttons">
          <a-button type="primary" @click="handlePasswordChange">修改密码</a-button>
          <a-button type="default" @click="handlePasswordReset">重置密码</a-button>
        </div>
      </a-card>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  
  // 假设这是从后端获取的用户信息
  const userAvatar = ref('/avatar.jpg');
  const userName = ref('张三');
  const phoneNumber = ref('13800138000');
  const email = ref('zhangsan@example.com');
  
  const handlePasswordChange = () => {
    console.log('修改密码点击事件');
  };
  
  const handlePasswordReset = () => {
    console.log('重置密码点击事件');
  };
  </script>
  
  <style scoped>
  .user-profile {
    display: flex;
    justify-content: center;
  }
  
  .user-info {
    display: flex;
    align-items: center;
  }
  
  .user-details {
    margin-left: 20px;
  }
  
  .action-buttons {
    margin-top: 20px;
  }
  </style>