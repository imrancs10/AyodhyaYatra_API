using AyodhyaYatra.API.Contants;
using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.DTO.Request.Common;
using AyodhyaYatra.API.Exceptions;
using AyodhyaYatra.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AyodhyaYatra.API.Repository
{
    public class VisitorRepository: IVisitorRepository
    {
        private AyodhyaYatraContext _context;
        public VisitorRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }

        public async Task<int> AddDocumentType(VisitorDocumentType documentType)
        {
             if(await _context.VisitorDocumentTypes.Where(x=>!x.IsDeleted && x.Name == documentType.Name).AnyAsync())
             {
                throw new BusinessRuleViolationException(StaticValues.ErrorType_AlreadyExist, StaticValues.Error_AlreadyExist);
             }

            var entity=_context.Add(documentType);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<int> AddVisitor(Visitor visitor)
        {
            var docType=await _context.VisitorDocumentTypes.Where(x=>!x.IsDeleted && x.Id==visitor.DocumentTypeId).FirstOrDefaultAsync()?? throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidGovDocType, StaticValues.Error_InvalidGovDocType);
            if (!string.IsNullOrEmpty(docType.DocNumberDataType))
            {
                if(string.IsNullOrEmpty(visitor.DocumentNumber))
                    throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidGovDocNo, StaticValues.Error_InvalidGovDocNo);

                Regex regex;
                switch (docType.DocNumberDataType)
                {
                    case "Numeric":
                        regex = new(@"^\d$");
                        if(!IsDigitsOnly(visitor.DocumentNumber))
                            throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidGovDocNo, StaticValues.Error_InvalidGovDocNo);
                        break;
                    case "AlphaNumeric":
                        regex = new(@"^[a-zA-Z][a-zA-Z0-9]*$");
                        if (!regex.IsMatch(visitor.DocumentNumber))
                            throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidGovDocNo, StaticValues.Error_InvalidGovDocNo);
                        break;
                    default:
                        throw new BusinessRuleViolationException(StaticValues.ErrorType_InvalidGovDocNo, StaticValues.Error_InvalidGovDocNo);
                }
                visitor.UniqueId = Guid.NewGuid();
                visitor.RegistrationDate= DateTime.Now;
                var entity = _context.Add(visitor);
                await _context.SaveChangesAsync();
                return entity.Entity.Id;
            }
            return 0;
            
        }

        public async Task<bool> DeleteDocumentType(int id)
        {
            var entity = await _context.VisitorDocumentTypes.Where(x=>!x.IsDeleted && x.Id==id).FirstOrDefaultAsync()??throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);
            entity.IsDeleted = true;
            _context.VisitorDocumentTypes.Update(entity);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<List<VisitorDocumentType>> GetsDocumentType()
        {
           return await _context.VisitorDocumentTypes.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<List<Visitor>> GetsVisitors(PagingRequest pagingRequest)
        {
            return await _context.Visitors.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Visitor> GetVisitor(int id)
        {
            return await _context.Visitors
                .Include(x=>x.VisitorDocumentType)
                .Where(x => !x.IsDeleted && x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<List<Visitor>> GetVisitor(string mobileNo)
        {
            return await _context.Visitors
                .Include(x=>x.VisitorDocumentType)
                .Where(x=>!x.IsDeleted && x.Mobile==mobileNo)
                .OrderByDescending(x=>x.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> UpdateDocumentType(VisitorDocumentType documentType)
        {
            var entity = await _context.VisitorDocumentTypes.Where(x => !x.IsDeleted && x.Id == documentType.Id).FirstOrDefaultAsync() ?? throw new BusinessRuleViolationException(StaticValues.ErrorType_RecordNotFound, StaticValues.Error_RecordNotFound);
            entity.DocNumberDataType = documentType.DocNumberDataType;
            entity.MinDocNumber=documentType.MinDocNumber;
            entity.MaxDocNumber=documentType.MaxDocNumber;
            entity.Name = documentType.Name;
            entity.Code = documentType.Code;
            _context.VisitorDocumentTypes.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Visitor?> ValidateVisitor(Guid uniqueId)
        {
            return await _context.Visitors.Where(x => x.UniqueId == uniqueId && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<int> VisitorCount(int month, int year)
        {
           if(month> 0 && year == 0)
           {
                year = DateTime.Now.Year;
           }
           if(month>12) month = 12;
           if(month<0) month = 0;
           if(year<0) year = 0;
           if (year>DateTime.Now.Year) year = DateTime.Now.Year;

           return await _context.Visitors
                .Where(x=>!x.IsDeleted && (month==0 || x.RegistrationDate.Month==month) && (year == 0 || x.RegistrationDate.Year == year))
                .CountAsync();
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
