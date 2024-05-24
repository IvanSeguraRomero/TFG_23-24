<script setup lang="ts">
import StudioRegisterForm from '@/components/StudioRegisterForm.vue';
</script>
<template>
    <div class="main">
        <div class="containerR">
            <StudioRegisterForm />
        </div>
    </div>
</template>
<style scoped>
.main{
    height: 780px;
    background-image: url("../assets/cyber_site.jpg");
    background-size: cover; /* Esto hace que la imagen de fondo cubra todo el contenedor */
    background-position: center; /* Esto centra la imagen de fondo */
    display: flex;
    justify-content: center;
    align-items: center;
}

.containerR {
    position: relative;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>