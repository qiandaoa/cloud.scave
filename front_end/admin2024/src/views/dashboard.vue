<template>
    <div class="no-data-container">
        <FileTextOutlined class="icon-large gray-icon" />
        <p class="center-text">暂无数据</p>
    </div>
</template>

<script setup>
import { FileTextOutlined } from '@ant-design/icons-vue';
</script>

<style scoped>
.no-data-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    height: 100%;
}

.icon-large {
    font-size: 48px;
}

.gray-icon {
    color: #ccc;
}

.center-text {
    margin-top: 10px;
    text-align: center;
    color: #ccc;
}
</style>