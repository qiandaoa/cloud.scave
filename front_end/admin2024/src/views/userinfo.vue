<template>
  <a-spin :spinning="loading" style="margin-left: 500px; width: 50px;"></a-spin>
  <div class="user-profile">
    <a-row :gutter="16">
      <a-col :span="8">
        <a-card :bordered="false" title="个人信息">
          <div class="user-info">
            <!-- <img :src="imageUrl"  alt="User Avatar" class="avatar"  @click="showAvatarUploader"  /> -->
            <AvatarUploader   @update:imageUrl="handleImageUrlUpdate" style="" />
            <div class="user-details">
              <LoginOutlined /> <span>登陆账号：{{ userName }}</span>


              <PhoneOutlined /><span>手机号: {{ userData.telephone }}</span>
              <MailOutlined /><span class="email">邮箱: {{ userData.email }}</span>
              <InsuranceOutlined /><span>安全设置 <span @click="isDisabled ? noPermission() : showModal"
                  style="cursor: pointer;color: blue ;">修改密码</span></span>
            </div>
          </div>
        </a-card>
      </a-col>

      <a-col :span="14">
        <a-card :bordered="false" title="用户资料" style="min-height: 200px;">

          <div class="data-item">
            <div class="input-group">
              <label>昵称:</label>
              <input type="text" class="custom-input" v-model="edituserData.nickName">
              <label for="">昵称不作登陆使用</label>
            </div>
            <div class="input-group">
              <label>手机号:</label>
              <input type="text" class="custom-input" :class="{ error: telephoneError }" v-model="edituserData.telephone"
                @blur="validateTelephone(edituserData.telephone)">
              <label for="">手机号不能重复</label>
              <div v-if="telephoneError" class="error-message">请输入正确的11位手机号</div>
            </div>
            <div class="input-group">
              <label>邮箱:</label>
              <input type="text" class="custom-input" v-model="edituserData.email">
            </div>
          </div>
          <div class="action-buttons">
            <a-button type="primary"@click="isDisabled ? noPermission() : saveConfiguration(edituserData.id)">保存配置</a-button>
          </div>
        </a-card>

      </a-col>

    </a-row>
  </div>
  <transition name="fade">
    <div class="modal" v-if="isModalVisible">
      <div class="modal-content">
        <h3>修改密码</h3>
        <form @submit.prevent="isDisabled ? noPermission() : submitPasswordChange(id)">
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
          <button type="button" @click="hideModal" style="margin-left: 100px;">取消</button>
        </form>
      </div>
    </div>
  </transition>
</template>

<script setup>
import { nextTick, onMounted, reactive, ref } from 'vue';
import { LoginOutlined, PhoneOutlined, MailOutlined, InsuranceOutlined } from '@ant-design/icons-vue';
import axios from 'axios';
import  AvatarUploader  from '../components/AvatarUploader.vue'
import axiosInstance from '../store/axiosInstance';
import hasPermission from '../store/hasPermission.js';
import { message } from 'ant-design-vue';
import { useRoute } from "vue-router";
const route = useRoute();
let isDisabled = ref(true);
let noPermission = () => {
  message.error("没有权限");
};
const render = async () => {
  // 权限判断
  let token = sessionStorage.getItem('token');
  hasPermission(token, route.meta.Permissions).then((x) => {
    if (x == true) {
      isDisabled.value = false;
    } else {
      isDisabled.value = true;
    }
  });}
// 假设这是从后端获取的用户信息
const yourActionURL = ref('');
const showAvatarUploaderFlag = ref(false);
const loading = ref(true);
const showAvatarUploader = () => {
  showAvatarUploaderFlag.value = true;
};
const userName = localStorage.getItem('username')
const userData = reactive({
  email: '',
  telephone: "",
  nickName: "",
})
const edituserData = reactive({

  email: '',
  telephone: "",
  nickName: "",
})
const telephoneError = ref(false); // 用于跟踪手机号验证状态

const saveConfiguration = async (id) => {
    if(telephoneError.value){
      alert('请输入正确的11位手机号')
      return
    }
  // console.log(id);

    if (confirm('确定保存修改后的个人信息吗？')) {
      try {
        let res = await axios.put(axiosInstance.updateuser(id), edituserData)
        console.log(res.data);
        location.reload()

      } catch (err) {
        console.log(err);
      }

  }

}


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
// console.log(id);

