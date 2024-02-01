using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class ConfigurationItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Value { get; set; }
        public int? ParentId { get; set; }

        public ConfigurationItem Parent { get; set; }
        public List<ConfigurationItem> Children { get; set; }
    }


}
