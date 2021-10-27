using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PhoneBookManager.Domain.Model
{
   public class Entry
    {
        public int Id { get; set; }

        public int PhoneBookId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public virtual PhoneBook PhoneBook { get; set; }
    }
}
