<template>
    <!-- 整体布局 -->
    <div class="el">
        <!-- 左侧角色菜单 -->
        <div class="el-left">
            <a-menu class="el-left-menu" :selected-keys="[selectedRole]">
                <!-- 默认禁用项，用于标题 -->
                <a-menu-item disabled>
                    角色名称
                </a-menu-item>
                <!-- 角色列表，可点击切换 -->
                <a-menu-item v-for="role in roles" :key="role.roleId" @click="handleClick(role)">
                    {{ role.roleName }}
                </a-menu-item>
            </a-menu>
        </div>
        <!-- 右侧用户列表 -->
        <div class="el-right">
            <!-- 操作按钮 -->
            <button type="button" class="el-right-button" style="background-color: rgb(24, 144, 255);"
                @click="Add">添加用户</button>
            <button type="button" class="el-right-button" style="background-color: rgb(255,73,73);"
                @click="cancels">全部取消</button>

            <!-- 搜索输入框 -->
            <div class="search-container">
                <!-- 搜索图标
     <span class="el-right-icon">
                <SearchOutlined />
            </span> -->
                <a-input v-model:value="keyword" placeholder="请输入关键字" />
                <a-button @click="find" type="primary">查找</a-button>
            </div>
            <!-- 用户表格 -->
            <table class="el-right-table">
                <tr>
                    <!-- 表头 -->
                    <th><input type="checkbox" name="" id=""></th>
                    <th>用户账号</th>
                    <th>用户昵称</th>
                    <th>邮箱</th>
                    <th>是否启用</th>
                    <th>备注</th>
                    <th>操作</th>
                </tr>
                <!-- 用户数据行 -->
                <tr v-for="user in filteredUsers" :key="user.userId">
                    <td><input type="checkbox" name="" :id="user.username"></td>
                    <td>{{ user.username }}</td>
                    <td>{{ user.nickname }}</td>
                    <td>{{ user.email }}</td>
                    <td>
                        <!-- 启用状态图标 -->
                        <div v-if="user.isActived === true">
                            <CheckCircleFilled style="color: green;" />
                        </div>
                        <div v-else-if="user.isActived === false">
                            <CloseCircleFilled style="color: red;" />
                        </div>
                    </td>
                    <td>{{ user.roleRemark }}</td>
                    <td><a-button @click="() => Del(user.userId)">删除</a-button></td>
                </tr>
            </table>
        </div>
        <!-- 新增模态框 -->
        <a-modal v-model:open="dialogVisible" title="添加用户" style="width: 700px;">
            <table>
                <tr>
                    <th>账号</th>
                    <th>昵称</th>
                    <th>邮箱</th>
                    <th>备注</th>
                    <th>是否启用</th>
                    <th>角色</th>
                    <th>操作</th>
                </tr>
                <tr v-for="item in combinedData" :key="item.id">
                    <td>{{ item.username }}</td>
                    <td>{{ item.nickName }}</td>
                    <td>{{ item.email }}</td>
                    <td>{{ item.remark }}</td>
                    <td>
                        <a-space direction="vertical" style="margin-left: 20px;">
                            <a-switch v-model:checked="item.isActived" size="small" @click="State(item.id)" disabled />
                        </a-space>
                    </td>
                    <td>
                        <!-- 使用 v-for 遍历 roles 数组 -->
                        <template v-for="(role, index) in item.roles" :key="index">
                            <span>{{ role.roleName }}</span><br>
                        </template>
                    </td>
                    <td>
                        <a-button @click="design(item.id)">
                            分配角色
                        </a-button>
                    </td>
                </tr>
            </table>
        </a-modal>
    </div>
</template>

<script setup>
import { ref, reactive, onMounted, nextTick,watch} from "vue";
import axios from "axios";
import { SearchOutlined, CheckCircleFilled, CloseCircleFilled, FundTwoTone } from '@ant-design/icons-vue';

// 定义引用变量
let roles = reactive([]); // 存储所有角色
let users = reactive([]); // 存储所有用户
let filteredUsers = reactive([]); // 存储根据角色筛选后的用户
let selectedRole = ref(null); // 当前选中的角色
let dialogVisible = ref(false)
const user = ref([]); // 单个用户数据
let data = ref([])
let combinedData = reactive([]);
let keyword = ref('')

onMounted(() => {
    fetchData()
})

watch(users,()=>{
    updateFilteredUsers();
    console.log(filteredUsers);
})

// 更新过滤后的用户列表
function updateFilteredUsers() {
    // console.log(user.isDeleted);
    filteredUsers = users.filter(user =>
        user.roles.includes(selectedRole.value) && !user.isDeleted
    );
    console.log(filteredUsers);
}

