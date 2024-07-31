<template>
      <a-watermark content="抓住云朵">
    <!-- 统计 -->
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
    <!-- 饼图 -->
    <div ref="echartsRef" style="width: 100%; height: 400px;">
    </div>
</a-watermark>
</template>

<script setup>
import { TeamOutlined, SmileOutlined } from '@ant-design/icons-vue';
import { reactive, onMounted, onUnmounted, ref } from 'vue';
import axios from 'axios'
// 引入echarts
import * as echarts from 'echarts'
// 获取echarts实例
let echartsRef = ref(null)

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
    let myChart = echarts.init(echartsRef.value)
    // 配置echarts
    myChart.setOption({
        // 标题
        title: {
            text: '用户活跃度',
            left: 'center'
        },
        // 提示
        tooltip: {
            trigger: 'item'
        },
        // 图例
        legend: {
            orient: 'vertical',
            left: 'left'
        },
        // 数据
        series: [
            {
                name: '用户活跃度',
                type: 'pie',
                radius: '80%'
            }
        ]
    })
    // 获取数据
    axios.get('http://localhost:63760/api/User')
        .then(data => {
            data.data.forEach(item => {
                let uselength = data.data.length;
                let tureUser=isActiveds.length;
                console.log(tureUser);
                let falseUser=uselength-tureUser;
                myChart.setOption({
                    series: [{
                        data: [
                            { value:falseUser, name: '非活跃用户' },
                            { value: tureUser, name: '活跃用户' }
                        ]
                    }]
                })
            })
        })
    onUnmounted(() => { })  //销毁
})
</script>


<style scoped></style>
