<template>
  <div class="mb-1">
    <button>Create</button>
  </div>
  <table>
    <tr>
      <th>#</th>
      <th>Name</th>
      <th></th>
    </tr>
    <tr v-for="user in userList" :key="user.id">
      <td>{{ user.id }}</td>
      <td>{{ user.firstName }}</td>
      <td>
        <button>Update</button>
        <button>Delete</button>
      </td>
    </tr>
  </table>
</template>

<script setup lang="ts">
import type { UserDto } from '@/models/user-dto'
import { useFetch } from '@vueuse/core'
import { onMounted, ref } from 'vue'

const userList = ref<UserDto[]>([])

const getUserList = async () => {
  const { data } = await useFetch('https://localhost:44376/api/Users')
    .get()
    .json<GetUserListResponse>()
  userList.value = data.value != null ? data.value.userList : []
}

onMounted(async () => {
  await getUserList()
})

interface GetUserListResponse {
  userList: UserDto[]
}
</script>

<style scoped>
.mb-1 {
  margin-bottom: 1rem;
}

table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td,
th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

td > button:last-child {
  margin-left: 5px;
}
</style>
