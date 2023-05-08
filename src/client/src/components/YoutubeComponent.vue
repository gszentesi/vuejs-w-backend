<script setup lang="ts">
import Utils from '@/utils';

const props = defineProps<{ url: string }>();

const getContent = () => {
    let id = Utils.getIdFromUrl(props.url);
    return `<iframe
      width="560"
      height="315"
      src="https://www.youtube.com/embed/${id}"
      title="YouTube video player"
      frameborder="0"
    ></iframe>
    `;
};
</script>
<template>
    <div class="flex justify-content-center" v-html="getContent()"></div>
</template>
