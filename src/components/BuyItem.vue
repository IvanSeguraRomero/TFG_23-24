<template>
    <div class="buy-section">
      <div class="buy-container">
        <h1>Buy Forza Horizon 5</h1>
      </div>
        <div class="purchase-info">
          <div class="price">40€</div>
          <button class="cart">Add To Cart</button>
        </div>
      
    </div>
  </template>
  
  <style scoped>
  .buy-section {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    padding: 10px;
    width: 100%;
  }
  
  .buy-container {
    width: 100%;
    background-color: var(--color-blue);
    height: 130px;
    padding: 20px;
    font-family: var(--font-archivo-black);
  }
  
  .purchase-info {
    display: flex;
    justify-content: flex-end; /* Alinea los elementos al final (derecha) */
    align-items: center;
    width: 100%; /* Extiende el contenedor a lo largo de toda la sección */
    margin-top: -10px;
    margin-right: 10px;
  }
  
  .price{
    width:max-content;
    padding: 10px;
    border: solid 2px var(--color-black);
    background-color: var(--color-dark-blue);
    color: var(--neutral-colors-white);
    font-family: var(--font-roboto);
  }
  
  .cart {
    background-color: var(--color-yellow);
    padding: 10px;
    color: var(--color-black);
    border: solid 2px var(--color-black);
    margin-right: 20px;
    font-family: var(--font-roboto);
  }
  </style>
  