using RafaelStore.Domain.StoreContext.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RafaelStore.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
           
        }
    }
}
