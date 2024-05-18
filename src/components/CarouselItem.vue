<script setup lang="ts">

</script>
<template>
    <v-carousel
    height="400"
    show-arrows="hover"
    cycle
    hide-delimiter-background
  >
    <v-carousel-item
      v-for="(slide, i) in slides"
      :key="i"
    >
      <v-sheet
        :color="colors[i]"
        height="100%"
      >
        <div class="d-flex fill-height justify-center align-center">
          <div class="text-h2">
            {{ slide }} Slide
          </div>
        </div>
      </v-sheet>
    </v-carousel-item>
  </v-carousel>

</template>

<style scoped>
.carousel-container {
  width: 100%;
  overflow: hidden;
}

.carousel-slide {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.carousel-slide img {
  width: 100%;
  height: auto;
}

.carousel-text {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: rgba(255, 255, 255, 0.7);
  padding: 10px;
  border-radius: 5px;
}
</style>