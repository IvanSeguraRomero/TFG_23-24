<script setup lang="ts">
import { useField, useForm } from 'vee-validate';
import { computed, ref, watch } from 'vue';
import { useApiStore, pinia } from '../store/api';
import { jwtDecode } from 'jwt-decode';

const existingUser = ref(false);

function proveExistingUser(users: any, values: any) {
  
  users.forEach((element: any) => {
    if (element.email === values.email) {
      existingUser.value = true;
    }
  });

  if (!existingUser.value) {
    fetchPostUser(values);
    handleReset();
    handleDateReset();
  } else {
    alert('Este usuario ya se ha registrado');
  }
}



//clean datefield when registered
const handleDateReset=()=>{
  const text = document.querySelector("#textDateField") as HTMLInputElement | HTMLTextAreaElement | null;

if (text !== null) {
    text.value = "";
}
  
}

const fetchPostUser = async (values: any) => {
  try {
    const userDTO = {
      name: values.name,
      surname: values.surname,
      password: values.passwd,
      age: values.age,
      email: values.email,
      registerDate: values.registeredDate,
      role: "user"
    };
    
    const token=await useApiStore(pinia).fetchPostRegisterUser(userDTO);
    if(token){
    localStorage.setItem('jwtToken', token);
    }
    await postUpdateTables();
  } catch (err) {
    console.error(err);
  }
};
  const postUpdateTables = async()=>{
    const token=localStorage.getItem('jwtToken');
  if (!token) {
    console.error('No se encontró un token JWT en el almacenamiento local.')
    return
  }

  // Decodificar el token JWT
  const decodedToken = jwtDecode(token) as { id: number };
  
    postLibraryCommunity(decodedToken.id);
    updateUserIds(decodedToken.id);
}
function postLibraryCommunity(userId : any){
  const libraryUserDTO = {
      addedDate: Date.now,
      userID : userId
    };
    useApiStore(pinia).fetchPostLibraryGameUser(libraryUserDTO);
  const communityUserDTO={
    message : "Start",
    userID : userId
  }
    useApiStore(pinia).fetchPostCommunity(communityUserDTO);

}
function updateUserIds(userId : any){
  const objectIds = {
    libraryGameUserID : userId,
    messageID : userId
  }
  useApiStore(pinia).fetchUpdateUser(userId++,objectIds);
}
const fetchGetUser = async (values: any) => {
  try {
    const users = await useApiStore(pinia).fetchUsers();
    localStorage.setItem('users',JSON.stringify(users));
    proveExistingUser(users, values);
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
    surname(value: any) {
      if (value?.length >= 2) return true;
      return 'Surname needs to be at least 2 characters.';
    },
    birthDate(value: any) {
      return true;
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
      )
        return true;
      return 'Password must contain at least 1 number, 1 letter, 1 symbol & have more than 7 characters';
    },
  },
});

const name = useField('name');
const surname = useField('surname');
const email = useField('email');
const checkbox = useField('checkbox');
const passwd = useField('passwd');
const visible = ref(false);

const birthDate = ref<Date | null>(null);
const formattedDate = ref<string | null>(null);
const menu = ref(false);

const maxDate = computed(() => {
  const today = new Date();
  const maxYear = today.getFullYear() - 12;
  const maxMonth = today.getMonth() + 1;
  const maxDay = today.getDate();
  return `${maxYear}-${maxMonth < 10 ? '0' + maxMonth : maxMonth}-${maxDay < 10 ? '0' + maxDay : maxDay}`;
});

const minDate = computed(() => {
  const today = new Date();
  const minYear = today.getFullYear() - 100;
  const minMonth = today.getMonth() + 1;
  const minDay = today.getDate();
  return `${minYear}-${minMonth < 10 ? '0' + minMonth : minMonth}-${minDay < 10 ? '0' + minDay : minDay}`;
});

function formatDate(date: Date): string {
  const year = date.getFullYear();
  const month = (date.getMonth() + 1).toString().padStart(2, '0');
  const day = date.getDate().toString().padStart(2, '0');
  return `${year}-${month}-${day}`;
}

watch(birthDate, (newVal) => {
  if (newVal) {
    formattedDate.value = formatDate(newVal);
  }
});

function calcAge(birthDate: Date): number {
  const today = new Date();
  let age = today.getFullYear() - birthDate.getFullYear();
  const m = today.getMonth() - birthDate.getMonth();
  if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
    age--;
  }
  return age;
}

const age = ref<number | null>(null);

const submit = handleSubmit((values) => {
  if (birthDate.value) {
    existingUser.value = false;
    formattedDate.value = formatDate(birthDate.value);
    age.value = calcAge(birthDate.value);
    values.age = age.value;
    values.registeredDate = formattedDate.value;
    fetchGetUser(values);
  }
});

const openMenu = () => {
  menu.value = true;
};

const closeMenu = () => {
  menu.value = false;
};

submit;

const resetFields = () => {
  birthDate.value = null;
  formattedDate.value = null;
  age.value = null;
  visible.value = false;
  menu.value = false;
};

const handleClear = () => {
  resetFields();
  handleReset();
};


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
    
        <v-menu v-model="menu" :close-on-content-click="false" transition="scale-transition" offset-y  class="centered-menu">
          <template v-slot:activator>
            <v-text-field v-model="formattedDate" label="Fecha de nacimiento" readonly @click="openMenu" id="textDateField"></v-text-field>
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
      
          <v-btn @click="handleClear" class="clear" id="regClear"> Clear </v-btn>
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

.centered-menu {
  top: 50% ;
  left: 45% ;
  transform: translate(-50%, -50%) ;
}
</style>