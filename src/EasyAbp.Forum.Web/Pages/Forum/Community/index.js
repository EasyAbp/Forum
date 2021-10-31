$(function () {

    var l = abp.localization.getResource('EasyAbpForum');

    var service = easyAbp.forum.posts.community;
    var createModal = new abp.ModalManager(abp.appPath + 'Forum/Post/CreateModal');

    createModal.onResult(function (result) {
        console.log(result)
    });

    $('#CreatePostButton').click(function (e) {
        e.preventDefault();
        createModal.open({ communityId: communityId });
    });
});
