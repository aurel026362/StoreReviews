using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.DtoModels
{
    public class CompanyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public float Ratting { get; set; }
    }
}
