<script setup lang="ts">
import { ref } from 'vue';
import draggable from 'vuedraggable';

const meals = ref([
    { name: 'Bat wing soup', index: 0 },
    { name: 'Spicy Octopus', index: 1 },
    { name: 'Chicken wings', index: 1 },
    { name: 'Anything from Taco Bell', index: 2 }
]);

const onEnd = (e: any) => {
    let index = 0;
    meals.value.forEach((m) => {
        m.index = index++;
    });
};

const add = () => {
    var index = meals.value.length - 1;
    var count = meals.value.filter((i) => i.name.startsWith('Added')).length;
    meals.value.push({ name: `Added: ${count + 1}`, index: index });
};
</script>

<template>
    <div class="flex-column">
        <h1>Terrible Foods</h1>
        <Button @click="add()">Add</Button>
        <draggable v-model="meals" item-key="name" @end="onEnd">
            <template #item="{ element }">
                <div class="flex-row" style="cursor: pointer">
                    <font-awesome-icon icon="fa-solid fa-grip-lines" />
                    {{ element.name }}
                </div>
            </template>
        </draggable>

        <pre
            >{{ JSON.stringify(meals, null, 2) }}
        </pre>
    </div>
</template>
