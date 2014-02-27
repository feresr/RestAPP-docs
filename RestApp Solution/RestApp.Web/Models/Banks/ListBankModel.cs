using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApp.Web.Framework;

namespace RestApp.Web.Models.Banks
{
    public class ListBankModel
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