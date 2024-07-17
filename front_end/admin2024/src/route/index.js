import { createRouter, createWebHistory } from 'vue-router'
import { routes } from './staticRoutes'

export const router = createRouter({
    history: createWebHistory(),
    routes
})