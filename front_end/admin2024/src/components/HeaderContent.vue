<template>
    <div>
        <a-tabs v-model:activeKey="activeKey" hide-add type="editable-card" @edit="onEdit" @change="handleTabsChange">
            <a-tab-pane v-for="pane in tabArr" :key="pane.key" :tab="pane.title" :closable="pane.closable">
                <!-- <router-view></router-view> -->
            </a-tab-pane>
        </a-tabs>
    </div>
</template>
<script setup>
import { storeToRefs } from 'pinia'
import { useRouterStore } from '../store/router'

// 使用pinia获取routerStore的引用
let routerStore = useRouterStore();
// 通过storeToRefs将routerStore中的tabArr和activeKey引用到本地
let { tabArr, activeKey } = storeToRefs(routerStore)

/**
 * 移除指定键值的标签页
 * @param {String} targetKey - 要移除的标签页的键值
 */
const remove = targetKey => {
    let lastIndex = 0;
    // 过滤掉要移除的标签页，并更新tabArr
    tabArr.value = tabArr.value.filter((pane, index) => {
        if (pane.key === targetKey) {
            lastIndex = Math.max(0, index - 1);
            return false
        }
        return true
    })
    // 如果被移除的标签页是当前活动的标签页，则调整activeKey
    if (tabArr.value.length && activeKey.value === targetKey) {
        if (lastIndex >= 0) {
            activeKey.value = tabArr.value[lastIndex].key;
            routerStore.changeActiveRoute(tabArr.value[lastIndex].key); // 触发路由更新
        } else {
            activeKey.value = tabArr.value[0].key
            routerStore.changeActiveRoute(tabArr.value[0].key); // 触发路由更新
        }
    }
};

/**
 * 处理标签页的编辑操作
 * @param {String} targetKey - 被编辑的标签页的键值
 * @param {String} action - 编辑操作类型（如'remove'）
 */
const onEdit = (targetKey, action) => {
    if (action === 'remove') {
        remove(targetKey)
    }
};

/**
 * 当标签页切换时触发的事件处理函数
 * @param {String} key - 新的活动标签页的键值
 */
function handleTabsChange(key) {
    routerStore.changeActiveRoute(key);
    
}
</script>