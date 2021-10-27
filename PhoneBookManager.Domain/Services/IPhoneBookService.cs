using PhoneBookManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookManager.Domain.Services
{
    public interface IPhoneBookService
    {
        int CreatePhoneBookEntry(Entry entry);

        bool DeletePhoneBookEntry(int Id);

        List<Entry> GetEntries();
    }
}
