using System.ComponentModel.DataAnnotations;

namespace MVP_App_Dienstintegration.Models;

public class PersonenViewModel
{
    public required int PK { get; set; }

    [Required(ErrorMessage = "Die eingabe eines Namen ist erforderlich.")]
    [StringLength(50, ErrorMessage = "Der Name darf maximal 50 Zeichen lang sein.")]
    public required string Name { get; set; }

    [Range(1,125, ErrorMessage = "Das Alter muss zwischen 1 und 125 Jahren liegen.")]
    public required int Alter { get; set; }

    [Required(ErrorMessage = "Die eingabe eines Geschlechts ist erforderlich.")]
    public required string Geschlecht { get; set; }

    [Required(ErrorMessage = "Die eingabe eines Wohnorts ist erforderlich.")]
    [StringLength(50, ErrorMessage = "Der Wohnort darf maximal 50 Zeichen lang sein.")]
    public required string Wohnort { get; set; }

}
