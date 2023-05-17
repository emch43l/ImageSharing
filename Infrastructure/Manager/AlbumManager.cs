﻿using Application_Core.Common.Specification;
using Application_Core.Exception;
using Application_Core.Model;
using Infrastructure.EF.Entity;
using Infrastructure.EF.Repository.AlbumRepository;
using Infrastructure.Manager.Param;
using Infrastructure.Utility.Pagination;

namespace Infrastructure.Manager;

public class AlbumManager
{
    private readonly IAlbumRepository _albumRepository;

    private readonly Paginator<Album> _paginator;

    public AlbumManager(IAlbumRepository albumRepository)
    {
        _paginator = new Paginator<Album>();
        _albumRepository = albumRepository;
    }

    public async Task<PaginatorResult<Album>> GetAllPaginated(int maxItems, int page)
    {
        PaginatorResult<Album> result = await _paginator
            .SetItemNumberPerPage(maxItems)
            .Paginate(_albumRepository.GetAllQuery(), page);

        if (result.Items.Count() == 0)
            throw new AlbumNotFoundException();

        return result;
    }

    public async Task<PaginatorResult<Album>> Search(AlbumSearchDto criteria, int page = 1, int maxItems = 10)
    {
        BaseSpecification<Album> specification = new BaseSpecification<Album>();

        if (!string.IsNullOrWhiteSpace(criteria.AlbumTitle))
            specification.AddCriteria(c => c.Title.Contains(criteria.AlbumTitle));

        if (criteria.MaxImages is not null && int.IsPositive((int)criteria.MaxImages))
            specification.AddCriteria(c => c.Images.Count() <= criteria.MaxImages);

        if (criteria.MinImages is not null && int.IsPositive((int)criteria.MinImages))
            specification.AddCriteria(c => c.Images.Count() >= criteria.MinImages);

        if (criteria.OrderBy == OrderBy.Asc) {
            specification.SetOrderBy(c => c.Title);
        } else { 
            specification.SetOrderByDescending(c => c.Title);
        }
        
        IQueryable<Album> query = _albumRepository.GetAlbumsByCriteriaQuery(
            specification
        );

        PaginatorResult<Album> result = await _paginator
            .SetItemNumberPerPage(maxItems)
            .Paginate(query, page);

        if (result.Items.Count() == 0)
            throw new AlbumNotFoundException();

        return result;
    }
}