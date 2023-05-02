<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink, RouterView } from 'vue-router'

const isHidden = ref(false)
</script>

<template>
    <div class="flex gap-1 align-items-center">
        <Button severity="secondary" outlined size="small" @click="isHidden = !isHidden"
            ><i class="pi pi-bars" style="font-size: 1rem"></i
        ></Button>
        HEADER
    </div>

    <div class="flex flex-row flex-grow-1 flex-grow-0" style="overflow: hidden">
        <Transition name="fade">
            <div
                v-if="isHidden"
                class="flex flex-column flex-shrink-1 overflow-auto"
                style="border: 1px solid purple; width: 200px"
            >
                <router-link to="/">Test</router-link>
                <router-link to="/other">Grid</router-link>
                <router-link to="/table">Table</router-link>
            </div>
        </Transition>

        <div class="flex flex-shrink-1 flex-grow-1" style="border: 1px solid magenta">
            <RouterView />
        </div>
    </div>

    <div class="flex" style="border: 1px solid orange">FOOTER</div>
</template>

<style scoped>
div {
    margin: 0.1rem;
}

.fade-enter-active,
.fade-leave-active {
    transition: opacity 0.1s;
}

.fade-enter,
.fade-leave-to {
    opacity: 0;
}
</style>
