﻿using Application_Core.Common.Specification;
using Application_Core.Model;
using Infrastructure.Database;
using Infrastructure.EF.Evaluator;

namespace Infrastructure.EF.Repository.ReactionRepository
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly ImageSharingDbContext _context;

        public ReactionRepository(ImageSharingDbContext context)
        {
            _context = context;
        }

        public async Task AddReactionAsync(Reaction reaction)
        {
            _context.Reactions.Add(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task<Reaction?> FindByCriteria(ISpecification<Reaction> criteria)
        {
            return await Task.FromResult(
                SpecificationToQueryEvaluator<Reaction>.ApplySpecification(
                    _context.Reactions, 
                    criteria
                    ).FirstOrDefault()
                );
        }

        public async Task DeleteAsync(Reaction reaction)
        {
            _context.Reactions.Remove(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetReactionsCountByPostAsync(Post post)
        {                        
            return await Task.FromResult(_context.Reactions.Where(i=>i.Post==post).Count());
        }

    }
}
