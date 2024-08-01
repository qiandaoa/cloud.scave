<template>
  <a-modal v-model:open="isModalOpen" title="添加用户" @ok="handleSubmit" @cancel="handleCancel">
    <a-form :model="formState" :rules="rules">
      <a-form-item name="username" label="用户名" :rules="[{ required: true, message: '请输入用户名' }]">
        <a-input v-model:value="formState.username" placeholder="请输入用户名" />
      </a-form-item>
      <a-form-item name="password" label="密码" :rules="[{ required: true, message: '请输入密码' }]">
        <a-input-password v-model:value="formState.password" placeholder="请输入密码" />
      </a-form-item>
      <a-form-item name="nickName" label="昵称" :rules="[{ required: true, message: '请输入昵称' }]">
        <a-input v-model:value="formState.nickName" placeholder="请输入昵称" />
      </a-form-item>
      <a-form-item name="email" label="邮箱"
        :rules="[{ required: true, message: '请输入邮箱' }, { type: 'email', message: '请输入正确的邮箱地址' }]">
        <a-input v-model:value="formState.email" placeholder="请输入邮箱" />
      </a-form-item>
      <a-form-item name="telephone" label="手机号" :rules="[{ required: true, message: '请输入手机号' }]">
        <a-input v-model:value="formState.telephone" placeholder="请输入手机号" />
      </a-form-item>
      <a-form-item name="remark" label="备注">
        <a-textarea v-model:value="formState.remark" placeholder="请输入备注" />
      </a-form-item>
    </a-form>
  </a-modal>
</template>

<script setup>
import axios from 'axios';
import { nextTick, reactive, ref } from 'vue';
import { useUserStore } from '../store/user.js'
//   import { aModal } from 'ant-design-vue';
const userList = reactive([])
const useStore = useUserStore()
  const isModalOpen = ref(false);
  const formState = reactive({
    username: '',
    password: '',
    nickName: '',
    email: '',
    telephone: '',
    remark: ''
  });
  
  const rules = {
    // Form validation rules
  };
  
  const show = () => {
    isModalOpen.value = true;
  };
  
  const handleCancel = () => {
    isModalOpen.value = false;
  };
  

  const handleSubmit = async () => {
    console.log('Form data:', formState);
    try{
        let res = await axios.post('http://101.133.150.189:63759/api/User',{
            username: formState.username,
            password:formState.password,
           
             nickName: formState.nickName,
         email: formState.email,
         telephone: formState.telephone,
      remark:formState.remark

    })
    console.log(res);
    if (res.status === 200) {
      await useStore.getUserDate();
      // await new Promise(resolve => setTimeout(resolve, 0));
      location.reload()
      handleCancel();

    }
  } catch (err) {
    console.log(err);
  }
};


defineExpose({ show });
</script>