<template>
    <div class="modal" v-if="visible">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">{{ title }}</h5>
            <button type="button" class="close" @click="close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <p>{{ message }}</p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-primary" @click="close">确认</button>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'Modal',
    props: ['title', 'message'],
    data() {
      return {
        visible: false,
      };
    },
    methods: {
      show() {
        this.visible = true;
      },
      close() {
        this.visible = false;
        this.$emit('modal-closed');
      },
    },
  };
  </script>
  
  <style scoped>
  .modal {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    display: flex;
    justify-content: center;
    align-items: center;
  }
  
  .modal-dialog {
    background-color: white;
    border-radius: 5px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    padding: 1rem;
  }
  
  .modal-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    border-bottom: 1px solid #ddd;
    padding-bottom: 1rem;
  }
  
  .modal-title {
    font-size: 1.5rem;
  }
  
  .close {
    background-color: transparent;
    border: none;
    cursor: pointer;
  }
  
  .modal-body {
    padding: 1rem 0;
  }
  
  .modal-footer {
    display: flex;
    justify-content: flex-end;
  }
  </style>