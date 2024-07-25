<template>
   <div class="el">
        <!-- el-left 页面左侧代码布局 -->
        <div class="el-left">
            <a-menu class="el-left-menu" :selected-keys="[selectedRole]" >
                <a-menu-item disabled>
                    角色名称
                </a-menu-item>
                <a-menu-item v-for="role in roles" :key="role.roleId" @click="handleClick(role)">
            {{ role.roleName }}
        </a-menu-item>
            </a-menu>
        </div>
        <!-- el-right 页面右侧代码布局 -->
        <div class="el-right">
            <button type="button" class="el-right-button" style="background-color: rgb(24, 144, 255);" @click="Add">添加用户</button>
            <button type="button" class="el-right-button" style="background-color: rgb(255,73,73);" @click="cancels">全部取消</button>
            <span class="el-right-icon">
                <SearchOutlined />
            </span>
            <input type="text" placeholder="请输入关键字">
            <table class="el-right-table">
                <tr>
                    <th><input type="checkbox" name="" id=""></th>
                    <th>用户账号</th>
                    <th>用户昵称</th>
                    <th>邮箱</th>
                    <th>是否启用</th>
                    <th>备注</th>
                </tr>
                <tr v-for="user in filteredUsers" :key="user.userId">
                    <td><input type="checkbox" name="" :id="user.username"></td>
                    <td>{{ user.username }}</td>
                    <td>{{ user.nickname }}</td>
                    <td>{{ user.email }}</td>
                    <td>
                        <div v-if="user.isActived === true">
                            <CheckCircleFilled style="color: green;" />
                        </div>
                        <div v-else-if="user.isActived === false">
                            <CloseCircleFilled style="color: red;" />
                        </div>
                    </td>
                    <td>{{ user.roleRemark }}</td>
                </tr>
            </table>
        </div>
         <!-- 新增模态框 -->
         <a-modal
     v-model:open="dialogVisible"
     title="添加用户"
     :footer="null"
     @ok="handleOk"
     @cancel="handleCancel"
      @change="handleTableChange"
   >
     <a-table
       :data-source="user"
       row-key="userId"
       size="small"
        <!-- :pagination="{ total: totalItems, current: currentPage, pageSize: itemsPerPage }" -->
     >
       <a-column
         title=""
         width="50"
         align="center"
         fixed="left"
         key="selection"
         type="selection"
       />
       <a-column
         title="用户账号"
         key="username"
         :dataIndex="['username']"
       />
       <a-column
         title="用户昵称"
         key="nickname"
         :dataIndex="['nickName']"
       />
       <a-column
         title="邮箱"
         key="email"
         :dataIndex="['email']"
       />
    
       <a-column
         title="备注"
         key="roleRemark"
         :dataIndex="['remark']"
       />
     </a-table>
   </a-modal>
    </div>
</template>



<script setup>
import { ref, reactive,onMounted,nextTick } from "vue";
import axios from "axios";
// import { ATable, AColumn } from 'ant-design-vue';
import {
    SearchOutlined,
    CheckCircleFilled,
    CloseCircleFilled
} from '@ant-design/icons-vue';
let roles = ref([]);
let users = ref([]);
let filteredUsers = ref([]);
let selectedRole = ref(null);
const dialogVisible = ref(false);
const tableRef=ref(null)
const searchKeyword = ref('');
const user=ref([])


onMounted(async () => {
    try {
        let resuser=await axios.get(`http://localhost:63760/api/user`)
        console.log(resuser);
        user.value=resuser.data
        // Object.assign(formState, user.data)
        const res = await axios.get('http://localhost:63760/api/UseRole');
        const data = res.data;
        console.log(data);
        // 将数据拆分为角色和用户
        data.forEach(item => {
            if (!roles.value.find(r => r.roleId === item.roleId)) {
                roles.value.push({ roleId: item.roleId, roleName: item.roleName });

                // console.log(roles);
            }
            if (!users.value.find(u => u.userId === item.userId)) {
                users.value.push({
                    userId: item.userId,
                    username: item.username,
                    nickname: item.nickname,
                    avatar: item.avatar,
                    email: item.email,
                    telephone: item.email,
                    roleRemark: item.roleRemark,
                    isActived:item.isActived,
                    roles: [item.roleId]
                });

                // console.log(users);
            } else {
                // 如果用户已存在，则添加角色ID到其roles数组中
                const userIndex = users.value.findIndex(u => u.userId === item.userId);
                users.value[userIndex].roles.push(item.roleId);
            }
         
        });

        // 设置默认选中的角色
        if (roles.value.length > 0) {
            selectedRole.value = roles.value[0].roleId;
            nextTick(() => {
                updateFilteredUsers();
            });
        updateFilteredUsers();

        }

        // 初始化过滤后的用户列表
    } catch (err) {
        console.error('Failed to fetch data:', err);
    }
});

