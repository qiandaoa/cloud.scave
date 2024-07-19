<<<<<<< HEAD
import axios from 'axios';

// 创建axios实例
const instance = axios.create({
    baseURL: 'http://localhost:5173',
});

// 请求拦截器
instance.interceptors.request.use(
  function (config) {
    // 添加token到请求头
    const token = localStorage.getItem('token');            
    console.log(token);
    if (token) {
        config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);
=======
// import axios from 'axios';
// import { useRouter } from 'vue-router';

// const router = useRouter();

// // 创建axios实例
// const instance = axios.create({
//     baseURL: 'http://localhost:63579',
// });

// // 请求拦截器
// instance.interceptors.request.use(
//   function (config) {
//     console.log(config);
//     // 添加token到请求头
//     const token = localStorage.getItem('token');            
//     console.log(token);
//     if (token) {
//         config.headers['Authorization'] = `Bearer ${token}`;
//     }
//     return config;
//   },
//   function (error) {
//     return Promise.reject(error);
//   }
// );
>>>>>>> bd0946ae7256185f3a852b334a8c785437036a32

// // 响应拦截器
// instance.interceptors.response.use(
//   function (response) {
//     return response;
//   },
//   function (error) {
//     console.log(error);
//     if (error.response.status === 401) {
//       // 清除token
//       localStorage.removeItem('token');
//       // 跳转到登录页面
//       router.push('/login');
//     }
//     return Promise.reject(error);
//   }
// );
// // 暴露模块
// export default instance;