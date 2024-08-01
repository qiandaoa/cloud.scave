<template>
    <a-spin :spinning="loading" style="margin-left: 500px; width: 50px;"></a-spin>

    <div class="el">
        <div class="el-left">
            <a-menu class="el-left-menu" :selected-keys="[selectedKey]" >
                <a-menu-item  disabled  >
                    角色名称
                </a-menu-item>
                <a-menu-item  v-for="item in filteredRoles" @click="() => handleClick(item.id)"  :key="item.id" :value="item.id">
                    {{ item.roleName }}
                </a-menu-item>
            </a-menu>
        </div>
        <div class="el-right">
            <button type="button"
                style="background-color: #037dfe; width: 80px;height: 35px;text-align: center; font-size: 13px;"
                @click="AllCheck(permission.isActived)">全部选择</button>
            <button type="button"
                style="background-color: #ff4949; width: 80px;height: 35px;text-align: center; font-size: 13px;">全部取消</button>
            <button type="button"
                style="background-color:#13ce66; width: 80px;height: 35px;text-align: center; font-size: 13px;">保存设置</button>
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
                <tr v-for="(item, index) in resource" :key="item.id">
                    <td>{{ index + 1 }}</td>
                    <!-- <td style="max-width: 5%;">{{ item.id }}</td> -->

                    <td style="max-width: 25%;">{{ item.resourceName }}</td>
                    <div class="permission-list">
                        <div v-for="permissionItem in permission" :key="permissionItem.id" class="permission-item">
                            <input type="checkbox"  v-model="permissionItem.isActived" :value="permissionItem.permissionName">
                        </input>
                            <span>{{ permissionItem.permissionName }}</span>
                        </div>
                    </div>
                </tr>
            </table>
        </div>
    </div>
</template>



<script setup>
import { reactive, onMounted, computed, ref, vModelCheckbox } from "vue";
import axios from "axios";
import {
    SearchOutlined,
} from '@ant-design/icons-vue';
let Rolearr = reactive([])
let filteredRoles = ref([])
let resource = reactive([])
const loading = ref(true);
let permission=reactive([])
const selectedKey = ref(null); // 新增：用于跟踪选中的菜单项

onMounted(async () => {
    await Promise.all([fetchpermission(), fetchrole(), fetchresource()]);
     // 设置默认选中项
     if (filteredRoles.value.length > 0) {
        selectedKey.value = filteredRoles.value[0].id;
    }
    // console.log(permission.isActived);
    loading.value=false;
});

// 添加点击处理函数
const handleClick = (key) => {
    selectedKey.value = key;
    // 可以在这里添加逻辑，例如根据选中的角色更新资源和权限的显示
};
const fetchresource=async()=>{
    try{
        let res = await axios.get(`http://101.133.150.189:63759/api/permission/api/resource`)
        resource = res.data.data
        console.log(resource);
    } catch (error) {
        console.log(error)
    }
}
const fetchrole = async () => {
    try {
        let res = await axios.get('http://101.133.150.189:63759/api/role');
        Rolearr = res.data;
        // console.log(Rolearr);    
        filteredRoles.value = Rolearr.data.filter(item => !item.isDeleted);
        console.log(filteredRoles.value);
    } catch (err) {
        console.log(err);
    }
}   
const fetchpermission = async () => {
    try {
        let res = await axios.get(`http://101.133.150.189:63759/api/permission`)
        permission = res.data.data 
        console.log(permission);
    } catch (err) {
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
</style>