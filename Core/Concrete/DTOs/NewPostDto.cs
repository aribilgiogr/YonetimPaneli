using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.DTOs
{
    public class NewPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
    }

    public class UpdatePostDto
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsDraft { get; set; } = true;
    }
}
