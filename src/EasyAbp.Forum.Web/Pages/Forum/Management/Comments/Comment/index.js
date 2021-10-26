$(function () {

    var l = abp.localization.getResource('EasyAbpForum');

    var service = easyAbp.forum.comments.comment;

    var dataTable = $('#CommentTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.Forum.Comment.Manage') && abp.auth.isGranted('EasyAbp.Forum.Comment.Delete'),
                                confirmMessage: function (data) {
                                    return l('CommentDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('CommentParentId'),
                data: "parentId"
            },
            {
                title: l('CommentPostId'),
                data: "postId"
            },
            {
                title: l('CommentText'),
                data: "text"
            },
        ]
    }));
});
