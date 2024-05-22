<script setup lang="ts">
import { useApiStore, pinia } from '../store/api';
import { ref, onMounted } from 'vue';

const games = ref([]);
const loading = ref(true);

onMounted(async () => {
  games.value = await useApiStore(pinia).fetchGames();
  loading.value = false;
});
</script>

<template>
  <div v-if="loading" class="d-flex justify-center align-center" style="height: 400px;">
    <v-progress-circular indeterminate color="primary"></v-progress-circular>
  </div>
  <v-carousel
    v-else
    height="400"
    show-arrows="hover"
    cycle
    hide-delimiter-background
  >
    <v-carousel-item
      v-for="(game, i) in games"
      :key="i"
    >
      <v-sheet
        height="100%"
        class="carousel-slide"
        style="backgroundImage: url(/src/assets/ForzaHorizon5_mainImage.jpg)"
      >
        <div class="carousel-content">
          <h3 class="carousel-title">{{ game.name }}</h3>
          <p class="carousel-description">{{ game.description }}</p>
          <p class="carousel-price">PRICE: {{ game.price }}€</p>
        </div>
      </v-sheet>
    </v-carousel-item>
  </v-carousel>
</template>

<style scoped>
.carousel-slide {
  position: relative;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-size: cover;
  background-position: center;
  color: white;
  text-align: left;
}

.carousel-content {
  position: absolute;
  bottom: 0px;
  left: 0px;
  background-color: rgba(0, 0, 0, 0.6);
  padding: 20px;
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
}

.carousel-title {
  font-size: var(--font-size-25xl);
  font-family: var(--font-archivo-black);
  margin-bottom: 12%;
  margin-left: 5%;
}

.carousel-description {
  font-size: var(--text-single-200-regular-size);
  font-family: var(--font-roboto);
  position: absolute; 
  top: 45%;
  margin-left: 5%;
  width: 30%; 
}

.carousel-price {
  font-size: var(--font-size-xl);
  font-family: var(--font-orbitron);
  font-weight: bold;
  margin-bottom: 10px;
  margin-left: 80%;
}
</style>
