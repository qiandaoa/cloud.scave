<template>
  <h1 style="text-align: center; font-size: 48px; color:#66D0FF ;">云朵管理系统</h1>
  <div class="context">
    <div class="card">
      <div class="cloud">
      </div>
      <div class="shadow"></div>
    </div>
    <a-row :gutter="[16, 16]">
      <a-col :span="8" v-for="(item, index) in cards" :key="index">
        <a-card :title="item.title" :body-style="{ padding: '24px 32px' }">
          {{ item.description }}
        </a-card>
      </a-col>
    </a-row>
  </div>
  <footer class="copyright">
    <p>官网 | 社区 | Cloud</p>
    <p>Copyright © 2024 云朵 Design All Rights Reserved</p>
    <p>Design By 抓住云朵 连增钱 Charlie没有巧克力 陈培杰 养生吗喽 邱楷杭</p>
  </footer>

</template>
<script setup>
import { ref } from 'vue'
const cards = ref([
  {
    title: '增强安全性',
    description: '用户管理系统可以实施多层次的安全策略，如密码策略、双因素认证、访问控制列表（ACLs）等，有效防止未经授权的访问，保护企业数据和资源的安全。',
  },
  {
    title: '简化用户管理',
    description: '通过集中化的用户管理，企业可以轻松创建、修改和删除用户账户，分配和调整权限，这大大简化了管理员的工作，提高了效率。',
  },
  {
    title: '提升用户体验',
    description: '用户管理系统可以提供个性化的界面和功能，根据用户的角色和权限展示不同的内容，提高用户的工作效率和满意度。',
  },
  {
    title: '促进合规性',
    description: '许多行业有严格的数据保护和隐私法规,用户管理系统可以帮助企业遵守这些法规，通过数据加密等手段，确保数据处理的合规性。',
  },
  {
    title: '支持协作与共享',
    description: '通过权限管理，用户管理系统可以促进团队间的协作，允许在不同部门和团队之间安全地共享资源和信息。',
  },
  {
    title: '成本节约',
    description: '自动化用户管理流程可以减少对IT人员的需求，降低培训成本和错误率，从而节省企业成本。',
  },
])
</script>
<style scoped>
.context {
  display: flex;
}

.copyright {
  /* margin-right: 150px; */
  margin-top: 15px;
  text-align: center;
  padding: 10px 0;
  /* position: absolute; */
  bottom: 0;
  width: 100%;
  
  /* background-color: #f5f5f5; */
  /* height: 100px; */
  /* 或者选择合适的背景色 */
  color: #8d8c8c;
  /* 文字颜色 */
}

.card {
  margin-right: 15px;
  width: 190px;
  height: auto;
  background-color: #66D0FF;
  padding: 20px;
  border-radius: 8px;
  transition: all .3s;
  border: 3px solid #66D0FF;
  box-shadow: 0 0 10px white;
  /* display: flex; */
}

.cloud {
  width: 150px;
  height: 70px;
  background: #ECEFF1;
  box-shadow: 10px 10px rgba(0, 0, 0, 0.2);
  border-radius: 70px;
}

.cloud::after,
.cloud::before {
  content: "";
  position: relative;
  display: inline-block;
  background: inherit;
  border-radius: inherit;
}

.cloud::after {
  width: 50px;
  height: 50px;
  top: -30px;
  left: -55px;
}

.cloud::before {
  width: 70px;
  height: 70px;
  top: -20px;
  left: 60px;
}

.cloud {
  animation: float 1.8s infinite alternate;
}


@keyframes float {
  0% {
    transform: translateY(15px);
  }

  100% {
    transform: translateY(0);
  }
}

.shadow {
  width: 150px;
  height: 24px;
  background-color: rgba(0, 0, 0, 0.2);
  margin-top: 100px;
  border-radius: 50%;
  filter: blur(7px);
  animation: sha 1.8s infinite alternate;
}

@keyframes sha {
  0% {
    transform: scale(1, 1);
  }

  100% {
    transform: scale(.85, .85);
  }
}

/* .card:hover {
  width: 200px;
  height: 264px;
  transform: scale(0.9);
  padding: 20px;
  border: 5px solid black;
} */
</style>