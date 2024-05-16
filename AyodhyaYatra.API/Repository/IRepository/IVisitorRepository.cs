﻿using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.Models;

namespace AyodhyaYatra.API.Repository.IRepository
{
    public interface IVisitorRepository
    {
        Task<int> AddDocumentType(VisitorDocumentType documentType);
        Task<bool> UpdateDocumentType(VisitorDocumentType documentType);
        Task<bool> DeleteDocumentType(int id);
        Task<List<VisitorDocumentType>> GetsDocumentType();

        Task<int> AddVisitor(Visitor visitor);
        Task<List<Visitor>> GetsVisitors(PagingRequest pagingRequest);
        Task<int> VisitorCount(int month,int year);
    }
}