window.SampleInterop = {

    OnHover: function (sender, args) {
        if (args && args.length > 0) {
            sender.srcElement.style.opacity = "0.5";
        }
    }
}
;