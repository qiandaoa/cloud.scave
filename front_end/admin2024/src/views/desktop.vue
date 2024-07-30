<template>
  <a-watermark content="抓住云朵">

    <a-tabs v-model:activeKey="activeKey">
      <!-- 首页 -->
      <a-tab-pane key="1" tab="首页">
        <a-card>
          <a-divider orientation="content">
            <h1>快速访问</h1>
          </a-divider>
          <a-row justify="space-evenly">
            <a-col :span="4">
              <a-button type="primary" :icon="h(UserOutlined)"
                style="width: 100px;height: 100px;background-color: #ff7ea8;border-radius: 50%;" @click="User"><span
                  style="margin-left:2px ;">用户详情</span></a-button>
            </a-col>
            <a-col :span="4">
              <a-button type="primary" :icon="h(IdcardOutlined)"
                style="width: 100px;height: 100px;background-color: #3dd0b5;border-radius: 50%;" @click="Role"><span
                  style="margin-left:2px ;">角色管理</span></a-button>
            </a-col>
            <a-col :span="4">
              <a-button type="primary" :icon="h(VerifiedOutlined)"
                style="width: 100px;height: 100px;background-color: #acd489;border-radius:  50%;" @click="Permission">
                <span style="margin-left:2px ;">权限管理</span></a-button>
            </a-col>
            <a-col :span="4">
              <a-button type="primary" :icon="h(ApartmentOutlined)"
                style="width: 100px;height: 100px;background-color: #f8e38c;border-radius:  50%;"
                @click="userRole"><span style="margin-left:2px ;">用户角色</span></a-button>
            </a-col>
            <a-col :span="4">
              <a-button type="primary" :icon="h(ProfileOutlined)"
                style="width: 100px;height: 100px;background-color: #dadaa9;border-radius:  50%;" @click="Menu"><span
                  style="margin-left:2px ;">菜单管理</span></a-button>
            </a-col>
          </a-row>
        </a-card>
        <a-card>
          <a-divider orientation="left">
            <!-- <h1>角色统计</h1> -->
          </a-divider>
          <a-row justify="content">
            <a-col :span="4">
              <div ref="echartsRef" style="width:830px; height: 300px; margin-left: 140px;"></div>
            </a-col>
            <a-col :span="4">
            </a-col>
          </a-row>
        </a-card>
      </a-tab-pane>

      <!-- 状态管理 -->
      <a-tab-pane key="2" tab="任务总览" force-render>
        <a-divider orientation="left">日历</a-divider>
        <a-row justify="space-around" style="width: 100%;">
          <div style="width: auto;height: auto;">
            <a-calendar v-model:value="value">
              <template #dateCellRender="{ current }">
                <ul class="events">
                  <li v-for="item in getListData(current)" :key="item.content">
                    <a-badge :status="item.type" :text="item.content" />
                  </li>
                </ul>
              </template>
              <template #monthCellRender="{ current }">
                <div v-if="getMonthData(current)" class="notes-month">
                  <section>{{ getMonthData(current) }}</section>
                  <span>Backlog number</span>
                </div>
              </template>
            </a-calendar>
          </div>
        </a-row>
      </a-tab-pane>

      <!-- 任务中心 -->
      <a-tab-pane key="3" tab="任务中心">
        <div style="background: #ececec; padding: 30px" justify="space-around">
          <a-row>
            <a-card title="今日任务" :bordered="false" style="width: 60%;margin: 10px;">
              <table style="width: 100%;">
                <tr v-for="item in tasks" :key="item.id" style="border-bottom: #ccc 1px solid;margin: 5px;">
                  <td>
                    {{ item.id }}、
                    <a-badge :status="item.status" :text="item.taskName" />
                  </td>
                  <td>
                    <div>
                      <a-space direction="vertical">
                        <a-switch v-model:checked="item.status" checked-children="√" un-checked-children="×">
                        </a-switch>
                      </a-space>
                    </div>
                  </td>
                </tr>
              </table>
            </a-card>
            <!-- 每日标语卡片 -->
            <a-card hoverable style="width: 30%;margin: 10px;">
              <template #cover>
                <img alt="example" src="../../public/好运莲莲.png" style="height: 400px;" />
              </template>
              <a-card-meta title="每日语录">
                <template #description>想多了都是问题，做多了都是答案</template>
              </a-card-meta>
            </a-card>
          </a-row>
        </div>
      </a-tab-pane>
    </a-tabs>
  </a-watermark>
