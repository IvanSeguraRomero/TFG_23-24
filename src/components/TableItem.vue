<script setup lang="ts">
import { ref } from 'vue';

const search = ref('');
const headers = ref([{
    key: 'name',
    title: 'Name',
    align: 'start',
    sortable: false
    
},
    {key: 'username', title: 'Username'},
    {key: 'password', title: 'Password'},
    {key: 'email', title: 'E-mail'},
    {key: 'role', title: 'Role'}])

    //Ejemplo del array a meter
    const desserts = ref([
        { name: 'Frozen Yogurt', username: 'User1', password: 'pass1', email:'user1@example.com',  role: 'admin' },
        { name: 'Ice Cream Sandwich', username: 'User2', password: 'pass2', email:'user1@example.com', role: 'user' }
    ]);

</script>
<template>
    <v-card
      title="Nutrition"
      flat
    >
      <template v-slot:text>
        <v-text-field
          v-model="search"
          label="Search"
          prepend-inner-icon="mdi-magnify"
          variant="outlined"
          hide-details
          single-line
        ></v-text-field>
      </template>
  
      <v-data-table
        :headers="headers"
        :items="desserts"
        :search="search"
      ></v-data-table>
    </v-card>
  </template>