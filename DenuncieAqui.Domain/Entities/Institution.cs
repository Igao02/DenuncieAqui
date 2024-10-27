using DenuncieAqui.Domain.Constants;
using DenuncieAqui.DomainCore.Entities;
using System.ComponentModel.DataAnnotations;

public class Institution : Entity
{
    public Institution()
    {
        //ORM purpose
    }
    //public string Address { get; set; } = "";

    [Required(ErrorMessage = "O nome da corporação é obrigatório")]
    [StringLength(LenghtConst.MaxName, ErrorMessage = "O máximo de caracteres é 150")]
    public string CorporateName { get; set; } = "";

    [Required(ErrorMessage = "O documento é obrigatório")]
    [StringLength(LenghtConst.MaxDocNumber, ErrorMessage = "O máximo de caracteres é 14")]
    public string Document { get; set; } = "";

    [Required(ErrorMessage = "O CEP e obrigatório")]
    [StringLength(LenghtConst.MaxCep, ErrorMessage = "O máximo de caracteres é 10")]
    public string Cep { get; set; } = "";

    [Required(ErrorMessage = "A rua é obrigatória")]
    [StringLength(LenghtConst.MaxAddName, ErrorMessage = "O máximo de caracteres é 150")]
    public string Street { get; set; } = "";

    [Required(ErrorMessage ="O número do endereço é obrigatório")]
    public int NumHome { get; set; } = 0;

    public DateTime? CreationDate { get; set; } = DateTime.Now;

    public string UserName { get; set; }    

    public Institution(string corporateName, string document, string cep, string street, int numHome, DateTime? creationDate, string userName) : base()
    {
        CorporateName = corporateName;
        Document = document;
        Cep = cep;
        Street = street;
        NumHome = numHome;
        CreationDate = creationDate;
        UserName = userName;
    }
}