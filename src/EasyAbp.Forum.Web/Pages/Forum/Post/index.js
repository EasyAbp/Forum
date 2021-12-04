(function ($) {

    var l = abp.localization.getResource('EasyAbpForum');
    var postService = easyAbp.forum.posts.post;
    var commentService = easyAbp.forum.comments.comment;
    var editPostModal = new abp.ModalManager(abp.appPath + 'Forum/Post/EditModal');
    var editCommentModal = new abp.ModalManager(abp.appPath + 'Forum/Comment/EditModal');

    var postId = $('.comments').data("post-id");

    function registerClickOfEditPostBtn() {
        $('#EditPostButton').click(function () {
            editPostModal.open({ id: postId });
        });
    }

    function registerClickOfDeletePostBtn() {
        $('#DeletePostButton').click(function (e) {
            e.preventDefault();
            abp.message.confirm(
                l('PostDeletionConfirmationMessage', ''),
                l('AreYouSure')
            ).then(function (confirmed) {
                if (confirmed) {
                    postService.delete(postId)
                        .then(function () {
                            abp.notify.info(l('SuccessfullyDeleted'));
                        });
                }
            });
        });
    }
    
    function registerClickOfCommentsBtn() {
        $('.btn-comments').click(function () {
            document.getElementById('comments').scrollIntoView();
        });
    }
    
    function registerClickOfReplyBtn() {
        $('.comment').each(function () {
            var comment = $(this);
            comment.find('.primary-btn-reply-comment').click(function () {
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
            comment.find('.primary-btn-edit-comment').click(function () {
                editCommentModal.open({ id: comment.data('comment-id') });
            });
        });
    }

    function registerClickOfSubmitBtn() {
        $('.comment').each(function () {
            var comment = $(this);
            comment.find('.primary-create-sub-comment-submit-btn').click(function () {
                var textElement = comment.find('.primary-create-sub-comment-text');
                commentService.create({
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

    function registerClickOfDeleteCommentBtn() {
        $('.comment').each(function () {
            var comment = $(this);
            comment.find('.primary-btn-delete-comment').click(function (e) {
                e.preventDefault();
                abp.message.confirm(
                    l('CommentDeletionConfirmationMessage', ''),
                    l('AreYouSure')
                ).then(function (confirmed) {
                    if (confirmed) {
                        commentService.delete(comment.data('comment-id'))
                            .then(function () {
                                document.location.href = document.location.origin + document.location.pathname;
                            });
                    }
                });
            });
        });
    }

    function init() {
        registerClickOfEditPostBtn();
        registerClickOfDeletePostBtn();
        registerClickOfCommentsBtn();
        registerClickOfReplyBtn();
        registerClickOfSubmitBtn();
        registerClickOfEditCommentBtn();
        registerClickOfDeleteCommentBtn();
    }

    $('.create-comment-form').on('abp-ajax-success', function (e, result) {
        $(this).hide();
        document.location.href = document.location.origin + document.location.pathname + '?pinnedCommentId=' + JSON.parse(result.responseText).id;
    });

    editPostModal.onResult(function () {
        window.location.reload();
    });

    editCommentModal.onResult(function () {
        window.location.reload();
    });

    init();
        
})(jQuery);