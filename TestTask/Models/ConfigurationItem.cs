using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class ConfigurationItem
    {
        [Key]
        public string Name { get; set; }
        public string? Value { get; set; }

        public List<ConfigurationItem> Children { get; set; }
    }


}
