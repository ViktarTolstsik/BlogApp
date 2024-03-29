﻿using BlogApp.RazorPages.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.RazorPages.Data
{
    public class BlogAppDbContext : DbContext
    {
        public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLike { get; set; } //Name in plural doesn't work (PluralizingTableNameConvention)
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
	}
}
