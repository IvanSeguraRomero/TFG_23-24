<script setup lang="ts">
import { useApiStore, pinia } from '../store/api';
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const games = ref([]);

const formatDate = (dateString: string) => {
  const date = new Date(dateString);
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, '0');
  const day = String(date.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
};

const categories=(category: string)=>{
    return category.split(','); 
}

onMounted(async () => {
  games.value = await useApiStore(pinia).fetchGames();
//   console.log(games.value);
});
</script>

<template>
    <div class="cards">
      <div class="card" v-for="game in games" :key="game.gameID">
        <img src="/src/assets/ForzaHorizon5_mainImage.jpg" class="card-image">
        <div class="card-content">
          <h2 class="card-title">{{ game.name }}</h2>
          
          <div class="card-subtitle">
    <span v-for="(category) in categories(game.categories)" :key="category" class="category">{{ category }}</span>
            </div>

            <p class="card-price">{{ game.price }}</p>
        </div>
        <button class="card-button">Add To Cart</button>
      </div>
    </div>
  </template>
  
  
 
  
  <style scoped>
  .cards {
    margin-bottom: 10%;
  }
  .card {
    margin-bottom: 10px;
    display: flex;
    justify-content: center;
    align-items: center;
    width: 900px;
    height: 200px;
    position: relative;
    left: 25%;
    background-color: var(--color-black);
    border-radius: 20px;
    overflow: hidden;
  }
  .card:hover {
    transform: scale(1.1);
    cursor: pointer;
  }
  .card-image {
    width: 40%;
    height: 90%;
    border-radius: 20px;
    margin-left: 2%;
  }
  .card-content {
    flex-grow: 1;
    padding: 20px;
    
  }
  .card-title {
    bottom: 15px;
    position: relative;
    color: var(--neutral-colors-white);
    font-family: var(--font-archivo-black);
  }
  .card-subtitle, .card-price {
    display: flex;
    margin-bottom: 10px;
    font-size: 14px;
    color: var(--neutral-colors-white);
    font-family: var(--font-orbitron);
    padding: 10px;
    width: min-content;
    background-color: var(--color-dark-blue);
    box-shadow: 3px 3px 4px 0 var(--color-blue);
    
  }
  .card-subtitle { 
    position: relative;
    height: 40px;
    width: 70%;
  }
  .card-price {
    position: relative;
    top: 18px;
    left: 55%;
  }

  .card-button {
    position: absolute;
    bottom: 20px;
    right: 20px;
    margin-bottom: 5px;
    background-color: var(--color-yellow);
    color: var(--color-black);
    border: none;
    padding: 10px 20px;
    border-radius: 5px;
    cursor: pointer;
    outline: none;
    font-family: var(--font-roboto);
  }
  .category {
    margin-right: 10px;
    margin-bottom: 10px;
    background-color: var(--color-light-blue);
    color: var(--color-black);
    padding: 5px 10px;
    border-radius: 5px;
  }
  </style>
  