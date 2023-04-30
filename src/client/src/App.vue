<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
    <div class="flex" style="border: 1px solid blue">HEADER</div>

    <div class="flex flex-row flex-grow-1 flex-grow-0" style="overflow: hidden">
        <div
            class="flex flex-column flex-shrink-1 overflow-auto"
            style="border: 1px solid purple; min-width: 300px"
        >
            <router-link to="/">Test</router-link>
            <router-link to="/other">Grid</router-link>
            <router-link to="/table">Table</router-link>
        </div>
        <div class="flex flex-shrink-1 flex-grow-1" style="border: 1px solid magenta">
            <RouterView />
        </div>
    </div>

    <div class="flex" style="border: 1px solid orange">FOOTER</div>
</template>

<style scoped>
div {
    margin: 0.1rem;
}
</style>
