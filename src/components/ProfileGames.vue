<template>
    <div class="card">
        <img src="/src/assets/cyber_site.jpg" alt="Descripción de la imagen" class="card-image">
        <div class="card-content">
            <h2 class="card-title">Título</h2>
            <p class="card-subtitle">Subtítulo</p>
        </div>
        <p class="last-session">Last Session: 10 APR</p>
        <p class="hours-played">Hours Played: 400h</p>
    </div>
</template>
<style scoped>
.card {
    position: relative;
    display: flex;
    align-items: flex-start; /* Alinea los elementos a la parte superior */
    width: 700px;
    height: 200px;
    left: 5%;
    margin-top:5%;
    background-color: var(--color-black);
    border-radius: 20px;
    overflow: hidden; /* Oculta el botón si se desborda de la tarjeta */
    margin-bottom: 20px;
}

.card-image {
    width: 40%; /* Ajusta el ancho de la imagen según tu preferencia */
    border-radius: 20px;
    margin-left: 3%;
    margin-top: 3%;
}

.card-content {
    flex-grow: 1; /* Para que ocupe el espacio restante */
    padding: 20px; /* Ajusta según tu preferencia */
}

.card-title {
    margin-bottom: 5px; /* Ajusta según tu preferencia */
    color: var(--neutral-colors-white); /* Ajusta el color del texto según tu preferencia */
    font-family: var(--font-archivo-black);
    margin-top: 0; /* Elimina el margen superior del título */
}

.card-subtitle {
    margin-bottom: 10px; /* Ajusta según tu preferencia */
    font-size: 14px; /* Ajusta el tamaño del texto según tu preferencia */
    color: var(--neutral-colors-white); /* Ajusta el color del texto según tu preferencia */
    font-family: var(--font-orbitron);
    padding: 10px;
    width: min-content;
    background-color: var(--color-dark-blue);
    box-shadow: 5px 5px 10px 0 var(--color-blue); 
}

.last-session {
    position: absolute; /* Posiciona el texto absolutamente */
    bottom: 10px; /* Ajusta la distancia desde la parte inferior */
    right: 20px; /* Ajusta la distancia desde la derecha */
    color: var(--color-gray); /* Ajusta el color del texto según tu preferencia */
    font-family: var(--font-roboto);
    padding: 10px;
}
.hours-played {
    position: absolute; /* Posiciona el texto absolutamente */
    bottom: 10px; /* Ajusta la distancia desde la parte inferior */
    left: 310px;
    color: var(--color-gray); /* Ajusta el color del texto según tu preferencia */
    font-family: var(--font-roboto);
    padding: 10px;
}
</style>