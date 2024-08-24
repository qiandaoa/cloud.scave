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