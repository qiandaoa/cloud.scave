```
<template>
    <!-- 页面布局容器 -->
    <div class="allbody">
        <!-- 头部内容区域 -->
        <div class="header-content">
            <!-- 面包屑导航 -->
            <div class="breadcrumb">
                <a-breadcrumb>
                    <!-- 循环遍历并展示面包屑项 -->
                    <a-breadcrumb-item class="text" v-for="(item, index) in breadcrumbItems" :key="index">
                        {{ item.text }}
                    </a-breadcrumb-item>
                </a-breadcrumb>
            </div>
            <!-- 用户头像及下拉菜单 -->
            <div class="acvtar">
                <a-dropdown>
                    <!-- 触发下拉菜单的链接 -->
                    <a class="ant-dropdown-link" @click.prevent>
                        <a-space direction="vertical" :size="80">
                            <a-space wrap :size="32">
                                <!-- 用户头像 -->
                                <a-avatar :src="imageUrl" alt="User Avatar" :size="52">
                                </a-avatar>
                                <!-- <span class="username">{{ username }}</span> -->
                            </a-space>
                        </a-space>
                    </a>
                    <!-- 下拉菜单内容 -->
                    <template #overlay>
                        <a-menu class="custom-menu">
                            <!-- 首页菜单项 -->
                            <a-menu-item>
                                <a class="a" href="/">首页</a>
                            </a-menu-item>
                            <!-- 个人中心菜单项 -->
                            <a-menu-item>
                                <router-link to="/userinfo" class="a">个人中心</router-link>
                            </a-menu-item>
                            <!-- 分割线 -->
                            <hr>
                            <!-- 登出菜单项 -->
                            <a-menu-item>
                                <a @click="handleLogout" class="a">退出登录</a>
                            </a-menu-item>
                        </a-menu>
                    </template>
                </a-dropdown>
            </div>
        </div>
        <!-- 标签页区域 -->
        <div class="tabs">
            <a-tabs v-model:activeKey="activeKey" ref="tabsRef" hide-add type="editable-card" @edit="onEdit"
                @change="handleTabsChange">
                <!-- 循环生成标签页 -->
                <a-tab-pane v-for="pane in tabArr" :key="pane.key" :tab="pane.title" :closable="pane.title !== '工作台' && pane.title !== '仪表盘'
                    "></a-tab-pane>
            </a-tabs>

        </div>

    </div>
</template>

<script setup>
import { storeToRefs } from 'pinia';
import { useRouterStore } from '../store/router';
import { nextTick, watch, computed, ref, onMounted, onUnmounted } from 'vue';
import { useRoute, onBeforeRouteUpdate, useRouter, RouterLink } from 'vue-router';

import axios from 'axios';
// 初始化Vue Router实例
const router = useRouter();
// 用户头像源地址
const imageUrl = ref('');//默认头像
// 引用Pinia的路由状态存储
const routerStore = useRouterStore();
// 从状态存储中引用tabArr和activeKey
const { tabArr, activeKey } = storeToRefs(routerStore);

const username = localStorage.getItem('username');
const id = localStorage.getItem('userId')
// 获取当前路由对象
const route = useRoute();
const handleAvatarUpdated = url => {
    imageUrl.value = url;
};
onMounted(() => {
    // 注册事件监听器
    window.addEventListener('imageUrl', handleAvatarUpdated);
});
onUnmounted(() => {
    // 移除事件监听器，避免内存泄漏
    window.removeEventListener('imageUrl', handleAvatarUpdated);
});
//获取头像
onMounted(async () => {
    let user = await axios.get(`http://101.133.150.189:63759/api/user/${id}`)
    // console.log(user);
    //
    if (user.data.avatar) {
        try {
            let res = await axios.get(`http://101.133.150.189:63759/api/avatar/${id}`)
            //   console.log(res);
            imageUrl.value = res.data;
            // console.log(imageUrl);
        } catch (err) {
            console.log(err);
        }
    }

})

// 计算属性：根据当前路由生成面包屑数组
const breadcrumbItems = computed(() => {
    return route.matched.filter(route => route.meta && route.meta.title).map(route => ({
        text: route.meta.title,
    }));
});

// 监听路由变化，更新面包屑数据
onBeforeRouteUpdate(() => {
    // 更新breadcrumbItems
});

const tabsRef = ref(null); // 在你的组件中定义

// 删除标签页
const remove = targetKey => {
    let index = tabArr.value.findIndex(pane => pane.key === targetKey);
    let pane = tabArr.value.find(pane => pane.key === targetKey);
    if (pane.isFixed) {
        return;
    }

    // 如果要关闭的是当前活动标签页
    if (targetKey === activeKey.value) {
        // 找到前一个页面的键值
        let previousKey = tabArr.value[index - 1]?.key;
        if (previousKey) {
            activeKey.value = previousKey;
            routerStore.changeActiveRoute(previousKey);
        } else {
            // 如果这是第一个页面，则跳转到数组中的第二个页面
            const newActiveKey = tabArr.value[1]?.key || tabArr.value[0]?.key;
            if (newActiveKey) {
                activeKey.value = newActiveKey;
                routerStore.changeActiveRoute(newActiveKey);
            }
        }
    }

    // 过滤掉要删除的选项卡，无论它是否是活动的选项卡
    tabArr.value = tabArr.value.filter(pane => pane.key !== targetKey);

    // 使用 nextTick 确保 DOM 更新后，再进行组件的强制更新
    nextTick().then(() => {
        if (tabsRef.value) {
            tabsRef.value.$forceUpdate(); // 强制更新 a-tabs 组件
        }
        // console.log('DOM updated after removing tab:', tabArr.value);
        // 新增：保存更新后的标签页状态到 localStorage
    });
};

// 处理标签页的编辑操作
const onEdit = (targetKey, action) => {
    if (action === 'remove') {
        remove(targetKey);
    }
};

// 当标签页切换时触发的事件处理函数
const handleTabsChange = key => {
    routerStore.changeActiveRoute(key);
    routerStore.selectKeys = [key];
};

// 登出功能
const handleLogout = () => {
    localStorage.removeItem('token')
    localStorage.removeItem('userInfo')
    router.push('/login');
};

</script>

<style scoped>
.header-content {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 0 16px;
}

.acvtar {
    margin-right: 3%;

}

/* 面包屑样式 */
.breadcrumb {
    position: sticky;
    top: 0;
    flex-grow: 1;
    display: flex;
    margin-left: 20px;
}

.breadcrumb .text {
    color: palevioletred;
    font-size: larger;
}

.breadcrumb-item:not(:last-child)::after {
    content: '/';
    margin: 0 8px;
}

.breadcrumb-item:hover {
    color: #1890ff;
    cursor: pointer;
}

.ant-dropdown-link {
    display: inline-block;
    padding: 0 8px;
    cursor: pointer;
}

.custom-menu {
    width: 90px;
    max-height: 120px;
    overflow-y: auto;
}

.a:hover {
    color: blue;
}

/* .username {
    margin-left: -22px; /* 添加适当的间距 */
/* line-height: 48px; /* 使文本垂直居中，与头像高度相同 */
/* font-size: 18px; */
/* } */
</style>
