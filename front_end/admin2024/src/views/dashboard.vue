<template>
    <div style="background: #ffffff; padding: 30px">
        <a-row :gutter="16">
            <a-col :span="12">
                <a-card>
                    <a-statistic title="用户总数" :value="useState.length" :precision="0" :value-style="{ color: 'blue' }"
                        style="margin-right: 50px">
                        <template #prefix>
                            <TeamOutlined />
                        </template>
                    </a-statistic>
                </a-card>
            </a-col>
            <a-col :span="12">
                <a-card>
                    <a-statistic title="活跃用户数" :value="isActiveds.length" :precision="0" class="demo-class"
                        :value-style="{ color: 'green' }">
                        <template #prefix>
                            <SmileOutlined />
                        </template>
                    </a-statistic>
                </a-card>
            </a-col>
        </a-row>
    </div>
    <div class="cc" style="width: 100vw; height: 400px; margin-top: 50px; margin-left: 50px; background-color: #f5f5f5; ">
        <VEchart :options="options" style="width: 100%; height: 400px" :auto-resize="true" />
    </div>
    <div class="dashboard">
        <div class="dashboard-item1">
            <a-progress type="dashboard" :percent="data.useState1" :format="percent => `${percent}%`"
                :stroke-color="{ '0%': '#108ee9', '100%': '#87d068' }" />
            用户评论总数
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
import { TeamOutlined, SmileOutlined } from '@ant-design/icons-vue';
import { reactive, onMounted } from 'vue';
import axios from 'axios'

//引入echarts
import VEchart from 'vue-echarts'

//使用echarts
import 'echarts/lib/chart/bar'
import 'echarts/lib/component/tooltip'
import 'echarts/lib/component/legend'
import 'echarts/lib/component/title'
import 'echarts/lib/component/markPoint'
import 'echarts/lib/component/markLine'
import 'echarts/lib/component/dataZoom'

//导入渲染器
import { use } from 'echarts/core'
import { CanvasRenderer } from 'echarts/renderers'
use(CanvasRenderer)


// 创建响应式数据
let data = reactive([
    {
        useState1: '',
        useState2: '',
        useState3: '',
        useState4: ''
    }
])

// 定时器刷新数据
setInterval(() => {
    data.useState2 = Math.floor(Math.random() * 100)
    data.useState3 = Math.floor(Math.random() * 100)
    data.useState4 = Math.floor(Math.random() * 100)
}, 1500)

//获取用户数组长度
let useState = reactive([])
let isActiveds = reactive([])
onMounted(() => {
    axios.get('http://localhost:63760/api/User')
        .then(data => {
            // 用户总数
            useState.push(data)
            let uselength = data.data.length;
            useState.length = uselength;
            // 用户活跃数
            data.data.forEach(item => {
                if (item.isActived == true) {
                    isActiveds.push(item.isActived)
                }
            });
        })
})

let options = {
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'shadow'
        }
    },
    legend: {
        data: ['用户评论总数', '用户操作频率', '用户反馈率', '用户活跃数']
    },
    grid: {
        left: '3%',
        right: '4%',
        bottom: '3%',
        containLabel: true
    }
}
    


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
