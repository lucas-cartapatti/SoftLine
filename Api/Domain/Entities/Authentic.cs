using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain;

[Table("Authentic")]
public class Authentic : EntityBase<Authentic>
{
    [Column(nameof(Username))]
    [MaxLength(50)]
    public string Username { get; set; }

    [Column(nameof(Password))]
    [MaxLength(150)]
    public string Password { get; set; }

    [Column(nameof(Email))]
    [MaxLength(100)]
    public string Email { get; set; }

    [Column(nameof(Active))]  
    public bool Active { get; set; }

    [Column(nameof(DateCreation))]
    public DateTime DateCreation { get; set; }

    public Authentic()
    {
        this.Username = string.Empty;
        this.Password = string.Empty;
        this.Email = string.Empty;
        this.Active = true;
        this.DateCreation = DateTime.Now;
    }
}