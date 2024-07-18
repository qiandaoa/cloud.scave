<template>
    <div>
        <div class="role-list-container">
            <span class="role-name">角色名称</span>
            <input type="text" class="input-text" placeholder="角色名称">
            <button type="button" class="search-button" @click="Search">
                <SearchOutlined /> 搜索
            </button>
            <button type="button" class="reset-button" @click="Reset">
                <SyncOutlined /> 重置
            </button>
        </div>
        <div class="role-list-container">
            <button type="button" class="add-button" @click="Add">
                <PlusOutlined /> 添加
            </button>
            <button type="button" class="delete-button" @click="BatchDelete">批量删除</button>
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
                        <td class="td330">角色编码</td>
                        <td class="td230">创建时间</td>
                        <td class="td230 tdcenter">操作</td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for=" item in currentPageData" :key="item.id">
                        <td>
                            <input type="checkbox" name="" id="">
                        </td>
                        <td class="tdcenter">{{ item.id }}</td>
                        <td>{{ item.name }}</td>
                        <td>{{ item.encode }}</td>
                        <td>{{ item.createTime }}</td>
                        <td class="tdcenter">
                            <button class="blue" @click="Edit(item.id)">
                                <EditOutlined />
                            </button>
                            <button class="red" @click="Delete(item.id)">
                                <DeleteOutlined />
                            </button>
                            <button class="yellow">
                                <PlusCircleOutlined />
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="role-list-container pagination">
            <a-pagination v-model:current="current" :total="tabArr.length" :pageSize="pageSize" show-quick-jumper
                @change="onChange" />
        </div>
    </div>
</template>



<script setup lang="ts">
import { ref, reactive, computed } from 'vue';
import {
    SearchOutlined,
    SyncOutlined,
    PlusOutlined,
    EditOutlined,
    DeleteOutlined,
    PlusCircleOutlined
} from '@ant-design/icons-vue';

// 创建响应式状态
const pageSize = 10;
const current = ref(Number(1));

const currentPageData = computed(() => {
    const start = (current.value - 1) * pageSize;
    const end = start + pageSize;
    return tabArr.slice(start, end);
});
// 分页改变时的处理函数
function onChange(pageNumber: number) {
    current.value = pageNumber;
};

let tabArr = reactive([
    {
        id: 1,
        name: '管理员',
        encode: 'admin',
        createTime: '2022-01-01',
    },
    {
        id: 2,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 3,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 4,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 5,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 6,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 7,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 8,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 9,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 10,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 11,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 12,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 13,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 14,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 15,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 16,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 17,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 18,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 19,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 20,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 21,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 22,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 23,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 24,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 25,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 26,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 27,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
    {
        id: 28,
        name: '用户',
        encode: 'user',
        createTime: '2022-01-01',
    },
]);
function Search() {
    console.log('搜索');
};

function Reset() {
    console.log('重置');
};

function Add() {
    console.log('添加');
};

function BatchDelete() {
    console.log('批量删除');
};

function Edit(id) {
    console.log(`编辑`);
};

function Delete(id) {
    console.log(`删除`);
};
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
    padding: 10px;
    border: 2px solid rgb(241, 243, 248);
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
    min-width: 800px;
    margin: 0 0 10px 0;
    padding: 10px;
    border: 2px solid rgb(241, 243, 248);
}

.pagination {
    text-align: center;
}

[type=button] {
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
    width: 30px;
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
</style>