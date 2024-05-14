<script setup lang="ts"></script>
<template>
  <link
    rel="stylesheet"
    href="https://fonts.googleapis.com/css2?family=Playfair Display:wght@400;600;700&display=swap"
  />
  <!-- <div class="logo">
    <canvas id="myCanvasH" width="286px" height="220px" class="logo-1-icon"> </canvas>
    <slot name="logosearchtexto"></slot>
  </div> -->

  <nav class="sections">
    <h3 class="admin">
      <slot name="admin"></slot>
    </h3>
    <h3 class="home">
      <slot name="home"></slot>
    </h3>

    <h3 class="about">
      <slot name="about"></slot>
    </h3>
    <h3 class="about">
      <slot name="contact"></slot>
    </h3>
    <h3 class="profile">
      <slot name="profile"></slot>
    </h3>
  </nav>
  <slot name="hrindex">
    <hr class="header-line-hr" />
  </slot>
  <slot name="iconregister"></slot>
</template>

<style scoped>
.logo {
  position: absolute;
  top: 0;
  left: 0;
  width: 458px;
  height: 80px;
}
.logo-1-icon {
  position: absolute;
  top: 0;
  left: 0;
  width: 143px;
  height: 110px;
  object-fit: cover;
}
.sections {
  transform: scale(0.7);
  right: 10px;
  position: absolute;
  top: 46px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: flex-end;
  gap: 38px;
  text-align: center;
  font-size: 28px;
  color: #000000;
  font-family: var(--font-roboto);
}

.header-line-hr {
  position: absolute;
  top: 109px;
  width: 100%;
  border-color: #000;
}
.home {
  margin: 0;
  position: relative;
  line-height: 18px;
  font-weight: 400;
  font-family: inherit;
}
.about {
  margin: 0;
  position: relative;
  line-height: 18px;
  font-weight: 400;
  font-family: inherit;
  cursor: pointer;
}
.admin {
  margin: 0;
  position: relative;
  line-height: 18px;
  font-weight: 400;
  font-family: inherit;
  display: none;
}
.profile {
  margin: 0;
  position: relative;
  line-height: 18px;
  font-weight: 400;
  font-family: inherit;
}
/*Search*/
.container {
  position: absolute;
  display: flex;
  justify-content: center;
  align-items: center;
  top: 13px;
  border-radius: 100%;
  width: 80px;
  height: 80px;
  left: 90%;
  box-shadow: 0 0 25px 2px rgba(0, 0, 0, 0.2);
  transform: scale(0.7);
  background-color: white;
  z-index: 10;
  cursor: pointer;
}

.search {
  position: absolute;
  width: 40px;
  height: 40px;
  transition: all 1s;
  z-index: 4;
}

input {
  position: absolute;
  margin: auto;
  width: 50px;
  height: 50px;
  outline: none;
  border: none;
  background: var(--color-maroon);
  border-radius: 30px;
  transition: all 1s;
  opacity: 0;
  z-index: 5;
  left: 20px; /* Ajustado a la izquierda */
  padding-left: 20px;
  color: var(--color-goldenrod);
  cursor: pointer;
}

input::placeholder {
  color: var(--color-goldenrod);
  opacity: 0.5;
  font-weight: bolder;
}
.search-results {
  position: absolute;
  top: 100%;
  left: 0;
  width: 100%;
  background: white;
  border: 1px solid #ccc;
  list-style: none;
  padding: 0;
  margin: 0;
  display: none;
}

.search-results li {
  line-height: 50px;
  height: 50px;
  font-family: var(--font-playfair-display);
  color: var(--color-gray);
  font-size: var(--font-size-xl);
  cursor: pointer;
  padding-left: 10px;
  position: relative; /* Asegura que el z-index funcione */
  z-index: 1000; /* Elige un valor alto para colocarlo por delante */
}
.search-results li:hover {
  background-color: var(--color-goldenrod);
}
</style>
