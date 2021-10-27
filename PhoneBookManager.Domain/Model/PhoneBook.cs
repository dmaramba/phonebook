using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookManager.Domain.Model
{
   public class PhoneBook
    {
        public PhoneBook()
        {
            this.Entries = new List<Entry>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }

    }
}
