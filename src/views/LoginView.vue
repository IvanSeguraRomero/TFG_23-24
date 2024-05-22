<script setup lang="ts">
import RegisterForm from '@/components/RegisterForm.vue';
import LoginForm from '@/components/LoginForm.vue';
</script>
<template>
    <div class="main">
        <div class="background-container">
            <input type="checkbox" id="chk" aria-hidden="true">
            <div class="containerR">
                <RegisterForm />
            </div>
            <div class="containerL">
                <LoginForm />
            </div>
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
.background-container {
    position: absolute;
    width: auto;
    height: 750px;
    overflow: hidden;
    margin-bottom: 40px;
    border: 1px solid #ccc;
    margin-top: 40px;
    border: 1px solid #ccc;
    border-radius: 5px;
}
.containerR {
    position: relative;
    display: flex;
    justify-content: center;
    align-items: center;
}
.containerL{
    display: flex;
    justify-content: center;
    align-items: center;
    transform: translateY(-50px);
	transition: .8s ease-in-out;
    border-radius: 60% / 10%;
    margin-bottom: 20px;
    height: 610px;
}
#chk{
    display: none;
}
#chk:checked ~ .containerL{
	transform: translateY(-610px);
}
#chk:checked ~ .containerL label{
	transform: scale(1);	
}
#chk:checked ~ .containerR label{
	transform: scale(.6);
}
</style>