using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManager.Domain
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets Id of given entity
        /// </summary>
        /// <value>
        /// Id of given entity
        /// </value>
        public int Id { get; set; }
    }
}
