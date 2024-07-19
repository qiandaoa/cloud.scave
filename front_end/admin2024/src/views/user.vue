<!-- 用户管理 -->
<script setup>
import { h, ref } from 'vue';
import { SearchOutlined, UserOutlined, DownOutlined, SyncOutlined, PlusOutlined,EditOutlined,DeleteOutlined } from '@ant-design/icons-vue'

let Findkeyword = ref("");

let Find = () => {
  console.log(Findkeyword.value);
}
let Reset = () => {
  console.log("重置");
}
const handleMenuClick = e => {
  console.log('click', e);
};
let UserAdd = () => {
  console.log("添加");
};
let UserEdit = () => {
  console.log("编辑");
};
let UserDelete = () => {
  if(confirm("确定删除吗？")){
    alert("删除成功！");
  }
};

</script>

<template>
  <div class="button-wrap">
    <div class="demo-dropdown-wrap">
      <div class="input-key">
        关键词：<input type="text" placeholder="用户名/姓名/手机号码" v-model="Findkeyword">
      </div>
      <div class="input-role">
        角色：
        <a-dropdown>
          <template #overlay>
            <a-menu @click="handleMenuClick">
              <a-menu-item key="1">
                <UserOutlined />
                角色1
              </a-menu-item>
              <a-menu-item key="2">
                <UserOutlined />
                角色2
              </a-menu-item>
              <a-menu-item key="3">
                <UserOutlined />
                角色3
              </a-menu-item>
            </a-menu>
          </template>
          <a-button class="ant-dropdown-link">
            请选择角色
            <DownOutlined />
          </a-button>
        </a-dropdown>
      </div>
    </div>
    <div class="Button-wrap-Find-Reset">
      <a-button type="primary" :icon="h(SearchOutlined)" @click="Find"> 搜索</a-button>
      <a-button :icon="h(SyncOutlined)" @click="Reset" >重置</a-button>
      
    </div>
  </div>
  <div class="button-wrap-UserAdd">
    <a-button type="primary" :icon="h(PlusOutlined)" @click="UserAdd"> 添加</a-button>
  </div>
  <div class="table-wrap">
    <table class="Usertable">
      <tr>
        <th>序号</th>
        <th>用户名</th>
        <th>手机</th>
        <th>所属角色</th>
        <th>状态</th>
        <th>创建时间</th>
        <th>操作</th>
      </tr>
      <tr>
        <td>1</td>
        <td>admin</td>
        <td>13800000000</td>
        <td>管理员</td>
        <td>正常</td>
        <td>2021-01-01 00:00:00</td>
        <td >
          <a-button type="primary" :icon="h(EditOutlined)" @click="UserEdit"></a-button>
          <a-button type="primary" :icon="h(DeleteOutlined)" @click="UserDelete"></a-button>
        </td>
      </tr>
    </table>
  </div>

</template>


<style scoped>
.demo-dropdown-wrap {
  border-radius: 10px;
  background-color: #ffffff;
  display: flex;
  columns: 2;
}

.input-key {
  margin: 10px;
  text-align: center;
}

.input-key input {
  width: 160px;
  height: 30px;
  border: #c2c2c2 2px;
  border-radius: 4px;
  background-color: rgb(237, 237, 237)
}

.input-role {
  margin: 9px;
}

.input-role ant-dropdown-link {
  color: #b4aeae;
}

.button-wrap {
  padding-bottom: 10px;
  border-bottom: 1px solid #c2c2c2;
}
.button-wrap .Button-wrap-Find-Reset {
  display: flex;
  justify-content:space-between;
  width: 180px;
}
.button-wrap-UserAdd{
  display: flex;
  justify-content: flex-start;
  height: 45px;
  margin-top: 10px;
  border-top: 1px solid #c2c2c2;
  border-bottom: 1px solid #c2c2c2;
  align-items: center;
}
.Usertable{
  padding-top: 10px;
  margin-top: 10px;
  width: 100%;
  
}
.Usertable tr,th,td{
  height: 40px;
  border:1px solid #c2c2c2 ;
  border-collapse: collapse;
  text-align: center;

}
</style>