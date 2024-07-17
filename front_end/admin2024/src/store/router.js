import { routes } from '../route/staticRoutes'
import { defineStore } from 'pinia'
import { computed, reactive, ref } from 'vue'
import { useRouter } from 'vue-router'

// 为了将路由实例引入进来，特意采用了setup语法，有没有注意到defineStore函数，没错，第2个参数是个函数，这就是setup语法
export const useRouterStore = defineStore('router', () => {
    // 引入路由实例
    const router = useRouter();

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
    let activeKey = ref('/desktop')
    const selectKeys=reactive([]);

    // 这个是计算属性，也是getters
    const flatMenuArr = computed(() => {
        let arr = flatArr(menuArr);
        return arr;
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

    function addTab(key) {// 添加对象到标签数组中（如果不存在则添加）
        // console.log('拍扁的菜单数据', this.flatMenuArr);
        var isExist = this.tabArr.filter(item => item.key === key);
        if (isExist.length > 0) {

        } else {
            let tmp = getOjbectByKey(key, this.flatMenuArr);
            // console.log(tmp);
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
        console.log(selectKeys);

        this.changeActiveKey(key);

        console.log(selectKeys);
    }

    // 改变当前项
    function changeActiveKey(key) {//切换当前Key
        console.log('这里输出准备要修改的key值：', key);

        if (activeKey.value !== key) {
            activeKey.value = key;
            selectKeys.splice(0);
            selectKeys.push(activeKey.value);
        }
    }


    // 这里必须返回
    return {
        menuArr,
        tabArr,
        activeKey,
        selectKeys,
        flatMenuArr,
        generatRoutes,
        addTab,
        changeActiveKey,
        changeActiveRoute
    }
})

// 一个函数，将一个路由对象，转换为左侧菜单栏对象
const createMenuItemFromRoute = (route) => {
    if (route.meta.hide && route.meta.hide === true) {
        return;
    }
    // 先拿到路由中的基本信息
    let obj = {
        key: route.path,
        title: route.meta.title,
        label: route.meta.title,
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
    })
    return resArr;
}