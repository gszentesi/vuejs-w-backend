<script setup lang="ts">
import { initCustomFormatter, reactive, ref } from 'vue'

export interface ResizeItem {
    selected: boolean
    size: string
}

const items = ref([
    { selected: false, size: '8px' },
    { selected: false, size: '10px' },
    { selected: false, size: '12px' },
    { selected: true, size: '14px' },
    { selected: false, size: '16px' }
] as ResizeItem[])

const inc = () => {
    let last = items.value.filter((i) => i.selected)[0]
    let index = items.value.indexOf(last)

    if (index < 4) {
        last.selected = false
        items.value[index + 1].selected = true
        onChanged(items.value[index + 1])
    }
}

const dec = () => {
    let last = items.value.filter((i) => i.selected)[0]
    let index = items.value.indexOf(last)

    if (index > 0) {
        last.selected = false
        items.value[index - 1].selected = true
        onChanged(items.value[index - 1])
    }
}

const onChanged = (item: ResizeItem) => {
    emit('changed', item)
}

const emit = defineEmits<{
    (e: 'changed', item: ResizeItem): void
}>()
</script>

<template>
    <div class="flex align-items-center gap-2">
        <button
            class="p-button p-component p-button-icon-only p-button-rounded p-button-text w-2rem h-2rem"
            type="button"
            @click="dec()"
        >
            <span class="p-button-icon pi pi-minus"></span>
            <span class="p-button-label">&nbsp;</span>
            <span class="p-ink" role="presentation" aria-hidden="true"></span>
        </button>
        <i
            v-for="item in items"
            class="pi pi-circle-fill text-600"
            :class="item.selected ? ['text-lg', 'text-primary'] : 'text-sm'"
        ></i>
        <button
            class="p-button p-component p-button-icon-only p-button-rounded p-button-text w-2rem h-2rem"
            type="button"
            @click="inc()"
        >
            <span class="p-button-icon pi pi-plus"></span>
            <span class="p-button-label">&nbsp;</span>
            <span class="p-ink" role="presentation" aria-hidden="true"></span>
        </button>
    </div>
</template>

<style scoped></style>
