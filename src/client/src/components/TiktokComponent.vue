<script setup lang="ts">
import Utils from '@/utils';

const props = defineProps<{ url: string }>();

const getContent = () => {
    Utils.addScript('https://www.tiktok.com/embed.js');
    let id = Utils.getIdFromUrl(props.url);

    return `<blockquote class="tiktok-embed" cite="${props.url}" data-video-id="${id}" style="max-width: 605px;min-width: 325px;"><section></section></blockquote>`;
};
</script>
<template>
    <div class="flex justify-content-center" v-html="getContent()"></div>
</template>
