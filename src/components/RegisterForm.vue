<script setup lang="ts">
import { useField, useForm } from 'vee-validate';
import { computed, ref } from 'vue';
import { useApiStore, pinia } from '../store/api';
const existingUser = ref(false);

function proveExistingUser(users:any,values : any){
  users.forEach((element:any) => {
    if(element.email === values.email || element.tlf==values.phone){
      existingUser.value=true;
    } 
  });

  if(existingUser.value==false){
    handleReset();
    }else{
      alert('Este usuario ya se ha registrado');
    }
}

  const { handleSubmit, handleReset } = useForm({
    validationSchema: {
      name(value:any) {
        if (value?.length >= 2) return true

        return 'Name needs to be at least 2 characters.'
      },
      surname(value:any) {
        if (value?.length >= 2) return true

        return 'Name needs to be at least 2 characters.'
      },
      birthDate(value:any) {
        return true
      },
      email(value:any) {
        if (/^[a-z.-]+@[a-z.-]+\.[a-z]+$/i.test(value)) return true

        return 'Must be a valid e-mail.'
      },
      checkbox(value:any) {
        if (value === '1') return true

        return 'Must be checked.'
      },
      passwd(value:any) {
        if (
          /^(?=.*[a-zA-Z])(?=.*\d)(?=.*[^\w\s])/.test(value) &&
          value.length >= 7
        )
          return true

        return 'Password must contain at leats 1 number, 1 letter, 1 symbol & have more than 7 characters'
      },
    },
  })
  const name = useField('name')
  const surname = useField('surname')
  const email = useField('email')
  const checkbox = useField('checkbox')
  const passwd = useField('passwd')
  const visible = ref(false);

  const birthDate = ref<Date | null>(null);
  const menu = ref(false);
  const maxDate = computed(() => {
    const today = new Date();
    const maxYear = today.getFullYear() - 12;
    const maxMonth = today.getMonth() + 1; // Añadimos 1 ya que los meses comienzan desde 0
    const maxDay = today.getDate();
    return `${maxYear}-${maxMonth < 10 ? '0' + maxMonth : maxMonth}-${maxDay < 10 ? '0' + maxDay : maxDay}`;
  });
  const minDate = computed(() => {
    const today = new Date();
    const minYear = today.getFullYear() - 100;
    const minMonth = today.getMonth() + 1; // Añadimos 1 ya que los meses comienzan desde 0
    const minDay = today.getDate();
    return `${minYear}-${minMonth < 10 ? '0' + minMonth : minMonth}-${minDay < 10 ? '0' + minDay : minDay}`;
  });

  const formattedDate = computed(() => {
    return birthDate.value ? new Date(birthDate.value).toLocaleDateString() : '';
  });

  const openMenu = () => {
    menu.value = true;
  };

  const closeMenu = () => {
    menu.value = false;
  };

  const submit = handleSubmit(values => {
    existingUser.value=false;
    
  });
  submit
</script>
<template>
      <form @submit.prevent="submit">
        <label for="chk" aria-hidden="true">Register</label>
        <v-text-field
          v-model="name.value.value"
          :counter="10"
          :error-messages="name.errorMessage.value"
          label="Nombre"
          placeholder="Paco"
        ></v-text-field>
    
        <v-text-field
          v-model="surname.value.value"
          :counter="40"
          :error-messages="surname.errorMessage.value"
          label="Apellidos"
          placeholder="Fernandez Domingo"
        ></v-text-field>
    
        <v-text-field
          v-model="email.value.value"
          :error-messages="email.errorMessage.value"
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
    
        <v-menu v-model="menu" :close-on-content-click="false" transition="scale-transition" offset-y >
          <template v-slot:activator>
            <v-text-field v-model="formattedDate" label="Fecha de nacimiento" readonly @click="openMenu"></v-text-field>
          </template>
          <v-date-picker :max="maxDate" :min="minDate" color="secondary" v-model="birthDate" @input="menu = false"></v-date-picker>
        </v-menu>
    
        <v-checkbox
          v-model="checkbox.value.value"
          :error-messages="checkbox.errorMessage.value"
          value="1"
          label="Acepto los Términos de Política y Privacidad"
          type="checkbox"
        >
        </v-checkbox>
        <div class="buttons">
          <v-btn class="me-4" type="submit"> Register </v-btn>
      
          <v-btn @click="handleReset" class="clear"> Clear </v-btn>
        </div>
      </form>
</template>
<style scoped>
form{
  margin-bottom: 20px;
  width: 500px;
  max-width: 400px; /* Ancho máximo del formulario */
  padding: 20px;
  background-image: linear-gradient(var(--color-yellow), var(--color-dark-blue));
  color: white;
  /* backdrop-filter: blur(16px); */
  height: 700px;
}
label{
  display: flex;
  justify-content: center;
  margin-bottom: 40px;
  color: var(--color-gray);
  font-size: var(--font-size-25xl);
  font-family: var(--font-orbitron);
  font-weight: bold;
  cursor: pointer;
  transition: .5s ease-in-out;
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
::v-deep .v-selection-control__input input{
  opacity: 1;
  top: 25%;
  left:25%;
  width:50%;
  height: 50%;
}

.v-date-picker {
    width: 400px;
}
</style>