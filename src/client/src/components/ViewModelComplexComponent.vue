<script setup lang="ts">
export interface IComplexModel {
    title: string;
    count: number;
}

defineProps<{ title: string; count: number }>();
defineEmits(['update:title', 'update:count']);
</script>

<template>
    <div>
        <h1>View Model Complex</h1>
        <InputText :value="title" @input="$emit('update:title', ($event.target as any).value)" />
        <InputText
            type="number"
            :value="count"
            @input="$emit('update:count', Number(($event.target as any).value))"
        />
        {{ title }}
        {{ count }}
    </div>
</template>
