using EasyAbp.Forum.Comments;
using EasyAbp.Forum.Posts;
using EasyAbp.Forum.Communities;
using System;
using EasyAbp.Forum.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;

namespace EasyAbp.Forum.EntityFrameworkCore
{
    public static class ForumDbContextModelCreatingExtensions
    {
        public static void ConfigureForum(
            this ModelBuilder builder,
            Action<ForumModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ForumModelBuilderConfigurationOptions(
                ForumDbProperties.DbTablePrefix,
                ForumDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */

            builder.Entity<Community>(b =>
            {
                b.ToTable(options.TablePrefix + "Communities", options.Schema);
                b.ConfigureByConvention(); 
                
                /* Configure more properties here */
            });


            builder.Entity<Post>(b =>
            {
                b.ToTable(options.TablePrefix + "Posts", options.Schema);
                b.ConfigureByConvention(); 

                /* Configure more properties here */
            });


            builder.Entity<Comment>(b =>
            {
                b.ToTable(options.TablePrefix + "Comments", options.Schema);
                b.ConfigureByConvention(); 
                
                /* Configure more properties here */
            });


            builder.Entity<PostContent>(b =>
            {
                b.ToTable(options.TablePrefix + "PostContents", options.Schema);
                b.ConfigureByConvention(); 
                
                b.HasKey(e => new
                {
                    e.PostId,
                });

                /* Configure more properties here */
            });


            builder.Entity<ForumUser>(b =>
            {
                b.ToTable(options.TablePrefix + "Users", options.Schema);

                b.ConfigureByConvention();
                b.ConfigureAbpUser();
            });
        }
    }
}
