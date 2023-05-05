<script setup lang="ts">
import ViewModelComponent from '@/components/ViewModelComponent.vue';
import { ref } from 'vue';
const title = ref('title');
const count = ref(10);
</script>

<template>
    <div
        class="flex flex-column flex-grow-1"
        style="border: 1px solid green; overflow: hidden auto"
    >
        In parent: Title: {{ title }} Count: {{ count }}
        <ViewModelComponent v-model:title="title" v-model:count="count"></ViewModelComponent>
    </div>
</template>
