using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Domain
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        //public User CreatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public long? UpdatedById { get; set; }
        //public User UpdatedBy { get; set; }

        protected Entity()
        {
            CreatedDate = DateTimeOffset.Now;
            UpdatedDate = DateTimeOffset.Now;
        }
    }
}
