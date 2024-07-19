<template>
    <div class="box">
        <div class="login_box">
            <div class="left">
                <div class="title">
                    <h2>云朵管理系统</h2>
                </div>
                <div class="login">
                    <div class="input">
                        <a-input v-model:value="userInfo.userName" placeholder="Basic usage">
                            <template #prefix>
                              <user-outlined />
                            </template>
                          </a-input>
                    </div>
                    <div class="input">
                        <a-input-password v-model:value="userInfo.password" placeholder="input password" />
                    </div>
                    <div class="input">
                        <a-button type="primary" size="large" @click="btnSub">
                            登录
                        </a-button>
                        <a-button type="primary" size="large" @click="btnReg">
                            注册
                        </a-button>
                    </div>
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
    import { onMounted,watch,ref,reactive } from 'vue';
    import axios from 'axios';
    import axiosInstance from '../store/axiosInstance.js';
    import { UserOutlined, LockOutlined } from "@ant-design/icons-vue";
    import { useRouter } from 'vue-router'
    
    const router = useRouter();
    const userInfo = reactive({
        userName : '',
        password : ''
    });
    // 如果用户已经登录，即有token的记录，则跳转至首页
    onMounted(() => {
        if(localStorage.getItem('token')){
            router.push('/');
        }
    });
    // 如果用户没有登录，则进行登录验证，获取token
    async function btnSub() {
       try {
        const res = await axiosInstance.post('http://localhost:5057/api/login', userInfo);
        if (res.status === 200) {
            // 登录成功
            console.log('登录成功');
            // 可以在这里存储用户信息，跳转页面等
            localStorage.setItem('token', res.data.data.token);
            const token = localStorage.getItem('token');
            console.log(token);
            router.push('/');
            console.log(res);
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
    function btnReg(){
        router.push('/registered');
    }
function handleregister(){
    router.push('/register');
}
</script>
<style scoped>
    .box{
        height: 100vh;
        width: 100vw;
        background-image: url(../imgs/Login_bg.webp);
        background-repeat: repeat;
        background-size: cover;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .login_box{
        background-color:white;
        height: 80vh;
        width: 60vw;
        border: 1px solid rgba(119, 117, 238, 0.808);
        display: flex;
        justify-content:center;
        flex-direction:column;
        align-items: center;
        flex-direction: row;
        border-radius: 10px;
        box-shadow: 2px 2px 5px rgba(70, 162, 207, 0.5);
    }
    .left{
        height: 100%;
        width: 60%;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }
    .left .login{
        height: 200px;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: space-evenly;
    }
    .left .input{
        width: 200px;
        display: flex;
        justify-content: center;
    }
    .left .input button{
        margin-left: 20px;
    }
    .right{
        height: 100%;
        width: 50%;

        display: flex;
        align-items: center;
    }
    .right img{
        width: 400px;
        height: 400px;
    }
</style>