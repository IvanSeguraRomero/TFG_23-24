<script setup lang="ts">
  import { useField, useForm } from 'vee-validate';
  import { useRouter } from 'vue-router';
  import { ref } from 'vue';
  import { useApiStore, pinia } from '../store/api';
  const existingUser = ref(false);

  //Home
  const router = useRouter();
  const navigateToHome = async() => {
    if(existingUser.value==true){
        router.push({ name: 'home' });
    }
  };

  function proveExistingUser(users:any,values : any){
    users.forEach((element:any) => {
      if((element.email === values.emailTlf || element.tlf==values.emailTlf) && element.passwd === values.passwd){
        existingUser.value=true;
        localStorage.setItem('user', JSON.stringify(element));
        if(element.email.indexOf('@svalero') !==-1){
          localStorage.setItem('admin', "true");
        }else{
          localStorage.setItem('admin', "false");
        }
      } 
    });

    if(existingUser.value==false){
        alert('Este usuario no se ha registrado');
      }else{
        handleReset();
        alert('El usuario se ha logeado correctamente');
        navigateToHome();
      }
    }

  

  const { handleSubmit, handleReset } = useForm({
    validationSchema: {
      emailTlf(value:any) {
        if (/^[a-z0-9.-]+@[a-z.-]+\.[a-z]+$/i.test(value)) return true

        return 'Must be a valid e-mail.'
        
      },
      checkbox(value:any) {
        if (value === '1') return true

        return 'Must be checked.'
      },
      passwd(value:any) {
        if (
          value?.length >= 7
        )
          return true

        return 'Password must contain at leats 1 number, 1 letter, 1 symbol & have more than 7 characters'
      },
    },
  })
  const emailTlf = useField('emailTlf')
  const checkbox = useField('checkbox')
  const passwd = useField('passwd')
  const visible = ref(false);

  const submit = handleSubmit(values => {
    existingUser.value=false;
    
  })

  const logOut = () =>{
    if(localStorage.getItem('user')!=JSON.stringify(null)){
      localStorage.setItem('user', JSON.stringify(null));
      localStorage.setItem('admin', "false");
      alert('Se ha cerrado sesión');
    }else{
      alert('Todavía no se ha logueado');
    }
    
  }
</script>
<template>
    <form @submit.prevent="submit">
        <label for="chk" aria-hidden="true">Login</label>
    
        <v-text-field
          v-model="emailTlf.value.value"
          :error-messages="emailTlf.errorMessage.value"
          label="Correo electrónico"
          placeholder="correo@ejemplo.com"
        ></v-text-field>
    
        <v-text-field
          v-model="passwd.value.value"
          :error-messages="passwd.errorMessage.value"
          :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
          :type="visible ? 'text' : 'password'"
          label="Contraseña"
          placeholder="Pon tu contraseña"
          @click:append-inner="visible = !visible"
        ></v-text-field>
    
        <v-checkbox
          v-model="checkbox.value.value"
          :error-messages="checkbox.errorMessage.value"
          value="1"
          label="Acepto los Términos de Política y Privacidad"
          type="checkbox"
        >
        </v-checkbox>
        <div class="buttons">
          <v-btn class="me-4" type="submit">Login</v-btn>
      
          <v-btn @click="handleReset" class="clear"> Clear </v-btn>
          
        </div>
        <div style="display: flex; align-items: center; justify-content: center;">
          <v-btn @click="logOut" class="logOut"> Log Out </v-btn>
        </div>
      </form>
</template>

<style scoped>
form{
  margin-top: 40px;
  margin-bottom: 20px;
  width: 500px;
  max-width: 400px; /* Ancho máximo del formulario */
  padding: 20px;
  background-image: linear-gradient(var(--color-dark-blue), var(--color-yellow)); 
  color: white;
  border-radius: 50px 50px 5px 5px;
  height: 650px;
}
label{
  display: flex;
  justify-content: center;
  margin-bottom: 20px;
  color: var(--color-goldenrod);
  font-size: var(--font-size-25xl);
  font-family: var(--font-orbitron);
  font-weight: bold;
  cursor: pointer;
  transition: .5s ease-in-out;
  margin-bottom: 40px;
}
.buttons{
  display: flex;
  justify-content: center;
}
.me-4{
  background: linear-gradient(to right, #99e380, #56ccf2); /* Cambia los colores según tu preferencia */
  color: white;
}
.clear{
  background: linear-gradient(to right, #450054, #db0606); /* Cambia los colores según tu preferencia */
  color: white;
}
.logOut{
  margin-top: 20px;
  width: auto;
  cursor: pointer;
  padding-left: 30px;
  padding-right: 30px;
  color: hsl(0, 100%, 62%);
  border: hsl(0, 100%, 62%) 0.125em solid;
  border-radius: 0.25em;
  text-shadow: 0 0 0.125em hsl(0 0% 100% / 0.3), 0 0 0.45em currentColor;
  box-shadow: inset 0 0 0.5em 0 hsl(0, 100%, 62%), 0 0 0.5em 0 hsl(0, 100%, 62%);
  background-color: transparent;
  box-sizing: border-box;
}

.logOut::before{
  background-color: hsl(0, 100%, 62%);
  transform: perspective(1em) rotateX(40deg) scale(1, 0.35);
  filter: blur(1em);
  opacity: 0.7;
}

.logOut::after{
  box-shadow: 0 0 20px 0.5em hsl(0, 100%, 62%);
  opacity: 0;
  background-color: hsl(0, 100%, 62%);
  z-index: -1;
  transition: opacity 100ms linear;
}
.logOut:hover, .logOut:focus{
  color: hsl(0, 0%, 0%);
  background-color: hsl(0, 100%, 62%);
  text-shadow: 0 0 0.125em hsl(0 0% 100% / 0.3), 0 0 0.45em currentColor;
  text-shadow: none;

}
.logOut:hover::before, .logOut:focus::before{
  opacity: 1;
}
.logOut:hover::after, .logOut:focus::after{
  opacity: 1;
}

::v-deep .v-selection-control__input input{
  opacity: 1;
  top: 25%;
  left:25%;
  width:50%;
  height: 50%;
}
</style>