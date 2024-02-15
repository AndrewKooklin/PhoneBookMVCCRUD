using PhoneBookMVCCRUD.Domain.Entities;
using PhoneBookMVCCRUD.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookMVCCRUD.Domain.Repositories.EF
{
    public class EFPhoneBookRecordsRepository : IPhoneBookRecordsRepository
    {
        private readonly AppDBContext _context;

        public EFPhoneBookRecordsRepository(AppDBContext context)
        {
            _context = context;
        }

        public IQueryable<PhoneBookRecord> GetPhoneBookRecords()
        {
            return _context.PhoneBookRecords;
        }

        //public async Task<IQueryable<PhoneBookRecord>> GetPhoneBookRecordsAsync()
        //{
        //    List<PhoneBookRecord> bookRecords = new List<PhoneBookRecord>();
        //    await foreach(var item in _context.PhoneBookRecords)
        //    {
        //        bookRecords.Add(item);
        //    }
            
        //    return  bookRecords.AsQueryable<PhoneBookRecord>();
        //}

        public PhoneBookRecord GetPhoneBookRecordById(int id)
        {
            return _context.PhoneBookRecords.FirstOrDefault(r => r.Id == id);
        }
    }
}
