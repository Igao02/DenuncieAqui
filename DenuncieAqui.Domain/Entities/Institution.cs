using DenuncieAqui.Domain.Constants;
using DenuncieAqui.DomainCore.Entities;
using System.ComponentModel.DataAnnotations;

public class Institution : Entity
{
    public Institution()
    {
        //ORM purpose
    }

    [Required(ErrorMessage = "O nome da corporação é obrigatório")]
    [StringLength(LenghtConst.MaxName, ErrorMessage = "O máximo de caracteres é 150")]
    public string CorporateName { get; set; } = "";

    [Required(ErrorMessage = "O documento é obrigatório")]
    [StringLength(LenghtConst.MaxDocNumber, ErrorMessage = "O máximo de caracteres é 14")]
    public string Document { get; set; } = "";

    [Required(ErrorMessage = "O endereço é obrigatório")]
    [StringLength(LenghtConst.MaxAddName, ErrorMessage = "O máximo de caracteres é 150")]
    public string Address { get; set; } = "";

    public DateTime? CreationDate { get; set; } = DateTime.Now;

    public string UserName { get; set; }    

    public Institution(string corporateName, string document, string address, DateTime? creationDate, string userName) : base()
    {
        CorporateName = corporateName;
        Document = document;
        Address = address;
        CreationDate = creationDate;
        UserName = userName;
    }

    
}