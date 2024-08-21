<template>
    <div class="register-container">
        <div class="register-form" @submit.prevent="onSubmit">
            <h2>注册</h2>
            <form>
                <div class="form-group">
                    <label for="username">用户名</label>
                    <input type="text" id="username" v-model="userinfo.username" required placeholder="请输入用户名" />
                </div>
           
                <div class="form-group">
                    <label for="password">密码</label>
                    <input type="password" id="password" v-model="userinfo.password" required placeholder="密码长度需要大于8位" />
                </div>
                <div class="form-group">
                    <label for="confirm-password">确认密码</label>
                    <input type="password" id="confirm-password" v-model="userinfo.confirmpwd" required  placeholder="请再次输入密码" />
                </div>
                <button >注册</button>
            </form>
            <div class="register-link">
                已有账号？<a href="#" @click.prevent="goToLogin">登录</a>
            </div>
            <Modal :title="'注册成功'"
    :message="'恭喜您，注册已完成，请继续登录！'"
    ref="successModal"
    @modal-closed="redirectToLogin"></Modal>
        </div>
    </div>
</template>

<script setup>
import Modal from '../components/Modal.vue'
import { reactive, ref, watchEffect } from 'vue';
import { router } from '../route';
import axios from 'axios';


const successModal = ref(null);
const userinfo=reactive({
    username: "",
    password: "",
    confirmpwd: ""
})

const onSubmit= async()=>{
    // 这里可以添加表单验证和提交逻辑
    if(userinfo.password !== userinfo.confirmpwd){
        alert('两次输入的密码不一致');
        return
    } 
    console.log(userinfo);
    try{
        const res = await axios.post('http://101.133.150.189:63759/api/register',userinfo)
        console.log(res);
        if(res.status === 200){
            console.log('注册成功');
            successModal.value.show()
        }else{
            alert('注册失败,请重试');
        }
    }catch(err){
        console.log('注册失败',err);
    }
}

const goToLogin = () => {
    // 导航到登录页面的逻辑
    // 使用Vue Router的话，这里可以用router.push('/login')
    router.push('/login')
};
const redirectToLogin = () => {
    console.log('denglu chengg');
    router.push('/login').catch(err=>{
        console.log(err);
    });
};

</script>

<style scoped>
.register-container {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: rgba(70, 162, 207, 0.5);
}

.register-form {
    background-color: white;
    padding: 2rem;
    border-radius: 10px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    width: 30%;
}

h2 {
    text-align: center;
    margin-bottom: 2rem;
}

.form-group {
    margin-bottom: 1rem;
}

label {
    display: block;
    margin-bottom: 0.5rem;
}

input[type="text"],
input[type="email"],
input[type="password"] {
    width: 100%;
    padding: 0.5rem;
    font-size: 1rem;
    border: 1px solid #ddd;
    border-radius: 5px;
}

button {
    width: 100%;
    padding: 0.75rem;
    font-size: 1rem;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
}

button:hover {
    background-color: #0056b3;
}

.register-link {
    text-align: center;
    margin-top: 1rem;
    font-size: 0.9rem;
    color: #6c757d;
}

.register-link a {
    color: #007bff;
    text-decoration: none;
}
</style>