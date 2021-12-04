(function ($) {

    var service = easyAbp.forum.comments.comment;
    var editCommentModal = new abp.ModalManager(abp.appPath + 'Forum/Comment/EditModal');

    var postId = $('.comments').data("post-id");


    function registerClickOfCommentsBtn() {
        $('.btn-comments').click(function () {
            document.getElementById('comments').scrollIntoView();
        });
    }
    
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

    function registerClickOfEditCommentBtn() {
        $('.comment').each(function () {
            var comment = $(this);
            comment.find('.primary-btn-edit').click(function () {
                editCommentModal.open({ id: comment.data('comment-id') });
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
        registerClickOfCommentsBtn();
        registerClickOfReplyBtn();
        registerClickOfSubmitBtn();
        registerClickOfEditCommentBtn();
    }

    $('.create-comment-form').on('abp-ajax-success', function (e, result) {
        $(this).hide();
        document.location.href = document.location.origin + document.location.pathname + '?pinnedCommentId=' + JSON.parse(result.responseText).id;
    });

    editCommentModal.onResult(function () {
        window.location.reload();
    });

    init();
        
})(jQuery);