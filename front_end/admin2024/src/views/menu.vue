<template>
    <div class="el">
        <div class="el-top" v-show="topshow">
            <SearchOutlined class="icon-search" />
            <input type="text" placeholder="请输入菜单名称" v-model="keyword">
            <button type="button" class="buttonsearch" @click="search">
                <SearchOutlined /> 搜索
            </button>
            <button type="button" @click="reset">
                <SyncOutlined /> 重置
            </button>
        </div>
        <div class="el-bottom">
            <button type="button" class="buttonAdd" @click="add">
                <PlusOutlined /> 新增
            </button>
            <button type="button" class="icon icon-sync" @click="show">
                <SyncOutlined />
            </button>
            <button type="button" class="icon icon-search" @click="sync">
                <SearchOutlined />
            </button>

            <a-table class="el-bottom-table" :columns="columns" :data-source="data" :scroll="{ x: 800 }" bordered>
                <template #action="{ record }">
                    <div>
                        <button type="button" class="icon icon-delete" @click="Delete(record.id)">
                            <DeleteOutlined />
                        </button>
                        <button type="button" class="icon icon-edit" @click="edit(record.id)">
                            <EditOutlined />
                        </button>
                    </div>
                </template>
            </a-table>
        </div>
    </div>
</template>

<script setup>
import { ref, computed, onMounted } from 'vue'
import {
    SearchOutlined,
    SyncOutlined,
    PlusOutlined,
    DeleteOutlined,
    EditOutlined,
} from '@ant-design/icons-vue';

// 表单头部结构
const columns = [
    {
        title: '菜单名称',
        dataIndex: 'name',
    },
    {
        title: '排序',
        dataIndex: 'key',
    },
    {
        title: '权限标识',
        dataIndex: 'permissions'
    }, {
        title: '路由地址',
        dataIndex: 'path',
    },
    {
        title: '组件路径',
        dataIndex: 'component',
    },
    {
        title: '是否缓存',
        dataIndex: 'cache',
        customRender: (item) => {
            return item.value === true || item.value === 'true' ? '是' : '否'
        }
    },
    {
        title: '状态',
        dataIndex: 'status',
        customRender: (item) => {
            return item.value === true || item.value === 'true' ? '显示' : '隐藏'
        }
    },
    {
        title: '操作',
        dataIndex: 'action',
        slots: { customRender: 'action' },
    }
];

// 表单数据
let data = ref([
    {
        key: 1,
        name: '基础信息',
        permissions: '',
        path: 'basic',
        component: '',
        cache: true,
        status: true,
        children: [
            {
                key: 2,
                name: '用户信息',
                permissions: '',
                path: 'basic/user',
                component: '',
                cache: true,
                status: false,
            }, {
                key: 3,
                name: '用户信息',
                permissions: '',
                path: 'basic/user/user',
            }
        ]
    }
])

//页面加载获取数据


//搜索数据
let keyword = ref('');
const search = () => {
    console.log(keyword.value)
}
//重置搜索框
const reset = () => {
    keyword.value = '';
}

//新增数据
let add = () => {

}

//搜索框显示与隐藏
let topshow = ref(true);
const show = () => {
    if (topshow.value === true) {
        topshow.value = false;
    }
    else {
        topshow.value = true;
    }
}
</script>


<style scoped>
.el {
    font-size: 12px;
    position: relative;
}

.el-top {
    margin: 0 0 30px 0;
}

.el-top .icon-search {
    position: absolute;
    top: 10px;
    left: 10px;
}

.el-top input,
.el-top button {
    height: 30px;
    margin: 0 10px 0 0;
    border: 1px solid rgb(240, 240, 240);
    border-radius: 3px;
    background-color: white;
}

.el-top input {
    padding: 0 0 0 30px;
}

.el-top button {
    width: 70px;
}

.el-top .buttonsearch {
    color: white;
    background-color: rgb(24, 144, 255);
}

button:hover {
    cursor: pointer;
}

button:active {
    transform: scale(0.9);
}
</style>
<style scoped>
.el-bottom button {
    height: 30px;
    border: 1px solid rgb(240, 240, 240);
    border-radius: 5px;
    background-color: white;
}

.el-bottom .buttonAdd {
    width: 80px;
    color: white;
    background-color: rgb(19, 206, 102);
}

.el-bottom-table {
    margin: 30px 0 0 0;
}

.el-bottom .icon {
    width: 50px;
    float: right;
}

.el-bottom .icon-search {
    border-radius: 5px 0 0 5px;
    background-color: rgb(244, 244, 245);
}

.el-bottom .icon-sync {
    border-radius: 0 5px 5px 0;
}

.el-bottom .icon-edit {
    color: white;
    border-radius: 5px 0 0 5px;
    background-color: rgb(144, 147, 153);
}

.el-bottom .icon-delete {
    color: white;
    border-radius: 0 5px 5px 0;
    background-color: rgb(255, 0, 0);
}
</style>