<template>
    <a-spin :spinning="loading" style="margin-left: 500px; width: 50px;"></a-spin>

    <div class="el">
        <div class="el-left">
            <a-menu class="el-left-menu" :selected-keys="[selectedKey]" >
                <a-menu-item  disabled  >
                    角色名称
                </a-menu-item>
                <a-menu-item  v-for="item in filteredRoless" @click="() => handleClick(item.id)"  :key="item.id" :value="item.id">
                    {{ item.roleName }}
                </a-menu-item>
            </a-menu>
        </div>
        <div class="el-right">
            <button type="button"
                style="background-color: #037dfe; width: 80px;height: 35px;text-align: center; font-size: 13px;"
                @click="AllCheck(permission.isActived)">全部选择</button>
                <button type="button"
                style="background-color:#13ce66; width: 80px;height: 35px;text-align: center; font-size: 13px;"  @click="showDrawer">新增权限</button>
                 
                <button type="button"
                style="background-color: #ff4949; width: 80px;height: 35px;text-align: center; font-size: 13px;" @click="deleteOpens">删除权限</button>
        
            <span class="el-right-icon">
                <SearchOutlined />
            </span>

            <input type="text" placeholder="请输入关键字">
            <table class="el-right-table">
                <tr>
                    <th>#</th>
                    <th>分组名称</th>
                    <th>权限列表</th>
                </tr>
                <tr v-for="(item, index) in resourceWithPermissions" :key="item.id">
                    <td>{{ index + 1 }}</td>
                    <td style="max-width: 25%;">{{ item.resourceName }}</td>
                    <div class="permission-list">
                        <div v-for="permissionItem in item.permissions" :key="permissionItem.id" class="permission-item">
                            <input type="checkbox" v-model="permissionItem.isActived" :value="permissionItem.permissionName">
                            <span>{{ permissionItem.permissionName }}</span>
                        </div>
                    </div>
                </tr>
            </table>
        </div>
    </div>
    <a-drawer
    v-model:open="open"
    class="custom-class"
    width="500"
    root-class-name="root-class-name"
    :root-style="{ color: 'blue' }"
    style="color: red;"
    title="新增权限"
    placement="right"
  >
  <div class="drawer-content">
  <a-select 
  v-model:value="selectedRoleId" 
    style="width: 240px"
    placeholder="选择添加权限的角色"
    :options="filteredRoles"
    ></a-select>
  <a-select 
  v-model:value="resourceId" 
    style="width: 240px"
    placeholder="选择资源"
    :options="resources"   
  ></a-select>
  <a-select 
  v-model:value="operationId" 
    style="width: 240px"
    placeholder="选择操作"
    :options="operation"   
  ></a-select>
  <a-input v-model:value="value" placeholder="权限名称" style="width: 240px;" />
    <a-button type="primary" @click="handleSubmit"  style="width: 100px;">提交</a-button>
</div>
  </a-drawer>
  <a-drawer
        v-model:open="deleteOpen"
        class="custom-class"
        width="500"
        title="删除权限"
        placement="right"
    >
        <div class="drawer-content">

            <a-select 
                v-model:value="selectedPermissionId" 
                style="width: 240px"
                placeholder="选择要删除的权限"
                :options="permissionsToDelete"
            ></a-select>
            <a-button type="danger" @click="handleDelete" style="width: 100px;">删除</a-button>
        </div>
    </a-drawer>
</template>

<script setup>
import { reactive, onMounted, computed, ref } from "vue";
import axios from "axios";
import {
    SearchOutlined,
} from '@ant-design/icons-vue';
import axiosInstance from "../store/axiosInstance";


let Rolearr = reactive([]);
let filteredRoles = ref([]);
let resource = ref([]); // 使用 ref 存储原始数据
let permission = ref([]); // 使用 ref 存储原始数据
const loading = ref(true);
const selectedKey = ref(null); // 新增：用于跟踪选中的菜单项
const open=ref(false)
const selectedRoleId = ref(null); // 新增：用于跟踪选中的角色ID
let filteredRoless=ref([])
const resourceId=ref(null)
const operationId=ref(null)
const selectedPermissionId=ref(null)
let resources = ref([]);
const value=ref('')
let operation=ref([])
let deleteOpen=ref(false)

const showDrawer = () => {
    open.value=true
};
const deleteOpens=()=>{
    deleteOpen.value=true
}
// const afterOpenChange = bool => {
//   console.log('open', bool);
// };
// 新增：构建权限数组
const permissionsToDelete = computed(() => {
    return resourceWithPermissions.value.flatMap(resource => {
        return resource.permissions.map(permission => ({
            label: permission.permissionName,
            value: permission.id
        }));
    });
});

