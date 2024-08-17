<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavView from './views/NavView.vue'
</script>

<template>
  <div>
    <nav class="sticky-nav"><NavView /></nav>

    <main class="main-content"><RouterView /></main>

    <footer class="sticky-footer">
      <h1>Este es el footer</h1>
    </footer>
  </div>
</template>

<style scoped>
.app-container {
  display: flex;
  flex-direction: column;
  min-height: 100vh; /* Asegura que la altura sea al menos la del viewport */
}

.main-content {
  flex-grow: 1; /* Hace que el contenido principal ocupe todo el espacio disponible */
  padding: 20px; /* Añade un espacio de relleno si lo deseas */
}
.sticky-nav {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  background-color: #ffffff; /* Cambia esto al color deseado */
  z-index: 100; /* Asegura que el nav esté por encima de otros elementos */
  /* Otros estilos según tus necesidades */
}
.sticky-footer {
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100%;
  background-color: #f9f9f9; /* Cambia esto al color deseado */
  z-index: 100; /* Asegura que el footer esté por encima de otros elementos */
  /* Otros estilos según tus necesidades */
}
</style>
