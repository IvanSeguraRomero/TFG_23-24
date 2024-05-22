<template>
    <div class="similar-games">
      <h2>Similar Games</h2>
      <hr />
      <div class="game-container">
        <div class="game" v-for="game in 3" :key="game">
          <img src="/src/assets/cyber_site.jpg" class="image">
          <div class="title">TITLE</div>
          <div class="price">PRICE</div>
        </div>
      </div>
    </div>
  </template>
  
  <style scoped>
  .similar-games {
    margin: 20px 0;
  }
  h2{
    font-family: var(--font-archivo-black);
  }
  hr{
    width: 100%;
    border-color: #000;
    margin-top: 10px;
    margin-bottom: 10px;
  }
  
  .game-container {
    display: flex;
    justify-content: space-between;
  }
  
  .game {
    padding: 10px;
    width: 30%;
    background-color: var(--color-black);
    border-radius: 10px;
  }
  .image{
    width:90%;
    height: 130px;
    margin-left: 5%;
    margin-top: 10px;
    border-radius: 5px;
  }
  .title, .price{
    margin-left: 5%;
    padding: 10px;
    font-family: var(--font-roboto);
    color: var(--neutral-colors-white);
  }
  </style>
  