using Newsier.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
