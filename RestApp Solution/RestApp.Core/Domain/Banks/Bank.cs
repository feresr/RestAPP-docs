using System;

namespace RestApp.Core.Domain.Banks
{
    public class Bank : BaseEntity
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public string Account { get; set; }

        public bool Enabled { get; set; }
    }
}
