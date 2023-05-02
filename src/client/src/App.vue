<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink, RouterView } from 'vue-router'
import type { ResizeItem } from './components/Resizer.vue'

const isHidden = ref(false)

const change = (event: ResizeItem) => {
    document.getElementsByTagName('html')[0].style.fontSize = event.size
}
</script>

<template>
    <div id="header" class="flex gap-2 align-items-center">
        <Button severity="secondary" text outlined size="small" @click="isHidden = !isHidden"
            ><i class="pi pi-bars" style="font-size: 1rem"></i
        ></Button>
        HEADER

        <div class="flex flex-grow-1 justify-content-end">
            <Resizer @changed="change($event)"></Resizer>
        </div>
    </div>

    <div id="content" class="flex flex-row flex-grow-1 flex-grow-0" style="overflow: hidden">
        <div
            id="sideNav"
            :style="{ width: isHidden ? '0px' : '200px', opacity: isHidden ? 0 : 1 }"
            class="flex flex-column flex-shrink-1 overflow-auto"
        >
            <router-link to="/">Test</router-link>
            <router-link to="/other">Grid</router-link>
            <router-link to="/table">Table</router-link>
        </div>

        <div class="flex flex-shrink-1 flex-grow-1" style="border: 1px solid magenta">
            <RouterView />
        </div>
    </div>

    <div id="footer" class="flex justify-content-center" style="border: 1px solid orange">
        FOOTER
    </div>
</template>

<style scoped>
#sideNav {
    transition: all 0.3s ease;
}

#footer {
    padding: 0.2rem;
}

#header {
    padding: 0.2rem;
}

#content {
    padding: 0.2rem;
}
</style>
