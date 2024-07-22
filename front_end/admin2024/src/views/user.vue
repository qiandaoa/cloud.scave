<!-- 用户管理 -->
<script setup>
import { h, ref, reactive, computed, onMounted } from 'vue';
import {
  SearchOutlined,
  UserOutlined,
  DownOutlined,
  SyncOutlined,
  PlusOutlined,
  EditOutlined,
  DeleteOutlined,
  CloseOutlined
} from '@ant-design/icons-vue'
import axios from 'axios'
import {useUserStore} from '../store/user.js'

let UserDatas = reactive([])
const useStore = useUserStore()

onMounted(async () => {
  // await axios.get('https://localhost:63759/api/user')
  //   .then(res => {
  //     console.log(res.data);
  //     res.data.forEach(item => {
  //       UserDatas.push(item)
  //     });
  //     var a = res.data;
  //     console.log(a[0].id);
  //   })
 const res =  await useStore.fetchUserDate()
 const user=res.data
//  console.log(user);
 user.forEach(item => {
   UserDatas.push(item)
 });

})

// 搜索关键词
let Findkeyword = ref('');

// 搜索按钮
let Find = () => {
  console.log(Findkeyword.value);
}


//模态框角色数据库
let ModalRoleData = ref([
  {
    value: '云朵',
    label: '云朵',
  },
  {
    value: '蓝天',
    label: '蓝天',
  },
  {
    value: '朝霞',
    label: '朝霞',
  },
]);


//分页
let current1 = ref(1);
let pageSize = 5;
let currentPageData = computed(() => {
  const start = (current1.value - 1) * pageSize;
  const end = start + pageSize;
  return UserDatas.slice(start, end);
});
let onChange = () => {
  console.log(current1.value);
}
// 修改状态
let State = () => {
  user.IsActive = !user.IsActive;
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
  ModalData.value = UserData.find(item => item.id === id)// 获取当前行的数据
  console.log("编辑" + id);
};
//删除并重新排序
let UserDelete = (index, id) => {
  if (confirm(`确定删除id为${id}的数据吗？`)) {
    console.log(`删除id为${id}的数据`);
    UserData.splice(index, 1);
  }
};
// 定义一个响应式数据用于控制模态框的显示状态
const showModal = ref(false);
if (showModal.value) {
  document.body.style.overflow = 'hidden';
}
// 关闭模态框时恢复滚动
else {
  document.body.style.overflow = '';
}

// 模态框表单中角色选择的提交功能
const handleBlur = () => {
  console.log('blur');
};
// 模态框表单中角色选择的搜索功能
const handleFocus = () => {
  console.log('focus');
};
// 模态框表单的过滤功能，
const filterOption = (input, option) => {
  return option.value.toLowerCase().indexOf(input.toLowerCase()) >= 0;
};
// 模态框表单的选中功能
const handleChange = value => {
  console.log(`selected ${value}`);
};
// 模态框表单的提交功能
let ButtonSubmit = () => {
  if (ModalData.id == null) {
    ModalData.value.id = UserData.length + 1;// 添加id
    UserData.push(ModalData.value);// 添加数据
    console.log(ModalData.value);
  } else {
    console.log(ModalData.value);
  }
  showModal.value = false;
}

