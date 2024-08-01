<template>
  <div class="avatar-uploader-wrap" title="点击更换头像">
    <a-upload
      v-model:file-list="fileList"
      name="avatar"
      list-type="picture-card"
      class="avatar-uploader"
      :show-upload-list="false"
      :action="uploadAxios"
      :before-upload="beforeUpload"
    >
      <img v-if="imageUrl" :src="imageUrl" sizes="36" alt="avatar" class="avatar" />
      <div v-else>
        <loading-outlined v-if="loading" />
        <plus-outlined v-else />
        <div class="ant-upload-text">点击更新你的头像</div>
      </div>
    </a-upload>
  </div>
</template>

<script setup>
import { ref, onMounted, defineEmits } from 'vue';
import { message } from 'ant-design-vue';
import { LoadingOutlined, PlusOutlined } from '@ant-design/icons-vue';
import axios from 'axios';

const id = localStorage.getItem('userId');
const uploadAxios = `http://101.133.150.189:63759/api/Avatar/${id}`;
const emit = defineEmits(['update:imageUrl']);

onMounted(async () => {
  await fetchData();
});

const fetchData = async () => {
  try {
    const user = await axios.get(`http://101.133.150.189:63759/api/user/${id}`);
    if (user.data.avatar) {
      const res = await axios.get(`http://101.133.150.189:63759/api/avatar/${id}`);
      imageUrl.value = res.data;
    }
  } catch (err) {
    console.error('Error fetching user data:', err);
  }
};

function getBase64(img, callback) {
  const reader = new FileReader();
  reader.addEventListener('load', () => callback(reader.result));
  reader.readAsDataURL(img);
}

const fileList = ref([]);
const loading = ref(false);
const imageUrl = ref('');

const beforeUpload = async (file) => {
  const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
  const isLt2M = file.size / 1024 / 1024 < 2;
  
  if (!isJpgOrPng) {
    message.error('You can only upload JPG file!');
    return false;
  }
  if (!isLt2M) {
    message.error('Image must smaller than 2MB!');
    return false;
  }
  
  try {
    const formData = new FormData();
    formData.append('avatar', file);
    await axios.post(uploadAxios, formData, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },
    });
    message.success('头像上传成功，请刷新页面');
    // Optionally update imageUrl here if needed
    return true;
  } catch (error) {
    console.error('Error uploading avatar:', error);
    message.error('头像上传失败');
    return false;
  }
};

</script>


<style scoped>

.avatar-uploader-wrap {
  width: 90px;
  height: 90px;
  position: relative;
  border-radius: 50%;
  overflow: hidden;
  margin-left: 40px;
}

.avatar {
  width: 100px;
  height: 100px;
  /* border-radius: 50%;   */
  object-fit: cover;
}
:where(.css-dev-only-do-not-override-19iuou).ant-upload-wrapper.ant-upload-picture-card-wrapper .ant-upload.ant-upload-select{
  border-radius: 50%;
}

</style>