using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace financeiro.Models.Filters
{
    public class ContaFilter
    {

        public List<Conta> Conta { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public int TotalPages => (TotalRecords + PageSize - 1) / PageSize;
    }
}