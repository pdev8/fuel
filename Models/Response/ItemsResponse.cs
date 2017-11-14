using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuel.Models.Response
{
    public class ItemsResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}