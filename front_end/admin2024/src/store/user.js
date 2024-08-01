import { defineStore } from "pinia";

import axios from "axios";
export const useUserStore = defineStore('user', () => {
    async function  getUserDate(){
        let res = await axios.get('http://101.133.150.189:63759/api/user')

        return res
    }
 
    return {getUserDate}

})