function updateFilteredUsers() {
    // 过滤用户列表，只保留与当前选择角色相关的用户
    filteredUsers.value = users.value.filter(user => 
        user.roles.includes(selectedRole.value)
    );
}

function handleClick(role) {
    if (!role || typeof role !== 'object') {
        // console.error('Invalid role object passed to handleClick');
        return;
    }
    selectedRole.value = role.roleId;

    // console.log('Selected role:', selectedRole.value);
    updateFilteredUsers();

}

//模态框代码

// 控制模态框显示和隐藏
const handleOk = () => {
  // 添加用户的逻辑
  console.log('Form State:', formState);
};

const handleCancel = () => {
  dialogVisible.value = false;
  // 清空表单
  Object.keys(formState).forEach(key => {
    formState[key] = '';
  });
};

// 搜索关键词处理
const handleSearch = (value) => {
  console.log('Searched value:', value);
};

// 打开模态框
const Add = () => {
  dialogVisible.value = true;
};
// const AddUserRole = async () => {
//   try {
//     const response = await axios.post(
//       'https://localhost:63759/api/UseRole/createuserole',
//       {
//         userid: formState.userid, // 确保你的表单状态中有这个字段
//         roleid: selectedRole.value // 使用你之前选择的角色ID
//       },
//       {
//         headers: {
//           'Content-Type': 'application/json'
//         }
//       }
//     );
//     console.log(response.data);
//     // 成功处理后，可能需要关闭模态框和刷新用户列表
//     dialogVisible.value = false;
//     // 清空表单
//     Object.keys(formState).forEach(key => {
//       formState[key] = '';
//     });
//     // 刷新用户列表
//     await fetchData();
//   } catch (error) {
//     console.error(error);
//     // 错误处理，例如显示错误消息给用户
//   }
// };
</script>

<style scoped>
.el,
.el-left,
.el-right,
.el-left-menu {
    height: 100%;
}

.el {
    width: 100%;
    min-width: 900px;
    display: flex;
    justify-content: space-between
}

.el-left {
    width: 200px;
}

.el-left-menu {
    width: 100%;
    border: 1px solid rgb(240, 240, 240);
}
</style>

<style scoped>
.el-right {
    min-width: 81%;
}

.el-right-button {
    width: 60px;
    height: 25px;
    color: white;
    border-radius: 3px;
    margin: 0 0 0 10px;
    font-size: 12px;
    border: 0;
}

.el-right button[type=button]:active {
    transform: scale(0.9);
}

.el-right-icon {
    position: absolute;
    z-index: 1;
    top: 155px;
    right: 220px
}

.el-right [type=text] {
    height: 30px;
    padding: 0 0 0 30px;
    border: 1px solid rgb(240, 240, 240);
    position: absolute;
    right: 53px;
}

.el-right-table,
.el-right tr {
    width: 100%;
    margin: 30px 0 0 0;
    text-align: center;
    border: 1px solid rgb(240, 240, 240);
}

.el-right-table th,
.el-right-table td {
    padding: 10px;
    border: 1px solid rgb(240, 240, 240);
}
</style>

<style scoped>
.el-dialog {
    width: 100%;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    position: absolute;
    background-color: rgba(0, 0, 0, 0.5);
    top: 0;
    left: 0;
}

.el-dialog-content {
    width: 50%;
    height: 70%;
    padding: 18px;
    position: relative;
    background-color: white;
}

.el-dialog label {
    font-size: 20px;
}

.el-dialog-icon {
    position: absolute;
    z-index: 1;
    top: 87px;
    right: 217px;
    color: rgb(240, 240, 240)
}

.el-dialog [type=text] {
    height: 30px;
    padding: 0 0 0 30px;
    border: 1px solid rgb(240, 240, 240);
    position: absolute;
    top: 80px;
    right: 50px;
}

.a-table {
    margin: 100px 0;
}

.el-dialog-footer {
    display: flex;
    justify-content: flex-end;
}

.el-dialog-footer button {
    width: 55px;
    height: 25px;
    font-size: 12px;
    border: 0;
    border-radius: 5px;
    margin: 0 30px 0 0;
}

.el-dialog-footer button:active {
    transform: scale(0.9);
}

.el-dialog-footer .button1 {
    color: white;
    background-color: rgb(24, 144, 255);
}

.el-dialog-footer .button2 {
    border: 2px solid rgb(240, 240, 240);
    background-color: white;
}
</style>