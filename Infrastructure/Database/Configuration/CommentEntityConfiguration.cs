﻿using Application_Core.Model;
using Infrastructure.EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration;

public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        builder
            .HasOne(c => (User)c.User)
            .WithMany(u => u.Comments);
        builder
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments);
        builder.ToTable("Comments");
    }
    
}