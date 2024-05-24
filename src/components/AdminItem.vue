<script setup lang="ts">
import { ref } from 'vue';
import { VDateInput } from 'vuetify/labs/VDateInput';

const show1 = ref(false);
const nuevoJuego = ref({
    title: '',
    descriptionPlay: '',
    synopsis: '',
    director: '',
    genre: '',
    role: ''
});

function addGame() {
    const { title, descriptionPlay, synopsis, director, genre, role } = nuevoJuego.value;

    if (!title || !descriptionPlay || !synopsis || !director || !genre || !role) {
        alert('Faltan campos por completar');
    } else {
        // Aquí va la lógica para añadir el juego
        // juegos.value.push({
        //   title,
        //   descriptionPlay,
        //   synopsis,
        //   director,
        //   genre,
        //   role
        // });
        // fetchPostGames(JSON.stringify(juegos.value[0]));
    }
}

const nameRules = ref([
    (value: string) => !!value || 'El campo no puede estar vacío',
]);
</script>

<template>
    <v-form class="custom-form">
        <v-container>
            <v-row>
                <v-col cols="12" md="4">
                    <v-text-field clearable
                        v-model="nuevoJuego.title"
                        :rules="nameRules"
                        label="Name"
                        placeholder="Paco"
                        counter="20"
                        required
                    ></v-text-field>
                </v-col>

                <v-col cols="12" md="4">
                    <v-text-field clearable
                        v-model="nuevoJuego.descriptionPlay"
                        :rules="nameRules"
                        label="Username"
                        placeholder="ByeDog4000"
                        required
                        counter="30"
                    ></v-text-field>
                </v-col>

                <v-col cols="12" md="4">
                    <v-text-field
                        v-model="nuevoJuego.synopsis"
                        :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                        :type="show1 ? 'text' : 'password'"
                        :rules="nameRules"
                        label="Password"
                        required
                        counter="15"
                        @click:append="show1 = !show1"
                    ></v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col cols="12" md="4">
                    <v-date-input clearable
                        v-model="nuevoJuego.director"
                        :rules="nameRules"
                        label="Birth Date"
                        required
                    ></v-date-input>
                </v-col>

                <v-col cols="12" md="4">
                    <v-text-field clearable
                        v-model="nuevoJuego.genre"
                        :rules="nameRules"
                        label="E-mail"
                        placeholder="E-Mail"
                        required
                    ></v-text-field>
                </v-col>

                <v-col cols="12" md="4">
                    <v-select
                        v-model="nuevoJuego.role"
                        :rules="nameRules"
                        label="Role"
                        :items="['admin', 'user']"
                        required
                    ></v-select>
                </v-col>
            </v-row>

            <v-row justify="end">
                <v-col cols="auto">
                    <button @click.prevent="addGame">Add Game</button>
                </v-col>
            </v-row>
        </v-container>
    </v-form>
</template>

<style scoped>
button { 
    padding: 10px; 
    margin: 5px; 
    background-color: var(--color-black); 
    color: #ffffff; 
    cursor: pointer; 
    font-size: 16px; 
    border-radius: 5px; 
    transition: background-color 0.3s, color 0.3s;
}
button:hover {
    color: var(--color-blue);
}
.custom-form {
    width: 100%;
}
.v-row {
    flex-wrap: wrap;
}
</style>
