<template>
    <div class="centerBlock">
        <div class="bloque">
            <div class="principal">
                <img src="/src/assets/cyber_site.jpg" alt="" class="imgPrn">
                <p class="category">Categoria</p>
                <p class="price">Price: 40€</p>
            </div>
            <div class="grid">
                <div class="grid-item">
                    <img src="/src/assets/cyber_site.jpg" alt="" class="imgMin">
                    <p class="price-min">Price: 40€</p>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .centerBlock{
        display: flex;
        justify-content: center;
        align-items: center;
        padding: 50px;

    }
    .bloque{
        display: grid;
        grid-template-columns: 1fr 1fr; /* Dos columnas de igual ancho */
        gap: 10px; /* Espacio entre las columnas */
        width: 900px;
        height: 450px;
    }
    .principal{
        display: flex;
        width: 100%;
        height: 100%;
        background-color: var(--color-blue);
        
    }
    .grid{
        display: grid;
        grid-template-columns: 1fr 1fr; /* Dos columnas de igual ancho */
        grid-template-rows: 1fr 1fr; /* Dos filas de igual alto */
        width: 100%;
        height: 100%;
        background-color: var(--color-yellow);
    }
    .grid-item {
        display: flex;
        background-color: var(--color-black);
        color: var(--color-black);
        font-size: 18px;    
        margin: 10px;
    }
    .imgPrn{
        position: relative;
        top: 23%;
        left: 7%;
        width: 52%;
        height: 70%;
    }
    .imgMin{
        position: relative;
        top: 23%;
        left: 7%;
        width: 52%;
        height: 70%;
    }
    .category{
        position: relative;
        display: flex;
        text-align: center;
        align-items: center;
        left: 11%;
        top: 23%;
        font-family: var(--font-orbitron);
        background-color: var(--color-black);
        color: var(--neutral-colors-white);
        padding: 30px;
        height: 40px;
    }
    .price{
        position: relative;
        display: flex;
        text-align: center;
        align-items: center;
        top: 80%;
        right: 22%;
        font-family: var(--font-orbitron);
        background-color: var(--color-black);
        color: var(--neutral-colors-white);
        white-space: nowrap;
        padding: 30px;
        height: 40px;
    }
    .price-min{
        position: relative;
        display: flex;
        text-align: center;
        align-items: center;
        top: 69%;
        right: 1%;
        font-family: var(--font-orbitron);
        background-color: var(--color-blue);
        color: var(--color-black);
        padding: 30px;
        height: 40px;
        transform: scale(0.6);
    }
</style>