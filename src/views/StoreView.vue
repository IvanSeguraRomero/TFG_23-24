<script setup lang="ts">
import { useApiStore, pinia } from '../store/api'
import { jwtDecode } from 'jwt-decode'

const user = {
  email: 'user2@example.com',
  password: 'password2'
}
// const userRegister = {
//   name: 'Probandoregister',
//   surname: 'Desde frontend',
//   password: '1234',
//   age: 21,
//   email: 'hola@registrado.com',
//   registerDate: '2024-05-14T15:47:16.200Z',
//   active: true,
//   role: 'admin'
// }
//put user prueba
const userData = {
  age: 777,
};
// test login
const loginUser = async () => {
  const token = await useApiStore(pinia).fetchPostLoginUser(user)
  if (token) {
    localStorage.setItem('jwtToken', token)
    decodedToken()
  } else {
    console.error('Error al iniciar sesión.')
  }
}
//test register
// const registerUser = async () => {
//   const token = await useApiStore(pinia).fetchPostRegisterUser(userRegister)
//   if (token) {
//     localStorage.setItem('jwtToken', token)
//     console.log('Token recibido:', token)
//     decodedToken()
//   } else {
//     console.error('Error al iniciar sesión.')
//   }
// }

const decodedToken = async () => {
  const token = localStorage.getItem('jwtToken')

  if (!token) {
    console.error('No se encontró un token JWT en el almacenamiento local.')
    return
  }

  // Decodificar el token JWT
  const decodedToken = jwtDecode(token)

  // console.log('Token decodificado:', decodedToken)
  console.log('Token sin decodificar:', token)
  await useApiStore(pinia).fetchUpdateUser(decodedToken.id,userData)
  // console.log(put)
}
loginUser()
// registerUser()
</script>

<template>
  <main>
    <h1>HOLAStore</h1>
  </main>
</template>

<style scoped>
main {
  background-color: var(--color-maroon);
  width: 100%;
  height: auto;
  text-align: center;
  font-size: var(--font-size-25xl);
  color: var(--color-goldenrod);
  font-family: var(--font-lobster);
}
</style>
