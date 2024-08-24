那么在 Vite 项目中的 `vite.config.js` 文件中，代理配置应该如下：
```javascript
import { defineConfig } from 'vite';

export default defineConfig({
  // ...其他配置...
  server: {
    proxy: {
      '/api': {
        target: 'http://101.133.150.189:24731',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, '/api'),
      },
    },
  },
});
```
在上面的配置中，`target` 是后端服务的地址，`changeOrigin` 设置为 `true` 可以让代理服务器的来源（origin）与客户端保持一致。`rewrite` 函数保持 `/api` 前缀不变。

但是，由于 Vercel 的代理配置不支持直接指定 `http` 协议的目标地址，所以你可能需要使用 Vercel 的环境变量来配置代理目标地址。

在 Vercel 的项目设置页面中，找到 "环境变量"，然后添加以下变量：
```
名称：PROXY_TARGET
值：http://101.133.150.189:24731
```
然后，在 `vite.config.js` 文件中，使用环境变量来配置代理目标地址：
```javascript
import { defineConfig } from 'vite';
import { env } from 'process';

export default defineConfig({
  // ...其他配置...
  server: {
    proxy: {
      '/api': {
        target: env.PROXY_TARGET,
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, '/api'),
      },
    },
  },
});
```
这样，你就可以在 Vercel 中使用环境变量来配置代理目标地址。
