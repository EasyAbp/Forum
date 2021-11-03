(function ($) {

    abp.widgets.ForumSubCommentsWidget = function ($widget) {
        var widgetManager = $widget.data('abp-widget-manager');
        var $subCommentsArea = $widget.find('.sub-comments-area');
        var service = easyAbp.forum.comments.comment;

        function getFilters() {
            return {
                postId: $subCommentsArea.data('post-id'),
                commentId: $subCommentsArea.data('comment-id'),
            };
        }

        function registerClickOfReplyBtn() {
            $widget.find('.sub-comment').each(function () {
                var subComment = $(this);
                subComment.find('.btn-reply').click(function () {
                    var createCommentArea = subComment.find(".create-sub-comment");
                    if (createCommentArea.is(":hidden")) {
                        createCommentArea.show();
                    } else {
                        createCommentArea.hide();
                    }
                });
            });
        }
        
        function registerClickOfSubmitBtn() {
            var postId = $subCommentsArea.data("post-id");
            var commentId = $subCommentsArea.data("comment-id");
            $widget.find('.sub-comment').each(function () {
                var subComment = $(this);
                subComment.find('.create-sub-comment-submit-btn').click(function () {
                    service.create({
                        parentId: commentId,
                        postId: postId,
                        text: subComment.find('.create-sub-comment-text').val()
                    }).then(function () {
                        widgetManager.refresh($widget);
                    })
                });
            });
        }
        
        function init() {
            registerClickOfReplyBtn();
            registerClickOfSubmitBtn();
        }

        return {
            init: init,
            getFilters: getFilters
        };
    };
})(jQuery);