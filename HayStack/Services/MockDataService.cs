using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HayStack.Models;

namespace HayStack.Services
{
    public class MockDataService : IContactDataService
    {
        private IEnumerable<Contact> _contacts;

        public MockDataService()
        {
            _contacts = new List<Contact>()
            {
                new Contact
                {
                    Name = "Isaac Tan",
                    PhoneNumbers = new string[]
                    {
                        "111-111-1111",
                        "222-222-2222"
                    },
                    Emails = new string[]
                    {
                        "isaactan@personal.com",
                        "isaactan@business.com"
                    },
                    Locations = new string[]
                    {
                        "111 Fake Street",
                        "222 Fake Ave"
                    }
                },
                new Contact
                {
                    Name = "Issy Tan",
                    PhoneNumbers = new string[]
                    {
                        "333-333-3333",
                        "444-444-4444"
                    },
                    Emails = new string[]
                    {
                        "issytan@personal.com",
                        "issytan@business.com"
                    },
                    Locations = new string[]
                    {
                        "111 Fake Street",
                        "222 Fake Ave"
                    }
                },
            };
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            _contacts = contacts;
        }
    }
}
