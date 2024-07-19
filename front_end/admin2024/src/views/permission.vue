<template>
    <div class="el">
        <div class="el-left">
            <a-menu class="el-left-menu">
                <a-menu-item key="1" disabled>
                    角色名称
                </a-menu-item>
                <a-menu-item key="2">
                    系统管理员
                </a-menu-item>
            </a-menu>
        </div>
        <div class="el-right">
            <button type="button" style="background-color: blue;">全部选择</button>
            <button type="button" style="background-color: red;">全部取消</button>
            <button type="button" style="background-color: green;">保存设置</button>
            <span class="el-right-icon">
                <SearchOutlined />
            </span>

            <input type="text" placeholder="请输入关键字">
            <table class="el-right-table">
                <tr>
                    <th>#</th>
                    <th>角色</th>
                    <th>权限列表</th>
                </tr>
                <tr v-for="item in tabArr">
                    <td style="max-width: 5%;">{{ item.id }}</td>
                    <td style="max-width: 25%;">{{ item.name }}</td>
                    <td style="max-width: 70%;">
                        <input type="checkbox" value="浏览" name="" :id="item.id"><span>浏览</span>
                        <input type="checkbox" value="添加" name="" :id="item.id"><span>添加</span>
                        <input type="checkbox" value="删除" name="" :id="item.id"><span>删除</span>
                        <input type="checkbox" value="编辑" name="" :id="item.id"><span>编辑</span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</template>



<script setup>
import { reactive } from "vue";
import {
    SearchOutlined,
} from '@ant-design/icons-vue';
let tabArr = reactive([
    {
        id: 1,
        name: '管理员',
    },
    {
        id: 2,
        name: '用户',
    },
    {
        id: 3,
        name: '游客',
    }

])
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

.el-right .el-right-table input[type=checkbox]:checked,
.el-right .el-right-table input[type=checkbox]:checked+span {
    color: blue;
    accent-color: blue;
}
</style>