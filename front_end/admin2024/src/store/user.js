import { defineStore } from "pinia";

import axios from "axios";
export const useUserStore = defineStore('user', () => {
    async function  getUserDate(){
        let res = await axios.get('http://localhost:63760/api/user')

        return res
    }
    
    async function fetchUserDate(){
        const res = await getUserDate()
        console.log(res);   
        return res
    }
    
    return {fetchUserDate}


})
