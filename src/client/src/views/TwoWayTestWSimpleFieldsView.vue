<script setup lang="ts">
import DataSimpleComponent from '@/components/DataSimpleComponent.vue';
import { ref } from 'vue';

const text = ref('szilva');
const count = ref(80);
</script>

<template>
    <div
        class="flex flex-column flex-grow-1 flex-shrink-1 gap-2"
        style="border: 1px solid green; overflow: hidden auto"
    >
        <div class="flex flex-column">
            <h1>Data stored on Simple View</h1>
            <InputText :value="text" @change="text = ($event.target as any).value" />
            <InputText :value="count" @change="count = Number(($event.target as any).value)" />
        </div>
        <DataSimpleComponent
            :text="text"
            :count="count"
            @textChanged="text = $event"
            @countChanged="count = $event"
        ></DataSimpleComponent>
    </div>
</template>
