<script setup lang="ts">

</script>
<template>
    <!-- <div class="logo">
        <canvas id="myCanvasF" width="286px" height="220px" class="logo-1-icon">

        </canvas>
      <slot name="logosearchtexto"></slot>
          
  </div> -->
  <slot name="hrindex">
    <hr class="footer-line-hr">
  </slot>
  <nav class="sections">
        <div class="redesSociales">
            <a href="https://www.facebook.com/" target="_blank">
                <div class="redSocial">
                    <slot name="facebook"></slot>
                </div>
            </a>
            <a href="https://www.instagram.com/" target="_blank">
                <div class="redSocial">
                    <slot name="instagram"></slot>
                </div>
            </a>
            <a href="https://twitter.com/?lang=en" target="_blank">
                <div class="redSocial">
                    <slot name="twitter"></slot>
                </div>
            </a>
        </div>
    </nav>
    
</template>

<style scoped>
.logo{
    position: relative;
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
.sections{
    transform: scale(0.7);
    position: relative;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: flex-end;
    gap: 40px;
    top: 32px;
    text-align: center;
    font-size: 28px;
    color: #5d5a88;
    font-family: "Playfair Display";
    margin-left: 250px;
}
.redesSociales{
    display: flex;
    width: auto;
    height: 36px;
    gap: 20px;
    margin-left: 20px;
}
.footer-line-hr {
  position: relative;
  width: 100%;
  border-color: #000;
}
.redSocial{
  background-color: #000000;
  width: 35px;
  height: 35px;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 8px;
  transition: background-color 2s;
}
.redSocial:hover{
    background-color: #1aeae6;
}
</style>