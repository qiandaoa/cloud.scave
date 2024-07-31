# 实训6组第一次项目:云朵管理系统
#### 项目架构说明
##### Api 向外提供接口服务层
#####  Application 应用层/服务层
##### Application.Contracts 定义应用接口及Dto
#####   Domain 领域层 核心层
![ 输出 aaa-2021-9-1718:04:33.png](https://gitee.com/lianzengqian/picture/raw/master/%20%E6%A0%BC%E5%BC%8F%20%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20240731150309-2024-7-3115:03:38.png%20/%20%E8%BE%93%E5%87%BA%20aaa-2021-9-1718:04:33.png)
#### 后端要点
+ 基于`Asp.Net Core 8.0`
+ 使用`EntityFrameworkCore`这个ORM工具，使用PostgreSQL数据库（由`Npgsql.EntityFrameworkCore.PostgreSQL`驱动）
+ 使用EFCore统一配置工具指定表名、字段名、字段长度等约束
+ 使用`dotnet-ef`全局工具，使用`dotnet ef migrations add XXX -p 迁移文件所有项目路径 -s 解决方案启动项目` 和`dotnet ef database update -s 解决方案启动项目` 完成迁移文件生成和同步迁移文件到数据库操作，即，先有模型，再有数据库，也就是代码优先的方式
+ 轻度使用领域驱动的层次设计（只借鉴其中的分层结构，领域事件、值对象等等概念未使用，保持相对的简单）
+ 编辑器使用VSCode
+ 后续添加全局异常过滤器、审计日志、全局认证、跨域功能等。

### 权限系统需求设计
#### 用户
``` 
注册
登录
登出
禁用
删除
修改用户基本信息
改密码（自己改）
分配用户角色
移除用户角色
```
#### 角色
```
创建角色
删除角色
修改角色基本信息（目前基本信息包含角色名称、角色描述）
禁用角色
```

#### 权限
```
创建权限
删除权限
禁用权限
修改权限基本信息（权限名称、权限描述）
```

### 前端

#### 需求设计
```
登录页面
注册页面
个人信息页面
用户管理页面
角色管理页面
权限管理页面
菜单管理页面
基本路由文件
```
#### 实现过程
```
原型设计
和后端的数据结构进行分析
提取需求
按照设计图实现页面
完成接口实现
优化设计
```





#### 贡献

1.  Fork 仓库
2.  创造你的分支
3.  提交你的代码
4.  提交pull请求


### Gitee 特性
1.你可以使用 Readme_XXX.md 来支持不同的语言，例如 Readme_en.md（英文版）、Readme_zh.md（中文版）
2.Gitee 博客 blog.gitee.com
3.探索开源项目 https://gitee.com/explore 最具价值的开源项目 GVP
4.Gitee 使用手册 https://gitee.com/help
5.最受欢迎的成员 https://gitee.com/gitee-stars/