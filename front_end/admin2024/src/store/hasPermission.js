import axios from "axios";
import {reactive} from "vue";

let list = reactive([]);
// let token = () => {
//   let token = sessionStorage.getItem("token_aa");
//   return token;
// }
let username = localStorage.getItem('username')
let hasPermission = async (token,perm) => {
    let userInfo =await axios.get(
      `http://101.133.150.189:24731/api/UserPermission/${username}`
    )
  console.log(userInfo);

//   console.log(perm);

   // 假设当前用户的权限存储在变量 userPermissions 中
  const userPermissions = userInfo.data.permissionName;
  userPermissions.forEach(element => {
    list.push(element);
    // console.log(list);

  });
//   router.beforeEach((to, from, next) => {
//   window.document.title = to.meta.title;
//   next();
// })
//   // 检查用户权限是否包含所需权限
//   for (const permissionName of perm) {
//     if (!list.includes(permissionName)) {
//       return false;
//     }
//   }
   // 检查用户权限是否包含所需权限
   for (const permissionName of perm) {
    console.log(`Checking permission: ${permissionName}`);
    const hasPerm = list.includes(permissionName);
    console.log(`Has permission "${permissionName}"? ${hasPerm}`);
    if (!hasPerm) {
      return false;
    }
  }
  // 所有所需权限都存在于用户权限中
  return true;
}
export default hasPermission;
