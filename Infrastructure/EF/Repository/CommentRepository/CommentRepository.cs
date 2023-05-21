﻿using Application_Core.Model;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repository.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ImageSharingDbContext _context;

        public CommentRepository(ImageSharingDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return comment.Guid;
        }

        public async Task DeleteAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task EditCommentAsync(Comment comment)
        {
            Comment? _comment = _context.Comments.FirstOrDefault(i => i.Guid == comment.Guid);
            _comment.Text = comment.Text;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllCommentsAsync(int postId)
        {
            return _context.Comments
                .Where(i => i.PostId == postId)
                .Include(p => p.Post)
                .Include(u => u.User)
                .ToList();
        }

        public async Task<IQueryable<Comment>> GetAllCommentsQueryAsync(int postId)
        {
            return _context.Comments
                .Where(i => i.PostId == postId)
                .Include(p => p.Post)
                .Include(u => u.User);
        }

        public async Task<Comment> GetCommentByGuIdAsync(Guid guId)
        {
            return await _context.Comments
                .Where(i => i.Guid == guId)
                .Include(p => p.Post)
                .Include(u => u.User)
                .FirstOrDefaultAsync();
        }
    }
}
