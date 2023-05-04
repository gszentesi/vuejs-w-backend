<script setup lang="ts">
import type { IData } from '@/components/Data.vue';
import { ref } from 'vue';

const td = ref({ text: 'alma', count: 10 } as IData);

const update = (incoming: IData) => {
    td.value.text = incoming.text;
    td.value.count = incoming.count;
};
</script>

<template>
    <div
        class="flex flex-column flex-grow-1 flex-shrink-1"
        style="border: 1px solid green; overflow: hidden auto"
    >
        <InputText :value="td.text" @change="td.text = ($event.target as any).value" />
        <div class="flex">Text: {{ td.text }}</div>
        <div class="flex">Count: {{ td.count }}</div>

        <Data :data="td" @update="update"></Data>
    </div>
</template>
