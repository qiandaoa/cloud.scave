<template>
    <div style="background: #ffffff; padding: 30px">
        <a-row :gutter="16">
            <a-col :span="12">
                <a-card>
                    <a-statistic title="反馈" :value="data.useState" :precision="2" suffix="%"
                        :value-style="{ color: '#3f8600' }" style="margin-right: 50px">
                        <template #prefix>
                            <arrow-up-outlined />
                        </template>
                    </a-statistic>
                </a-card>
            </a-col>
            <a-col :span="12">
                <a-card>
                    <a-statistic title="空闲" :value="data.useState" :precision="2" suffix="%" class="demo-class"
                        :value-style="{ color: '#cf1322' }">
                        <template #prefix>
                            <arrow-down-outlined />
                        </template>
                    </a-statistic>
                </a-card>
            </a-col>
        </a-row>
    </div>
    <div class="dashboard">
        <div class="dashboard-item1">
            <a-progress type="dashboard" :percent="data.useState1" :format="percent => `${percent}%`"
                :stroke-color="{ '0%': '#108ee9', '100%': '#87d068' }" />
            用户注册率
        </div>
        <div class="dashboard-item2">
            <a-progress type="dashboard" :percent="data.useState2" :format="percent => `${percent}%`"
                :stroke-color="{ '0%': '#cccccc', '100%': '#8aaaaa' }" />
            用户操作频率
        </div>
        <div class="dashboard-item3">
            <a-progress type="dashboard" :percent="data.useState3" :format="percent => `${percent}%`"
                :stroke-color="{ '0%': '#133ee9', '100%': '#10b037' }" />
            用户反馈率
        </div>
        <div class="dashboard-item4">
            <a-progress type="dashboard" :percent="data.useState4" :format="percent => `${percent}%`"
                :stroke-color="{ '0%': '#aaaaac', '100%': '#daddaa' }" />
            用户活跃数
        </div>
    </div>
</template>

<script setup>
import { ArrowUpOutlined, ArrowDownOutlined } from '@ant-design/icons-vue';
import { reactive } from 'vue';
/// 创建响应式数据
let data = reactive([
    {
        useState: '',
        useState1: '',
        useState2: '',
        useState3: '',
        useState4: ''
    }
])
// 定时器刷新数据
setInterval(() => {
    data.useState = Math.floor(Math.random() * 100)
    data.useState1 = Math.floor(Math.random() * 100)
    data.useState2 = Math.floor(Math.random() * 100)
    data.useState3 = Math.floor(Math.random() * 100)
    data.useState4 = Math.floor(Math.random() * 100)
}, 150)
</script>

<style scoped>
.dashboard {
    margin-top: 50px;
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: center;
    flex-wrap: wrap;
    gap: 100px;
    .ant-progress-circle-trail {
        stroke: #3f8600;
        stroke-linecap: round;
        stroke-dasharray: 0, 100;
        stroke-dashoffset: 0;
        animation: dash 1.5s ease-in-out infinite;
        animation-play-state: running;
    }
}

.dashboard-item1,
.dashboard-item2,
.dashboard-item3,
.dashboard-item4 {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 200px;
    height: 200px;
    background-color: #f5f5f5;
    border-radius: 10px;
    margin-bottom: 50px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
    transition: all 0.3s ease-in-out;
    &:hover {
        transform: scale(1.1);
        box-shadow: 0 0 20px rgba(0, 0, 0, 0.4);
    }
}
</style>
