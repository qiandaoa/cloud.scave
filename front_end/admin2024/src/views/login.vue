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
    import { useUserStore } from '../store/user';
    import axios from 'axios';
    import { UserOutlined, LockOutlined } from "@ant-design/icons-vue";
    import { useRouter } from 'vue-router'
    
    const router = useRouter();
    const userInfo = reactive({
        userName : '',
        password : ''
    });

    onMounted(() => {
        if(useUserStore().user.token){
            router.push('/');
        }
    });

    async function btnSub(){
        console.log(userInfo);
        // const res = await axios.post('/api/login',userInfo);
        // console.log(res);
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