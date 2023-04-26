﻿namespace Application_Core.Commons.Repository;

public interface IIdentity<T> : IComparable<T> where T: IComparable<T>
{
    public T Id { get; set; }

    int IComparable<T>.CompareTo(T? other)
    {
        return this.CompareTo(other);
    }
}