<template>
    <div>
        <div class="role-list-container">
            <span class="role-name">角色名称</span>
            <input type="text" class="input-text" v-model="Findkeyword" style="width: 250px;" placeholder="角色名称">
            <button type="button" class="search-button" @click="Search">
                <SearchOutlined /> 搜索
            </button>
            <button type="button" class="reset-button" @click="Reset">
                <SyncOutlined /> 重置
            </button>
        </div>
        <div class="role-list-container">
            <button type="button" class="add-button"  @click="Add">
                <PlusOutlined /> 添加
            </button>
            <button type="button" class="delete-button" @click="BatchDelete">批量删除</button>
            <a-button type="primary" @click="opens">分配权限</a-button>
        </div>
        <div class="role-list-container">
            <table>
                <thead>
                    <tr>
                        <td class="td50">
                            <input type="checkbox" name="" id="">
                        </td>
                        <td class="td50 tdcenter">序号</td>
                        <td class="td330">角色名称</td>
                        <td class="td330">备注</td>
                        <td class="td230">创建时间</td>
                        <td class="td230 tdcenter">操作</td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for=" (item, index) in currentPageData" :key="item.id">
                        <td>
                            <input type="checkbox" name="" id="">
                        </td>
                        <td class="tdcenter">{{ index + 1}}</td>
                        <td>{{ item.roleName }}</td>
                        <td>{{ item.remark }}</td>
                        <td>{{ formatItemCreateAt(item) }}</td>
                        <td class="tdcenter">
                            <button type="button" class="blue" @click="isDisabled ? noPermission() : Edit(item.id)">
                                <EditOutlined />
                            </button>
                            <button type="button" class="red" @click="isDisabled ? noPermission() : Delete(item.id)">
                                <DeleteOutlined />
                            </button>
                          
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="role-list-container pagination">
            <a-pagination v-model:current="current" :total="tabArr.length" :pageSize="pageSize" />
            <span>第</span><input type="text" v-model="page"><span>页</span>
            <button type="button" @click="onChange">跳转</button>
        </div>
    </div>


    <div class="modal" v-show="display">
        <div class="modal-interior">
            <span style="font-size:20px;" v-show="interior1">添加角色</span>
            <span style="font-size:20px;" v-show="interior2">编辑角色</span>
            <table>
                <tr>
                    <td><span style="color: red;">*</span> 角色名称</td>
                    <td class="td370"><input type="text" name="username" class="input-text" v-model="formState.roleName"
                            required>
                    </td>
                </tr>
                <tr>
                    <td><span style="color: red;">*</span> 备注</td>
                    <td class="td370"><input type="text" name="encode" class="input-text" v-model="formState.remark"
                            required>
                    </td>
                </tr>
                <div>
                    <button type="button" class="cancel-button" @click="cancel">取消</button>
                    <button type="submit" class="confirm-button" @click="isDisabled ? noPermission() : confirm(id)">确认</button>
                </div>
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
    :options="formattedRoles"
    ></a-select>
    <a-select 
                v-model:value="selectedPermissionId" 
                style="width: 240px"
                placeholder="选择要添加的权限"
                :options="permissions"
            ></a-select>
  
    <a-button type="primary" @click="isDisabled ? noPermission() : handleSubmit" style="width: 100px;">提交</a-button>
</div>
  </a-drawer>
</template>



<script setup lang="js">
import { ref, reactive, computed, onMounted } from 'vue';
import {
    SearchOutlined,
    SyncOutlined,
    PlusOutlined,
    EditOutlined,
    DeleteOutlined,
    PlusCircleOutlined
} from '@ant-design/icons-vue';
import axios from 'axios';
import { message } from 'ant-design-vue';
import axiosInstance from '../store/axiosInstance';
import { useResourceStore } from '../store/permission';
import hasPermission from '../store/hasPermission.js';
import { useRoute } from "vue-router";
const route = useRoute();
let isDisabled = ref(true);
let noPermission = () => {
  message.error("没有权限");
};
const render = async () => {
  // 权限判断
  let token = sessionStorage.getItem('token');
  hasPermission(token, route.meta.Permissions).then((x) => {
    if (x == true) {
      isDisabled.value = false;
    } else {
      isDisabled.value = true;
    }
  });}
const resourceStore = useResourceStore();



// 创建响应式状态
let display = ref(false);
let interior1 = ref(false);
let interior2 = ref(false);
let Findkeyword = ref('')
let formState = reactive({
    id: '',
    roleName: '',
    remark: ''
})
let permission=ref([])
let permissions=ref([])
let isAdmin=ref(true)
//抽屉代码
let open=ref(false)
const opens=async()=>{
    open.value=true
}
let selectedRoleId = ref(null);
let selectedPermissionId=ref(null)

