<template>
    <div class="card">
        <img src="/src/assets/cyber_site.jpg" alt="Descripción de la imagen" class="card-image">
        <div class="card-content">
            <h2 class="card-title">Título</h2>
            <p class="card-subtitle">Subtítulo</p>
        </div>
        <button class="card-button">Botón</button>
    </div>
</template>
<style scoped>
.card {
    position: relative;
    display: flex;
    align-items: flex-start; /* Alinea los elementos a la parte superior */
    width: 700px;
    height: 200px;
    left: 20%;
    background-color: var(--color-black);
    border-radius: 20px;
    overflow: hidden; /* Oculta el botón si se desborda de la tarjeta */
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

.card-button {
    position: absolute; /* Posiciona el botón absolutamente */
    bottom: 20px; /* Ajusta la distancia desde la parte inferior */
    right: 20px; /* Ajusta la distancia desde la derecha */
    background-color: var(--color-blue); /* Ajusta el color del botón según tu preferencia */
    color: var(--color-white); /* Ajusta el color del texto del botón según tu preferencia */
    border: none;
    padding: 10px 20px; /* Ajusta según tu preferencia */
    border-radius: 5px; /* Ajusta según tu preferencia */
    cursor: pointer;
    outline: none;
    font-family: var(--font-roboto);
}
</style>
