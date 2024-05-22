<script setup lang="ts">
</script>
<template>
    <div class="page">
      <div class="container">
        <div class="main-image"></div>
        <div class="thumbnail-container">
          <div class="thumbnail"></div>
          <div class="thumbnail"></div>
          <div class="thumbnail"></div>
          <div class="thumbnail"></div>
        </div>
      </div>
      <div class="side-container">
        <div class="side-image"></div>
        <div class="side-text">
          <p>"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."</p>
        </div>
      </div>
    </div>
</template>
<style scoped>
  .page {
    display: flex;
    justify-content: center;
    align-items: flex-start;
    /* min-height: 100vh; */
    background-color: #f4f4f4;
  }
  
  .container {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-right: 20px;
  }
  
  .main-image {
    width: 600px;
    height: 300px;
    background-color: #cccccc;
    margin-bottom: 10px;
  }
  
  .thumbnail-container {
    display: flex;
    justify-content: space-between;
    width: 600px;
  }
  
  .thumbnail {
    width: 140px;
    height: 100px;
    background-color: #cccccc;
  }
  
  .side-container {
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  
  .side-image {
    width: 300px;
    height: 200px;
    background-color: #cccccc;
    margin-bottom: 10px;
  }
  
  .side-text {
    width: 300px;
    padding: 10px;
    background-color: #333333;
    color: white;
    text-align: justify;
  }
</style>
  