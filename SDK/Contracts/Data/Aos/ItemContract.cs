using System.ComponentModel.DataAnnotations;

namespace Core.Contract.V3.Aos
{
    public class ItemContract
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Code { get; set; }

        public int Count { get; set; }

        public int TargetId { get; set; }
    }
}
