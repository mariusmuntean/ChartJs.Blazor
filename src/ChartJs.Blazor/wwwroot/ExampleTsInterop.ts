/// <reference path="Chart.min.d.ts" />

class ExampleJsFunctions {
    public showPrompt(message: string): string {
        return prompt(message, 'Type anything here' + Chart.defaults);
    }
}

function Load(): void {
    window['exampleJsFunctions'] = new ExampleJsFunctions();
}

Load();