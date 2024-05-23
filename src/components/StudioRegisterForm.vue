<script setup lang="ts">
import { useField, useForm } from 'vee-validate';
import { ref } from 'vue';
import { useApiStore, pinia } from '../store/api';
import { RouterLink } from 'vue-router';

async function proveExistingStudio(email: string): Promise<boolean> {
  const studios = await useApiStore(pinia).fetchStudios();
  
  for (const studio of studios) {
    if (studio.emailLogin === email) {
      alert('Este estudio ya se ha registrado');
      return true;
    }
  }
  return false;
}


const fetchPostUser = async (values: any) => {
  try {
    const exists = await proveExistingStudio(values.email);
    if (!exists) {
      const studioDTO = {
        name: values.name,
        fundation: new Date().toISOString(),
        country: values.country,
        emailLogin: values.email,
        password: values.passwd
      };
      await useApiStore(pinia).fetchPostStudio(studioDTO);
      handleClear();
    }
  } catch (err) {
    console.error(err);
  }
};

const { handleSubmit, handleReset } = useForm({
  validationSchema: {
    name(value: any) {
      if (value?.length >= 2) return true;
      return 'Name needs to be at least 2 characters.';
    },
    country(value: any) {
      if (value?.length >= 2) return true;
      return 'Country needs to be at least 2 characters.';
    },
    email(value: any) {
      if (/^[a-z.-]+@[a-z.-]+\.[a-z]+$/i.test(value)) return true;
      return 'Must be a valid e-mail.';
    },
    checkbox(value: any) {
      if (value === '1') return true;
      return 'Must be checked.';
    },
    passwd(value: any) {
      if (
        /^(?=.*[a-zA-Z])(?=.*\d)(?=.*[^\w\s])/.test(value) &&
        value.length >= 7
      ) return true;
      return 'Password must contain at least 1 number, 1 letter, 1 symbol & have more than 7 characters';
    },
  },
});

const name = useField('name');
const country = useField('country');
const email = useField('email');
const checkbox = useField('checkbox');
const passwd = useField('passwd');
const visible = ref(false);

const submit = handleSubmit((values) => {
  fetchPostUser(values);
});

const handleClear = () => {
  handleReset();
};
</script>



<template>
      <form @submit.prevent="submit">
        <label for="chk" aria-hidden="true">Register</label>
        <v-text-field
          v-model="name.value.value"
          :counter="30"
          :error-messages="name.errorMessage.value"
          label="Name"
          placeholder="TStudios"
        ></v-text-field>
    
        <v-text-field
          v-model="country.value.value"
          :counter="40"
          :error-messages="country.errorMessage.value"
          label="Country"
          placeholder="England"
        ></v-text-field>
    
        <v-text-field
          v-model="email.value.value"
          :error-messages="email.errorMessage.value"
          label="E-Mail"
          placeholder="tstudios@example.com"
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
          <v-btn class="me-4" type="submit"> Register </v-btn>
      
          <v-btn @click="handleClear" class="clear" id="regClear"> Clear </v-btn>
        </div>
        <RouterLink to="/login&Register" class="custom-link">Are you a User?</RouterLink>
      </form>
</template>
<style scoped>
form{
  margin-bottom: 20px;
  width: 500px;
  max-width: 400px; /* Ancho máximo del formulario */
  padding: 20px;
  background-image: linear-gradient(var(--color-black), var(--color-dark-blue));
  color: white;
  height: 700px;
  border-radius: 10px;
}
label{
  display: flex;
  justify-content: center;
  margin-bottom: 40px;
  color: var(--neutral-colors-white);
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
  background: linear-gradient(to right, #ecfe94, #56ccf2); /* Cambia los colores según tu preferencia */
  color: black;
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

.centered-menu {
  top: 50% ;
  left: 45% ;
  transform: translate(-50%, -50%) ;
}
.custom-link {
  font-style: italic;
  display: block;
  text-align: center;
  margin-top: 10px;
  color: var(--color-blue);
}
</style>