<template>
  <div class="user-profile">
    <a-row :gutter="16">
      <a-col :span="10">
        <a-card :bordered="false" title="个人信息">
          <div class="user-info">
            <a-avatar shape="cirle" size="128" :src="userAvatar" style="margin-left: 100px;" />
            <div class="user-details">
              <LoginOutlined /> <span>登陆账号：{{ userName }}</span>
             
            
              <PhoneOutlined /><span>手机号: {{ userData.telephone }}</span>
              <MailOutlined /><span class="email">邮箱: {{ userData.email }}</span>
              <InsuranceOutlined /><span>安全设置 <span @click="showModal" style="margin-left: 150px;cursor: pointer;color: blue ;">修改密码</span></span>
             
              
              
            </div>
          </div>
        </a-card>
      </a-col>
      <a-col :span="14">
        <a-card :bordered="false" title="用户资料" style="min-height: 200px;">
          <div class="data-item">
  <div class="input-group">
    <label>昵称:</label>
    <input type="text">
  </div>
  <div class="input-group">
    <label>手机号:</label>
    <input type="text">
  </div>
  <div class="input-group">
    <label>邮箱:</label>
    <input type="text">
  </div>

</div>
          <div class="action-buttons">
            <a-button type="primary" @click="saveConfiguration">保存配置</a-button>
          </div>
        </a-card>
      </a-col>
    </a-row>
  </div>
  <transition name="fade">
      <div class="modal" v-if="isModalVisible">
        <div class="modal-content">
          <h3>修改密码</h3>
          <form @submit.prevent="submitPasswordChange(id)">
            <div class="form-group">
              <label for="oldPassword">旧密码</label>
              <input type="password" id="oldPassword" v-model="formState.oldPassword" required />
            </div>
            <div class="form-group">
              <label for="newPassword">新密码</label>
              <input type="password" id="newPassword" v-model="formState.newPassword" required />
            </div>
            <div class="form-group">
              <label for="confirmPassword">确认新密码</label>
              <input type="password" id="confirmPassword" v-model="formState.confirmNewPassword" required />
            </div>
            <button type="submit" style="margin-left: 30px;">提交</button>
            <button type="button" @click="hideModal" style="margin-left: 100px;" >取消</button>
          </form>
        </div>
      </div>
    </transition>
</template>

<script setup>
import { onMounted, reactive, ref } from 'vue';
import { LoginOutlined,PhoneOutlined,MailOutlined ,InsuranceOutlined } from '@ant-design/icons-vue';
import axios from 'axios';
// 假设这是从后端获取的用户信息
const userAvatar = ref('/avatar.jpg');

const userName = localStorage.getItem('username')
const userData=reactive({
  email:'',
  telephone:""
})
const saveConfiguration = () => {
  console.log('保存配置点击事件');
};
const isModalVisible = ref(false);
const formState = ref({
  oldPassword: "",
  newPassword: "",
  confirmNewPassword: ""
});

const showModal = () => {
  isModalVisible.value = true;
};

const hideModal = () => {
  isModalVisible.value = false;
  formState.value = {
    oldPassword: "",
    newPassword: "",
    confirmNewPassword: ""
  };
};


const id = localStorage.getItem('userId')
console.log(id);

onMounted(async()=>{
  if(id){
    try{
      let res = await axios.get(`http://localhost:63760/api/user/${id}`)
      console.log(res);
      Object.assign(userData,res.data)
    }catch(err){
      console.log(err);
    }
  }
})
const submitPasswordChange = async (id) => {
  if (formState.value.newPassword === formState.value.oldPassword) {
    alert('新密码不能与旧密码相同！');
    return;
  }

  // 验证两次输入的新密码是否一致
  if (formState.value.newPassword !== formState.value.confirmNewPassword) {
    alert('新密码和确认密码不一致！');
    return;
  }

  // 如果所有验证都通过，执行密码修改逻辑
  try{
    let res = await axios.put(`http://localhost:63760/api/modify/${id}`,{
     
        newPassword: formState.value.newPassword,
        confirmNewPassword: formState.value.confirmNewPassword
      
    })

    console.log(res.data);
  }catch(err){
    console.log(err);
  }
  
  hideModal(); // 成功后关闭模态框
  };
  
</script>

<style scoped>
.action-buttons {
  /* 确保按钮在卡片内居下 */
  /* position: absolute; */
  bottom: 16px;
  margin-top: 20px;
  /* right: 16px; */
  margin-left: 80px;
 
}

.email{
  margin-left: 2px;
  
}


.data-item {
  display: flex;
  flex-direction: column; /* 改为垂直排列 */
  margin-bottom: 8px;
}

.data-item .input-group {
  display: flex;
  align-items: center; /* 文本和输入框垂直居中 */
  margin-bottom: 8px;
}

.data-item .input-group:last-child {
  margin-bottom: 0; /* 最后一个数据项不需要底部间距 */
}

.data-item .input-group label {
  width: 100px; /* 固定宽度的标签 */
  text-align: right; /* 标签右对齐 */
  margin-right: 8px; /* 标签和输入框之间的间距 */
}

.data-item .input-group input[type="text"] {
  flex: 1; /* 输入框占据剩余的空间 */
}
:where(.css-dev-only-do-not-override-19iuou).ant-avatar{
  width: 100px;
  height: 100px;
}
.user-details{
  margin-top: 15px;
  
  font-size: 13.5px;
}
.user-details > *:not(.anticon)::after {
  content: '';
  display: block;
  width: 100%;
  border-top: 1px solid #ccc;
  margin-top: 8px;
  margin-bottom: 8px;
}
.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
}

.modal-content {
  width: 30%; /* 调整宽度以适应更大的模态框 */
  max-width: 400px; /* 设置最大宽度限制 */
  background-color: white;
  padding: 30px; /* 增加内边距 */
  border-radius: 5px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.3);
  display: flex; /* 使用Flex布局 */
  flex-direction: column; /* 垂直堆叠元素 */
  align-items: center; /* 居中对齐 */
}

.form-group {
  display: flex; /* 使用Flex布局 */
  align-items: center; /* 垂直居中对齐 */
  margin-bottom: 20px;
  width: 100%; /* 使表单组占据整个宽度 */
}

.form-group label {
  width: 100px; /* 设置label的固定宽度 */
  text-align: right; /* 右对齐label */
  margin-right: 10px; /* 在label和input之间添加间距 */
}

.form-group input {
  flex-grow: 1; /* 输入框占据剩余的空间 */
}
/* 添加按钮样式以使其更美观 */
button[type="submit"],
button[type="button"] {
  /* margin-top: 20px; */
  padding: 10px 20px;
  background-color: #007BFF;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
}

button[type="submit"]:hover,
button[type="button"]:hover {
  background-color: #0056b3;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
.input-group input[type="text"] {
  width: 100px; /* 或者你希望的任何其他宽度 */
}
</style>