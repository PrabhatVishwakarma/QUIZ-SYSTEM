﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Shared.Models {
    public class PaginationDTO {
        public int Page { get; set; } = 1;
        public int QuantityPerPage { get; set; } = 5;
    }
}
