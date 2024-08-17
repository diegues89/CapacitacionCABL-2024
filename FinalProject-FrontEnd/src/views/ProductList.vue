<template>
  <div>
    <div class="card">
      <Toolbar class="mb-6">
        <template #start>
          <Button
            label="Agregar Producto"
            icon="pi pi-plus"
            severity="success"
            class="mr-2"
            @click="productDialog = true"
          />
        </template>
      </Toolbar>
      <DataTable :value="products" tableStyle="min-width: 50rem">
        <template #header>
          <div class="flex flex-wrap gap-2 items-center justify-between">
            <h4 class="m-0">Administrar Productos</h4>
          </div>
        </template>
        <Column field="idProduct" header="Id"></Column>
        <Column field="descriptionProduct" header="Descripcion"></Column>
        <Column field="stockQuantity" header="Stock"></Column>
        <Column field="category" header="Categoria"></Column>
        <Column field="supplierName" header="Proveedor"></Column>

        <Column :exportable="false" style="min-width: 12rem">
          <template #body="slotProps">
            <Button
              icon="pi pi-pencil"
              outlined
              rounded
              class="mr-2"
              @click="editProduct(slotProps.data)"
            />
            <Button
              icon="pi pi-trash"
              outlined
              rounded
              severity="danger"
              @click="confirmDeleteProduct(slotProps.data)"
            />
          </template>
        </Column>
      </DataTable>
    </div>

    <Dialog
      v-model:visible="productDialog"
      :style="{ width: '450px' }"
      header="Product Details"
      :modal="true"
    >
      <div class="flex flex-col gap-6">
        <div>
          <label for="InputdescriptionProduct" class="block font-bold mb-3"
            >Descripcion Producto</label
          >
          <InputText
            id="InputdescriptionProduct"
            v-model.trim="product.descriptionProduct"
            required="true"
            autofocus
            fluid
          />
        </div>
        <div>
          <label for="inputstockQuantity" class="block font-bold mb-3">Stock</label>
          <InputNumber
            v-model="product.stockQuantity"
            inputId="inputstockQuantity"
            mode="decimal"
            showButtons
            :min="0"
            fluid
          />
        </div>
        <div>
          <label for="selectSuppliers" class="block font-bold mb-3">Proveedor</label>
          <Select
            v-model="selectedSupplier"
            id="selectSuppliers"
            :options="suppliers"
            optionLabel="name"
            placeholder="Seleccione Proveedor"
            class="w-full md:w-56"
            fluid
          />
        </div>
        <div>
          <label for="selectCategory" class="block font-bold mb-3">Categoria</label>
          <Select
            v-model="selectproductCategories"
            id="selectCategory"
            :options="productCategories"
            optionLabel="descriptionCategory"
            placeholder="Seleccione Categoria"
            class="w-full md:w-56"
            fluid
          />
        </div>
      </div>
      <template #footer>
        <Button label="Cancel" icon="pi pi-times" @click="productDialog = false" />
        <Button label="Save" icon="pi pi-check" @click="saveProduct" />
      </template>
    </Dialog>

    <Dialog
      v-model:visible="deleteProductsDialog"
      :style="{ width: '450px' }"
      header="Confirm"
      :modal="true"
    >
      <div class="flex items-center gap-4">
        <i class="pi pi-exclamation-triangle !text-3xl" />
        <span>Esta seguro que desea eliminar el producto {{ product?.descriptionProduct }} ?</span>
      </div>
      <template #footer>
        <Button label="Yes" icon="pi pi-check" text @click="deleteSelectedProducts" />
        <Button label="No" icon="pi pi-times" text @click="deleteProductsDialog = false" />
      </template>
    </Dialog>
  </div>
  <div class="card flex justify-center">
    <Toast position="bottom-right" group="br" />
  </div>
</template>

<script setup lang="ts">
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import { onMounted, ref } from 'vue'
import { useFetch } from '@vueuse/core'
import type { ProductDto } from '../models/produc-dto'
import type { Product } from '@/models/product'
import type { SupplierDto } from '@/models/SupplierDto'
import type { CategoryProductDto } from '@/models/CategoryProductDto'
import Dialog from 'primevue/dialog'
import Button from 'primevue/button'
import 'primeicons/primeicons.css'
import Toolbar from 'primevue/toolbar'
import InputText from 'primevue/inputtext'
import InputNumber from 'primevue/inputnumber'
import Select from 'primevue/select'
//import Message from 'primevue/message'
//import type internal from 'stream'
import { useToast } from 'primevue/usetoast'
import Toast from 'primevue/toast'

const toast = useToast()
const product = ref<CreateProduct>({}) //ref<Product>()
const products = ref<ProductDto[]>([])
const deleteProductsDialog = ref(false)
const productDialog = ref(false)
const suppliers = ref<SupplierDto[]>([])
const productCategories = ref<CategoryProductDto[]>([])
const selectedSupplier = ref()
const selectproductCategories = ref()

const getProductList = async () => {
  const { data } = await useFetch('https://localhost:44376/api/Products')
    .get()
    .json<GetProductListResponse>()
  products.value = data.value != null ? data.value.productsList : []
}
const getSuppliersList = async () => {
  const { data } = await useFetch('https://localhost:44376/api/Suppliers')
    .get()
    .json<SuppliersListResponse>()
  suppliers.value = data.value != null ? data.value.suppliersList : []
}
const getProductCategoryList = async () => {
  const { data } = await useFetch('https://localhost:44376/api/ProductCategory')
    .get()
    .json<CategoryProductListResponse>()
  productCategories.value = data.value != null ? data.value.productCategoryList : []
}
const confirmDeleteProduct = (prod: Product) => {
  product.value = prod
  deleteProductsDialog.value = true
  console.log(prod.idProduct)
}
const deleteSelectedProducts = async () => {
  let response = await useFetch(
    'https://localhost:44376/api/Products' + '/' + product.value?.idProduct
  ).delete()
  deleteProductsDialog.value = false
  console.log(response.statusCode.value)
  if (response.statusCode.value == 200) {
    showDeleteOK()
  }
  await getProductList()
}

const editProduct = (prod: Product) => {
  product.value = { ...prod }
  productDialog.value = true
  console.log(product.value.idProduct)
}

const saveProduct = () => {
  product.value.idSupplier = selectedSupplier.value.idSupplier
  product.value.idCategory = selectproductCategories.value.idCategory
  createProduct(product.value)
  productDialog.value = false
}
const showCreateOK = () => {
  toast.add({
    severity: 'success',
    summary: 'Se cargo correctamente el producto',
    group: 'br',
    life: 3000
  })
}
const showDeleteOK = () => {
  toast.add({
    severity: 'success',
    summary: 'Se borro correctamente',
    group: 'br',
    life: 3000
  })
}
const createProduct = async (prod: CreateProduct) => {
  const response = await useFetch('https://localhost:44376/api/Products').post(prod)
  if (response.statusCode.value == 200) {
    showCreateOK()
  }
  await getProductList()
}

onMounted(async () => {
  await getProductList()
  await getSuppliersList()
  await getProductCategoryList()
})

interface GetProductListResponse {
  productsList: ProductDto[]
}
interface SuppliersListResponse {
  suppliersList: SupplierDto[]
}
interface CategoryProductListResponse {
  productCategoryList: CategoryProductDto[]
}
interface CreateProduct {
  idProduct?: number
  descriptionProduct?: string
  stockQuantity?: number
  idCategory?: number
  idSupplier?: number
}
</script>

<style scoped></style>
