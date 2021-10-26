$(function () {

    var l = abp.localization.getResource('EasyAbpForum');

    var service = easyAbp.forum.posts.post;

    var dataTable = $('#PostTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('EasyAbp.Forum.Post.Manage') && abp.auth.isGranted('EasyAbp.Forum.Post.Delete'),
                                confirmMessage: function (data) {
                                    return l('PostDeletionConfirmationMessage', data.record.id);
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
                title: l('PostCommunityId'),
                data: "communityId"
            },
            {
                title: l('PostTitle'),
                data: "title"
            },
            {
                title: l('PostOutline'),
                data: "outline"
            },
            {
                title: l('PostContent'),
                data: "content"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPostButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
