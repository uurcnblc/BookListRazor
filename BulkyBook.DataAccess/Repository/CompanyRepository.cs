using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System.Linq;

namespace BulkyBook.DataAccess.Repository
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {

        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            var objFromDb = _db.Companies.FirstOrDefault(x => x.Id == company.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = company.Name;
                objFromDb.StreetAddress = company.StreetAddress;
                objFromDb.State = company.State;
                objFromDb.PhoneNumber = company.PhoneNumber;
                objFromDb.PostalCode = company.PostalCode;
                objFromDb.City = company.City;
                objFromDb.IsAuthorizedCompany = company.IsAuthorizedCompany;

            }
        }
    }
}
