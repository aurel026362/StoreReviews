﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Commands
{
    public class CreateShopCommand : IRequest<long>
    {
        public string Adress { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public long CompanyId { get; set; }
    }
}
