using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.Forum.Communities.Dtos
{
    [Serializable]
    public class CreateUpdateCommunityDto : ExtensibleObject
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            if (!Regex.IsMatch(Name, ForumConsts.Community.NameRegexRule))
            {
                yield return new ValidationResult(
                    "Name should be only letters, numbers, hyphen and underscore!",
                    new[] { nameof(Name) }
                );
            }
        }
    }
}