let ButtonSave = () => {
  console.log(`保存`);
}
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
    <a-button type="primary" id="AddButton" :icon="h(PlusOutlined)" @click="AddButton, showModal = true"> 添加</a-button>
  </div>
  <div class="table-wrap">
    <!-- public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? NickName { get; set; }
    public string? Avatar { get; set; }
    public string? Salt { get; set; }
    public string? Email { get; set; }
    public string? Telephone { get; set; } -->

   
    <table class="Usertable">
      <tr>
        <th>序号</th>
        <th>用户Id</th>
        <th>用户名</th>
        <th>昵称</th>
        <th>邮箱</th>
        <th>电话</th>
        <th>所属角色</th>
        <th>状态</th>
        <th>创建时间</th>
        <th>操作</th>
      </tr>
      <tr v-for="(item, index) in currentPageData" :key="item.id">
        <td>{{ index + 1 }}</td>
        <td>{{ item.id }}</td>
        <td>{{ item.username }}</td>
        <td>{{ item.nickName }}</td>
        <td>{{ item.email }}</td>
        <td>{{ item.telephone }}</td>
        <td>{{ item.role }}</td>
        <td>
          <a-space direction="vertical">
            <a-switch v-model:checked="item.IsActive" size="small" @click="State" />
          </a-space>
        </td>
        <td>{{ item.createcime }}</td>
        <td>
          <a-button type="primary" id="EditButton" :icon="h(EditOutlined)"
            @click="UserEdit(item.id), showModal = true"></a-button>
          <a-button type="primary" id="DeleteButton" :icon="h(DeleteOutlined)"
            @click="UserDelete(index, item.id)"></a-button>
        </td>
      </tr>
    </table>
  </div>
  <div class="Page">
    <a-pagination v-model:current="current1" show-quick-jumper :total="UserDatas.length" @change="onChange" />
  </div>
  <!-- 编辑添加模态框 -->
  <div v-if="showModal" class="modal-wrap">
    <div>
      <div v-if="showModal" class="modal-backdrop">
        <div class="modal">
          <div class="modal-content">
            <h1>云朵编辑</h1>
            <a-button type="primary" id="modalClose" :icon="h(CloseOutlined)" @click="showModal = false"></a-button>
          </div>
          <div class="modal-table-from">
            <form action="" method="post">
              <table class="modal-table">
                <tr>
                  <th>用户名</th>
                  <td>
                    <a-space direction="vertical">
                      <a-input v-model:value="ModalData.username" placeholder="请输入用户名" />
                    </a-space>
                  </td>
                </tr>
                <tr>
                  <th>姓名</th>
                  <td>
                    <a-space direction="vertical">
                      <a-input v-model:value="ModalData.nickName" placeholder="请输入昵称" />
                    </a-space>
                  </td>
                </tr>
                <tr>
                  <th>手机</th>
                  <td>
                    <a-space direction="vertical">
                      <a-input v-model:value="ModalData.email" placeholder="请输入邮箱" />
                    </a-space>
                  </td>
                </tr>
                <tr>
                  <th>手机</th>
                  <td>
                    <a-space direction="vertical">
                      <a-input v-model:value="ModalData.telephone" placeholder="请输入手机" />
                    </a-space>
                  </td>
                </tr>
                <tr>
                  <th>所属角色</th>
                  <td>
                    <!-- // 绑定 v-model:value 指令到 UserData.Role，实现双向数据绑定，用于显示和更新用户的角色选择
                        // 启用搜索功能，方便在选项较多时进行快速查找
                        show-search 
                        // 设置占位符文本，当没有选择任何选项时显示
                        placeholder="请选择角色" 
                        // 设置样式宽度为180px，以适应布局需求
                        style="width: 180px"
                        // 动态绑定 options 属性，将 ModalRoleData 数组作为下拉选项的数据源
                        :options="ModalRoleData" 
                        // 动态绑定 filter-option 属性，使用自定义的过滤函数来筛选下拉列表中的选项
                        :filter-option="filterOption" 
                        // 监听 focus 事件，当元素获得焦点时触发 handleFocus 方法
                        @focus="handleFocus" 
                        // 监听 blur 事件，当元素失去焦点时触发 handleBlur 方法
                        @blur="handleBlur"
                        // 监听 change 事件，当下拉选项发生改变时触发 handleChange 方法
                        @change="handleChange"> -->
                    <a-select v-model:value="ModalData.Role" show-search placeholder="请选择角色" style="width: 180px"
                      :options="ModalRoleData" :filter-option="filterOption" @focus="handleFocus" @blur="handleBlur"
                      @change="handleChange"></a-select>
                  </td>
                </tr>
                <tr>
                  <td>
                    <a-space wrap>
                      <a-button type="primary" id="ButtonSubmit" @click="ButtonSubmit">提交</a-button>
                    </a-space>
                  </td>
                  <td>
                    <a-space wrap>
                      <a-button type="primary" id="ButtonSave" @click="ButtonSave">保存</a-button>
                    </a-space>
                  </td>
                </tr>
              </table>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* 模态框 */
.modal-backdrop {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
  /* 确保模态框在所有元素之上 */
}

.modal-table tr,
.modal-table td,
.modal-table th {
  border: 0px;
  margin: 200px;
  height: 70px;
}

h1 {
  font-size: 40px;
  /* 设置较大的字体大小 */
  color: #ffc0ce;
  /* 设置橙色字体 */
  font-family: 'Artistic Impression', cursive;
  /* 使用艺术字风格的字体 */
  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);
  /* 添加阴影效果 */
  text-align: center;
  /* 文本居中 */
}

.modal {
  background-color: #ffffff;
  padding: 20px;
  border-radius: 5px;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
  width: 800px;
  height: 600px;
  display: flex;
  align-items: center;
  flex-direction: column;
}

.close {
  cursor: pointer;
  position: absolute;
  top: 10px;
  right: 10px;
  /* font-size: 20px; */
}

.modal-content {
  width: 100%;
  height: 100px;
  display: flex;
  justify-content: space-between;
}

/* 模态框里的控件样式 */
#modalClose {
  margin-top: -10px;
  margin-right: -10px;
  border-radius: 50%;
  background-color: #a0cfff;
}

#ButtonSave {
  background-color: #fab6b6;
  width: 100px;
}

#ButtonSubmit {
  background-color: #a0cfff;
  width: 100px;
}

/* 用户列表 */
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
  color: #bfbfc9;
}

.button-wrap {
  padding: 10px;
  border: 2px solid #f1f3f8;
}

.Page {
  margin-top: 10px;
  padding: 10px;
  border: 2px solid #fbfbfb;
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