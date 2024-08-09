// stores/resourceStore.js
import { defineStore } from 'pinia';
import axios from 'axios';
import axiosInstance from './axiosInstance';
export const useResourceStore = defineStore('resource', {
  state: () => ({
    resources: [],
    permissions: [],
    resourceWithPermissions: []
  }),
  actions: {
    async fetchResourcesAndPermissions() {
      // 这里应该是从后端获取资源和权限数据
      let res = await axios.get(axiosInstance.resource);
      
      // 假设你已经获取到了 resource 和 permission 的数据
      const resource = res.data.data; // 从后端获取的资源数据
      let ress = await axios.get(axiosInstance.getpermission);

      const permission = ress.data.data; // 从后端获取的权限数据

      this.resources = resource;
      this.permissions = permission;

      this.updateResourceWithPermissions();
    },
    updateResourceWithPermissions() {
      if (!this.resources || this.resources.length === 0) return [];
      this.resourceWithPermissions = this.resources.filter(resourceItem => !resourceItem.isDeleted).map(resourceItem => {
        const permissions = this.permissions.filter(permissionItem => 
            permissionItem.resourceId === resourceItem.id && !permissionItem.isDeleted
        );
        return {
            
          ...resourceItem,
          permissions
        };
      });
      console.log('Processed resourceWithPermissions:', this.resourceWithPermissions);
    }

  },
  getters: {
    getResourceWithPermissions: (state) => state.resourceWithPermissions
  }
});