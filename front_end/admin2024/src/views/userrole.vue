<template>
    <div class="el">
        <!-- //el-left 页面左侧代码布局 -->
        <div class="el-left">
            <a-menu class="el-left-menu"  @click="handleClick">
                <a-menu-item disabled >
                    角色名称
                </a-menu-item>
                <a-menu-item v-for="item in filteredRoles.values" :key="item.id">
                    {{ item.roleName }}
                </a-menu-item>

            </a-menu>
        </div>
        <!-- //el-right 页面右侧代码布局 -->
        <div class="el-right">
            <button type="button" class="el-right-button" style="background-color: rgb(24, 144, 255);"
                @click="Add">添加用户</button>
            <button type="button" class="el-right-button" style="background-color: rgb(255,73,73);"
                @click="cancels">全部取消</button>
            <span class="el-right-icon">
                <SearchOutlined />
            </span>
            <input type="text" placeholder="请输入关键字">
            <table class="el-right-table">
                <tr>
                    <th><input type="checkbox" name="" id=""></th>
                    <th>用户账号</th>
                    <th>用户昵称    </th>
                    
                    <th>邮箱</th>
                    <th>是否启用</th>
                    <th>备注</th>
                </tr>
                <tr v-for="item in tabArr">
                    <td><input type="checkbox" name="" :id="item.id.toString()"></td>
                    <td>{{ item.username }}</td>
                    <td>{{ item.nickName }}</td>
                    
                    <td>{{ item.email }}</td>
                    <td>
                        <div v-if="item.isActived == true">
                            <CheckCircleFilled style="color: green;" />
                        </div>
                        <div v-else-if="item.isActived == false">
                            <CloseCircleFilled style="color: red;" />
                        </div>
                    </td>
                    <td>{{ item.remark }}</td>
                </tr>
            </table>
        </div>
        <!-- //el-dialog 模态框-->
        <div class="el-dialog" v-show="dialog">
            <div class="el-dialog-content">
                <div><label>添加用户</label></div>
                <span class="el-dialog-icon">
                    <SearchOutlined />
                </span>
                <input type="text" placeholder="请输入关键字">

                <a-table class="a-table" :row-selection="rowSelection" :columns="columns" :data-source="data"
                    :pagination="{ pageSize: 50 }" :scroll="{ x: 700, y: 450 }" bordered />
                <div class="el-dialog-footer">
                    <button type="button" class="button1" @click=confirm>确定</button>
                    <button type="button" class="button2" @click="cancel">取消</button>
                </div>
            </div>
        </div>
    </div>
</template>



<script setup>
import { ref, reactive,onMounted } from "vue";
import axios from "axios";
import {
    SearchOutlined,
    CheckCircleFilled,
    CloseCircleFilled
} from '@ant-design/icons-vue';
let rolename = reactive([])
const filteredRoles=reactive([])

onMounted(async () => {
    try {
    let res = await axios.get('http://localhost:63760/api/role');
    let user = await axios.get('https://localhost:63759/api/user')
    const users= user.data.filter(item=>!item.isDeleted);
    console.log(users);
    tabArr.value=users
    rolename = res.data;
    // console.log(Rolearr);    
    filteredRoles.values = rolename.data.filter(item=>!item.isDeleted);
    console.log(filteredRoles);
  } catch (err) {
    console.log(err);
  }
});

//模态框显示或隐藏
let dialog = ref(false);
//表格测试数据
let tabArr = ref([])

//模态框内固定表头的样式
const columns = [
    {
        title: '用户账号',
        dataIndex: 'account',
    },
    {
        title: '用户名称',
        dataIndex: 'name',
    },
    {
        title: '性别',
        dataIndex: 'gender',
    },
    {
        title: '邮箱',
        dataIndex: 'email',
    },
    {
        title: '是否可用',
        dataIndex: 'checked',
    },
    {
        title: '备注',
        dataIndex: 'remark',
    },
];
// 模态框内表格数据
let data = [
    {
        key: 1,
        account: '1111',
        name: '系统管理员',
        gender: '男',
        email: '1111@163.com',
        checked: true,
        remark: ''
    }
]

//行选择配置
const rowSelection = {
    onChange: (selectedRowKeys, selectedRows) => {
        console.log('Selected row keys:', selectedRowKeys);
        console.log('Selected rows:', selectedRows);
    }
}
function handleClick(key) {
    if (key == 2) {
        console.log(key);
    }
}
//添加用户
function Add() {
    dialog.value = true;
}
//全部取消
function cancels() {

}
//确定
function confirm() {

}
//取消
function cancel() {
    dialog.value = false;
}
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