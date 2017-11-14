using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuel.Models.Response
{
    public class ItemResponse<T>
    {
        public T Item { get; set; }
    }
}