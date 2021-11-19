﻿using System;

namespace Tolitech.CodeGenerator.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }

        public int PageCount { get; private set; }

        public int TotalItemCount { get; private set; }

        public PaginatedList(IList<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling(count / (double)pageSize);
            TotalItemCount = count;

            AddRange(items);
        }

        public PaginatedList(IList<T> items, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling(items.Count / (double)pageSize);
            TotalItemCount = items.Count;
            var paginatedItems = items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            AddRange(paginatedItems);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < PageCount);
            }
        }

        public bool IsFirstPage
        {
            get
            {
                return (PageNumber <= 1);
            }
        }

        public bool IsLastPage
        {
            get
            {
                return (PageNumber >= PageCount);
            }
        }
    }
}