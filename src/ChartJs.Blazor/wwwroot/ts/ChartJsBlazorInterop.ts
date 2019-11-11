
function AttachChartJsInterop(): void {
    window[ChartJsInterop.name] = new ChartJsInterop();
}

AttachChartJsInterop();

function AttachMomentJsInterop(): void {
    window[MomentJsInterop.name] = new MomentJsInterop();
}

AttachMomentJsInterop();
