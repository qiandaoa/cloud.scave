<!-- 用户管理 -->
<script setup>
import { h, ref, reactive, computed, onMounted } from 'vue';
import {
  SearchOutlined,
  SyncOutlined,
  PlusOutlined,
  EditOutlined,
  DeleteOutlined,
} from '@ant-design/icons-vue'
import { message } from 'ant-design-vue'
import axios from 'axios'
import { useUserStore } from '../store/user.js'
import AddUserModal from '../components/AddModal.vue'
import axiosInstance from '../store/axiosInstance.js';
import hasPermission from '../store/hasPermission.js';
import { useRoute } from "vue-router";
const route = useRoute();

let UserDatas = reactive([])
const useStore = useUserStore()
let Findkeyword = ref('');
let originalData = reactive([]);
const loading = ref(true);
let isDisabled = ref(true);
let noPermission = () => {
  message.error("没有权限");
};
onMounted(async () => {

  await getdata()
  render()
  //  let total=originnaTotal
  loading.value = false;

})
const handleButtonClick = () => {
    if (isDisabled.value) {
      noPermission();
    } else {
      showModals();
    }
  };
const render = async () => {
  // 权限判断
  let token = sessionStorage.getItem('token');
  hasPermission(token, route.meta.Permissions).then((x) => {
    if (x == true) {
      isDisabled.value = false;
    } else {
      isDisabled.value = true;
    }
  });}
const getdata = async () => {
  let res = await axios.get(axiosInstance.getUsers)
  console.log(res);
  const user = res.data

  originalData.push(...user);
  // 将原始数据复制到 UserDatas
  UserDatas.push(...originalData);

}

const addUserModalRef = ref(null)
const showModals = () => {
  addUserModalRef.value.show()

}
// 搜索关键词

// 搜索按钮
let Find = async () => {
  let keywords = Findkeyword.value.trim()
  try {
    if (keywords) {
      let res = await axios.get(axiosInstance.getUsersbykeyword(keywords))
      console.log(res);
      // tabArr.splice(0, tabArr.length, ...res.data); // 清空并填充新的搜索结果
      UserDatas.splice(0, UserDatas.length);
      res.data.forEach(item => {
        UserDatas.push(item)
      });

    } else {
      UserDatas.splice(0, UserDatas.length);
      UserDatas.push(...originalData);
    }

  } catch (err) {
    console.log(err);
  }
}



let ModalData = reactive({
  username: "",
  nickName: "",
  email: "",
  telephone: "",
  remark: "",
  avatar: "1"
}
)

//分页
let page = ref();
let current1 = ref(1);
let pageSize = 10;
//排列顺序按照isactived来进行排列
let filteredAndSortedData = computed(() => {
  return UserDatas.filter(item => !item.isDeleted).sort((a, b) => {
    return b.isActived - a.isActived;
  });
});
const filteredAndSortedDataLength = computed(() => filteredAndSortedData.value.length);

// 分页
let currentPageData = computed(() => {
  const start = (current1.value - 1) * pageSize;
  const end = start + pageSize;
  return filteredAndSortedData.value.slice(start, end);
});
//分页快速跳转
const onChange = () => {
  if (page.value && Number(page.value) && page.value <= Math.ceil(UserDatas.length / pageSize)) {
    current1.value = Number(page.value);
  } else {
    alert('请输入正确的页码');
  }
  page.value = '';
}
// 修改状态  给后端发送请求来更改是否启用的状态
let State = async (id) => {
  // UserDatas.IsActive = !UserDatas.IsActive;
  const index = UserDatas.findIndex(item => item.id == id);
  if (index === -1) {
    console.log('没有找到该用户');
    return
  }
  const user = UserDatas[index]
  console.log(user.isActived);
  try {
    const isActive = user.isActived;
    // console.log(isActive);
    let res = await axios.put(axiosInstance.changeActive(id, !isActive))
    if (res.status === 200) {
      console.log(res);
      UserDatas[index].isActived = isActive
    } else {
      console.log('请求失败', res.status);
    }
  } catch (err) {
    console.log(err);
  }
}

// 重置按钮
let Reset = async () => {
  Findkeyword.value = "";
  // console.log("重置");s
  try {
    const res = await getdata();
    const user = res.data
    // 清空并用原始数据重新填充
    originalData.splice(0, originalData.length);
    originalData.push(...user);
    // 使用原始数据填充 UserDatas
    UserDatas.splice(0, UserDatas.length);
    UserDatas.push(...originalData);
  } catch (err) {
    console.log(err);
  }
}

// 编辑
let UserEdit = async (id) => {
  console.log(id);
  try {
    let res = await axios.get(axiosInstance.getUserByid+id)
    console.log(res.data);
    // 不再重新定义 ModalData，而是更新现有的 ModalData
    ModalData.id = id;
    ModalData.username = res.data.username;
    ModalData.nickName = res.data.nickName;
    ModalData.email = res.data.email;
    ModalData.telephone = res.data.telephone;
    ModalData.remark = res.data.remark;

    showModal.value = true;
  } catch (err) {
    console.log(err);
  }

};
//删除并重新排序

