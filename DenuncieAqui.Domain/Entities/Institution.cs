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

    [Required(ErrorMessage = "O nome da corpora��o � obrigat�rio")]
    [StringLength(LenghtConst.MaxName, ErrorMessage = "O m�ximo de caracteres � 150")]
    public string CorporateName { get; set; } = "";

    [Required(ErrorMessage = "O documento � obrigat�rio")]
    [StringLength(LenghtConst.MaxDocNumber, ErrorMessage = "O m�ximo de caracteres � 14")]
    public string Document { get; set; } = "";

    [Required(ErrorMessage = "O CEP e obrigat�rio")]
    [StringLength(LenghtConst.MaxCep, ErrorMessage = "O m�ximo de caracteres � 10")]
    public string Cep { get; set; } = "";

    [Required(ErrorMessage = "A rua � obrigat�ria")]
    [StringLength(LenghtConst.MaxAddName, ErrorMessage = "O m�ximo de caracteres � 150")]
    public string Street { get; set; } = "";

    [Required(ErrorMessage ="O n�mero do endere�o � obrigat�rio")]
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