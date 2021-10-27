using PhoneBookManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PhoneBookManager.Domain.Services
{
    public class PhoneBookService : IPhoneBookService
    {

        private readonly PhoneBookDbContext _phoneBookDbContext;

        public PhoneBookService(PhoneBookDbContext transactionDbContext)
        {
            _phoneBookDbContext = transactionDbContext;
            _phoneBookDbContext.Database.EnsureCreated();
        }

        public int CreatePhoneBookEntry(Entry entry)
        {
            var existEntry = _phoneBookDbContext.Entries.FirstOrDefault(x => x.Name == entry.Name || x.PhoneNumber == entry.PhoneNumber);
            if (existEntry != null)
                return 0;
            _phoneBookDbContext.Entries.Add(entry);
            _phoneBookDbContext.SaveChanges();
            return entry.Id;
        }


        public bool DeletePhoneBookEntry(int Id)
        {
            var entry = _phoneBookDbContext.Entries.FirstOrDefault(x => x.Id.Equals(Id));
            if (entry != null)
            {
                _phoneBookDbContext.Entries.Remove(entry);
                _phoneBookDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Entry> GetEntries()
        {
            return _phoneBookDbContext.Entries.ToList();
        }


    }
}
