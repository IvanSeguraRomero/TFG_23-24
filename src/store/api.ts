import { defineStore, createPinia } from 'pinia'

// Creamos la instancia de Pinia
const pinia = createPinia()

// Exportamos la tienda
export const useApiStore = defineStore('flashgaminghub', {
  state: () => ({
    // loggedInUser: JSON.parse(localStorage.getItem('user')!),
    // admin: false
  }),
  actions: {
    async fetchPostLoginUser(user: any) {
      try {
        const response = await fetch('https://localhost:7025/Auth/Login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(user)
        })

        if (!response.ok) {
          console.error(`Error: ${response.status} - ${response.statusText}`)
          return null
        }

        const data = await response.text()
        const token = data

        // localStorage.setItem('jwtToken', token)

        return token
      } catch (error) {
        console.error('Error al enviar los datos:', error)
        return null
      }
    }
  }
})

export { pinia }
