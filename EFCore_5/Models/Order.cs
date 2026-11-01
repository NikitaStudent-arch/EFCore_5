using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Идентификатор клиента обязателен для заполнения")]
    public int ClientId { get; set; }

    [ForeignKey("ClientId")]
    public Client Client { get; set; }

    public ICollection<Product> Products { get; set; }
}
