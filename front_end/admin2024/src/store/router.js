import { routes } from '../route/staticRoutes'
import { defineStore } from 'pinia'
import { computed, reactive, ref, watch,onMounted    } from 'vue'
import { useRouter, useRoute } from 'vue-router'

// 为了将路由实例引入进来，特意采用了setup语法，有没有注意到defineStore函数，没错，第2个参数是个函数，这就是setup语法
export const useRouterStore = defineStore('router', () => {
    // 引入路由实例
    const router = useRouter();
    const route = useRoute();

    // 以下为定义的state
    const menuArr = reactive([]);// 菜单数据
    const tabArr = reactive([// 标签栏数据
        {
            key: '/desktop',
            title: '工作台',
            content: ''
        },
        {
            key: '/dashboard',
            title: '仪表盘',
            content: ''
        },
    ]);
    // 当前的key，用于绑定到菜单栏和标签栏的“当前项”属性
    let activeKey = ref('/desktop')//存储当前活动的标签页的键
    // 存储当前选中的菜单项和应该打开的菜单子项的键
    const selectKeys = reactive([]);
    const openKeys = reactive([]);

    // 扁平化的菜单数据，这个是计算属性，也是getters
    const flatMenuArr = computed(() => {
        let arr = flatArr(menuArr);      
        return arr;
    })

    // 下面两个函数用于在本地存储中保存和加载当前活动的标签页状态，以实现页面刷新后的状态保持
    function saveStateToLocalStorage() {
        // localStorage.setItem('activeTab', String(activeKey.value));
        localStorage.setItem('activeTab', JSON.stringify(activeKey.value));
    }

    function loadStateFromLocalStorage() {
        const savedActiveKey = JSON.parse(localStorage.getItem('activeTab'));
        
        // console.log(savedActiveKey);
       
        if (savedActiveKey) {
            activeKey.value = savedActiveKey;
            // console.log(activeKey.value);
            // 确保界面状态正确更新
            changeActiveKey(savedActiveKey);
        }
    }
    

    // 监听路由变化，在路由改变时调用 changeActiveKey 更新状态
    watch(route, (newVal) => {
        changeActiveKey(newVal.path)
    })

    // 由路由数据生成菜单数据
    function generatRoutes() {
        // 清空原来的所有菜单数据，准备重新生成
        this.menuArr.splice(0);
        routes.forEach(item => {
            let menu = createMenuItemFromRoute(item);
            if (menu) {
                this.menuArr.push(menu);
            }
        })
    }
    // 添加对象到标签数组中（如果不存在则添加）
    function addTab(key) {
        var isExist = this.tabArr.filter(item => item.key === key);
        if (isExist.length > 0) {
        } else {
            let tmp = getOjbectByKey(key, this.flatMenuArr);;
            let obj = {
                title: tmp.title,
                content: ``,
                key: key,
            }
            this.tabArr.push(obj);
        }
    }

    // 菜单栏和标签栏点击后，改变路由的统一逻辑
    function changeActiveRoute(key) {
        router.push(key);
        this.addTab(key);
    }

    // 改变当前项,用于更新当前活动的标签页状态
    function changeActiveKey(key) {
        // 设置标签栏的当前key
        activeKey.value = key;
        
        // 设置菜单栏的当前选择的菜单项
        // selectKeys.splice(0);
        // selectKeys.push(key);
        selectKeys.splice(0,selectKeys.length,key);

        // 设置菜单栏当前展开的子菜单
        let x = findParent(key, flatMenuArr.value);
        let y = findParentChainIterative(flatMenuArr.value, key);
        
        openKeys.splice(0);
        openKeys.push(...y);

        saveStateToLocalStorage();
    }

    onMounted(() => {
        loadStateFromLocalStorage();
    })

    // 这里必须返回
    return {
        menuArr,
        tabArr,
        openKeys,
        activeKey,
        selectKeys,
        flatMenuArr,
        generatRoutes,
        addTab,
        changeActiveKey,
        changeActiveRoute,
       
    }
}

)

// 辅助函数，将一个路由对象，转换为左侧菜单栏对象
const createMenuItemFromRoute = (route) => {
    if (route.meta.hide && route.meta.hide === true) {
        return;
    }
    // 先拿到路由中的基本信息
    let obj = {
        key: route.path,
        title: route.meta.title,
        label: route.meta.title,
        icon:route.meta.icon
    }

    // 尝试处理其下级路由，将其转化为菜单数组返回，挂载到孩子属性
    let arr = [];
    if (route.children && route.children.length > 0) {
        route.children.forEach(item => {
            let tmpObj = createMenuItemFromRoute(item);
            arr.push(tmpObj);
        })

        if (arr.length > 0) {
            obj.children = arr;
        }
    }
    return obj;
}

// 从数组中筛选key值对应的对象
const getOjbectByKey = function (key, arr) {
    let tmp = arr.filter(item => item.key === key);
    if (tmp.length > 0) {
        return tmp[0];
    }
    return undefined;
}

// 将数组扁平化，突然想到，这个好像可以用计算属性，嗯，就这么办，所以这个闲置了，本功能代码待清理
const flatArr = (arr) => {
    let resArr = [];
    arr.forEach(item => {
        if (item && typeof item === 'object' && 'key' in item) { // 确保 item 是一个对象且有 key 属性
            let obj = {
                key: item.key,
                title: item.title,
                content: ''
            }
            resArr.push(obj);
            if (item.children && item.children.length > 0) {
                let tmpArr = flatArr(item.children);
                resArr = resArr.concat(tmpArr);
            }
        }
    })
    return resArr;
}

// 在拍扁的数组中，查找上级key，需要查找多级
const findParent = (key, arr) => {
    // console.log('传入的拍扁的数组',arr);
    let res = [];
    let tmpArr = arr.filter(item => item.key === key).map(item => item.parentKey);
    tmpArr.forEach(item => {
        if (item) {
            res.push(item);
        }
    })
    return res;
}

function findParentChainIterative(records, key) {
    const parentIdMap = records.reduce((acc, record) => {
        acc[record.key] = record.parentKey;
        return acc;
    }, {});

    const ancestors = [];
    let currentId = key;

    while (parentIdMap[currentId] !== 0) {
        const parentRecord = records.find(r => r.key === parentIdMap[currentId]);
        if (parentRecord) {
            ancestors.unshift(parentRecord);
            currentId = parentIdMap[currentId];
        } else {
            break; // 如果找不到父级记录，停止查找
        }
    }
    return ancestors.map(x => x.key);
}