onMounted(async () => {
  if (id) {
    try {
      let res = await axios.get(axiosInstance.getUserByid + id)
      console.log(res);
      Object.assign(edituserData, res.data)
      Object.assign(userData, res.data)
      render()
      loading.value=false

    } catch (err) {
      console.log(err);
    }
  }
})
const imageUrl = ref('');
const handleImageUrlUpdate = imageUrl => {
  console.log('Updated image URL:', imageUrl);
};
const validateTelephone = (value) => {
  const reg = /^1[3-9]\d{9}$/;
  if (!reg.test(value)) {
    telephoneError.value = true;
  } else {
    telephoneError.value = false;
  }
};
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
  try {
    let res = await axios.put(axiosInstance.modify(id), {

      newPassword: formState.value.newPassword,
      confirmNewPassword: formState.value.confirmNewPassword

    })

    console.log(res.data);
  } catch (err) {
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

.error-message {
  color: red;
  font-size: 12px;
  margin-top: 5px;
}

.email {
  margin-left: 2px;

}


.data-item {
  display: flex;
  flex-direction: column;
  /* 改为垂直排列 */
  margin-bottom: 8px;
}

.data-item .input-group {
  display: flex;
  align-items: center;
  /* 文本和输入框垂直居中 */
  margin-bottom: 8px;
}

.data-item .input-group:last-child {
  margin-bottom: 0;
  /* 最后一个数据项不需要底部间距 */
}

.data-item .input-group label {
  width: 100px;
  /* 固定宽度的标签 */
  text-align: right;
  /* 标签右对齐 */
  margin-right: 8px;
  /* 标签和输入框之间的间距 */
}


:where(.css-dev-only-do-not-override-19iuou).ant-avatar {
  width: 100px;
  height: 100px;
}

.user-details {
  margin-top: 15px;

  font-size: 13.5px;
}

.user-details>*:not(.anticon)::after {
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
  width: 30%;
  /* 调整宽度以适应更大的模态框 */
  max-width: 400px;
  /* 设置最大宽度限制 */
  background-color: white;
  padding: 30px;
  /* 增加内边距 */
  border-radius: 5px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.3);
  display: flex;
  /* 使用Flex布局 */
  flex-direction: column;
  /* 垂直堆叠元素 */
  align-items: center;
  /* 居中对齐 */
}

.form-group {
  display: flex;
  /* 使用Flex布局 */
  align-items: center;
  /* 垂直居中对齐 */
  margin-bottom: 20px;
  width: 100%;
  /* 使表单组占据整个宽度 */
}

.form-group label {
  width: 100px;
  /* 设置label的固定宽度 */
  text-align: right;
  /* 右对齐label */
  margin-right: 10px;
  /* 在label和input之间添加间距 */
}

.form-group input {
  flex-grow: 1;
  /* 输入框占据剩余的空间 */
}

/* 添加按钮样式以使其更美观 */
button[type="submit"],
button[type="button"] {
  /* margin-top: 20px; */
  /* padding: 10px 20px; */
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
  width: 200px;
  /* 或者你希望的任何其他宽度 */
}

.custom-input {
  width: 200px;
  /* 或者你希望的任何其他宽度 */
  border: 1px solid #ccc;
  padding: 5px 10px;
  border-radius: 4px;
}

.input-group input[type="text"][data-v-11bde6a2] {
  width: 200px;
}

/* 使输入框和标签在一行中对齐并设置标签颜色为灰色 */
.input-group {
  display: flex;
  align-items: center;
  /* 垂直居中对齐 */
  /* gap: 5px; 间隔 */
  margin-bottom: 10px;
  /* 每个输入组下方的间距 */
}

.input-group label {
  color: gray;
  /* 将标签颜色设置为灰色 */
  flex-shrink: 0;
  /* 防止标签在容器缩小时缩小 */
}

/* 保持输入框宽度一致 */


/* 额外的标签应该紧挨着输入框 */
.input-group label[for=""] {
  margin-left: 10px;
  /* 与输入框的间距 */
  font-size: smaller;
  /* 减小字体大小 */
}
</style>