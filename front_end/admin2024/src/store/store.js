import { defineStore } from "pinia";
import {reactive} from 'vue';

export const useUserStore = defineStore('user', () => {
  const user = reactive({
    username:'',
    token:'',
  });
  return {user};
})