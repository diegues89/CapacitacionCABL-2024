<template>
  <div>
    <DataTable :value="products" tableStyle="min-width: 50rem">
      <Column field="idProduct" header="Id"></Column>
      <Column field="descriptionProduct" header="Descripcion"></Column>
      <Column field="stockQuantity" header="Stock"></Column>
      <Column field="category" header="Categoria"></Column>
      <Column field="supplierName" header="Proveedor"></Column>
    </DataTable>
  </div>
</template>

<script setup lang="ts">
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import { onMounted, ref } from 'vue'
import { useFetch } from '@vueuse/core'
import type { ProductDto } from '../models/produc-dto'

const products = ref<ProductDto[]>([])

const getProductList = async () => {
  const { data } = await useFetch('https://localhost:44376/api/Products')
    .get()
    .json<GetProductListResponse>()
  products.value = data.value != null ? data.value.productsList : []
}

onMounted(async () => {
  await getProductList()
})

interface GetProductListResponse {
  productsList: ProductDto[]
}
</script>

<style scoped></style>
