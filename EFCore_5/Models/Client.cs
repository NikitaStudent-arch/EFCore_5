using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Имя клиента обязательно для заполнения")]
    [MaxLength(50, ErrorMessage = "Имя клиента должно содержать не более 50 символов")]
    public string Name { get; set; }

    [EmailAddress(ErrorMessage = "Введите корректный адрес электронной почты")]
    public string Email { get; set; }
}
