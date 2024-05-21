<template>
    <div class="page">
      <div class="container">
        <img src="/src/assets/ForzaHorizon5_mainImage.jpg" class="main-image">
        <div class="thumbnail-container">
            <img src="/src/assets/ForzaHorizon5_mainImage.jpg" class="thumbnail">
            <img src="/src/assets/ForzaHorizon5_secondImage.jpg" class="thumbnail">
            <img src="/src/assets/ForzaHorizon5_thirdImage.jpg" class="thumbnail">
            <img src="/src/assets/ForzaHorizon5_forthImage.jpg" class="thumbnail">
        </div>
      </div>
      <div class="side-container">
        <img src="/src/assets/ForzaHorizon5_gameImage.jpg" class="side-image">
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
    min-height: 100vh;
  }
  
  .container {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-right: 20px;
    margin-top: 20px;
  }
  
  .main-image {
    width: 600px;
    height: 300px;
    background-color: #cccccc;
    margin-bottom: 10px;
    border-radius: 20px;
  }
  
  .thumbnail-container {
    display: flex;
    justify-content: space-between;
    margin-top: 50px;
    width: 600px;
  }
  
  .thumbnail {
    width: 140px;
    height: 100px;
    background-color: #cccccc;
    border-radius: 8px;
  }
  
  .side-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-top: 20px;
  }
  
  .side-image {
    width: 300px;
    height: 200px;
    background-color: #cccccc;
    margin-bottom: 10px;
    border-radius: 10px;
  }
  
  .side-text {
    width: 300px;
    padding: 10px;
    color: var(--color-black);
    text-align: justify;
    max-height: 300px;
    height: 250px;
    font-family: var(--font-roboto);
  }
  </style>
  