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

const categories = (category: string) => {
  return category[0].categories.split(','); 
};

const categoriesSnd = (category: any) => {
  const categoriesArray = category.replace(/'/g, '').split(',');
  return categoriesArray[0];
};

const router = useRouter();

const navigateToGame = (id: any) => {
  router.push({ name: 'game', params: { id: id } });
};

const calculateDiscountedPrice = (price: number, discount: number) => {
  return (price - (price * (discount / 100))).toFixed(2);
};

onMounted(async () => {
  games.value = await useApiStore(pinia).fetchGames();
  if (games.value.length > 0) {
    games.value.forEach(game => {
      if (game.discount > 0) {
        game.finalPrice = calculateDiscountedPrice(game.price, game.discount);
      } else {
        game.finalPrice = game.price;
      }
    });
  }
});
</script>

<template>
  <div class="titleDiscountGames">Games In Offer</div>
  <div class="centerBlock" v-if="games.length > 0">
    <div class="bloque">
      <div class="principal" @click="navigateToGame(games[0].gameID)">
        <div class="image-container">
          <img src="/src/assets/ForzaHorizon5_mainImage.jpg" alt="" class="imgPrn">
        </div>
        <div class="info">
          <p class="date">Until {{ formatDate(games[0].releaseDate) }}</p>
          <h1 class="title">{{ games[0].name }}</h1>
          <div class="categories">
            <span class="category" v-for="(category) in categories(games)" :key="games[0].id">{{ category }}</span>
          </div>
          <div class="price">
            <div class="discount-container" v-if="games[0].discount > 0">
              <span class="discount">{{ games[0].discount }}% OFF</span>
              <span class="second-discount">{{ games[0].price }}€</span>
            </div>
            <div class="final-price">PRICE: {{ games[0].finalPrice }}€</div>
          </div>
        </div>
      </div>
      <div class="grid">
        <div class="grid-item" v-for="(game) in games.slice(1, 5)" :key="game.id" @click="navigateToGame(game.gameID)">
          <div class="image-container">
            <img src="/src/assets/ForzaHorizon5_mainImage.jpg" alt="" class="imgMin">
          </div>
          <div class="info-min">
            <p class="date-min">Until {{ formatDate(game.releaseDate) }}</p>
            <p class="title-min">{{ game.name }}</p>
            <span class="category-min">{{ categoriesSnd(game.categories) }}</span>
            <div class="price-min">
              <div class="discount-original-container" v-if="game.discount > 0">
                <span class="discount-min">{{ game.discount }}% OFF</span>
                <span class="price-original-min">{{ game.price }}€</span>
              </div>
              <span class="price-final-min">PRICE: {{ game.finalPrice }}€</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

  
  
  
  
  
  <style scoped>
.centerBlock {
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 150px;
}

.bloque {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: var(--gap-3xs);
  width: 1500px;
  height: 450px;
  position: relative;
  right: 8%;
}

.principal {
  display: flex;
  background-color: #00b3d8;
  width: 80%;
  margin-left: 20%;
  border-radius: 0 20px 20px 0; 
}

.image-container {
  flex: 1;
}

.imgPrn {
  width: 110%;
  height: 80%;
  object-fit: cover;
  margin-left: 10%;
  margin-top: 30%;
}

.info {
  flex: 1;
  padding: 10px;
  color: var(--color-black);
  font-family: var(--font-archivo-black);
}

.date, .date-min {
  font-size: var(--text-smallest-regular-size);
  position: relative;
  left: 30%;
  top: 2%;
  font-size: var(--text-single-100-regular-size);
  font-family: var(--font-roboto);
}

.date-min {
  bottom: 10%;
  color: var(--color-blue);
}

.title, .title-min {
  font-size: var(--font-size-9xl);
  font-family: var(--font-archivo-black);
  position: relative;
  right: 95%;
}
.title{
  bottom: 5%;
}

.title-min {
  bottom: 10%;
  right: 100%;
  color: var(--color-blue);
}

.categories {
  position: absolute;
  display: flex;
  flex-direction: column;
  gap: 5px;
  width: 15%;
  left: 34%;
  top: 30%;
}

.category {
  background-color: var(--color-black);
  color: var(--neutral-colors-white);
  padding: 5px;
  font-size: var(--text-single-200-regular-size);
  font-family: var(--font-orbitron);
  text-align: center;
}

.price {
  display: flex;
  flex-direction: column;
  margin-top: 115%;
  border: 1.5px solid black;
  position: relative;
  width: 80%;
  left: 20%;
}

.price-min {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  background-color: #00b3d8;
  padding: 2px;
  border: 1.5px solid black;
  left: 15%;
  position: relative;
}

.discount-container, .price-min {
  display: flex;
  background-color: black;
}
.discount, .discount-min{
  font-weight: bolder;
}

.discount, .discount-min {
  background-color: var(--color-yellow);
  color: black;
  font-size: var(--text-single-100-regular-size);
  font-family: var(--font-orbitron);
  padding: 5px;
  text-align: center;
  flex: 1;
}

.second-discount, .price-original-min {
  background-color: var(--color-blue);
  font-size: var(--text-single-100-regular-size);
  font-family: var(--font-orbitron);
  color: black;
  padding: 5px;
  text-align: center;
  text-decoration: line-through;
  flex: 1;
  border-left: 2px solid black;
}

.final-price {
  background-color: black;
  color: var(--color-blue);
  font-size: var(--text-smallest-regular-size);
  font-family: var(--font-orbitron);
  padding: 5px;
  text-align: center;
}

.price-final-min {
  color: var(--color-black);
  font-size: var(--text-single-200-regular-size);
  font-family: var(--font-orbitron);
  font-weight: bold;
  padding: 5px;
  text-align: center;
  width: 100%;
  margin-top: 5px;
}

.price-original {
  text-decoration: line-through;
  font-size: var(--text-smallest-regular-size);
  margin-right: 5px;
}

.grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-rows: 1fr 1fr;
  gap: 10px;
  width: 120%;
}

