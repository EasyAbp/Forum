$(function () {

    var l = abp.localization.getResource('EasyAbpForum');

    var service = easyAbp.forum.communities.community;
    var createModal = new abp.ModalManager(abp.appPath + 'Forum/Management/Communities/Community/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Forum/Management/Communities/Community/EditModal');

    var dataTable = $('#CommunityTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                text: l('Edit'),
                                visible: abp.auth.isGranted('EasyAbp.Forum.Community.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.Forum.Community.Delete'),
                                confirmMessage: function (data) {
                                    return l('CommunityDeletionConfirmationMessage', data.record.id);
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
                title: l('CommunityName'),
                data: "name"
            },
            {
                title: l('CommunityDisplayName'),
                data: "displayName"
            },
            {
                title: l('CommunityDescription'),
                data: "description"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCommunityButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
