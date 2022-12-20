using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.Entities.Category
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedAt { get; set; }

        public CategoryEntity (){
            InitializedObjectValue();
         }
        internal void InitializedObjectValue()
        {
            this.CategoryId = 0;
            this.Name = string.Empty;
            this.Slug = string.Empty;
            this.CreatedAt = DateTime.Now;
        }
    }
}
