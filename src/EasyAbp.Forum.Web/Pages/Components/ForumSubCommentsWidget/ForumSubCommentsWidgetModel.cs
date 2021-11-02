using System.Collections.Generic;
using EasyAbp.Forum.Comments.Dtos;

namespace EasyAbp.Forum.Web.Pages.Components.ForumSubCommentsWidget
{
    public class ForumSubCommentsWidgetModel
    {
        public CommentDto Comment { get; set; }
        
        public IEnumerable<ForumSubCommentsWidgetItemModel> SubComments { get; set; }
    }
}