.grid-item {
  display: flex;
  background-color: black;
  color: white;
  padding: 10px;
  position: relative;
  border: 2px solid black;
  border-radius: 10px; 
}

.image-container {
  flex: 1;
}

.imgMin {
  width: 110%;
  height: 80%;
  object-fit: cover;
  margin-left: 5%;
  margin-top: 20%;
  border: 3px solid black;
  border-radius: 5px;
}

.info-min {
  flex: 1;
  padding: 10px;
  font-family: 'Orbitron', sans-serif;
}

.date-min, .title-min, .price-min, .discount-min, .price-original-min {
  margin: 2px 0;
}

.title-min {
  font-size: var(--text-single-100-regular-size);
}

.price-min {
  top: 27%;
  width: 90%;
  background-color: #00b3d8;
  padding: 2px;
}

.discount-min {
  background-color: var(--color-yellow);
  color: black;
  font-size: var(--text-single-200-regular-size);
  font-family: var(--font-orbitron);
  padding: 3px;
  text-align: center;
  flex: none;
  position: relative;
  left: 5px;
}

.price-original-min {
  background-color: var(--color-black);
  font-size: var(--text-smallest-regular-size);
  font-family: var(--font-orbitron);
  color: var(--color-blue);
  padding: 5px;
  position: relative;
  width: 110px;
  text-decoration: line-through;
}

.category-min {
  background-color: var(--color-blue);
  color: var(--color-black);
  padding: 10px;
  font-size: var(--text-single-200-regular-size);
  position: relative;
  top: 20px;
  margin-left: 35%;
  border-radius: 5px;
}

.titleDiscountGames {
  font-size: var(--font-size-9xl);
  color: var(--neutral-colors-white);
  font-family: var(--font-archivo-black);
  margin-left: 10%;
  position: absolute;
  margin-top: 2%;
}

.discount-original-container {
  display: flex;
  align-items: center;
}

.discount-min, .price-original-min {
  margin-right: 10px;
}
.grid-item:hover {
  transform: scale(1.1);
  cursor: pointer;
}
.principal:hover{
  cursor: pointer;
}
</style>



  
  
  
