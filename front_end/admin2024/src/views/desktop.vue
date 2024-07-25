<template>
    <a-layout class="dashboard-layout">
      <a-layout-header :style="{ position: 'sticky', zIndex: 1, top: 0, background: '#fff' }">
        <a-row type="flex" justify="space-between" align="middle">
          <a-col :span="12">
          </a-col>
          <a-col :span="12">
            <a-menu theme="light" mode="horizontal" :style="{ lineHeight: '64px' }">
              <a-menu-item key="1">首页</a-menu-item>
              <a-menu-item key="2">项目管理</a-menu-item>
              <a-menu-item key="3">报告</a-menu-item>
            </a-menu>
          </a-col>
        </a-row>
      </a-layout-header>
  
      <a-layout-content :style="{ margin: '24px 16px 0' }">
        <a-row :gutter="[16, 16]">
          <a-col :xs="24" :sm="12" :md="8">
            <a-card title="今日任务">
              <a-list>
                <a-list-item v-for="(task, index) in tasks" :key="index">
                  {{ task }}
                </a-list-item>
              </a-list>
            </a-card>
          </a-col>
          <a-col :xs="24" :sm="12" :md="8">
            <a-card title="销售趋势">
              <div id="sales-chart" style="height: 200px;">
              </div>
            </a-card>
          </a-col>
          <a-col :xs="24" :sm="12" :md="8">
            <a-card title="最新消息">
              <a-timeline>
                <a-timeline-item v-for="(activity, index) in activities" :key="index">
                  <span>{{ activity.date }}</span>
                  <p>{{ activity.content }}</p>
                </a-timeline-item>
              </a-timeline>
            </a-card>
          </a-col>
        </a-row>
        <a-row style="margin-top: 24px;">
          <a-col :xs="24" :sm="24" :md="24">
           
          </a-col>
        </a-row>
      </a-layout-content>
  
      <a-layout-footer :style="{ textAlign: 'center' }">
        ©2024 Ant Design Vue
      </a-layout-footer>
    </a-layout>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  
  const tasks = ref([
    '完成项目A的需求分析',
    '参加下午的团队会议',
    '提交周报',
  ]);
  
  const activities = ref([
    { date: '今天', content: '项目A的需求文档已提交给客户。' },
    { date: '昨天', content: '完成了项目B的初步设计。' },
  ]);
  
  const currentDate = ref(new Date());
  </script>
  
  <style scoped>
  .dashboard-layout .ant-layout-header {
    padding: 0 !important;
  }
  
  .ant-card-meta-title {
    margin: 0;
  }
  
  .ant-card-body {
    padding: 16px;
  }
  </style>