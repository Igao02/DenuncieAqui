using DenuncieAqui.Domain.Constants;
using DenuncieAqui.DomainCore.Entities;
using System.ComponentModel.DataAnnotations;

public class Institution : Entity
{
    public Institution()
    {
        //ORM purpose
    }

    [Required(ErrorMessage = "O nome da corpora��o � obrigat�rio")]
    [StringLength(LenghtConst.MaxName, ErrorMessage = "O m�ximo de caracteres � 150")]
    public string CorporateName { get; set; } = "";

    [Required(ErrorMessage = "O documento � obrigat�rio")]
    [StringLength(LenghtConst.MaxDocNumber, ErrorMessage = "O m�ximo de caracteres � 14")]
    public string Document { get; set; } = "";

    [Required(ErrorMessage = "O endere�o � obrigat�rio")]
    [StringLength(LenghtConst.MaxAddName, ErrorMessage = "O m�ximo de caracteres � 150")]
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