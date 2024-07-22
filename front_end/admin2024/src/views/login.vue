<template>
    <div class="box">
        <div class="login_box">
            <div class="left">
                <div class="title">
                    <h2>欢迎登录云朵管理系统</h2>
                </div>
                <div class="login">
                    <a-form
                       :model="userInfo"
                       name="basic"
                       :label-col="{ span: 8 }"
                       :wrapper-col="{ span: 16 }"
                       autocomplete="off"
                        @finish="btnSub"     
                    >
                       <!-- 用户名输入框 -->
                      <a-form-item
                        label="Username"
                        name="username"
                        :rules="[{ required: false, message: '用户名不能为空!',trigger: ['blur'] }]"
                      >
                         <a-input v-model:value="userInfo.userName" placeholder="请输入用户名">
                            <template #prefix>
                                <user-outlined />
                            </template>
                         </a-input>
                       </a-form-item>     
                       <!-- 密码输入框 -->
                       <a-form-item
                          label="Password"
                          name="password"
                          :rules="[{ required: true, message: '密码不能为空!' }]"
                       >
                           <a-input-password v-model:value="userInfo.password" placeholder="请输入密码" />
                       </a-form-item>
            
                       <a-form-item :wrapper-col="{ offset: 8, span: 16 }">
                         <a-button type="primary" class="sub" html-type="submit" @click="btnSub">登录</a-button>
                         <a-button type="primary" @click="handleregister">注册</a-button>
                       </a-form-item>
                    </a-form>
                </div>
            </div>
            <div class="right">
                <div class="img">
                    <img src="../imgs/Login_icon.webp" alt="">
                </div>
            </div>
        </div>
    </div>
</template>
<script setup>
import { onMounted, watch, ref, reactive } from 'vue';
import axios from 'axios';
import axiosInstance from '../store/axiosInstance.js';
import { UserOutlined, LockOutlined } from "@ant-design/icons-vue";
import { useRouter } from 'vue-router';
import { useUserStore } from '../store/store';

const router = useRouter();
const useStore = useUserStore();
const userInfo = reactive({
    userName: '',
    password: ''
});
// 如果用户已经登录，即有token的记录，则跳转至首页
onMounted(() => {
    // if (localStorage.getItem('token')) {
    //     router.push('/');
    // }
});

// 如果用户没有登录，则进行登录验证，获取token
async function btnSub() {
    try {
        const res = await axiosInstance.post('http://localhost:63760/api/login', userInfo);
        console.log(res);
        if (res.status === 200) {
            // 登录成功
            console.log('登录成功');
            // 从服务器响应中获取的token存储到本地t
            useStore.user.token = res.data.data.data;
            // 将 Token 存储到 LocalStorage，以保持用户的登录状态
            localStorage.setItem('token', res.data.data.token);
            // 将用户名存储到 LocalStorage，为了在后续请求或页面加载时能够快速访问用户的身份信息
            localStorage.setItem('username',userInfo.userName);
            localStorage.setItem('userId',res.data.data.id)
            // console.log(res.data.data.id);
            // 跳转首页
            router.push('/');
        } else {
            // 处理其他状态码的情况
            console.error('登录状态码异常:', res.status);
        }
       } catch (err) {
           if (err.response && err.response.status === 401) {
               // 如果登录失败
               alert('登录失败，请重新输入');
               userInfo.userName = '';
               userInfo.password = '';
           } else {
               // 处理其他类型的错误
               console.error('登录失败:', err);
           }
       }
    }      

// 注册跳转
function handleregister() {
    router.push('/register');
}
</script>
<style scoped>
.box {
    height: 100vh;
    width: 100vw;
    background-image: url(../imgs/Login_bg.webp);
    background-repeat: repeat;
    background-size: cover;
    display: flex;
    justify-content: center;
    align-items: center;
}

.login_box {
    background-color: white;
    opacity: 0.8;
    height: 80vh;
    width: 60vw;
    border: 1px solid rgba(119, 117, 238, 0.808);
    display: flex;
    justify-content: center;
    flex-direction: column;
    align-items: center;
    flex-direction: row;
    border-radius: 10px;
    box-shadow: 2px 2px 9px rgba(29, 81, 107, 0.637);
}

.left {
    height: 100%;
    width: 60%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    margin: 0;
    
}

.left .login {
    height: 200px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-evenly;
}


.left{
    margin-left: 20px;
}
form{
    width: 100%;
}
form button{
    margin-right: 10px;
}
.right {
    height: 100%;
    width: 50%;
    display: flex;
    align-items: center;
}

.right img {
    width: 400px;
    height: 400px;
}
</style>