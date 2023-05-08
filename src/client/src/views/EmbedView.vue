<script setup lang="ts">
import InputUrlComponent from '@/components/InputUrlComponent.vue';
import { useDialog } from 'primevue/usedialog';
import { onMounted, ref } from 'vue';

const dialog = useDialog();

onMounted(() => {});

const menu = [
    { icon: 'pi pi-facebook', type: 'facebook' },
    { icon: 'pi pi-twitter', type: 'twitter' },
    { icon: 'fa-brands fa-tiktok', type: 'tiktok' },
    { icon: 'pi pi-instagram', type: 'insta' },
    { icon: 'pi pi-youtube', type: 'youtube' }
];

const add = (what: string) => {
    let el = document.getElementById('html-content');
    console.log(what);
    if (el) {
        el.innerHTML = what + el.innerHTML;
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
                        break;
                    case 'twitter':
                        add(getTwitter(data.url));
                        break;
                    case 'tiktok':
                        add(getTikTok(data.url));
                        break;
                    case 'insta':
                        add(getInsta(data.url));
                        break;
                    case 'youtube':
                        add(getYoutube(data.url));
                        break;
                }
            }
        }
    });
};

const getFacebook = (url: string): string => {
    return `<iframe src="https://www.facebook.com/plugins/post.php?href=${url}&show_text=true&width=500" width="500" height="481" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowfullscreen="true" allow="autoplay; clipboard-write; encrypted-media; picture-in-picture; web-share"></iframe>`;
};

const addScript = (url: string) => {
    console.log(`adding script: ${url}`);
    var s = document.createElement('script');
    s.type = 'text/javascript';
    s.src = url;
    document.body.appendChild(s);
    console.log('adding script done');
};

const getTwitter = (url: string): string => {
    addScript('https://platform.twitter.com/widgets.js');
    return `<blockquote class="twitter-tweet"><a href="${url}"></a></blockquote>`;
};

const getTikTok = (url: string): string => {
    addScript('https://www.tiktok.com/embed.js');

    let splited = url.split('/');
    let id = splited[splited.length - 1];

    return `<blockquote class="tiktok-embed" cite="${url}" data-video-id="${id}" style="max-width: 605px;min-width: 325px;"><section></section></blockquote>`;
};

const getInsta = (url: string) => {
    addScript('http://instagram.com/embed.js');
    return ` <blockquote
      class="instagram-media"
      data-instgrm-captioned
      data-instgrm-permalink="${url}"
      data-instgrm-version="14"
    ></blockquote>
    `;
};

const getYoutube = (url: string) => {
    let splited = url.split('/');
    let id = splited[splited.length - 1];

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
    <div class="flex flex-column flex-grow-1 overflow-auto">
        <div class="flex flex-row justify-content-center">
            <div class="flex flex-row gap-2 menu" v-for="item in menu">
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
