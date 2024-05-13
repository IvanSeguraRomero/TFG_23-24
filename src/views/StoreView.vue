<script setup lang="ts">
import { useApiStore, pinia } from '../store/api'
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { jwtDecode } from 'jwt-decode'

//import css

const user = {
  email: 'user1@example.com',
  password: 'password1'
}

const loginUser = async () => {
  const token = await useApiStore(pinia).fetchPostLoginUser(user)
  if (token) {
    localStorage.setItem('jwtToken', token)
    console.log('Token recibido:', token)
    loginUserToken()
  } else {
    console.error('Error al iniciar sesión.')
  }
}

const loginUserToken = async () => {
  const token = localStorage.getItem('jwtToken')

  if (!token) {
    console.error('No se encontró un token JWT en el almacenamiento local.')
    return
  }

  // Decodificar el token JWT
  const decodedToken = jwtDecode(token)

  console.log('Token decodificado:', decodedToken)
}

// Llamar a la función para decodificar el token
loginUser()
</script>

<template>
  <main>
  <h1>HOLAStore</h1>
  </main>
</template>

<style scoped>
  main{
  background-color: var(--color-maroon);
  width: 100%;
  height: auto;
  text-align: center;
  font-size: var(--font-size-25xl);
  color: var(--color-goldenrod);
  font-family: var(--font-lobster);
}
</style>

