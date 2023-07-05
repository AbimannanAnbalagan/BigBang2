using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Patients
{
    public interface IPatients
    {
        Task<List<Patient>> getbyname(string name);

    }
}
