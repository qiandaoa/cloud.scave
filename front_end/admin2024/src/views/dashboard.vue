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
import axiosInstance from '../store/axiosInstance.js';
// 引入echarts
import * as echarts from 'echarts'
// 获取echarts实例
let echartsRef = ref(null)

//获取用户数组长度
let useState = reactive([])
let isActiveds = reactive([])
onMounted(() => {
    axios.get(axiosInstance.getUsers)
        .then(data => {
            // 用户总数
            useState.push(data)
            // let uselength = data.data.length;
            let filter =  data.data.filter(item => item.isDeleted == false);
            let total = data.data.filter(item => item.isDeleted == false).length;
            useState.length = total;
         
            // 用户活跃数
            filter.forEach(item => {
                if (item.isActived == true) {
                    isActiveds.push(item.isActived)
                }
            });
            console.log(total);
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
    axios.get(axiosInstance.getUsers)
        .then(data => {
            data.data.forEach(item => {
                // let uselength = data.data.length;
                let uselength = data.data.filter(item => item.isDeleted == false).length;  
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
