import { defineStore, createPinia } from 'pinia'

// Creamos la instancia de Pinia
const pinia = createPinia()

// Exportamos la tienda
export const useApiStore = defineStore('flashgaminghub', {
  state: () => ({
    token: localStorage.getItem('jwtToken') || null,
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

        return token
      } catch (error) {
        console.error('Error al enviar los datos:', error)
        return null
      }
    },
    async fetchPostRegisterUser(user: any) {
      try {
        const response = await fetch('https://localhost:7025/Auth/Register', {
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

        return token
      } catch (error) {
        console.error('Error al enviar los datos:', error)
        return null
      }
    },
    //USER
    async fetchUsers() {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch('https://localhost:7025/User', {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al obtener los datos')
        }
        return await response.json()
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message)
        throw error
      }
    },
    async fetchUser(idUser: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/User/${idUser}`, {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al obtener los datos')
        }
        return await response.json()
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message)
        throw error
      }
    },
    async fetchMessagesUser(idUser: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/User/${idUser}/messages`, {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al obtener los datos')
        }
        return await response.json()
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message)
        throw error
      }
    },
    async fetchDeleteUser(idUser: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/User/${idUser}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al eliminar el usuario')
        }
        return 'Usuario eliminado correctamente'
      } catch (error: any) {
        console.error('Error al eliminar el usuario:', error.message)
        throw error
      }
    },
    async fetchUpdateUser(idUser: number, userData: any) {
      
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }

        const formattedUserData: { [key: string]: any } = {};
        Object.keys(userData).forEach(key => {
          formattedUserData[key] = userData[key];
        });
        const response = await fetch(`https://localhost:7025/User/${idUser}`, {
          method: 'PUT',
          headers: {
            Authorization: `Bearer ${this.token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formattedUserData)
        });
    
        if (!response.ok) {
          throw new Error('Error al actualizar el usuario')
          
        }
        const responseBody = await response.text();
        if (!responseBody) {
          return null;
        }
    
        return JSON.parse(responseBody);
      } catch (error: any) {
        
        console.error('Error al actualizar el usuario:', error.message);
        throw error;
      }
    }
    //END USER
    
  }
})

export { pinia }
