<template>
    <div class="el">
        <div class="el-top" v-show="topshow">
            <div class="icon-div">
                <SearchOutlined class="icon-search" />
            </div>
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
            <button type="button" class="icon icon-sync" @click="reset">
                <SyncOutlined />
            </button>
            <button type="button" class="icon icon-search" @click="show">
                <SearchOutlined />
            </button>

            <a-table class="el-bottom-table" :columns="columns" :data-source="menuData" :scroll="{ x: 800 }" bordered>
                <template #action="{ record }">
                    <div>
                        <button type="button" class="icon icon-delete" @click="Delete(record.key)">
                            <DeleteOutlined />
                        </button>
                        <button type="button" class="icon icon-edit" @click="edit(record.key)">
                            <EditOutlined />
                        </button>
                    </div>
                </template>
            </a-table>
        </div>
        <div class="modal" v-show="modalShow">
            <div class="modal-content">
                <div class="modal-header">新增菜单
                    <CloseOutlined class="icon-close" @click="cancel" />
                </div>
                <table>
                    <input type="text" v-model="key" hidden>
                    <tr>
                        <td><span style="color: red;">*</span> 菜单名称</td>
                        <td><input type="text" v-model="name"></td>
                        <td><span style="color: red;">*</span> 显示排序</td>
                        <td><input type="number" v-model="sort" min="0"></td>
                    </tr>
                    <tr>
                        <td><span style="color: red;">*</span> 路由地址</td>
                        <td><input type="text" v-model="path"></td>
                        <td>&nbsp;&nbsp;组件路径</td>
                        <td><input type="text" v-model="component"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;权限标识</td>
                        <td><input type="text" v-model="permissions"></td>
                        <td>&nbsp;&nbsp;是否缓存</td>
                        <td>
                            <input type="radio" id="1" value="true" v-model="cache">
                            <label for="1">是</label>
                            <input type="radio" id="0" value="false" v-model="cache" checked>
                            <label for="0">否</label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;显示状态</td>
                        <td>
                            <input type="radio" id="1" value="true" v-model="status">
                            <label for="1">显示</label>
                            <input type="radio" id="0" value="false" v-model="status" checked>
                            <label for="0">隐藏</label>
                        </td>
                    </tr>
                </table>
                <div class="div-button">
                    <button type="button" class="save-button" @click="save">确定</button>
                    <button type="button" class="cancel-button" @click="cancel">取消</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, computed, onMounted } from 'vue'
