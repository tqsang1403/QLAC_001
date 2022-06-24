(function ($) {
    $.fn.extend({
        //pass the options variable to the function
        styleToggle: function (options) {
            var defaults = {
                onText: '',
                offText : '',
                onCss: 'btn-success',
                offCss: 'btn-danger',
                onChecked: null,
                onUnchecked: null,
                onClicked: null
            };
            var options = $.extend(defaults, options);

            //init
            $(this).addClass(options.offCss);
            if (options.offText && options.offText.length > 0) {
                if ($(this).tagName == "input")
                    $(this).val(options.offText);
                else
                    $(this).html(options.offText);
            }

            $(this).click(function () {
                if (options.onClicked != null)
                    options.onClicked();
                if ($(this).hasClass('active')) {
                    //unchecked
                    if (options.offText && options.offText.length > 0) {
                        if ($(this).tagName == "input")
                            $(this).val(options.offText);
                        else
                            $(this).html(options.offText);
                    }
                    $(this).removeClass(options.onCss);
                    $(this).addClass(options.offCss);
                    if (options.onUnchecked != null)
                        options.onUnchecked();
                }
                else {
                    //checked
                    if (options.onText && options.onText.length > 0) {
                        if ($(this).tagName == "input")
                            $(this).val(options.onText);
                        else
                            $(this).html(options.onText);
                    }
                    $(this).removeClass(options.offCss);
                    $(this).addClass(options.onCss);
                    if (options.onChecked != null)
                        options.onChecked();
                }
            });
        }
    });

})(jQuery);