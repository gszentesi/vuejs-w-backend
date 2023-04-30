<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
    <div class="flex flex-column gap-2 md:flex-row">
        <RouterView />
        <RouterView />
    </div>
</template>
