$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            // Serializes data to name-value pairs.
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            // Takes html thats coming from the server and wraps inside a variable
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        // Prevents the server navigating away and joining the server all by itself and rejoining the page.
        return false;
    };

    // Parameter "ui" is a part of jquery-ui built-in parameters and has other information that can be received from it.
    var submitAutoCompleteForm = function (events, ui) {
        var $input = $(this);
        // Sets value to the input incase select event isnt activated by the time its selected.
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutoComplete = function () {
        var $input = $(this);
        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutoCompleteForm
            // There are many other options that auto complete inherits and can be used such as timer based autocomplete.
        };

        $input.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });

        return false;
    };

    $("form[data-otf-ajax='true'").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete").each(createAutoComplete);

    $(".body-content").on("click", ".pagedList a", getPage);

})