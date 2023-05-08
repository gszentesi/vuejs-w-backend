<script setup lang="ts">
import Utils from '@/utils';

const props = defineProps<{ url: string }>();

const getContent = () => {
    Utils.addScript('https://platform.twitter.com/widgets.js');
    return `<blockquote class="twitter-tweet"><a href="${props.url}"></a></blockquote>`;
};
</script>
<template>
    <div class="flex justify-content-center" v-html="getContent()"></div>
</template>
