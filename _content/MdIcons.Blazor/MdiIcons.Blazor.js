// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function loadIconFont() {


    if (!document.getElementById("mdiicons-blazor-css")) {
        var baseHref = "/";
        var base = document.getElementsByTagName("base")[0];
        if (base) {
           baseHref= base.getAttribute('href');
        }

        var head = document.getElementsByTagName('head')[0];
        var link = document.createElement('link');
        link.id = "mdiicons-blazor-css";
        link.rel = 'stylesheet';
        link.type = 'text/css';
        link.href = baseHref+'_content/MdIcons.Blazor/lib/@mdi/css/materialdesignicons.min.css';
        link.media = 'all';
        head.appendChild(link);
    }

}