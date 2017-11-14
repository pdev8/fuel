using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.Models.Response
{
    public class ItemsResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}