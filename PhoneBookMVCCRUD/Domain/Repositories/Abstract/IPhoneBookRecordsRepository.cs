using PhoneBookMVCCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookMVCCRUD.Domain.Repositories.Abstract
{
    public interface IPhoneBookRecordsRepository
    {
        IQueryable<PhoneBookRecord> GetPhoneBookRecords();

        //Task<IQueryable<PhoneBookRecord>> GetPhoneBookRecordsAsync();
        PhoneBookRecord GetPhoneBookRecordById(int id);
    }
}
