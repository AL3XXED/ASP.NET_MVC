using MVP_App_Dienstintegration.Models;

namespace MVP_App_Dienstintegration.Services;

public class PersonenService
{
    private List<PersonenViewModel> personen = new List<PersonenViewModel>();

    //GET ALL
    public List<PersonenViewModel> GetAll() //=> personen
    {
        return personen;
    }
    //GET BY ID
    public PersonenViewModel? GetById(int id)
    {
        return personen.FirstOrDefault(p => p.PK == id);
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
    public void Delete(int id)
    {
        var personToDelete = GetById(id);
        if (personToDelete != null)
        {
            personen.Remove(personToDelete);
        }
    }
}
