<script setup lang="ts">
import type { IComplexModel } from '@/components/ViewModelComplexComponent.vue';
import { ref } from 'vue';

const md = ref({
    title: 'title',
    count: 10
} as IComplexModel);
</script>

<template>
    <div
        class="flex flex-column flex-grow-1"
        style="border: 1px solid green; overflow: hidden auto"
    >
        In parent: Title: {{ md.title }} Count: {{ md.count }}
        <ViewModelComplexComponent
            v-model:title="md.title"
            v-model:count="md.count"
        ></ViewModelComplexComponent>
    </div>
</template>
