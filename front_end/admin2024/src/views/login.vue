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
                    </div>
                </div>
            </div>
            <div class="right">
                <div class="img">
    
                </div>
            </div>
        </div>
    </div>
</template>
<script setup>
    import { onMounted,watch,ref,reactive } from 'vue';
    import axios from 'axios';
    import { UserOutlined, LockOutlined } from "@ant-design/icons-vue";
    import { useRouter } from 'vue-router'
    
    const router = useRouter();
    const userInfo = reactive({
        userName : '',
        password : ''
    });

    onMounted(() => {
        if(localStorage.getItem('token')){
            router.push('/');
        }
    });

    async function btnSub() {
        console.log(userInfo);
        try {
            const res = await axios.post('http://localhost:5057/api/login', userInfo);
            
            // 如果登录成功
            if (res.data.success) {
                localStorage.setItem('token', res.data.data.token);
                console.log('Token stored:', localStorage.getItem('token'));
                router.push('/');
            } else {
                // 如果登录失败，处理逻辑
                alert('登录失败，请重新输入');
                userInfo.userName = '';
                userInfo.password = '';
            }
        } catch (err) {
            // 捕获请求失败的情况
            if (err.response && err.response.status === 401) {
                alert('登录失败，请重新输入');
                userInfo.userName = '';
                userInfo.password = '';
            } else {
                console.error('登录请求失败:', err);
            }
        }
    }

</script>
<style scoped>
    .box{
        height: 100vh;
        width: 100vw;
        background-color:lightskyblue;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .login_box{
        background-color:white;
        height: 80vh;
        width: 60vw;
        border: 1px solid black;
        display: flex;
        justify-content:center;
        flex-direction:column;
        align-items: center;
        flex-direction: row;
    }
    .left{
        height: 100%;
        width: 50%;
        background-color: aquamarine;
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
    
    .right{
        height: 100%;
        width: 50%;
        background-color: bisque;
    }
</style>