using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Commands
{
    public class UpdateCompanyCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string LogoUrl { get; set; }
        public string WebSite { get; set; }
        public IList<string> PhotoUrls { get; set; }
    }
}
