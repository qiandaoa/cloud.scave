<!-- 用户管理 -->
<script setup>
import { h, ref, reactive, computed } from 'vue';
import {
  SearchOutlined,
  UserOutlined,
  DownOutlined,
  SyncOutlined,
  PlusOutlined,
  EditOutlined,
  DeleteOutlined
} from '@ant-design/icons-vue'

// 搜索关键词
let Findkeyword = ref('123');
// 搜索按钮
let Find = () => {
  console.log(Findkeyword.value);
}
//数据库
let UserData = reactive([
  {
    id: 1,
    UserName: '用户',
    Compellation: '张三',
    PhoneNumberer: 122222222222,
    Role: '蓝天',
    IsActive: false,
    State: '离线',
    CreateTime: '2022-01-01'
  },
  {
    id: 2,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 3,
    UserName: '用户',
    Compellation: '李四',
    PhoneNumberer: 122222222222,
    Role: '乌云',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 4,
    UserName: '用户',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '朝霞',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 5,
    UserName: '管理员',
    Compellation: '李白',
    PhoneNumberer: 122222222222,
    Role: '日出',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 6,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 7,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 8,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 9,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 10,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 11,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 12,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 13,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 14,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 15,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 16,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 17,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 18,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 19,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 20,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 21,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 22,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 23,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 24,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
  {
    id: 25,
    UserName: '管理员',
    Compellation: '王五',
    PhoneNumberer: 122222222222,
    Role: '云朵',
    IsActive: false,
    State: '在线',
    CreateTime: '2022-01-01'
  },
]);
//分页
let current1 = ref(1);
let pageSize = 6;
let currentPageData = computed(() => {
  const start = (current1.value - 1) * pageSize;
  const end = start + pageSize;
  return UserData.slice(start, end);
});
let onChange = () => {
  console.log(current1.value);
}

// 修改状态
let State = () => {
  UserData.IsActive = !UserData.IsActive;
}


// 重置按钮
let Reset = () => {
  console.log("重置");
}
// 用户选择角色的下拉菜单
let handleMenuClick = e => {
  console.log('click', e);
};
// 添加按钮
let AddButton = () => {
  console.log("添加");
};
// 编辑
let UserEdit = (id) => {
  console.log("编辑" + id);
};
//删除
let UserDelete = (id) => {
  if (confirm(`确定删除${id}吗？`)) {
    UserData.splice(id - 1, 1);
  }
};

</script>

<template>
  <div class="button-wrap">
    <div class="demo-dropdown-wrap">
      <div class="input-key">
        <div class="input-key-text">
          关键词：
        </div>
        <div class="input-key-input">
          <a-space direction="vertical">
            <a-input v-model:value="Findkeyword" placeholder="用户名/姓名/手机号码" />
          </a-space>
        </div>
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
      <a-button type="primary" :icon="h(SearchOutlined)" @click="Find" id="FindButton"> 搜索</a-button>
      <a-button :icon="h(SyncOutlined)" @click="Reset" id="ResetButton">重置</a-button>
    </div>
  </div>
  <div class="button-wrap-UserAdd">
    <a-button type="primary" id="AddButton" :icon="h(PlusOutlined)" @click="AddButton"> 添加</a-button>
  </div>
  <div class="table-wrap">
    <table class="Usertable">
      <tr>
        <th>序号</th>
        <th>用户名</th>
        <th>姓名</th>
        <th>手机</th>
        <th>所属角色</th>
        <th>状态</th>
        <th>创建时间</th>
        <th>操作</th>
      </tr>
      <tr v-for="item in currentPageData" :key="item.id">
        <td>{{ item.id }}</td>
        <td>{{ item.UserName }}</td>
        <td>{{ item.Compellation }}</td>
        <td>{{ item.PhoneNumberer }}</td>
        <td>{{ item.Role }}</td>
        <td>
          <a-space direction="vertical">
            <a-switch v-model:checked="item.IsActive" size="small" @click="State" />
          </a-space>
        </td>
        <td>{{ item.CreateTime }}</td>
        <td>
          <a-button type="primary" id="EditButton" :icon="h(EditOutlined)" @click="UserEdit(item.id)"></a-button>
          <a-button type="primary" id="DeleteButton" :icon="h(DeleteOutlined)" @click="UserDelete(item.id)"></a-button>
        </td>
      </tr>
    </table>
  </div>
  <div class="Page">
    <a-pagination v-model:current="current1" show-quick-jumper :total="500" @change="onChange" />
  </div>

</template>


<style scoped>
<style scoped>
.demo-dropdown-wrap {
  border-radius: 10px;
  background-color: #ffffff;
  display: flex;
  columns: 3;
}

.input-key {
  margin: 10px;
  text-align: center;
  width: 300px;
  ;
  display: flex;
}

.input-key-text {
  margin: 9px;
}


.input-role {
  margin: 9px;
}

#DeleteButton {
  margin: 10px;
  background-color: #fab6b6;
  height: 20px;
  width: 30px;
  line-height: 0px;
  padding: 0px;
  border-radius: 5px;

}

#ResetButton {
  margin-left: 10px;
  width: 100px;
  height: 28px;
  line-height: 0px;
  border-radius: 5px;
}

#FindButton {

  width: 100px;
  height: 28px;
  line-height: 0px;
  border-radius: 5px;
  margin-top: 0px;
}

#EditButton {
  margin: 10px;
  background-color: #a0cfff;
  height: 20px;
  width: 30px;
  line-height: 0px;
  padding: 0px;
  border-radius: 5px;
}

#AddButton {
  margin: 10px;
  margin-left: 0px;
  background-color: rgb(179, 225, 157);
  width: 100px;
  height: 28px;
  line-height: 0px;
  padding: 5px;
  border-radius: 5px;
}

.input-role ant-dropdown-link {
  color: #b4aeae;
}

.button-wrap {
  padding: 10px;
  border: 2px solid #f1f3f8;
}

.Page {
  margin-top: 10px;
  padding: 10px;
  border: 2px solid #f1f3f8;
  text-align: center;
  height: 60px;
}

.button-wrap .Button-wrap-Find-Reset {
  display: flex;
  justify-content: space-between;
  width: 180px;
}

.button-wrap-UserAdd {
  display: flex;
  justify-content: flex-start;
  height: 45px;
  margin-top: 10px;
  border: 2px solid #f1f3f8;
  align-items: center;
  padding-left: 10px;
}

.Usertable {
  padding-top: 10px;
  margin-top: 10px;
  width: 100%;
}

.Usertable tr,
th,
td {
  height: 40px;
  border: 1px solid #f1f3f8;
  border-collapse: collapse;
  text-align: center;
}

.Usertable tr:hover {
  background-color: #f1f3f8;
}

.ant-dropdown-link {
  color: #8b8989;

  &:hover {
    color: #8b8989;
  }
}
</style>