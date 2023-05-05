<script setup lang="ts">
defineProps<{ title: string; count: number }>();
</script>

<template>
    <div>
        <h1>View Model test</h1>
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
