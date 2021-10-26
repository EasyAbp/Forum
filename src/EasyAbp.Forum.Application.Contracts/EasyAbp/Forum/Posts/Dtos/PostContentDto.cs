using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Forum.Posts.Dtos
{
    [Serializable]
    public class PostContentDto : EntityDto
    {
        public Guid PostId { get; set; }

        public string Text { get; set; }
    }
}