import { defineStore } from 'pinia';
export const useUserStore = defineStore('user',()=>{
  const user = {
    name:'admin',
    token:'',
    email:'123456@qq.com',
    phone:123456,
    role:'admin'
  };
  return{
    user
  }
})