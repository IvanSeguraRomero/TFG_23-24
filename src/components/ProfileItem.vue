<template>
    <div class="card">
        <img src="/src/assets/cyber_site.jpg" alt="Descripción de la imagen" class="card-image">
        <div class="card-content">
            <div class="card-column">
                <div class="card-username">
                    <p class="username-title">Username</p>
                    <h2 class="username-subtitle">HelloKitty2000</h2>
                </div>
                <div class="card-name">
                    <p class="name-title">Name</p>
                    <h2 class="name-subtitle">Gustavo Hernandez</h2>
                </div>
            </div>
            <div class="card-column">
                <div class="card-email">
                    <p class="email-title">Email</p>
                    <h2 class="email-subtitle">gustavo2000@gmail.com</h2>
                </div>
                <div class="card-phone">
                    <p class="phone-title">Password</p>
                    <h2 class="phone-subtitle">Contraseña</h2>
                </div>
            </div>
        </div>
        <button class="card-button">Cambiar Datos</button>
    </div>
</template>
<style scoped>
.card {
    position: relative;
    display: flex;
    align-items: flex-start; /* Alinea los elementos a la parte superior */
    width: 80%;
    height: 250px;
    left: 10%;
    margin-top: 10%;
    background: linear-gradient(to right, var(--color-black), var(--color-dark-blue), var(--color-blue));
    border-radius: 20px;
    overflow: hidden; /* Oculta el botón si se desborda de la tarjeta */
}

.card-image {
    width: 20%; /* Ajusta el ancho de la imagen según tu preferencia */
    height: 60%;
    border-radius: 20px;
    margin-left: 3%;
    margin-top: 3%;
}

.card-content {
    display: flex;
    flex-direction: row; /* Coloca los elementos en una fila */
    justify-content: space-between; /* Distribuye espacio equitativamente */
    padding: 20px;
    flex-grow: 1; /* Permite que el contenedor crezca para ocupar el espacio disponible */
}

.card-column {
    display: flex;
    flex-direction: column; /* Coloca los elementos en una columna */
    justify-content: space-between;
    margin-right: 20px; /* Añade espacio entre las dos columnas */
}

.username-title,
.name-title,
.email-title,
.phone-title {
    margin-top: 20px;
    color: var(--color-gray);
    font-family: var(--font-orbitron);
}

.username-subtitle,
.name-subtitle,
.email-subtitle,
.phone-subtitle {
    margin: 0;
    color: var(--neutral-colors-white);
    font-family: var(--font-archivo-black);
}

.card-button {
    position: absolute; /* Posiciona el botón absolutamente */
    bottom: 20px; /* Ajusta la distancia desde la parte inferior */
    right: 20px; /* Ajusta la distancia desde la derecha */
    background-color: var(--color-black); /* Ajusta el color del botón según tu preferencia */
    color: var(--neutral-colors-white); /* Ajusta el color del texto del botón según tu preferencia */
    border: none;
    padding: 10px 20px; /* Ajusta según tu preferencia */
    border-radius: 5px; /* Ajusta según tu preferencia */
    cursor: pointer;
    outline: none;
    font-family: var(--font-roboto);
}
</style>