let UserDelete = async (id) => {
  console.log(id);
  if (confirm(`确定删除该用户吗？`)) {
    try {
      let res = await axios.delete(axiosInstance.deleteUser(id))
      const index = UserDatas.findIndex(item => item.id === id);
      if (index !== -1) {
        UserDatas[index].isDeleted = true;
      }
      console.log(res);
    } catch (err) {
      console.log(err);
    }
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

// 模态框提交功能
const ButtonSubmit = async (id) => {
  try {
    if (id) {
      await axios.put(axiosInstance.updateuser(id),ModalData);
      const index = UserDatas.findIndex(item => item.id === id);
      if (index !== -1) {
        UserDatas[index] = { ...UserDatas[index], ...ModalData };
      }
      showModal.value = false;
    } else {
      // 实现添加功能
    }
  } catch (err) {
    console.error('提交错误:', err);
  }
};

let Cancel = () => {
  showModal.value = !showModal.value
}
//更改时间格式 更加直观
const formatDateTime = (isoString) => {
  const date = new Date(isoString);
  const formatter = new Intl.DateTimeFormat('zh-CN', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
    hour: '2-digit',
    minute: '2-digit',
    second: '2-digit',
    hour12: false,
  });
  return formatter.format(date);
};
const formatItemCreateAt = (item) => {
  return formatDateTime(item.createAt);
}

</script>

<template>
  <a-spin :spinning="loading" style="margin-left: 500px; width: 50px;"></a-spin>
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
    </div>
    <div class="Button-wrap-Find-Reset">
      <a-button type="primary" :icon="h(SearchOutlined)" @click="Find" id="FindButton"> 搜索</a-button>
      <a-button :icon="h(SyncOutlined)" @click="Reset" id="ResetButton">重置</a-button>
    </div>
  </div>
  <div class="button-wrap-UserAdd">
    <a-button type="primary" id="AddButton" :icon="h(PlusOutlined)" @click="handleButtonClick"> 添加</a-button>
    <AddUserModal ref="addUserModalRef" />
  </div>
  <div class="table-wrap">
    <table class="Usertable">
      <tr>
        <th>序号</th>
        <th>用户名</th>
        <th>昵称</th>
        <th>邮箱</th>
        <th>电话</th>

        <th>是否启用</th>
        <th>创建时间</th>
        <th>备注</th>
        <th>操作</th>
      </tr>
      <tr v-for="(item, index) in currentPageData" :key="item.id">
        <td>{{ index + 1 }}</td>
        <td>{{ item.username }}</td>
        <td>{{ item.nickName }}</td>
        <td>{{ item.email }}</td>
        <td>{{ item.telephone }}</td>
        <td>
          <a-space direction="vertical">
            <a-switch v-model:checked="item.isActived" size="small" @click="isDisabled ? noPermission() : State(item.id)" />
          </a-space>
        </td>
        <td>{{ formatItemCreateAt(item) }}</td>
        <td>{{ item.remark }}</td>
        <td>
          <a-button type="primary" id="EditButton" :icon="h(EditOutlined)" @click="isDisabled ? noPermission() : UserEdit(item.id)"></a-button>
          <a-button type="primary" id="DeleteButton" :icon="h(DeleteOutlined)"  @click="isDisabled ? noPermission() : UserDelete(item.id)"></a-button>
        </td>
      </tr>
    </table>
  </div>
  <div class="Page">
    <a-pagination v-model:current="current1" :total="filteredAndSortedDataLength" />
    <span>第</span><input type="text" v-model="page"><span>页</span>
    <button type="button" @click="onChange">跳转</button>
  </div>
  <!-- 编辑添加模态框 -->
  <div v-if="showModal" class="modal-backdrop" style="height: 100%;">
    <div class="modal" style="height: auto;width: 500px;">
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
              <th>昵称</th>
              <td>
                <a-space direction="vertical">
                  <a-input v-model:value="ModalData.nickName" placeholder="请输入昵称" />
                </a-space>
              </td>
            </tr>
            <tr>
              <th>邮箱</th>
              <td>
                <a-space direction="vertical">
                  <a-input v-model:value="ModalData.email" placeholder="请输入邮箱" />
                </a-space>
              </td>
            </tr>
            <tr>
              <th>手机号</th>
              <td>
                <a-space direction="vertical">
                  <a-input v-model:value="ModalData.telephone" placeholder="请输入手机号" />
                </a-space>
              </td>
            </tr>
            <tr>
              <th>备注</th>
              <td>
                <a-space direction="vertical">
                  <a-input v-model:value="ModalData.remark" placeholder="请输入备注" />
                </a-space>
              </td>
            </tr>
            <tr>
              <td>
                <a-space wrap>
                  <a-button type="primary" id="ButtonSubmit" @click="isDisabled ? noPermission() : ButtonSubmit(ModalData.id)">保存</a-button>
                </a-space>
              </td>
              <td>
                <a-space wrap>
                  <a-button type="primary" id="ButtonSave" @click="Cancel">取消</a-button>
                </a-space>
              </td>
            </tr>
          </table>
        </form>
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

#ButtonSubmit[data-v-5ccf79a5] {
  background-color: #a0cfff;
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
  display: flex;
  align-items: center;
  justify-content: center;
  margin-top: 10px;
  padding: 10px;
  border: 2px solid #fbfbfb;
  text-align: center;
  height: 60px;
}

.Page input,
.Page button {
  width: 50px;
  height: 30px;
  margin: 0 10px;
  border-radius: 3px;
  background-color: white;
  text-align: center;
  border: 2px solid rgb(240, 240, 240);
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