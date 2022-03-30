using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCliente.Models
{
    [Table("Cliente", Schema = "Adm")]
    public class Cliente
    {
        [Key]
        [Column(TypeName ="varchar(10)")]
        [Required]
        public string codCliente { get; set; }

        [Column(TypeName ="varchar(40)")]
        [Required(ErrorMessage ="")]
        public string nombreCompleto { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string nombreCorto { get; set; }

        [Column(TypeName = "varchar(40)")]
        [Required]
        public string Abreviatura { get; set; }

        [Column(TypeName = "varchar(11)")]
        [Required]
        public string RUC { get; set; }

        [Column(TypeName = "char(1)")]
        [Required]
        public string estado{ get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? grupoFacturacion { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? inactivoDesde { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigoSAP { get; set; }

    }


    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.codCliente)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Debe ingresar el {PropertyName}.")
                .MaximumLength(10);
            RuleFor(x => x.nombreCompleto)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Debe ingresar el {PropertyName}.")
                .MaximumLength(200);
            RuleFor(x => x.nombreCorto)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Debe ingresar el {PropertyName}.")
                .MaximumLength(40);
            RuleFor(x => x.Abreviatura)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Debe ingresar la {PropertyName}.")
                .MaximumLength(40);
            RuleFor(x => x.RUC)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Debe ingresar el {PropertyName}.")
                .Length(11,11)
                .Must(IsValidNumber).WithMessage("{PropertyName} solo permite numeros.");
            RuleFor(x => x.estado)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Debe ingresar el {PropertyName}.")
                .Length(1,1);
            RuleFor(x => x.grupoFacturacion).MaximumLength(100);
            RuleFor(x => x.inactivoDesde);
            RuleFor(x => x.codigoSAP).MaximumLength(20);
        }


        private bool IsValidNumber(string number)
        {
            return number.All(Char.IsNumber);
        }

    }

    
}