const formattedRoles = computed(() => {
    return currentPageData.value.map(item => ({
        label: item.roleName,
        value: item.id
    }));
});

const handleSubmit = async () => {
    if (!selectedRoleId.value || !selectedPermissionId.value) {
        alert('请确保所有字段都已填写！');
        return
    }else{
        try{
            let res = await axios.post(`http://139.9.80.124:66/api/RolePerAssign?roleId=${selectedRoleId.value}&perId=${selectedPermissionId.value}`)
            console.log(res);
            
        }catch(err){
            console.log('添加权限失败');
            
        }
    }
    
    console.log(selectedRoleId.value);
    console.log(selectedPermissionId.value);
    
}

// 分页
let page = ref();
const pageSize = 5;
const current = ref(1);
const filteredTabArr = computed(() => {
    return tabArr.filter(item => !item.isDeleted);
});
const currentPageData = computed(() => {
    const start = (current.value - 1) * pageSize;
    const end = start + pageSize;
    return filteredTabArr.value.slice(start, end);
});
//快速跳转页面
function onChange() {
    if (page.value && Number(page.value) && page.value <= Math.ceil(tabArr.length / pageSize)) {
        current.value = Number(page.value);
    } else {
        alert('请输入正确的页码')
    }
    page = '';
}

//获取权限
const fetchpermission = async () => {
    try {
        let res = await axios.get(axiosInstance.getpermission);
        permission.value = res.data.data; // 更新 ref 的值
        permissions.value = permission.value.filter(permissionItem => !permissionItem.isDeleted)
        .map(item=>({
            label:item.permissionName,
            value:item.id
        }));
        console.log(permissions);
    } catch (err) {
        console.log(err);
    }
}


//页面加载获取列表
let tabArr = reactive([]);
onMounted(async () => {
    await fetchpermission()
    resourceStore.fetchResourcesAndPermissions()
    render()
    try {

        const res = await axios.get(axiosInstance.getrole);
        console.log(res.data.data);
        const filterDate = res.data.data.filter(item => !item.isDeleted)
        tabArr.push(...filterDate); // 假设 res.data 是一个数组
    } catch (err) {
        console.log(err);
    }
});

// 分页改变时的处理函数


let Search = async () => {
    let keywords = Findkeyword.value.trim()
    try {
        if (keywords) {
            let res = await axios.get(axiosInstance.getrolebykeyword(keywords))
            // console.log(res);
            tabArr.splice(0, tabArr.length, ...res.data.data); // 清空并填充新的搜索结果

        } else {
            alert('请输入关键字')
        }

    } catch (err) {
        console.log(err);
    }
}

//重置页面
function Reset() {
    // console.log('重置');
    Findkeyword.value = ""
    fetchRoles()
};

function Add() {
    console.log('添加');
    display.value = true;
    Object.assign(formState, {
        roleName: '',
        remark: ''
    });

};

function BatchDelete() {
    console.log('批量删除');
};

let Edit = async (id) => {
    try {
        let res = await axios.get(axiosInstance.getrolebyid(id))
        // console.log(res.data);

        formState = {
            id: res.data.data.id,
            roleName: res.data.data.roleName,
            remark: res.data.data.remark
        }
        display.value = true;
    } catch (err) {
        console.log(err);
    }
}
let Delete = async (id) => {
    console.log(id);
    if (confirm(`确定将id为${id}的数据标记为已删除吗？`)) {
        try {
            let res = await axios.delete(axiosInstance.deleterole(id))
            const index = tabArr.findIndex(item => item.id === id);
            if (index !== -1) {
                tabArr.splice(index, 1);
                await fetchRoles(current.value)
            }
          
            // console.log(res);
        } catch (err) {
            console.log(err);
        }
    }
};
function cancel() {
    display.value = false;
    interior1.value = false;
    interior2.value = false;


}
let confirm = async (id) => {
    // console.log(id);
    try {
        console.log(formState.id);

        if (formState.id) {
            //编辑
            let res = await axios.put(axiosInstance.updaterole(formState.id), {
                roleName: formState.roleName,
                remark: formState.remark
            })
            // 找到需要更新的元素，并更新其属性
            const index = tabArr.findIndex(item => item.id === formState.id);
            if (index !== -1) {
                tabArr[index].roleName = formState.roleName;
                tabArr[index].remark = formState.remark;
            }

        } else {
            let res = await axios.post(axiosInstance.addrole, {
                roleName: formState.roleName,
                remark: formState.remark
            })
            await fetchRoles();


        }
        display.value = false;
    } catch (err) {
        console.log(err);
    }
}
// 定义一个新的方法用于获取角色数据
const fetchRoles = async (page = 1) => {
    try {
        const res = await axios.get(axiosInstance.getroles(pege));
        const filterDate = res.data.data.filter(item => !item.isDeleted);
        tabArr.splice(0, tabArr.length, ...filterDate); // 清空并重新填充数据
    } catch (err) {
        console.log(err);
    }
}
const formatDateTime = (isoString) => {
    const date = new Date(isoString);
    const formatter = new Intl.DateTimeFormat('zh-CN', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit',
        hour12: false,
    });
    return formatter.format(date);
};
const formatItemCreateAt = (item) => {
    return formatDateTime(item.createAt);
}

