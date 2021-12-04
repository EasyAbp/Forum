(function ($) {

    var l = abp.localization.getResource('EasyAbpForum');
    var editCommentModal = new abp.ModalManager(abp.appPath + 'Forum/Comment/EditModal');

    abp.widgets.ForumSubCommentsWidget = function ($widget) {
        var widgetManager = $widget.data('abp-widget-manager');
        var $subCommentsArea = $widget.find('.sub-comments-area');
        var service = easyAbp.forum.comments.comment;

        function getFilters() {
            return {
                postId: $subCommentsArea.data('post-id'),
                commentId: $subCommentsArea.data('comment-id'),
                hasChildren: true
            };
        }

        function registerClickOfReplyBtn() {
            $widget.find('.sub-comment').each(function () {
                var subComment = $(this);
                subComment.find('.btn-reply').click(function () {
                    var createCommentArea = subComment.find(".create-sub-comment");
                    if (createCommentArea.is(":hidden")) {
                        $('.create-sub-comment').hide();
                        var textarea = createCommentArea.find('.create-sub-comment-text');
                        var username = subComment.data('creator-username');
                        createCommentArea.show();
                        textarea.focus();
                        if (username) {
                            textarea.val('@' + username + ' ');
                        }
                    } else {
                        $('.create-sub-comment').hide();
                    }
                });
            });
        }

        function registerClickOfEditBtn() {
            var commentId = $subCommentsArea.data('comment-id');
            
            $widget.find('.sub-comment').each(function () {
                var subComment = $(this);
                subComment.find('.btn-edit').click(function () {
                    editCommentModal.open({ id: subComment.data('comment-id') });
                });
            });

            editCommentModal.onResult(function (e, result) {
                if (commentId && commentId === JSON.parse(result.responseText).parentId) {
                    widgetManager.refresh($widget);
                }
            });
        }
        
        function registerClickOfSubmitBtn() {
            var postId = $subCommentsArea.data("post-id");
            var commentId = $subCommentsArea.data("comment-id");
            $widget.find('.sub-comment').each(function () {
                var subComment = $(this);
                var btn = subComment.find('.create-sub-comment-submit-btn');
                btn.click(function () {
                    btn.buttonBusy(true);
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
        
        function registerClickOfDeleteBtn() {
            $widget.find('.sub-comment').each(function () {
                var subComment = $(this);
                subComment.find('.btn-delete').click(function (e) {
                    e.preventDefault();
                    abp.message.confirm(
                        l('CommentDeletionConfirmationMessage', ''),
                        l('AreYouSure')
                    ).then(function (confirmed) {
                        if (confirmed) {
                            service.delete(subComment.data('comment-id'))
                                .then(function () {
                                    widgetManager.refresh($widget);
                                });
                        }
                    });
                });
            });
        }
        
        function init() {
            registerClickOfReplyBtn();
            registerClickOfSubmitBtn();
            registerClickOfEditBtn();
            registerClickOfDeleteBtn();
        }

        return {
            init: init,
            getFilters: getFilters
        };
    };
})(jQuery);