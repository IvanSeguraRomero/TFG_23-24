<script setup lang="ts">
import ProfileItem from '../components/ProfileItem.vue';
import ProfileGames from '../components/ProfileGames.vue';
import Comments from '../components/ProfileComments.vue';
</script>
<template>
    <ProfileItem />
    <div class="container">
        <div class="left-section">
            <h1>Last Bought Games</h1>
            <hr class="line" />
            <ProfileGames />
        </div>
        <div class="right-section">
            <h1>Comments</h1>
            <hr class="line" />
            <Comments />
        </div>
    </div>
</template>

<style scoped>
.container {
    display: flex;
    justify-content: space-between;
    margin: 0 5%;
}

.left-section {
    flex: 3; /* Da más espacio a la sección izquierda */
}

.right-section {
    flex: 1; /* Da menos espacio a la sección derecha */
    margin-left: 5%;
    margin-top: 4.7%;
}

h1 {
    margin-top: 10%;
}

hr {
    width: 100%;
    border-color: #000;
}

.left-section hr,
.left-section h1 {
    margin-left: 0;
}

.right-section hr,
.right-section h1 {
    margin-right: 0;
    text-align: left;
}
</style>
