using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace EasyAbp.Forum.Web.Pages.Components.ForumSubCommentsWidget
{
    public class ForumSubCommentsWidgetModel
    {
        [CanBeNull]
        public string CurrentUserName { get; set; }
        
        public bool CanLoadMore { get; set; }
        
        public bool CanCreateComment { get; set; }
        
        public Guid PostId { get; set; }
        
        public Guid CommentId { get; set; }

        public IEnumerable<ForumSubCommentsWidgetItemModel> SubComments { get; set; }
    }
}