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
    <tr>
      <td>id</td>
      <td>name</td>
      <td>
        <button>Update</button>
        <button>Delete</button>
      </td>
    </tr>
  </table>
</template>

<script setup lang="ts"></script>

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