const handleDelete = async()=>{
    console.log(selectedPermissionId.value);
    try{
        if(selectedPermissionId.value===null){
            alert('请选择要删除的权限！');
        }else{
            let res = await axios.delete(axiosInstance.deletepermission(selectedPermissionId.value))
            console.log(res);
                    // 重新获取资源和权限列表
    await Promise.all([fetchresource(), fetchpermission()]);
    deleteOpen.value=false
        }
    }catch(error){
        console.log('删除权限失败！');
        
    }

    
}
const handleSubmit = async()=>{
    // if (!selectedRoleId.value || !resourceId.value || !value.value) {
    // alert('请确保所有字段都已填写！');
    try{
        let res = await axios.post(axiosInstance.addresourcepermission,{
            resourceId:resourceId.value,
            permissionName:value.value,
            operationId:operationId.value
        })
       
        console.log(res);
        // 重新获取资源和权限列表
    await Promise.all([fetchresource(), fetchpermission()]);
    
        open.value=false
        
    }catch(error){
        console.log('添加权限失败！');
        alert('添加权限失败，请检查输入或稍后再试！');
        
    }
  }
    

onMounted(async () => {
    await Promise.all([fetchpermission(), fetchrole(), fetchresource(),fetoperation()]);
    
    // 设置默认选中项
    if (filteredRoles.value.length > 0) {
        selectedKey.value = filteredRoless.value[0].id;
    }

    console.log(resourceWithPermissions.value);

    loading.value = false;
});
const resourceWithPermissions = computed(() => {
    if (!resource.value || resource.value.length === 0) return [];
    return resource.value.filter(resourceItem => !resourceItem.isDeleted).map(resourceItem => {
        const permissions = permission.value.filter(permissionItem => 
            permissionItem.resourceId === resourceItem.id && !permissionItem.isDeleted
        );
        return {
            ...resourceItem,
            permissions
        };
    });
});
console.log(resourceWithPermissions);

// 添加点击处理函数
const handleClick = (key) => {
    selectedKey.value = key;
    // 可以在这里添加逻辑，例如根据选中的角色更新资源和权限的显示
};

const fetchresource = async () => {
    try {
        let res = await axios.get(axiosInstance.resource);
        resource.value = res.data.data; // 更新 ref 的值
        resources.value=resource.value.map(item=>({
            label: item.resourceName,
            value: item.id
        }))
        console.log(resource.value);
    } catch (error) {
        console.log(error);
    }
}

const fetchrole = async () => {
    try {
        let res = await axios.get(axiosInstance.getrole);
        Rolearr = res.data;
        filteredRoless.value = Rolearr.data.filter(item => !item.isDeleted)
        filteredRoles.value = Rolearr.data.filter(item => !item.isDeleted).map(item => ({
            label: item.roleName,
            value: item.id,
        }));
        console.log(filteredRoles);
    } catch (err) {
        console.log(err);
    }
}   

const fetchpermission = async () => {
    try {
        let res = await axios.get(axiosInstance.getpermission);
        permission.value = res.data.data; // 更新 ref 的值
        console.log(permission.value);
    } catch (err) {
        console.log(err);
    }
}
const fetoperation = async()=>{
    try{
        let res = await axios.get(axiosInstance.getoperation)
        operation.value=res.data.data.map(item=>({
            label: item.operationName,
            value: item.id
        }))

        console.log(operation.value);
    
    }catch(err){
        console.log(err);
    }
}
// 定义一个计算属性来过滤 Rolearr，使其依赖于 Rolearr
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

.el-right {
    min-width: 81%;
    position: relative;
}

.el-right button[type=button] {
    color: white;
    border-radius: 3px;
    margin: 0 0 0 10px;
    padding: 5px;
    border: 0;
}

.el-right button[type=button]:active {
    transform: scale(0.9);
}

.el-right-icon {
    position: absolute;
    z-index: 1;
    top: 7px;
    right: 108px
}

.el-right [type=text] {
    height: 30px;
    padding: 0 0 0 30px;
    border: 1px solid rgb(240, 240, 240);
    position: absolute;
    right: 0;
}

.el-right .el-right-table,
.el-right tr {
    width: 100%;
    margin: 30px 0 0 0;
    border: 1px solid rgb(240, 240, 240);
}

.el-right-table td {
    text-align: center;
}

.el-right-table th {
    background-color: #f0f0f0;
}

.el-right-table td:nth-child(2) {
    width: 250px;
}

.el-right-table td:nth-child(1) {
    width: 100px;
}

.el-right th,
.el-right td {
    padding: 10px;
    border: 1px solid rgb(240, 240, 240);
}

.el-right span {
    margin: 0 30px 0 10px;
}

.el-right .el-right-table input[type=checkbox]:hover {
    cursor: pointer;
}

/* .el-right .el-right-table input[type=checkbox]:checked,
.el-right .el-right-table input[type=checkbox]:checked+span {
    color: blue;
    accent-color: blue;
} */
:where(.css-dev-only-do-not-override-19iuou).ant-menu-light .ant-menu-item-selected {
    background-color: #fff;
}

.permission-list {
    width: 600px;
    height: 70px;
    display: flex;
    flex-wrap: wrap;
    /* 允许换行 */
    gap: 5px;
    /* 项目之间的间隙 */
    margin-left: 10px;
    font-size: 18px;
}

.permission-item {
    font-size: 0.8em;
    /* 缩小字体大小 */
    display: flex;
    /* 确保 checkbox 和 text 在一行 */
    align-items: center;
    /* 垂直居中 */
}

.permission-item span {
    margin-left: 5px;
    /* checkbox 和 text 之间的间距 */
}
.drawer-content {
    display: flex;
    flex-direction: column;
    gap: 10px; /* 间距 */
    padding: 20px; /* 内边距 */
}
</style>