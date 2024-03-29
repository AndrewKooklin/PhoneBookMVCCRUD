﻿using PhoneBookMVCCRUD.Domain.Entities;
using PhoneBookMVCCRUD.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookMVCCRUD.Domain.Repositories.EF
{
    public class EFPhoneBookRecordsRepository : IPhoneBookRecordRepository
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

        public PhoneBookRecord GetPhoneBookRecordById(int id)
        {
            return _context.PhoneBookRecords.FirstOrDefault(r => r.Id == id);
        }

        public void SavePhoneBookRecord(PhoneBookRecord phoneBookRecord)
        {
            if (phoneBookRecord.Id == default)
            {
                _context.Entry(phoneBookRecord).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.PhoneBookRecords.Add(phoneBookRecord);
            }
            _context.SaveChanges();
        }

        public void DeletePhoneBookRecord(int id)
        {
            _context.PhoneBookRecords.Remove(new PhoneBookRecord{Id = id });
            _context.SaveChanges();
        }

        public void EditPhoneBookRecord(PhoneBookRecord phoneBookRecord)
        {
            _context.Entry(phoneBookRecord).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           // _context.PhoneBookRecords.Update(phoneBookRecord);
            _context.SaveChanges();
        }
    }
}
