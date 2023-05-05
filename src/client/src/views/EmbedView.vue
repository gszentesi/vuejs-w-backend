<script setup lang="ts">
import InputUrlComponent from '@/components/InputUrlComponent.vue';
import { useDialog } from 'primevue/usedialog';
import { onMounted, ref } from 'vue';

const dialog = useDialog();

onMounted(() => {});

const menu = [
    { icon: 'pi pi-facebook', type: 'facebook' },
    { icon: 'pi pi-twitter', type: 'twitter' }
];

const add = (what: string) => {
    let el = document.getElementById('html-content');
    if (el) {
        el.innerHTML += what;
    }
};

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

                switch (type) {
                    case 'facebook':
                        add(getFacebook(data.url));
                    case 'twitter':
                        add(getTwitter(data.url));
                }
            }
        }
    });
};

const getFacebook = (url: string): string => {
    return `<iframe src="https://www.facebook.com/plugins/post.php?href=${url}&show_text=true&width=500" width="500" height="481" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowfullscreen="true" allow="autoplay; clipboard-write; encrypted-media; picture-in-picture; web-share"></iframe>`;
};

const twitterScriptAdded = ref(false);
const addTwitterScript = () => {
    if (twitterScriptAdded.value) return;

    console.log('adding script');
    var s = document.createElement('script');
    s.type = 'text/javascript';
    s.src = 'https://platform.twitter.com/widgets.js';
    document.head.appendChild(s);
    console.log('adding script done');

    twitterScriptAdded.value = true;
};

const getTwitter = (url: string): string => {
    addTwitterScript();
    return `<blockquote class="twitter-tweet">
            <a
                href="${url}"
            ></a>
        </blockquote>`;
};
</script>

<template>
    <div class="flex flex-column flex-grow-1 overflow-auto">
        <div class="flex flex-row gap-2 menu">
            <Button
                v-for="item in menu"
                :icon="item.icon"
                text
                raised
                rounded
                severity="secondary"
                @click="getUrl(item.type)"
            ></Button>
        </div>

        <div
            id="html-content"
            class="flex flex-column justify-content-center align-items-center gap-4"
        ></div>
        <DynamicDialog />
    </div>
</template>

<style scoped>
.menu {
    padding: 0.5rem;
}
</style>
