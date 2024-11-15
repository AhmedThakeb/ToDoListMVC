using System.ComponentModel.DataAnnotations;

namespace ToDoListMVC.Entities
{
	public class Activety
	{
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }

    }
}