function Add(params) {
    nextTick(() => {
        dialogVisible.value = true
    })
}
const Del = async (id) => {
    let delres = await axios.post(`http://localhost:63760/api/UseRole/pagingRole`, {
        pageNumber: 0,
        pageSize: 0
    })
    // console.log(delres);
    let userroleid = delres.data.data.find(item => item.userId === id)
    // console.log(userroleid);
    if (userroleid) {
        try {
            let res = await axios.post(`http://localhost:63760/api/UseRole/deleteuserole`,
                { useroleId: userroleid.id }
            )
            // console.log(res);
            if (res.status === 200) {
            //   const update=delres.data.data
            console.log(userroleid);
              const index=users.findIndex(user=>user.userId===id)
              if(index!==-1){
                users[index].isDeleted = userroleid.isDeleted
              }
            //   console.log(users);
            }
            await fetchData()
            //   updateFilteredUsers()
            // console.log(filteredUsers);
            }catch (err) {
        console.log(err);
    }
}
}
const design = async (id) => {
    console.log(selectedRole.value);
    console.log(id);
    const user = combinedData.find(item => item.id === id)
    let roleName = user.roles.map(roles => roles.roleName)
    console.log(roleName);
    // 检查角色名称数组中是否包含 '游客'
    if (roleName.includes('游客')) {
        try {
            let res = await axios.post(`http://localhost:63760/api/UseRole/createuserole`, {
                userid: id,
                roleid: selectedRole.value
            })
            if (res.status === 200) {
                alert('分配成功')
                dialogVisible.value = false
                // await onMounted()
                await fetchData()
            } else {
                console.log(res.message);
            }

        } catch (err) {
            console.log(err);
        }

    } else {
        alert('该用户已经有角色了,请联系超级管理员进行分配')
    }
}
// 角色点击事件处理器
function handleClick(role) {
    if (!role || typeof role !== 'object') {
        return;
    }
    selectedRole.value = role.roleId;
    updateFilteredUsers();

}
const find = async () => {
    let searchkeyword = keyword.value.trim()
    if (searchkeyword) {
        try {
            let res = await axios.get(`http://localhost:63760/api/UseRole?keywords=${searchkeyword}`)
            // console.log(res);

            if (res.status === 200) {

                // 使用 reactive 将返回的数据转换为响应式数据
                const newData = [res.data]
                // console.log(newData);
                // 清空旧数据，避免重复添加
                filteredUsers = [];

                // 将响应式数据添加到 filteredUsers
                filteredUsers.push(...newData);

                console.log(filteredUsers);
            } else {

            }
        } catch (err) {
        }
    }
}

// 模态框相关代码
//这是用来抓取数据// ...
const fetchData = async () => {
    try {
        // 获取用户数据
        const resuser = await axios.get(`http://localhost:63760/api/user`);
        user.value = resuser.data;

        // 获取角色数据
        const res = await axios.get('http://localhost:63760/api/UseRole');
        data.value = res.data;

        // 重置 roles 和 users 数组
        roles = reactive([]);
        users = reactive([]);

        // 处理数据
        data.value.forEach(item => {
            // 添加角色
            if (!roles.find(r => r.roleId === item.roleId)) {
                roles.push({ roleId: item.roleId, roleName: item.roleName });
            }

            // 添加或更新用户，同时检查 isDeleted 字段
            if (!item.isDeleted) { // 只处理未标记为删除的用户
                let existingUser = users.find(u => u.userId === item.userId);
                if (!existingUser) {
                    users.push({
                        userId: item.userId,
                        username: item.username,
                        nickname: item.nickname,
                        avatar: item.avatar,
                        email: item.email,
                        isDeleted: item.isDeleted,
                        telephone: item.email,
                        roleRemark: item.roleRemark,
                        isActived: item.isActived,
                        roles: [item.roleId]
                    });
                } else {
                    if (!existingUser.roles.includes(item.roleId)) {
                        existingUser.roles.push(item.roleId);
                    }
                }
            }
        });

        // 设置默认选中的角色并更新用户列表
        if (roles.length > 0) {
            selectedRole.value = roles[0].roleId;
        }

        // 更新过滤后的用户列表
        updateFilteredUsers();

        // 确保视图更新
        await nextTick();
    } catch (err) {
        console.error('Failed to fetch data:', err);
    }
};

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

.search-container {
    display: flex;
    align-items: center;
}

/* 如果需要间距 */
.search-container .ant-btn {
    margin-left: 10px;
}

.el-left-menu {
    width: 100%;
    border: 1px solid rgb(240, 240, 240);
}



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

.ant-modal-content {
    width: 800px;
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
    width: 200px;
    margin-top: 10px;

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