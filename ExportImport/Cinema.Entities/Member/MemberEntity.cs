using System;

namespace Cinema.Entities.Member
{
    /// <summary>
    /// Defines the <see cref="MemberEntity" />.
    /// </summary>
    public class MemberEntity
    {
        /// <summary>
        /// Gets or sets the member id.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the movie id.
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// Gets or sets the salutation id.
        /// </summary>
        public int SalutationId { get; set; }

        /// <summary>
        /// Gets or sets the fullname.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberEntity"/> class.
        /// </summary>
        public MemberEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.MemberId = 0;
            this.MovieId = 0;
            this.SalutationId = 0;
            this.FullName = string.Empty;
            this.Address = string.Empty;
        }


    }
}
