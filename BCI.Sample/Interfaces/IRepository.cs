﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BCI.SharedCores.BaseClasses;

namespace BCI.SharedCores.Interfaces
{
    public interface IRepository<T, TId>
        where T : IAggregateRoot, IEntity<TId>
    {
        IQueryable<T> All { get; }

        T Get(TId id);

        IEnumerable<Tresult> Get<Tresult>(Expression<Func<T, Tresult>> selector, Specification<T> by)
            where Tresult : class;

        Tresult First<Tresult>(Expression<Func<T, Tresult>> selector, Specification<T> by)
            where Tresult : class;

        bool Any(Specification<T> by);

        long Count(Specification<T> by = null);

        void Append(T entity, DomainEvent<TId> @event);

        void Remove(T entity);
    }
}