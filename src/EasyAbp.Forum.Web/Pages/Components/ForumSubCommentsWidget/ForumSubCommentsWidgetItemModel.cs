using System.Collections.Generic;
using EasyAbp.Forum.Comments.Dtos;

namespace EasyAbp.Forum.Web.Pages.Components.ForumSubCommentsWidget
{
    public class ForumSubCommentsWidgetItemModel
    {
        public CommentDto Comment { get; set; }
        
        public bool CanCreateComment { get; set; }
        
        public bool CanEditComment { get; set; }
        
        public bool CanDeleteComment { get; set; }
    }
}