import {
    SearchOutlined,
    SyncOutlined,
    CloseOutlined,
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
        dataIndex: 'sort',
        sorter: (a, b) => a.sort - b.sort, // 添加排序比较函数
        defaultSortOrder: 'ascend', // 设置默认排序方向为升序
    },
    {
        title: '路由地址',
        dataIndex: 'path',
    },
    {
        title: '权限标识',
        dataIndex: 'permissions'
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
let menuData = ref([]);
const initializeMenuData = () => {
    menuData.value = [
        {
            sort: 1,
            key: 1,
            name: '首页',
            permissions: '',
            path: '/',
            component: '',
            cache: true,
            status: true,
            children: [
                {
                    sort: 1,
                    key: 2,
                    name: '工作台',
                    permissions: '',
                    path: 'desktop',
                    component: '',
                    cache: true,
                    status: true,
                },
                {
                    sort: 2,
                    key: 3,
                    name: '仪表盘',
                    permissions: '',
                    path: 'sdashboard',
                    component: '',
                    cache: true,
                    status: true,
                }
            ]
        },
        {
            sort: 2,
            key: 4,
            name: '系统管理',
            permissions: '',
            path: 'system',
            component: '',
            cache: true,
            status: true,
            children: [
                {
                    sort: 1,
                    key: 5,
                    name: '用户管理',
                    permissions: '',
                    path: 'user',
                    component: '',
                    cache: true,
                    status: true,
                    children: [
                        {
                            sort: 1,
                            key: 6,
                            name: '用户详细',
                            permissions: '',
                            path: 'detail',
                            component: '',
                            cache: true,
                            status: true,

                        }
                    ]
                },
            ]
        },
        {
            sort: 3,
            key: 7,
            name: '角色管理',
            permissions: '',
            path: 'role',
            component: '',
            cache: true,
            status: true
        },
        {
            sort: 4,
            key: 8,
            name: '权限管理',
            permissions: '',
            path: 'permission',
            component: '',
            cache: true,
            status: true
        },
        {
            sort: 5,
            key: 9,
            name: '用户角色',
            permissions: '',
            path: 'userrole',
            component: '',
            cache: true,
            status: true
        },
        {
            sort: 6,
            key: 10,
            name: '菜单管理',
            permissions: '',
            path: 'menu',
            component: '',
            cache: true,
            status: true
        },
    ]
}

//页面加载获取数据
onMounted(initializeMenuData)

//搜索数据
let keyword = ref('');
let menuArr = [];
const search = () => {
    menuArr = [];
    menuData.value.forEach(item => {
        createMenuItemFromsearch(item, keyword.value, menuArr);
    });
    menuData.value.splice(0, menuData.value.length, ...menuArr);
    menuArr = [];
    if (keyword.value == '') {
        initializeMenuData();
    }
};
const createMenuItemFromsearch = (route, keyword) => {
    let matchedChildren = [];

    if (route.children && route.children.length > 0) {
        route.children.forEach(item => {
            createMenuItemFromsearch(item, keyword, matchedChildren);
        });
    }

    if (route.name.indexOf(keyword) !== -1 || matchedChildren.length > 0) {
        let obj = {
            key: route.key,
            name: route.name,
            permissions: route.permissions,
            path: route.path,
            component: route.component,
            cache: route.cache,
            status: route.status,
        };
        menuArr.push(obj);
    }
    // 将匹配的子菜单添加到menuArr中
    menuArr.push(...matchedChildren);
};
//重置搜索框
const reset = () => {
    keyword.value = '';
    initializeMenuData();
}

//新增数据
const maxKey = computed(() => {
    let max = 0;
    menuData.value.forEach(item => {
        createMenuItemFromAdd(item, max);
    });
    return max;
});
let modalShow = ref(false);
const add = () => {
    modalShow.value = true;
}
const createMenuItemFromAdd = (route, maxkey) => {
    if (route.key > maxkey) {
        maxkey = route.key;
    }

    if (route.children && route.children.length > 0) {
        route.children.forEach(item => {
            createMenuItemFromAdd(item);
        })
    }
}
//编辑数据
let key = ref(0)
let sort = ref(0);
let name = ref('');
let permissions = ref('');
let path = ref('');
let component = ref('');
let cache = ref('');
let status = ref('');
const edit = (Key) => {
    menuData.value.forEach(item => {
        createMenuItemFromedit(item, Key);
    });
    modalShow.value = true;
}
const createMenuItemFromedit = (route, Key) => {
    if (route.key === Key) {
        key.value = route.key;
        sort.value = route.sort;
        name.value = route.name;
        permissions.value = route.permissions;
        path.value = route.path;
        component.value = route.component;
        cache.value = route.cache;
        status.value = route.status;
    }

    if (route.children && route.children.length > 0) {
        route.children.forEach(item => {
            createMenuItemFromsearch(item, key);
        })
    }
}

//确认与保存
const save = () => {
    if (sort.value < 0) {
        alert('排序最小值不能小于0');
        return
    }
    if (name.value === '' || sort.value === '' || path.value === '') {
        alert('请填写所有必填项');
        return;
    }
    if (key.value === 0) {
        const newItem = {
            sort: sort.value,
            key: maxKey.value + 1,
            name: name.value.trim(),
            permissions: permissions.value.trim(),
            path: path.value.trim(),
            component: component.value.trim(),
            cache: cache.value,
            status: status.value,
        };
        menuData.value.push(newItem);
    } else {
        menuData.value.forEach((item) => {
            createMenuItemFrom(item, key.value);
        })
    }
    cancel();
};
// 编辑菜单项的递归函数
const createMenuItemFrom = (route, Key) => {
    if (route.key === Key) {
        route.sort = sort.value;
        route.name = name.value;
        route.permissions = permissions.value;
        route.path = path.value;
        route.component = component.value;
        route.cache = cache.value;
        route.status = status.value;
    }

    if (route.children && route.children.length > 0) {
        route.children.forEach(item => {
            createMenuItemFromsearch(item);
        })
    }
}

//取消
const cancel = () => {
    key.value = 0;
    sort.value = 0;
    name.value = '';
    permissions.value = '';
    path.value = '';
    component.value = '';
    cache.value = '';
    status.value = '';
    modalShow.value = false;
}
//删除数据
const Delete = (key) => {
    if (confirm('确定删除所选菜单及其所有子菜单吗？')) {
        menuData.value = deleteMenuItemRecursively(menuData.value, key);
    }
};
const deleteMenuItemRecursively = (items, keyToDelete) => {
    return items.filter(item => {
        // 如果当前项是要删除的项，则不包括在新数组中
        if (item.key === keyToDelete) {
            return false;
        }
        // 如果当前项有子项，递归地删除子项中的目标项
        if (item.children && item.children.length > 0) { // 避免空数组报错
            item.children = deleteMenuItemRecursively(item.children, keyToDelete); // 递归删除子项
        }
        // 包括当前项在新数组中
        return true;
    });
};

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
}

.el-top {
    margin: 0 0 30px 0;
}

.el-top .icon-div {
    position: relative;
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
<style scoped>
.modal {
    width: 100vw;
    height: 100vh;
    display: flex;
    background-color: rgba(0, 0, 0, 0.5);
    position: absolute;
    justify-content: center;
    top: 0;
    left: 0;
    z-index: 100;
}

.modal-content {
    width: 800px;
    height: 400px;
    padding: 30px;
    background-color: white;
    position: relative;
    border-radius: 10px;
    top: 100px;
}

.modal .icon-close {
    font-size: 14px;
    position: absolute;
    right: 40px;
}

.modal .icon-close:hover {
    color: aqua;
}

.modal-header {
    margin: 0 0 20px 0;
    font-size: large;
}

.modal table {
    font-size: 15px;
}

.modal input[type=text],
.modal input[type=number] {
    width: 250px;
    padding: 5px 0 5px 10px;
    border: 1px solid rgb(240, 240, 240);
    border-radius: 5px;
}

.modal input[type=text]:focus {
    outline: none;
}

.modal input[type=radio] {
    margin: 0 0 0 30px;
}

.modal table td {
    min-width: 80px;
    padding: 0 0 20px 0;
}

.modal button {
    width: 55px;
    height: 30px;
    border: 1px solid rgb(240, 240, 240);
    border-radius: 5px;
    margin: 0 0 0 10px;
    background-color: white;
}

.modal .save-button {
    color: white;
    background-color: rgb(24, 144, 255);
}

.modal .div-button {
    position: absolute;
    right: 30px;
    bottom: 30px;
}
</style>