export default abstract class Utils {
    static addScript = (url: string): void => {
        console.log(`adding script: ${url}`);
        var s = document.createElement('script');
        s.type = 'text/javascript';
        s.src = url;
        document.body.appendChild(s);
        console.log('adding script done');
    };

    static getIdFromUrl = (url: string): string => {
        let splited = url.split('/');
        return splited[splited.length - 1];
    };
}
