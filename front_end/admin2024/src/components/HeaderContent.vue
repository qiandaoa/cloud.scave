<template>
    <div class="allbody">
        <div class="header-content" >
            <div class="breadcrumb">
                <a-breadcrumb>
                    <a-breadcrumb-item class="text" v-for="(item, index) in breadcrumbItems" :key="index">
                        {{ item.text }}
                        <template #icon><RightOutlined /></template>
                    </a-breadcrumb-item>
                </a-breadcrumb>
            </div>
            <div class="acvtar">
                <a-dropdown >
                    <a class="ant-dropdown-link" @click.prevent>
                        <a-space direction="vertical" :size="32">
                            <a-space wrap :size="16">
                                <a-avatar src="https://xsgames.co/randomusers/avatar.php?g=pixel&key=1" :size="36">
                                    <template #icon></template>
                                </a-avatar>
                            </a-space>
                        </a-space>
                        
                    </a>
                    <template #overlay>
                        <a-menu class="custom-menu">
                            <a-menu-item>
                                <a href="/">首页</a>
                            </a-menu-item>
                            <a-menu-item>
                                <a href="../views/test.vue">测试</a>
                            </a-menu-item>
                            <a-menu-item>
                                <a href="../views/about.vue">测试</a>
                            </a-menu-item>
                        </a-menu>
                    </template>
                </a-dropdown>
            </div>
            
        </div>
    <div class="tabs">
        <a-tabs v-model:activeKey="activeKey" hide-add type="editable-card" @edit="onEdit" @change="handleTabsChange">
            <a-tab-pane  v-for="pane in tabArr" :key="pane.key" :tab="pane.title" :closable="!pane.closable">
                <!-- <router-view></router-view> -->
            </a-tab-pane>
        </a-tabs>
    </div>
</div>
</template>
<script setup>
import { storeToRefs } from 'pinia'
import { useRouterStore } from '../store/router'
import { nextTick, watch,computed } from 'vue';
import {RightOutlined } from '@ant-design/icons-vue';
import { useRoute,onBeforeRouteUpdate } from 'vue-router';

// 使用pinia获取routerStore的引用
let routerStore = useRouterStore();
// 通过storeToRefs将routerStore中的tabArr和activeKey引用到本地
let { tabArr, activeKey } = storeToRefs(routerStore)

watch(tabArr,()=>{
    if(tabArr.value.length>=2){
        tabArr.value[0].isFixed=true;
        tabArr.value[1].isFixed=true;

    }
    },{
        deep:true
})
const router=useRoute()
// 计算属性用于生成面包屑数组
const breadcrumbItems = computed(() => {
    // 获取当前活动的tab
    const currentTab = tabArr.value.find(pane => pane.key === activeKey.value);
    // 如果没有找到当前活动的tab，返回空数组
    if (!currentTab) return [];

    // 从tabArr中获取所有父级tab，直到找到一个isFixed为true的tab（假设isFixed为true的tab是根级别）
    const parentTabs = tabArr.value.filter(pane => {
        return tabArr.value.some(parent => parent.children?.includes(pane) && parent.isFixed);
    });

    // 将所有父级tab的title添加到数组中，再加上当前活动tab的title
    const items = [...parentTabs.map(pane => ({ text: pane.title })), { text: currentTab.title }];

    return items;
});


/**
 * 移除指定键值的标签页
 * @param {String} targetKey - 要移除的标签页的键值
 */
const remove = targetKey => {
    let index = tabArr.value.findIndex(pane => pane.key === targetKey);
    let pane = tabArr.value.find(pane => pane.key === targetKey);
    if(pane.isFixed)
        return;
     if (index > -1 && targetKey === activeKey.value) {
        // 如果要关闭的是当前活动标签页
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
    // Filter out the tab to be removed regardless of whether it's the active one
    tabArr.value = tabArr.value.filter(pane => pane.key !== targetKey);
    nextTick().then(()=>{
        console.log('DOM updated after removing tab:', tabArr.value);
        
        
    })
};

/**
 * 处理标签页的编辑操作
 * @param {String} targetKey - 被编辑的标签页的键值
 * @param {String} action - 编辑操作类型（如'remove'）
 */
const onEdit = (targetKey, action) => {
    if (action === 'remove') {
        remove(targetKey);
    }
};

/**
 * 当标签页切换时触发的事件处理函数
 * @param {String} key - 新的活动标签页的键值
 */
function handleTabsChange(key) {
    routerStore.changeActiveRoute(key);
    routerStore.changeActiveKey(key)
    // 如果左侧菜单的selectKeys直接从routerStore引用，这行代码可能不需要
    // 但是，它可以确保在所有情况下都保持同步
    routerStore.selectKeys = [key]; // 注意这里使用数组形式
    
}


</script>

<style scoped>
.header-content {
    display: flex;
    align-items: center;
    justify-content: flex-end;
    gap: 16px; /* 间距 */
}

.acvtar{
    margin-right: 80px;
}

/* 面包屑样式 */
.breadcrumb {
    position: sticky;
    top: 0;
    flex-grow: 1;
    display: flex;
    

    
    .text{
        color: pink;
    }
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
    width: 120px; /* 调整宽度 */
    max-height: 100px; /* 设置最大高度 */
    overflow-y: hidden; /* 不显示滚动条 */
}   

</style>