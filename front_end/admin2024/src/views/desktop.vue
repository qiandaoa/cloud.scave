<template>
  <!-- 工作台
   用户统计
   项目管理
   角色管理
   权限管理
   菜单管理
   账号管理
   任务栏
   通知
 -->
  <a-tabs v-model:activeKey="activeKey">
    <!-- 首页 -->
    <a-tab-pane key="1" tab="首页">
      <a-card>
        <a-divider orientation="left">
          <h1>快捷方式</h1>
        </a-divider>
        <a-row justify="space-evenly">
          <a-col :span="4">
            <a-button type="primary" :icon="h(UserOutlined)"
              style="width: 100px;height: 70px;background-color: #ff7ea8;border-radius: 55px;"
              @click="User">用户详情</a-button>
          </a-col>
          <a-col :span="4">
            <a-button type="primary" :icon="h(IdcardOutlined)"
              style="width: 100px;height: 70px;background-color: #3dd0b5;border-radius: 55px;"
              @click="Role">角色管理</a-button>
          </a-col>
          <a-col :span="4">
            <a-button type="primary" :icon="h(VerifiedOutlined)"
              style="width: 100px;height: 70px;background-color: #acd489;border-radius: 55px;"
              @click="Permission">权限管理</a-button>
          </a-col>
          <a-col :span="4">
            <a-button type="primary" :icon="h(ApartmentOutlined)"
              style="width: 100px;height: 70px;background-color: #f8e38c;border-radius: 55px;"
              @click="userRole">用户角色</a-button>
          </a-col>
          <a-col :span="4">
            <a-button type="primary" :icon="h(ProfileOutlined)"
              style="width: 100px;height: 70px;background-color: #dadaa9;border-radius: 55px;"
              @click="Menu">菜单管理</a-button>
          </a-col>
        </a-row>
      </a-card>
      <a-card>
        <a-divider orientation="left">
          <h1>操作记录</h1>
        </a-divider>
        <a-row justify="left">
          <a-col :span="4">
            <div ref="echartsRef" style="width: 300px; height: 200px;"></div>
          </a-col>
          <a-col :span="4">
            <!-- <a-button type="primary" :icon="h(IdcardOutlined)"
              style="width: 100px;height: 70px;background-color: #3dd0b5;border-radius: 55px;"
              @click="Role">角色管理</a-button> -->
          </a-col>
        </a-row>
      </a-card>


    </a-tab-pane>

    <!-- 状态管理 -->
    <a-tab-pane key="2" tab="状态管理" force-render>状态管理</a-tab-pane>
    <!-- 任务中心 -->
    <a-tab-pane key="3" tab="任务中心">任务中心</a-tab-pane>
  </a-tabs>

</template>
<script setup>
import { ref, h, onMounted, onUnmounted } from 'vue';
import {
  UserOutlined,
  ProfileOutlined,
  VerifiedOutlined,
  IdcardOutlined,
  ApartmentOutlined
} from '@ant-design/icons-vue';
import { useRouter } from 'vue-router';
import * as echarts from 'echarts'
import axios from 'axios'


let echartsRef = ref(null)
onMounted(() => {
  // 获取echarts实例
  let myChart = echarts.init(echartsRef.value)
  // 绘制图表
  myChart.setOption({
    // 标题
    title: {
      text: '数据统计',
      left: 'center'
    },
    // 提示
    tooltip: {
      // 触发方式
      trigger: 'axis',
      axisPointer: {
        type: 'shadow'
      }
    },
    // x轴
    xAxis: {
      type: 'category',
    },
    // y轴
    yAxis: {
      type: 'value'
    },
    // 数据
    series: [{
      // 柱状图
      type: 'bar',
      smooth: true
    }]
  })
  //获取数据
  let datas = ref([]);
  axios.get('http://localhost:63760/api/role').then(res => {
    console.log(res.data.data);
    let resdata = res.data.data;
    resdata.forEach(item => {
      datas.value = item.roleName;
      console.log(datas.value);
      let length = datas.value.length;
      console.log(length);
      myChart.setOption({
        xAxis: {
          data: [
            { value: datas.value, name: '角色名称' },
            { value: datas.value, name: '角色名称' }

          ]
        },
        series: [{
          data: [
            { value: datas.value.length, name: "roleName" },
            { value: datas.value.length, name: "roleName" }

          ]
        }]
      })

    });

  })
  onUnmounted(() => { })  //销毁
})

let router = useRouter()

const activeKey = ref('1');

let User = () => {
  router.push('/user')
}
let Permission = () => {
  router.push('/permission')
}
let Role = () => {
  router.push('/role')
}
let userRole = () => {
  router.push('/userrole')
}
let Menu = () => {
  router.push('/menu')
}


</script>

<style scoped>
:deep(#components-grid-demo-flex) [class~='ant-row'] {
  background: rgba(128, 128, 128, 0.08);
}

a-col {
  background-color: aqua;
}
</style>
