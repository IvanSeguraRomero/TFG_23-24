<script setup lang="ts">
import { useApiStore, pinia } from '../store/api';
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

const games = ref([]);

const formatDate = (dateString : string) => {
  const date = new Date(dateString);
  const options = { month: 'short', day: 'numeric', year: 'numeric' };
  return date.toLocaleDateString('en-US', options);
};

const categories = (category: string) => {
  return category.split(','); 
}

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

const calculateDiscountedPrice = (price, discount) => {
  return (price - (price * (discount / 100))).toFixed(2);
};

const router = useRouter();

const navigateToGame = (id: any) => {
  router.push({ name: 'game', params: { id: id } });
};
</script>

<template>
  <v-container class="cards-container" fluid>
    <div class="cards">
      <div class="card" v-for="game in games" :key="game.gameID"  @click="navigateToGame(game.gameID)">
        <img src="/src/assets/ForzaHorizon5_mainImage.jpg" class="card-image">
        <div class="card-content">
          <h2 class="card-title">{{ game.name }}</h2>
          
          <div class="card-subtitle">
            <span v-for="(category) in categories(game.categories)" :key="category" class="category">{{ category }}</span>
          </div>

          <div class="releaseDate">{{ formatDate(game.releaseDate) }}</div>

          <div v-if="game.discount > 0" class="discounted-price">
            <span class="discount">-{{ game.discount }}%</span>
            <span class="original-price">{{ game.price }}€</span>
            <span class="current-price">{{ game.finalPrice }}€</span>
          </div>
          <p v-else class="card-price">{{ game.price }}€</p>
        </div>
        <button class="card-button">Add To Cart</button>
      </div>
    </div>
  </v-container>
</template>



<style scoped>
.cards-container {
  height: 900px;
  overflow-y: auto;
  scrollbar-width: none; /* Scroll invisible */
}


.cards {
  display: flex;
  flex-direction: column;
}

.card {
  margin-top: 10px;
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
  bottom: 25px;
  right: 2%;
  position: relative;
  color: var(--neutral-colors-white);
  font-family: var(--font-archivo-black);
}

.card-price {
  font-size: var(--text-smallest-regular-size);
  color: var(--neutral-colors-white);
  background-color: var(--color-dark-blue);
  font-family: var(--font-orbitron);
  box-shadow: 3px 3px 4px 0 var(--color-blue);
  padding: 10px;
  width: min-content;
  position: relative;
  top: 10px;
  right: 2%;
}

.discounted-price {
  display: flex;
  align-items: center;
  font-size: var(--text-smallest-regular-size);
  color: var(--neutral-colors-white);
  background-color: var(--color-dark-blue);
  font-family: var(--font-orbitron);
  box-shadow: 3px 3px 4px 0 var(--color-blue);
  padding: 5px;
  width: min-content;
  position: relative;
  top: 10px;
  right: 2%;
}

.discount {
  background-color: yellow;
  color: black;
  padding: 5px;
  font-size: var(--text-single-100-regular-size);
  font-weight: bold;
  margin-right: 10px;
}

.original-price {
  text-decoration: line-through;
  color: grey;
  margin-right: 10px;
}

.current-price {
  font-size: var(--text-single-100-regular-size);
  color: var(--neutral-colors-white);
}

.card-subtitle,
.releaseDate { 
  position: relative;
  bottom: 20px;
  height: 40px;
  display: flex;
  color: var(--neutral-colors-white);
  font-family: var(--font-orbitron);
  padding: 10px;
  width: min-content;
  white-space: nowrap;
}

.releaseDate {
  font-family: var(--font-orbitron) sans-serif;
  font-weight: 200;
  right: 3%;
}

.card-button {
  position: absolute;
  bottom: 10px;
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
  top: 5%;
  position: relative;
  left: -15px;
  background-color: var(--color-dark-blue);
  color: var(--neutral-colors-white);
  padding: 0px 5px;
  box-shadow: 3px 3px 4px 0 var(--color-blue);
}
</style>
