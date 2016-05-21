﻿using System.Collections.Generic;

namespace Coffsy.Application.ViewModels
{
    public class DTResults<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}
