<script setup lang="ts">
import CarouselItem from '@/components/CarouselItem.vue'
import GridItem from '@/components/GridItem.vue'
import CardItem from '@/components/CardItem.vue'
</script>

<template>
    <CarouselItem />
    <div class="bodyBack">
        <GridItem />
        <CardItem />
    </div>
</template>

<style scoped>
.bodyBack{
    background-color: var(--color-dark-blue);
}
</style>