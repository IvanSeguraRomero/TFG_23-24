<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HeaderItem from './components/HeaderItem.vue';
import FooterItem from './components/FooterItem.vue';
//import css
// import './assets/main.css'
</script>

<template>
  <!-- <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Playfair+Display:wght@400;600;700&display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Lobster:wght@400&display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Gentium+Basic:wght@400;700&display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=DM+Sans:wght@400;700&display=swap">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Onest:wght@700&display=swap"> -->
  <header>
    <HeaderItem>
      <template #admin><RouterLink to="/admin" style="text-decoration: none; color: var(--neutral-colors-headings-black)">Admin</RouterLink></template>
      <template #home><RouterLink to="/" style="text-decoration: none; color: var(--neutral-colors-headings-black)">Store</RouterLink></template>
      <template #about><RouterLink to="/library" style="text-decoration: none; color: var(--neutral-colors-headings-black)" >Library</RouterLink></template>
      <template #contact><RouterLink to="/aboutUs" style="text-decoration: none; color: var(--neutral-colors-headings-black)" >About us</RouterLink></template>
      <template #profile><RouterLink to="/login" style="text-decoration: none; color: var(--neutral-colors-headings-black)" >Login</RouterLink></template>
    </HeaderItem>
  </header>

  <main>
    <div class="desktop-home">
      <RouterView />
    </div>
  </main>
  
  <footer>
    <FooterItem>
      <template #hrindex></template>
      <!--Redes Sociales-->
      <template #facebook><img alt="" src="./assets/facebook.svg" ></template>
      <template #instagram><img alt="" src="./assets/instagram.svg"></template>
      <template #twitter><img alt="" src="./assets/twitter.svg"></template>
    </FooterItem>
  </footer>
</template>

<style scoped>
body {
  margin: 0;
  line-height: normal;
}
header {
  background-color: --neutral-colors-white;
  width: 100%;
  height: 110px;
  background-color: #D8DC06;
}
footer {
  background-color: --neutral-colors-white;
  width: 100%;
  height: 110px;
  background-color: #D8DC06;
}
.logosolo-texto-1 {
  position: absolute;
  top: 0;
  left: 0;
  width: 143px;
  height: 110px;
  object-fit: cover;
  left: 143px;
  width: 315px;
  height: 109px;
}
.register-icon {
  position: absolute;
  top: 39px;
  width: 30px;
  height: 30px;
  object-fit: cover;
  left: 87%;
}
.icon {
  width: 40px;
  height: 39px;
}
</style>