// 分页改变时的处理函数

</script>



<style scoped>
.role-name {
    font-weight: bold;
    color: gray;
    margin: 0 0 0 5px;
}

.input-text {
    width: 90%;
    margin-left: 10px;
    padding: 5px;
    border: 2px solid rgb(241, 243, 248);
    border-radius: 5px;
}

.search-button {
    color: aliceblue;
    background-color: rgb(64, 158, 255);
}

.reset-button {
    background-color: rgb(255, 255, 255);
}

.add-button {
    color: aliceblue;
    background-color: rgb(179, 225, 157);
}

.delete-button {
    color: rgb(235, 235, 235);
    background-color: rgb(255, 255, 255);
}

.role-list-container {
    width: 100%;
    min-width: 840px;
    margin: 0 0 10px 0;
    padding: 10px;
    border: 2px solid rgb(241, 243, 248);
}

.pagination {
    display: flex;
    align-items: center;
    justify-content: center;
    text-align: center;
}
.drawer-content {
    display: flex;
    flex-direction: column;
    gap: 10px; /* 间距 */
    padding: 20px; /* 内边距 */
}
.pagination input,
.pagination button {
    width: 50px;
    height: 30px;
    margin: 0 10px;
    border: 2px solid rgb(240, 240, 240);
    border-radius: 3px;
    text-align: center;
    background-color: white;
}

.search-button,
.reset-button,
.add-button,
.delete-button {
    width: 100px;
    height: 30px;
    margin: 10px;
    padding: 5px;
    border: 2px solid rgb(241, 243, 248);
    border-radius: 5px;
}

table,
tr,
th,
td {
    border: 1px solid rgb(241, 243, 248);
    border-spacing: 0;
}

.tdcenter {
    text-align: center;
}

.td50 {
    width: 50px;
}

.td330 {
    width: 330px;
}

.td230 {
    width: 230px;
}

td {
    height: 40px;
    padding: 0 5px;
}

td button {
    width: 40px;
    height: 20px;
    color: rgb(255, 255, 255);
    margin: 5px;
    border: none;
    border-radius: 5px;
}

.blue {
    background-color: rgb(160, 207, 255);
}

.red {
    background-color: rgb(250, 182, 182);
}

.yellow {
    background-color: rgb(243, 209, 158);
}

button:hover,
[type=checkbox]:hover {
    cursor: pointer;
}

button:active {
    transform: scale(0.9);
}

.modal {
    min-width: 100vw;
    min-height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    position: absolute;
    background-color: rgba(0, 0, 0, 0.5);
    top: 0;
    left: 0;
}

.modal-interior {
    width: 500px;
    height: 300px;
    padding: 20px;
    position: relative;
    background-color: rgb(255, 255, 255);
}

.modal table,
.modal tr,
.modal th,
.modal td {
    margin: 40px 0 0 0;
    border: 0;
}

.td370 {
    width: 370px;
}

.td400 input {
    width: 100%;
    height: 70%;
    padding: 0;
}

.cancel-button,
.confirm-button {
    width: 50px;
    height: 30px;
    margin: 10px;
    padding: 5px;
    font-size: 12px;
    border-radius: 5px;
    border: 0;
    background-color: rgb(255, 255, 255);
}

.cancel-button {
    color: rgb(24, 144, 255);
    position: absolute;
    right: 80px;
    bottom: 20px;
}

.confirm-button {
    color: rgb(255, 255, 255);
    background-color: rgb(24, 144, 255);
    position: absolute;
    right: 20px;
    bottom: 20px;
}
</style>