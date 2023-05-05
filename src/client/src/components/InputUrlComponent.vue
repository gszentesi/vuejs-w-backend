<script setup lang="ts">
import { ref } from 'vue';
import { inject } from 'vue';

const url = ref('');

const dialogRef = inject('dialogRef');

const okClick = (data: any) => {
    (dialogRef as any).value.close(data);
};
</script>

<template>
    <div class="flex flex-column gap-4">
        <InputText :value="url" @input="url = ($event.target as any).value" />
        <div class="flex justify-content-end">
            <Button
                type="button"
                label="Ok"
                icon="pi pi-check"
                @click="okClick({ buttonType: 'Yes', url: url })"
                autofocus
            ></Button>
        </div>
    </div>
</template>
