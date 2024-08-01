import axios from 'axios';

// 创建axios实例
const instance = axios.create({
    baseURL: 'http://101.133.150.189:63759',
});

// 请求拦截器
instance.interceptors.request.use(
  function (config) {
    // 添加token到请求头
    const token = localStorage.getItem('token');            
    if (token) {
        config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);

// 响应拦截器
instance.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error) {
    console.log(error);
    if (error.response.status === 401) {
      // 清除token
      localStorage.removeItem('token');
      // 跳转到登录页面
      router.push('/login');
    }
    return Promise.reject(error);
  }
);
// 暴露模块
export default instance;