</template>
<script setup>
import { ref, h, onMounted, onUnmounted, reactive } from 'vue';
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
let router = useRouter()



//首页
let echartsRef = ref(null)
onMounted(() => {
  // 获取echarts实例
  let myChart = echarts.init(echartsRef.value)
  // 绘制图表
  myChart.setOption({
    // 标题
    title: {
      text: '角色数量统计图',
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
    yAxis: {
      type: 'category',
    },
    // y轴
    xAxis: {
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
  axios.get('http://localhost:63760/api/UseRole').then(res => {
    console.log(res.data);
    let resdata = res.data;
    resdata.forEach(item => {
      if(!datas.value[item.roleName]){
        datas.value[item.roleName] = 1;
      }else{
        datas.value[item.roleName]++;
      }
      const roleNames = Object.keys(datas.value);
      const roleCounts = Object.values(datas.value);

      // // 获取数据
      // datas.value = item.roleName;
      // // 设置数据
      // datas.value = resdata;

      // 设置图表数据
      myChart.setOption({
        yAxis: {
          // data: datas.value.map(item => item.roleName),
          data:roleNames,
          name: '角色名称'
        },
        series: {
          // data: datas.value.map(item => item.roleName.length),
          data:roleCounts,
          name: '角色数量'
        }
      })
    });
  })
  onUnmounted(() => { })  //销毁
})

//首页快捷方式(路由跳转)
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

//状态管理页
const value = ref();

//日历
const getListData = value => {
  // 定义数据
  let listData;
  // 获取当前日期
  switch (value.date()) {
    case 8:
      listData = [
        {
          type: 'warning',
          content: 'This is warning event.',
        },
        {
          type: 'success',
          content: 'This is usual event.',
        },
      ];
      break;
    case 10:
      listData = [
        {
          type: 'warning',
          content: 'This is warning event.',
        },
        {
          type: 'success',
          content: 'This is usual event.',
        },
        {
          type: 'error',
          content: 'This is error event.',
        },
      ];
      break;
    case 15:
      listData = [
        {
          type: 'warning',
          content: 'This is warning event',
        },
        {
          type: 'success',
          content: 'This is very long usual event。。....',
        },
        {
          type: 'error',
          content: 'This is error event 1.',
        },
        {
          type: 'error',
          content: 'This is error event 2.',
        },
        {
          type: 'error',
          content: 'This is error event 3.',
        },
        {
          type: 'error',
          content: 'This is error event 4.',
        },
      ];
      break;
    default:
  }
  return listData || [];
};
//月份
const getMonthData = value => {

  if (value.month() === 8) {
    return 1394;
  }

};
/*任务中心：  */
let tasks = reactive(
  [
    {
      id: 1,
      taskName: '工作台的设计与功能实现，可视化功能的实现',
      schedule: 100,
      status: false
    },
    {
      id: 2,
      taskName: '仪表盘的完善',
      schedule: 70,
      status: true
    },
    {
      id: 3,
      taskName: '完成周报',
      schedule: 30,
      status: false
    }
  ]
)
// const state = reactive({
//   checked3: false,
// });

</script>

<style scoped>
:deep(#components-grid-demo-flex) [class~='ant-row'] {
  background: rgba(128, 128, 128, 0.08);
}

/* 日历样式 */
.events {
  list-style: none;
  margin: 0;
  padding: 0;
}

.events .ant-badge-status {
  overflow: hidden;
  white-space: nowrap;
  width: 100%;
  text-overflow: ellipsis;
  font-size: 12px;
}

.notes-month {
  text-align: center;
  font-size: 28px;
}

.notes-month section {
  font-size: 28px;
}
</style>
