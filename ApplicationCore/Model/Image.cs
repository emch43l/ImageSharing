﻿using Application_Core.Model.Base;
using Application_Core.Model.Interface;

namespace Application_Core.Model;

public class Image : UidIdentity
{
    public string Slug { get; set; }
    
    public string Title { get; set; }
    
    public Post Post { get; set; }

    public ICollection<Album> Albums { get; set; }
    
    public IUser<int> User { get; set; }

    public int UserId { get; set; }

    public Image() : base()
    {
        this.Albums = new List<Album>();
    }
}