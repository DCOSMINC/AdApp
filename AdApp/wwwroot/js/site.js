// Write your JavaScript code.
// extindere text area
$("#descriptionTextArea").on('paste input', function () {
    if ($(this).outerHeight() > this.scrollHeight) {
        $(this).height(1)
    }
    while ($(this).outerHeight() < this.scrollHeight + parseFloat($(this).css("borderTopWidth")) + parseFloat($(this).css("borderBottomWidth"))) {
        $(this).height($(this).height() + 1)
    }
});

// show more index descriere
$(".show-more a").on("click", function () {
    var $this = $(this);
    var $content = $this.parent().prev("div.content");
    var linkText = $this.text().toUpperCase();

    if (linkText === "SHOW MORE") {
        linkText = "Show less";
        $content.switchClass("hideContent", "showContent", 400);
    } else {
        linkText = "Show more";
        $content.switchClass("showContent", "hideContent", 400);
    };

    $this.text(linkText);
});