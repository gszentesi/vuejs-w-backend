<script setup lang="ts">
defineProps<{ display: string }>();
</script>

<template>
    <div>
        <h1>View Model test</h1>
        <InputText
            :value="display"
            @input="$emit('update:display', ($event.target as any).value)"
        />
        {{ display }}
    </div>
</template>
