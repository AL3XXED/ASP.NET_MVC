using MVP_App_Dienstintegration.Models;

namespace MVP_App_Dienstintegration.Services;

public class PersonenService
{
    private List<PersonenViewModel> personen = new List<PersonenViewModel>();

    public List<PersonenViewModel> GetAll() //=> personen
    {
        return personen;
    }

    public PersonenViewModel? GetById(int PK)
    {
        return personen.FirstOrDefault(p => p.PK == PK);
    }

    //CREATE
    public void Add(PersonenViewModel person)
    {
        person.PK = personen.Any() ? personen.Max(p => p.PK) + 1 : 1;
        personen.Add(person);
    }

    //UPDATE
    public void Update(PersonenViewModel person)
    {
        var existingPerson = GetById(person.PK);
        if (existingPerson != null)
        {
            existingPerson.Name = person.Name;
            existingPerson.Alter = person.Alter;
            existingPerson.Geschlecht = person.Geschlecht;
            existingPerson.Wohnort = person.Wohnort;
        }
    }

    //DELETE
    public void Delete(int PK)
    {
        var personToDelete = GetById(PK);
        if (personToDelete != null)
        {
            personen.Remove(personToDelete);
        }
    }
}
