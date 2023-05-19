﻿using Application_Core.Model;
using Infrastructure.Dto;
using Infrastructure.EF.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Mapper;
using WebAPI.Request;
using WebAPI.Response;
using WebAPI.Services;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumSerivce;

    public AlbumController(IAlbumService albumSerivce)
    {
        _albumSerivce = albumSerivce;
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        PaginatorResult<Album> paginator = await _albumSerivce.GetAllPaginated(paginationRequest.ItemNumber, paginationRequest.Page);
        PaginatorResult<AlbumResponse> response = paginator.MapToOtherType(AlbumMapper.FromAlbumToAlbumResponse);

        return Ok(response);
    }
    
    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> Search([FromQuery] SearchAlbumRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        AlbumSearchDto param = request.ToParam();
        
        PaginatorResult<Album> paginator = await _albumSerivce.Search(param,request.Page,request.ItemNumber);
        PaginatorResult<AlbumResponse> response = paginator.MapToOtherType(AlbumMapper.FromAlbumToAlbumResponse);

        return Ok(response);
    }
}
