using System;
using System.Linq;
using RestApp.Web.Framework;

namespace RestApp.Web.Models.Banks
{
    public class BankModel
    {
        public int Id { get; set; }

        [RestAppResourceDisplayName("Model.Bank.Code")]
        public int Code { get; set; }

        [RestAppResourceDisplayName("Model.Bank.Name")]
        public string Name { get; set; }

        [RestAppResourceDisplayName("Model.Bank.Account")]
        public string Account { get; set; }

        [RestAppResourceDisplayName("Model.Bank.Enabled")]
        public bool Enabled { get; set; }
    }
}