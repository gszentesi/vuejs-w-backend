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
        <h1>Data stored on Simple View</h1>
        <InputText :value="text" @change="text = ($event.target as any).value" />
        <InputText :value="count" @change="count = Number(($event.target as any).value)" />

        <DataSimple
            :text="text"
            :count="count"
            @textChanged="text = $event"
            @countChanged="count = $event"
        ></DataSimple>
    </div>
</template>
