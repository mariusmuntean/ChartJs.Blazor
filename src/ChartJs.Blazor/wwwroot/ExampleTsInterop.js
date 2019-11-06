/// <reference path="Chart.min.d.ts" />
class ExampleJsFunctions {
    showPrompt(message) {
        return prompt(message, 'Type anything here' + Chart.defaults);
    }
}
function Load() {
    window['exampleJsFunctions'] = new ExampleJsFunctions();
}
Load();
