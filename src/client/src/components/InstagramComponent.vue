<script setup lang="ts">
import Utils from '@/utils';

const props = defineProps<{ url: string }>();

const getContent = () => {
    Utils.addScript('http://instagram.com/embed.js');
    return ` <blockquote
      class="instagram-media"
      data-instgrm-captioned
      data-instgrm-permalink="${props.url}"
      data-instgrm-version="14"
    ></blockquote>
    `;
};
</script>
<template>
    <div class="flex justify-content-center" v-html="getContent()"></div>
</template>
