<script setup lang="ts">
const props = defineProps<{ url: string }>();

const getContent = () => {
    return `<iframe
            src="https://www.facebook.com/plugins/post.php?href=${props.url}&show_text=true&width=500"
            width="500"
            height="481"
            style="border: none; overflow: hidden"
            scrolling="no"
            frameborder="0"
            allowfullscreen="true"
            allow="autoplay; clipboard-write; encrypted-media; picture-in-picture; web-share"
        ></iframe>`;
};
</script>
<template>
    <div class="flex justify-content-center" v-html="getContent()"></div>
</template>
