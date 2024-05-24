<script setup lang="ts">
import { ref } from 'vue';

const search = ref('');
const headers = ref([{
    key: 'name',
    title: 'Name',
    align: 'start',
    sortable: false
    
},
    {key: 'email-login', title: 'E-Mail Login'},
    {key: 'email-contact', title: 'E-Mail Contact'},
    {key: 'password', title: 'Password'},
    {key: 'country', title: 'Country'},
    {key: 'website', title: 'Website'}])

    //Ejemplo del array a meter - desserts
    const desserts = ref([
    {
        name: 'Chocolate Cake',
        'email-login': 'choco@example.com',
        'email-contact': 'contact@choco.com',
        password: 'choco123',
        country: 'USA',
        website: 'www.choco.com'
    },
    {
        name: 'Lemon Tart',
        'email-login': 'lemon@example.com',
        'email-contact': 'contact@lemon.com',
        password: 'lemon123',
        country: 'France',
        website: 'www.lemon.com'
    },
    {
        name: 'Apple Pie',
        'email-login': 'apple@example.com',
        'email-contact': 'contact@apple.com',
        password: 'apple123',
        country: 'UK',
        website: 'www.apple.com'
    }
]);

</script>
<template>
    <v-card
      flat
    >
    <template v-slot:title>
      <span style="font-weight: bold; text-decoration: underline;">Games</span>
    </template>
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