<script setup lang="ts">
import GameItem from '@/components/GameItem.vue'
import BuyItem from '@/components/BuyItem.vue'
import GameCategories from '@/components/GameCategories.vue'
import DescriptionItem from '@/components/DescriptionItem.vue'
import SimilarGames from '@/components/SimilarGames.vue'
import GameComments from '@/components/GameComments.vue'
</script>

<template>
    <GameItem />
    <hr class="line" />
    <div class="table">
        <div class="left-column">
            <BuyItem class="buy-item" />
            <DescriptionItem class="description-item" />
        </div>
        <GameCategories class="game-categories" />
    </div>
    <div class="secondary-content">
        <SimilarGames />
        <GameComments />
    </div>
</template>

<style scoped>
hr {
    width: 80%;
    border-color: #000;
    margin-left: 10%;
}

.secondary-content {
  widtH: 80%;
  flex: 1;
  padding: 20px;
  margin-left: 10%;
}

.table {
  display: grid;
  grid-template-columns: 2fr 1fr; /* Ajusta las fracciones para que Buy y Description ocupen más espacio */
  width: 80%;
  gap: 20px;
  margin-top: 20px;
  margin-left: 10%;
}

.left-column {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.buy-item, .description-item {
  padding: 20px;
  flex: 1;
  margin-bottom: 20px;
}

.buy-item{
    padding: 0px;
}

.game-categories {
  padding: 20px;
}
</style>