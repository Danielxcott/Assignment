using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Salutation
{
    /// <summary>
    /// Defines the <see cref="SalutationEntity" />.
    /// </summary>
    public class SalutationEntity
    {
        /// <summary>
        /// Gets or sets the salutation id.
        /// </summary>
        public int SalutationId { get; set; }

        /// <summary>
        /// Gets or sets the salutation.
        /// </summary>
        public string Salutation { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieEntity"/> class.
        /// </summary>
        public SalutationEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.SalutationId= 0;
            this.Salutation= string.Empty;
        }
    }
}
