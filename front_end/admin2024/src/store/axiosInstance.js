import axios from 'axios';
import Permission from '../views/permission.vue';

// // 创建axios实例
// const instance = axios.create({
//     baseURL: 'http://101.133.150.189:63759',
// });

// // 请求拦截器
// instance.interceptors.request.use(
//   function (config) {
//     // 添加token到请求头
//     const token = localStorage.getItem('token');
//     if (token) {
//         config.headers['Authorization'] = `Bearer ${token}`;
//     }
//     return config;
//   },
//   function (error) {
//     return Promise.reject(error);
//   }
// );

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
// 暴露模块
// export default instance;

// let baseURL= "http://139.9.80.124:66"
let baseURL = "http://101.133.150.189:24731"


export default {
  //用户的基本操作
  login:`${baseURL}/api/login`,
  getUsers:`${baseURL}/api/user`,
  getUserByid:`${baseURL}/api/user/`,
  changeActive:(userId,or)=>`${baseURL}/api/actived/${userId}?or=${or}`,
  getUsersbykeyword:(keyword)=>`${baseURL}/api/GetAllUsers?keywords=${keyword}`,
  deleteUser:(userId)=>`${baseURL}/api/user/${userId}`,
  updateuser:(userId)=>`${baseURL}/api/userupdate/${userId}`,
  adduser:`${baseURL}/api/user`,
  modify:(userId)=>`${baseURL}/api/modify/${userId}`,
  //用户角色
  getrolename:(userId)=>`${baseURL}/api/userole/${userId}`,
  getuserole:`${baseURL}/api/userole`,
  getuserolebykeyword:(keyword)=>`${baseURL}/api/userole?keywords=${keyword}`,
  adduserole:`${baseURL}/api/userole/createuserole`,
  deleteuserole:(useroleId)=>`${baseURL}/api/userole/${useroleId}`,
  // updateuserole:(useroleId)=>`${baseURL}/api/useroleupdate/${useroleId}`,
  //角色
  getrole:`${baseURL}/api/role`,
  getrolebyid:(roleid)=>`${baseURL}/api/role/${roleid}`,
  getrolebykeyword:(keyword)=>`${baseURL}/api/role?keywords=${keyword}`,
  addrole:`${baseURL}/api/role`,
  deleterole:(roleId)=>`${baseURL}/api/role/${roleId}`,
  updaterole:(roleId)=>`${baseURL}/api/role/${roleId}`,
  getroles:(page)=>`${baseURL}/api/role?page=${page}`,
  // addrolepermission:(roleId,perId)=>`${baseURL}/api/RolePerAssign?${roleId}&perId=${perId}`,
  getpermission:`${baseURL}/api/permission`,
  deletepermission:(permissId)=>`${baseURL}/api/permission/${permissId}`,

  //资源
  resource:`${baseURL}/api/permission/api/resource`,
  //增加一个资源的权限
  addresourcepermission:`${baseURL}/api/permission`,
  //获取全部操作
  getoperation:`${baseURL}/api/permission/api/operation`
}