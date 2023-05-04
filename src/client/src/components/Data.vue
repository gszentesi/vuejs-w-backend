<script setup lang="ts">
export interface IData {
    text: string;
    count: number;
}

const props = defineProps<{ data: IData }>();
const emits = defineEmits<{
    (e: 'update', data: IData): void;
}>();

const onUpdateText = (tx: string) => {
    props.data.text = tx;
    fireEmit();
};

const onUpdateCount = (cnt: string) => {
    props.data.count = Number(cnt);
    fireEmit();
};

const fireEmit = () => {
    emits('update', props.data);
};
</script>

<template>
    <div class="flex flex-column" style="border: 1px solid green; overflow: hidden auto">
        <h1>Data component</h1>
        <label for="text">Text</label>
        <InputText
            id="text"
            type="text"
            :value="data?.text"
            @change="onUpdateText(($event.target as any).value)"
        />
        <label for="count">Count</label>
        <InputText
            id="count"
            type="text"
            :value="data?.count"
            @change="onUpdateCount(($event.target as any).value)"
        />
    </div>
</template>
