<template>
  <a-upload
    v-model:file-list="fileList"
    name="avatar"
    list-type="picture-card"
    class="avatar-uploader"
    :show-upload-list="false"
   :action="uploadAxios"
    :before-upload="beforeUpload"
    @change="handleChange"
  >
    <img v-if="imageUrl" :src="imageUrl" alt="avatar" style="width: 100px;" />
    <div v-else>
      <loading-outlined v-if="loading"></loading-outlined>
      <plus-outlined v-else></plus-outlined>
      <div class="ant-upload-text">Upload</div>
    </div>
  </a-upload>
</template>

<script setup>
import { ref } from 'vue';
import { message } from 'ant-design-vue';
import { LoadingOutlined, PlusOutlined } from '@ant-design/icons-vue';
import axios from 'axios';

const id = localStorage.getItem('userId')

const uploadAxios = axios.create({
       baseURL: 'http://localhost:63760',
       // 其他配置...
   });

const emit = defineEmits(['update:imageUrl']);

function getBase64(img, callback) {
const reader = new FileReader();
reader.addEventListener('load', () => callback(reader.result));
reader.readAsDataURL(img);
}

const fileList = ref([]);
const loading = ref(false);
const imageUrl = ref('/avatar.jpg');

const handleChange = info => {
if (info.file.status === 'uploading') {
  loading.value = true;
  return;
}
if (info.file.status === 'done') {
  getBase64(info.file.originFileObj, base64Url => {
    imageUrl.value = base64Url;
    loading.value = false;
    emit('update:imageUrl', imageUrl.value);
  });
}
if (info.file.status === 'error') {
  loading.value = false;
  message.error('upload error');
}
};

const beforeUpload = file => {
const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
if (!isJpgOrPng) {
  message.error('You can only upload JPG file!');
}
const isLt2M = file.size / 1024 / 1024 < 2;
if (!isLt2M) {
  message.error('Image must smaller than 2MB!');
}
return isJpgOrPng && isLt2M;
};
</script>

<style scoped>
.avatar-uploader > .ant-upload {
width: 128px;
height: 128px;
}
.ant-upload-select-picture-card i {
font-size: 32px;
color: #999;
}
.ant-upload-select-picture-card .ant-upload-text {
margin-top: 8px;
color: #666;
}
</style>