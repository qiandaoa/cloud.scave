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
    @change="handleChange"
    
  >
    <img v-if="imageUrl" :src="imageUrl" alt="avatar" class="avatar"  />
    <div v-else>
      <loading-outlined v-if="loading"></loading-outlined>
      <plus-outlined v-else></plus-outlined>
      <div class="ant-upload-text">Upload</div>
    </div>
  </a-upload>
</div>
</template>

<script setup>
import { ref,onMounted } from 'vue';
import { message } from 'ant-design-vue';
import { LoadingOutlined, PlusOutlined } from '@ant-design/icons-vue';
import axios from 'axios';

const id = localStorage.getItem('userId')

const uploadAxios = `http://localhost:63760/api/Avatar/${id}`

const emit = defineEmits(['update:imageUrl']);

onMounted(async () => {
  let user = await axios.get(`http://localhost:63760/api/user/${id}`)
  console.log(user);

  if (user.data.avatar) {
        try{
          let res = await axios.get(`http://localhost:63760/api/avatar/${id}`)
          console.log(res);
          imageUrl.value = res.data;
        }catch(err){
          console.log(err);
        }
      }
})
function getBase64(img, callback) {
const reader = new FileReader();
reader.addEventListener('load', () => callback(reader.result));
reader.readAsDataURL(img);
}

const fileList = ref([]);
const loading = ref(false);
const imageUrl = ref('');

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