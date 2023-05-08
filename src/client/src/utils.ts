export default abstract class Utils {
    static addScript = (url: string): void => {
        var s = document.createElement('script');
        s.type = 'text/javascript';
        s.src = url;
        document.body.appendChild(s);
    };

    static getIdFromUrl = (url: string): string => {
        let splited = url.split('/');
        return splited[splited.length - 1];
    };
}
