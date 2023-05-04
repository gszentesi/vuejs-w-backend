<script setup lang="ts">
import { ref } from 'vue';

const text = ref('szilva');
const count = ref(80);
</script>

<template>
    <div
        class="flex flex-column flex-grow-1 flex-shrink-1"
        style="border: 1px solid green; overflow: hidden auto"
    >
        <div class="flex">Text: {{ text }}</div>
        <div class="flex">Count: {{ count }}</div>

        <DataSimple
            :text="text"
            :count="count"
            @textChanged="text = $event"
            @countChanged="count = $event"
        ></DataSimple>
    </div>
</template>
