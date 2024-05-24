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
    role: '',
    website: ''
});

const items = ref([
  "Afghanistan",
  "Albania",
  "Algeria",
  "Andorra",
  "Angola",
  "Antigua and Barbuda",
  "Argentina",
  "Armenia",
  "Australia",
  "Austria",
  "Austrian Empire*",
  "Azerbaijan",
  "Baden*",
  "Bahamas, The",
  "Bahrain",
  "Bangladesh",
  "Barbados",
  "Bavaria*",
  "Belarus",
  "Belgium",
  "Belize",
  "Benin (Dahomey)",
  "Bolivia",
  "Bosnia and Herzegovina",
  "Botswana",
  "Brazil",
  "Brunei",
  "Brunswick and Lüneburg*",
  "Bulgaria",
  "Burkina Faso (Upper Volta)",
  "Burma",
  "Burundi",
  "Cabo Verde",
  "Cambodia",
  "Cameroon",
  "Canada",
  "Cayman Islands, The",
  "Central African Republic",
  "Central American Federation*",
  "Chad",
  "Chile",
  "China",
  "Colombia",
  "Comoros",
  "Congo Free State, The*",
  "Costa Rica",
  "Cote d’Ivoire (Ivory Coast)",
  "Croatia",
  "Cuba",
  "Cyprus",
  "Czechia",
  "Czechoslovakia*",
  "Democratic Republic of the Congo",
  "Denmark",
  "Djibouti",
  "Dominica",
  "Dominican Republic",
  "Duchy of Parma, The*",
  "East Germany (German Democratic Republic)*",
  "Ecuador",
  "Egypt",
  "El Salvador",
  "Equatorial Guinea",
  "Eritrea",
  "Estonia",
  "Eswatini",
  "Ethiopia",
  "Federal Government of Germany (1848-49)*",
  "Fiji",
  "Finland",
  "France",
  "Gabon",
  "Gambia, The",
  "Georgia",
  "Germany",
  "Ghana",
  "Grand Duchy of Tuscany, The*",
  "Greece",
  "Grenada",
  "Guatemala",
  "Guinea",
  "Guinea-Bissau",
  "Guyana",
  "Haiti",
  "Hanover*",
  "Hanseatic Republics*",
  "Hawaii*",
  "Hesse*",
  "Holy See",
  "Honduras",
  "Hungary",
  "Iceland",
  "India",
  "Indonesia",
  "Iran",
  "Iraq",
  "Ireland",
  "Israel",
  "Italy",
  "Jamaica",
  "Japan",
  "Jordan",
  "Kazakhstan",
  "Kenya",
  "Kingdom of Serbia/Yugoslavia*",
  "Kiribati",
  "Korea",
  "Kosovo",
  "Kuwait",
  "Kyrgyzstan",
  "Laos",
  "Latvia",
  "Lebanon",
  "Lesotho",
  "Lew Chew (Loochoo)*",
  "Liberia",
  "Libya",
  "Liechtenstein",
  "Lithuania",
  "Luxembourg",
  "Madagascar",
  "Malawi",
  "Malaysia",
  "Maldives",
  "Mali",
  "Malta",
  "Marshall Islands",
  "Mauritania",
  "Mauritius",
  "Mecklenburg-Schwerin*",
  "Mecklenburg-Strelitz*",
  "Mexico",
  "Micronesia",
  "Moldova",
  "Monaco",
  "Mongolia",
  "Montenegro",
  "Morocco",
  "Mozambique",
  "Namibia",
  "Nassau*",
  "Nauru",
  "Nepal",
  "Netherlands, The",
  "New Zealand",
  "Nicaragua",
  "Niger",
  "Nigeria",
  "North German Confederation*",
  "North German Union*",
  "North Macedonia",
  "Norway",
  "Oldenburg*",
  "Oman",
  "Orange Free State*",
  "Pakistan",
  "Palau",
  "Panama",
  "Papal States*",
  "Papua New Guinea",
  "Paraguay",
  "Peru",
  "Philippines",
  "Piedmont-Sardinia*",
  "Poland",
  "Portugal",
  "Qatar",
  "Republic of Genoa*",
  "Republic of Korea (South Korea)",
  "Republic of the Congo",
  "Romania",
  "Russia",
  "Rwanda",
  "Saint Kitts and Nevis",
  "Saint Lucia",
  "Saint Vincent and the Grenadines",
  "Samoa",
  "San Marino",
  "Sao Tome and Principe",
  "Saudi Arabia",
  "Schaumburg-Lippe*",
  "Senegal",
  "Serbia",
  "Seychelles",
  "Sierra Leone",
  "Singapore",
  "Slovakia",
  "Slovenia",
  "Solomon Islands, The",
  "Somalia",
  "South Africa",
  "South Sudan",
  "Spain",
  "Sri Lanka",
  "Sudan",
  "Suriname",
  "Sweden",
  "Switzerland",
  "Syria",
  "Tajikistan",
  "Tanzania",
  "Texas*",
  "Thailand",
  "Timor-Leste",
  "Togo",
  "Tonga",
  "Trinidad and Tobago",
  "Tunisia",
  "Turkey",
  "Turkmenistan",
  "Tuvalu",
  "Two Sicilies*",
  "Uganda",
  "Ukraine",
  "Union of Soviet Socialist Republics*",
  "United Arab Emirates, The",
  "United Kingdom, The",
  "Uruguay",
  "Uzbekistan",
  "Vanuatu",
  "Venezuela",
  "Vietnam",
  "Württemberg*",
  "Yemen",
  "Zambia",
  "Zimbabwe"
]);

function addStudio() {
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
                        label="E-mail Login"
                        placeholder="admin@tstudios.com"
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
                        label="Date-Fundation"
                        required
                    ></v-date-input>
                </v-col>

                <v-col cols="12" md="4">
                    <v-text-field clearable
                        v-model="nuevoJuego.genre"
                        :rules="nameRules"
                        label="E-mail Contact"
                        placeholder="tstudios@gmail.com"
                        required
                    ></v-text-field>
                </v-col>

                <v-col cols="12" md="4">
                    <v-select
                        v-model="nuevoJuego.role"
                        :rules="nameRules"
                        label="Country"
                        :items="items"
                        required
                    ></v-select>
                </v-col>
            </v-row>
            <v-row justify="end">
                <v-text-field clearable
                        v-model="nuevoJuego.website"
                        :rules="nameRules"
                        label="Website"
                        placeholder="https://tstudios.com"
                        required
                    ></v-text-field>
            </v-row>

            <v-row justify="end">
                <v-col cols="auto">
                    <button @click.prevent="addStudio">Add Studio</button>
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
