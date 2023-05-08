<script setup lang="ts">
import InputUrlComponent from '@/components/InputUrlComponent.vue';
import YoutubeComponent from '@/components/YoutubeComponent.vue';
import TiktokComponent from '@/components/TiktokComponent.vue';
import InstagramComponent from '@/components/InstagramComponent.vue';
import TwitterComponent from '@/components/TwitterComponent.vue';
import FacebookComponent from '@/components/FacebookComponent.vue';

import { useDialog } from 'primevue/usedialog';
import { ref } from 'vue';

const dialog = useDialog();

const YOUTUBE = 'youtube';
const INSTAGRAM = 'instagram';
const TWITTER = 'twitter';
const TIKTOK = 'tiktok';
const FACEBOOK = 'facebook';

const menu = [
    { icon: 'pi pi-facebook', type: FACEBOOK },
    { icon: 'pi pi-twitter', type: TWITTER },
    { icon: 'fa-brands fa-tiktok', type: TIKTOK },
    { icon: 'pi pi-instagram', type: INSTAGRAM },
    { icon: 'pi pi-youtube', type: YOUTUBE }
];

interface Content {
    url: string;
    type: string;
}

const contents = ref([
    { url: 'https://youtu.be/RuM4JIoO0lQ', type: YOUTUBE },
    { url: 'https://www.tiktok.com/@scout2015/video/6718335390845095173', type: TIKTOK },
    {
        url: 'https://www.instagram.com/reel/CqWjCaoIF08/?utm_source=ig_web_copy_link',
        type: INSTAGRAM
    },
    { url: 'https://twitter.com/elonmusk/status/1652849795336159233?s=20', type: TWITTER },
    {
        url: 'https://www.facebook.com/photo/?fbid=235944375693223&set=gm.6859843630699566&idorvanity=122643284419668',
        type: FACEBOOK
    }
] as Content[]);

const getUrl = (type: string) => {
    console.log(type);
    const dialogRef = dialog.open(InputUrlComponent, {
        props: {
            header: 'Adja meg az urlt',
            style: {
                width: '50vw'
            },
            breakpoints: {
                '960px': '75vw',
                '640px': '90vw'
            },
            modal: true
        },
        onClose: (options: any) => {
            const data = options.data;
            if (data && data.buttonType === 'Yes') {
                console.log(data.url);
                contents.value.push({ url: data.url, type: type });
            }
        }
    });
};
</script>

<template>
    <div class="flex flex-column flex-grow-1 gap-2">
        <div class="flex flex-row justify-content-center shadow-1">
            <div class="flex flex-row gap-2 container" v-for="item in menu">
                <Button
                    v-if="item.icon.startsWith('fa') === false"
                    :icon="item.icon"
                    text
                    raised
                    rounded
                    severity="secondary"
                    size="large"
                    @click="getUrl(item.type)"
                ></Button>

                <Button
                    v-if="item.icon.startsWith('fa') === true"
                    :icon="item.icon"
                    text
                    raised
                    rounded
                    severity="secondary"
                    size="large"
                    @click="getUrl(item.type)"
                >
                    <font-awesome-icon :icon="item.icon" />
                </Button>
            </div>
        </div>

        <div style="overflow: auto" class="container">
            <div v-for="content in contents">
                <YoutubeComponent
                    v-if="content.type === YOUTUBE"
                    v-model:url="content.url"
                ></YoutubeComponent>
                <TiktokComponent
                    v-if="content.type === TIKTOK"
                    v-model:url="content.url"
                ></TiktokComponent>
                <InstagramComponent
                    v-if="content.type === INSTAGRAM"
                    v-model:url="content.url"
                ></InstagramComponent>
                <TwitterComponent
                    v-if="content.type === TWITTER"
                    v-model:url="content.url"
                ></TwitterComponent>
                <FacebookComponent
                    v-if="content.type === FACEBOOK"
                    v-model:url="content.url"
                ></FacebookComponent>
            </div>
        </div>
        <DynamicDialog />
    </div>
</template>

<style scoped>
.container {
    padding: 0.5rem;
}
</style>
