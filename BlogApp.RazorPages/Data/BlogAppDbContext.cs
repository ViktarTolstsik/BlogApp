﻿using BlogApp.RazorPages.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.RazorPages.Data
{
    public class BlogAppDbContext : DbContext
    {
        public BlogAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}