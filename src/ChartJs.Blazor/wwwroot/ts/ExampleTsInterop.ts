/// <reference path="types/moment.d.ts" />
/// <reference path="types/Chart.min.d.ts" />   

class ExampleJsFunctions {
    public showPrompt(message: string): string {

        return prompt(message, 'Type anything here' + moment.now() + Chart.defaults.global.defaultFontFamily);
    }
}

function Load(): void {
    window['exampleJsFunctions'] = new ExampleJsFunctions();
}

Load();
