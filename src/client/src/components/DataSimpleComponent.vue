<script setup lang="ts">
const props = defineProps<{ text: string; count: number }>();

const emits = defineEmits<{
    (e: 'textChanged', text: string): void;
    (e: 'countChanged', count: number): void;
}>();
</script>

<template>
    <div class="flex flex-column" style="border: 1px solid green; overflow: hidden auto">
        <h1>Simple Data component</h1>
        <label for="text">Text</label>
        <InputText
            id="text"
            type="text"
            :value="props.text"
            @change="emits('textChanged', ($event.target as any).value)"
        />
        <label for="count">Count</label>
        <InputText
            type="number"
            id="count"
            :value="props.count"
            @change="emits('countChanged', Number(($event.target as any).value))"
        />
    </div>
</template>
