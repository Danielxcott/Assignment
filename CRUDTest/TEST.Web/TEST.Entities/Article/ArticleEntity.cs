using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.Entities.Article
{
    /// <summary>
    /// Defines the <see cref="ArticleEntity" />.
    /// </summary>
    public class ArticleEntity
    {
        /// <summary>
        /// Gets or sets the article id.
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Excerpt
        /// </summary>
        public string Excerpt { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleEntity"/> class.
        /// </summary>
        public ArticleEntity() {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.ArticleId = 0;
            this.CategoryId = 0;
            this.Title = string.Empty;
            this.Slug = string.Empty;
            this.Description = string.Empty;
            this.Excerpt = string.Empty;
            this.CreatedAt = DateTime.Now;
        }
    }
}
