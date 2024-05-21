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
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
    
        const response = await fetch('https://localhost:7025/User', {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        });
    
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
    
        const data = await response.json();
    
        // Verificar si la respuesta contiene datos válidos
        if (!data || !Array.isArray(data)) {
          throw new Error('La respuesta no contiene datos válidos');
        }
    
        return data;
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message);
        throw error;
      }
    },
    async fetchUser(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/User/${id}`, {
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
    async fetchMessagesUser(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/User/${id}/messages`, {
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
    async fetchDeleteUser(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/User/${id}`, {
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
    async fetchUpdateUser(id: number, userData: any) {
      
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }

        const formattedUserData: { [key: string]: any } = {};
        Object.keys(userData).forEach(key => {
          formattedUserData[key] = userData[key];
        });
        const response = await fetch(`https://localhost:7025/User/${id}`, {
          method: 'PUT',
          headers: {
            Authorization: `Bearer ${this.token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formattedUserData)
        });
    
        if (!response.ok) {
          throw new Error('Error al actualizar el elemento')
          
        }
        const responseBody = await response.text();
        if (!responseBody) {
          return null;
        }
    
        return JSON.parse(responseBody);
      } catch (error: any) {
        
        console.error('Error al actualizar el elemento:', error.message);
        throw error;
      }
    },
    //END USER
    //STUDIO
    async fetchStudios(name?: string, country?: string) {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
    
        let url = 'https://localhost:7025/Studio';
        if (name !== undefined) {
          url += `?name=${name}`;
        } else if (country !== undefined) {
          url += `?country=${country}`;
        }
    
        const response = await fetch(url, {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        });
    
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
    
        const data = await response.json();
    
        // Verificar si la respuesta contiene datos válidos
        if (!data || !Array.isArray(data)) {
          throw new Error('La respuesta no contiene datos válidos');
        }
    
        return data;
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message);
        throw error;
      }
    },
    async fetchStudio(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/Studio/${id}`, {
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
    async fetchGamesStudio(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/Studio/${id}/games`, {
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
    async fetchPostStudio(studioData:any) {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
    
        const url = 'https://localhost:7025/Studio';
    
        const response = await fetch(url, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${this.token}`
          },
          body: JSON.stringify(studioData)
        });
    
        if (!response.ok) {
          throw new Error('Error al crear el estudio');
        }
    
        const createdStudio = await response.json();
    
        return createdStudio;
      } catch (error: any) {
        console.error('Error al crear el estudio:', error.message);
        throw error;
      }
    },
    async fetchDeleteStudio(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/Studio/${id}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al eliminar el elemento')
        }
        return 'Usuario eliminado correctamente'
      } catch (error: any) {
        console.error('Error al eliminar el elemento:', error.message)
        throw error
      }
    },
    async fetchUpdateStudio(id: number, studioData: any) {
       
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }

        const formattedStudioData: { [key: string]: any } = {};
        Object.keys(studioData).forEach(key => {
          formattedStudioData[key] = studioData[key];
        });
        const response = await fetch(`https://localhost:7025/Studio/${id}`, {
          method: 'PUT',
          headers: {
            Authorization: `Bearer ${this.token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formattedStudioData)
        });
    
        if (!response.ok) {
          throw new Error('Error al actualizar el elemento')
          
        }
        const responseBody = await response.text();
        if (!responseBody) {
          return null;
        }
    
        return JSON.parse(responseBody);
      } catch (error: any) {
        
        console.error('Error al actualizar el elemento:', error.message);
        throw error;
      }
    },
    //END STUDIO
    //ShoppingCart
    async fetchShoppingCart(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/ShoppingCart/${id}`, {
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
    
    async fetchPostShoppingCart(shoppingCartData:any) {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        console.log( JSON.stringify(shoppingCartData));
        
        const url = 'https://localhost:7025/ShoppingCart';
    
        const response = await fetch(url, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${this.token}`
          },
          body: JSON.stringify(shoppingCartData)
        });
    
        if (!response.ok) {
          throw new Error('Error al crear el estudio');
        }
    
        const createdStudio = await response.json();
    
        return createdStudio;
      } catch (error: any) {
        console.error('Error al crear el estudio:', error.message);
        throw error;
      }
    },
    
    async fetchUpdateShoppingCart(id: number, shoppingCartData: any) {
       
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }

        const formattedStudioData: { [key: string]: any } = {};
        Object.keys(shoppingCartData).forEach(key => {
          formattedStudioData[key] = shoppingCartData[key];
        });
        const response = await fetch(`https://localhost:7025/ShoppingCart/${id}`, {
          method: 'PUT',
          headers: {
            Authorization: `Bearer ${this.token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formattedStudioData)
        });
    
        if (!response.ok) {
          throw new Error('Error al actualizar el elemento')
          
        }
        const responseBody = await response.text();
        if (!responseBody) {
          return null;
        }
    
        return JSON.parse(responseBody);
      } catch (error: any) {
        
        console.error('Error al actualizar el elemento:', error.message);
        throw error;
      }
    },
    async fetchDeleteShoppingCart(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/ShoppingCart/${id}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al eliminar el elemento')
        }
        return 'ShoppingCart eliminado correctamente'
      } catch (error: any) {
        console.error('Error al eliminar el elemento:', error.message)
        throw error
      }
    },
    //END ShoppingCart
    //LibraryGameUser
    async fetchLibraryGameUsers() {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        const response = await fetch('https://localhost:7025/LibraryGameUser', {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        });
    
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
    
        const data = await response.json();
    
        // Verificar si la respuesta contiene datos válidos
        if (!data || !Array.isArray(data)) {
          throw new Error('La respuesta no contiene datos válidos');
        }
    
        return data;
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message);
        throw error;
      }
    },
    async fetchLibraryGameUser(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/LibraryGameUser/${id}`, {
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
    async fetchGamesLibraryGameUser(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/LibraryGameUser/${id}/games`, {
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
    async fetchPostLibraryGameUser(libraryGameUserData:any) {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        console.log( JSON.stringify(libraryGameUserData));
        
        const url = 'https://localhost:7025/LibraryGameUser';
    
        const response = await fetch(url, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${this.token}`
          },
          body: JSON.stringify(libraryGameUserData)
        });
    
        if (!response.ok) {
          throw new Error('Error al crear el elemento');
        }
    
        const createdStudio = await response.json();
    
        return createdStudio;
      } catch (error: any) {
        console.error('Error al crear el elemento:', error.message);
        throw error;
      }
    },
    async fetchUpdateLibraryGameUser(id: number, libraryGameUserData: any) {
       
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }

        const formattedLibraryGameUserData: { [key: string]: any } = {};
        Object.keys(libraryGameUserData).forEach(key => {
          formattedLibraryGameUserData[key] = libraryGameUserData[key];
        });
        const response = await fetch(`https://localhost:7025/LibraryGameUser/${id}`, {
          method: 'PUT',
          headers: {
            Authorization: `Bearer ${this.token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formattedLibraryGameUserData)
        });
    
        if (!response.ok) {
          throw new Error('Error al actualizar el elemento')
          
        }
        const responseBody = await response.text();
        if (!responseBody) {
          return null;
        }
    
        return JSON.parse(responseBody);
      } catch (error: any) {
        
        console.error('Error al actualizar el elemento:', error.message);
        throw error;
      }
    },
    async fetchDeleteLibraryGameUser(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/LibraryGameUser/${id}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al eliminar el elemento')
        }
        return 'ShoppingCart eliminado correctamente'
      } catch (error: any) {
        console.error('Error al eliminar el elemento:', error.message)
        throw error
      }
    },
    //End LibraryGameUser
    //GAMESHOP
    async fetchGameShops() {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        const response = await fetch('https://localhost:7025/GameShop', {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        });
    
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
    
        const data = await response.json();
    
        // Verificar si la respuesta contiene datos válidos
        if (!data || !Array.isArray(data)) {
          throw new Error('La respuesta no contiene datos válidos');
        }
    
        return data;
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message);
        throw error;
      }
    },
    async fetchGameShop(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/GameShop/${id}`, {
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
    async fetchGamesGameShop(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/GameShop/${id}/games`, {
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
    async fetchPostGameShop(gameShopData:any) {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        console.log( JSON.stringify(gameShopData));
        
        const url = 'https://localhost:7025/GameShop';
    
        const response = await fetch(url, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${this.token}`
          },
          body: JSON.stringify(gameShopData)
        });
    
        if (!response.ok) {
          throw new Error('Error al crear el elemento');
        }
    
        const createdStudio = await response.json();
    
        return createdStudio;
      } catch (error: any) {
        console.error('Error al crear el elemento:', error.message);
        throw error;
      }
    },
    async fetchUpdateGameShop(id: number, gameShopData: any) {
       
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }

        const formattedGameShopData: { [key: string]: any } = {};
        Object.keys(gameShopData).forEach(key => {
          formattedGameShopData[key] = gameShopData[key];
        });
        const response = await fetch(`https://localhost:7025/GameShop/${id}`, {
          method: 'PUT',
          headers: {
            Authorization: `Bearer ${this.token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formattedGameShopData)
        });
    
        if (!response.ok) {
          throw new Error('Error al actualizar el elemento')
          
        }
        const responseBody = await response.text();
        if (!responseBody) {
          return null;
        }
    
        return JSON.parse(responseBody);
      } catch (error: any) {
        
        console.error('Error al actualizar el elemento:', error.message);
        throw error;
      }
    },
    async fetchDeleteGameShop(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/GameShop/${id}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al eliminar el elemento')
        }
        return 'ShoppingCart eliminado correctamente'
      } catch (error: any) {
        console.error('Error al eliminar el elemento:', error.message)
        throw error
      }
    },
    //End GAMESHOP
    //GAME
    async fetchGames() {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        const response = await fetch('https://localhost:7025/Game', {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        });
    
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
    
        const data = await response.json();
    
        // Verificar si la respuesta contiene datos válidos
        if (!data || !Array.isArray(data)) {
          throw new Error('La respuesta no contiene datos válidos');
        }
    
        return data;
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message);
        throw error;
      }
    },
    async fetchGame(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/Game/${id}`, {
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
    async fetchPostGame(gameData:any) {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        console.log( JSON.stringify(gameData));
        
        const url = 'https://localhost:7025/Game';
    
        const response = await fetch(url, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${this.token}`
          },
          body: JSON.stringify(gameData)
        });
    
        if (!response.ok) {
          throw new Error('Error al crear el elemento');
        }
    
        const createdStudio = await response.json();
    
        return createdStudio;
      } catch (error: any) {
        console.error('Error al crear el elemento:', error.message);
        throw error;
      }
    },
    async fetchUpdateGame(id: number, gameData: any) {
       
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }

        const formattedGameData: { [key: string]: any } = {};
        Object.keys(gameData).forEach(key => {
          formattedGameData[key] = gameData[key];
        });
        const response = await fetch(`https://localhost:7025/Game/${id}`, {
          method: 'PUT',
          headers: {
            Authorization: `Bearer ${this.token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formattedGameData)
        });
    
        if (!response.ok) {
          throw new Error('Error al actualizar el elemento')
          
        }
        const responseBody = await response.text();
        if (!responseBody) {
          return null;
        }
    
        return JSON.parse(responseBody);
      } catch (error: any) {
        
        console.error('Error al actualizar el elemento:', error.message);
        throw error;
      }
    },
    async fetchDeleteGame(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/Game/${id}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al eliminar el elemento')
        }
        return 'ShoppingCart eliminado correctamente'
      } catch (error: any) {
        console.error('Error al eliminar el elemento:', error.message)
        throw error
      }
    },
    //End GAME
    //COMMUNITY
    async fetchCommunities() {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        const response = await fetch('https://localhost:7025/Community', {
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        });
    
        if (!response.ok) {
          throw new Error('Error al obtener los datos');
        }
    
        const data = await response.json();
    
        // Verificar si la respuesta contiene datos válidos
        if (!data || !Array.isArray(data)) {
          throw new Error('La respuesta no contiene datos válidos');
        }
    
        return data;
      } catch (error: any) {
        console.error('Error al obtener los datos:', error.message);
        throw error;
      }
    },
    async fetchCommunity(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/Community/${id}`, {
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
    //NO FUNKA EL POST ERROR INTERNO SERVIOR 500
    async fetchPostCommunity(communityData:any) {
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }
        console.log( JSON.stringify(communityData));
        
        const url = 'https://localhost:7025/Community';
    
        const response = await fetch(url, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${this.token}`
          },
          body: JSON.stringify(communityData)
        });
    
        if (!response.ok) {
          throw new Error('Error al crear el elemento');
        }
    
        const createdStudio = await response.json();
    
        return createdStudio;
      } catch (error: any) {
        console.error('Error al crear el elemento:', error.message);
        throw error;
      }
    },
    async fetchUpdateCommunity(id: number, communityData: any) {
       
      try {
        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage');
          return;
        }

        const formattedCommunityData: { [key: string]: any } = {};
        Object.keys(communityData).forEach(key => {
          formattedCommunityData[key] = communityData[key];
        });
        const response = await fetch(`https://localhost:7025/Community/${id}`, {
          method: 'PUT',
          headers: {
            Authorization: `Bearer ${this.token}`,
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(formattedCommunityData)
        });
    
        if (!response.ok) {
          throw new Error('Error al actualizar el elemento')
          
        }
        const responseBody = await response.text();
        if (!responseBody) {
          return null;
        }
    
        return JSON.parse(responseBody);
      } catch (error: any) {
        
        console.error('Error al actualizar el elemento:', error.message);
        throw error;
      }
    },
    async fetchDeleteCommunity(id: number) {
      try {

        if (!this.token) {
          console.error('No se encontró ningún token JWT en el localStorage')
          return
        }

        const response = await fetch(`https://localhost:7025/Community/${id}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${this.token}`
          }
        })
        if (!response.ok) {
          throw new Error('Error al eliminar el elemento')
        }
        return 'ShoppingCart eliminado correctamente'
      } catch (error: any) {
        console.error('Error al eliminar el elemento:', error.message)
        throw error
      }
    },
    //End COMMUNITY
  }
})

export { pinia }
