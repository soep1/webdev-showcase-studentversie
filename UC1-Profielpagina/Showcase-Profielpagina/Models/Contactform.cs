using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Showcase_Profielpagina.Models;

public class Contactform
{
    [Required]
    [StringLength(60)]
    public string FirstName {  get; set; }

    [Required]
    [StringLength(60)]
    public string LastName {  get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string Phone { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Subject { get; set; }
    
    [Required]
    [StringLength(600)]
    public string Content { get; set; }
    
    [ValidateNever]
    public string Message { get; set; }
}