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
        class="flex flex-column flex-grow-1 flex-shrink-1 gap-2"
        style="border: 1px solid green; overflow: hidden auto"
    >
        <div class="flex flex-column">
            <h1>Data stored on View</h1>
            <InputText :value="td.text" @change="td.text = ($event.target as any).value" />
            <InputText
                :value="td.count"
                @change="td.count = Number(($event.target as any).value)"
            />
        </div>

        <Data :data="td" @update="update"></Data>
    </div>
</template>
