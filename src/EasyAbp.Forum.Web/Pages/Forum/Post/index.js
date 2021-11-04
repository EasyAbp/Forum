(function ($) {

    var service = easyAbp.forum.comments.comment;
    var postId = $('.comments').data("post-id");

    function registerClickOfReplyBtn() {
        $('.comment').each(function () {
            var comment = $(this);
            comment.find('.primary-btn-reply').click(function () {
                var createCommentArea = comment.find(".primary-create-sub-comment");
                if (createCommentArea.is(":hidden")) {
                    $('.create-sub-comment').hide();
                    createCommentArea.show();
                } else {
                    $('.create-sub-comment').hide();
                }
            });
        });
    }

    function registerClickOfSubmitBtn() {
        $('.comment').each(function () {
            var comment = $(this);
            comment.find('.primary-create-sub-comment-submit-btn').click(function () {
                var textElement = comment.find('.primary-create-sub-comment-text');
                service.create({
                    parentId: comment.data("comment-id"),
                    postId: postId,
                    text: textElement.val()
                }).then(function () {
                    var $widget = comment.find('.abp-widget-wrapper[data-widget-name="ForumSubCommentsWidget"]');
                    var widgetManager = $widget.data('abp-widget-manager');
                    widgetManager.refresh($widget);
                    $('.create-sub-comment').hide();
                    textElement.val('')
                })
            });
        });
    }

    function init() {
        registerClickOfReplyBtn();
        registerClickOfSubmitBtn();
    }

    init();
        
})(jQuery);