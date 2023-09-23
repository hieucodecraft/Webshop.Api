using System.ComponentModel.DataAnnotations.Schema;

namespace Webshop.Api
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
