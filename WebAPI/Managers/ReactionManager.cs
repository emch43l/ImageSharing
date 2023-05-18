﻿using Application_Core.Common.Specification;
using Application_Core.Exception;
using Application_Core.Model;
using AutoMapper;
using Infrastructure.EF.Entity;
using Infrastructure.EF.Repository.PostRepository;
using Infrastructure.EF.Repository.ReactionCommentRepository;
using WebAPI.Request;

namespace WebAPI.Managers
{
    public class ReactionManager : IReactionManager
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public ReactionManager(IReactionRepository reactionRepository, IMapper mapper, IPostRepository postRepository)
        {
            _reactionRepository = reactionRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task AddReaction(AddReactionRequest request, UserEntity user)
        {
            Post post = await _postRepository.GetByGuidAsync(request.Id) ?? throw new PostNotFoundException();

            BaseSpecification<Reaction> criteria = new BaseSpecification<Reaction>();
            
            criteria.AddCriteria(r => r.Post == post);
            criteria.AddCriteria(r => r.User == user);

            Reaction? reaction = await _reactionRepository.FindByCriteria(criteria);

            if (reaction is null)
            {
                await _reactionRepository.AddReactionAsync(
                    new Reaction() 
                    {
                        Post = post,
                        User = user 
                    }
                );
            }
            else
            {
                await _reactionRepository.DeleteAsync(reaction);
            }
        }
    }
}
