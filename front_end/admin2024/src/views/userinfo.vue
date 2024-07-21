<template>
  <div class="user-profile">
    <a-row :gutter="16">
      <a-col :span="6">
        <a-card :bordered="false" title="个人信息">
          <div class="user-info">
            <a-avatar shape="square" size="128" :src="userAvatar" />
            <div class="user-details">
              <h2>{{ userName }}</h2>
              <div class="contact-info">
                <p>手机号: {{ phoneNumber }}</p>
                <p>邮箱: {{ email }}</p>
              </div>
            </div>
          </div>
        </a-card>
      </a-col>
      <a-col :span="14">
        <a-card :bordered="false" title="用户资料">
          <div v-for="(item, index) in userData" :key="index" class="data-item">
            <span>{{ item.label }}:</span>
            <span>{{ item.value }}</span>
          </div>
          <div class="action-buttons">
            <a-button type="primary" @click="saveConfiguration">保存配置</a-button>
          </div>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script setup>
import { ref } from 'vue';

// 假设这是从后端获取的用户信息
const userAvatar = ref('/avatar.jpg');
const userName = ref('张三');
const phoneNumber = ref('13800138000');
const email = ref('zhangsan@example.com');
const userData = ref([
  { label: '详细资料1', value: '内容1' },
  { label: '详细资料2', value: '内容2' },
  // 更多数据...
]);

const saveConfiguration = () => {
  console.log('保存配置点击事件');
};
</script>

<style scoped>
.action-buttons {
  /* 确保按钮在卡片内居下 */
  position: absolute;
  bottom: 16px;
  right: 16px;
}

.contact-info {
  /* 为了让手机号和邮箱信息垂直居中 */
  display: flex;
  flex-direction: column;
  justify-content:last baseline ;
}

.data-item {
  /* 每个数据项的label和value并列显示 */
  display: flex;
  justify-content: space-between;
  margin-bottom: 8px;
}
</style>