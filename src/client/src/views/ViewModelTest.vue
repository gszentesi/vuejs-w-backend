<script setup>
import { ref } from 'vue';
const display = ref('alma');
</script>

<template>
    <div
        class="flex flex-column flex-grow-1"
        style="border: 1px solid green; overflow: hidden auto"
    >
        In parent: {{ display }}
        <ViewModel v-model:display="display"></ViewModel>
    </div>
</template>
