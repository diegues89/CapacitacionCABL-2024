<script setup lang="ts">
//import TheWelcome from '../components/TheWelcome.vue'
import Menubar from 'primevue/menubar'
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()
const items = ref([
  {
    label: 'Home',
    icon: 'pi pi-home',
    command: () => {
      router.push('/')
    }
  },
  {
    label: 'Product',
    icon: 'pi pi-star',
    command: () => {
      router.push('/productos')
    }
  },

  {
    label: 'Contact',
    icon: 'pi pi-envelope'
  }
])
</script>

<template>
  <main>
    <div class="card">
      <Menubar :model="items" />
    </div>
  </main>
</template>
