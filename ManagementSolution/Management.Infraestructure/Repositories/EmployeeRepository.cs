using Management.Infraestructure.DTO;
using Management.Infraestructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Management.Infraestructure.Repositories
{
    public class EmployeeRepository : Repository<EmployeeDTO>, IEmployeeRepository
    {

        public EmployeeRepository(EnterpriseContext enterpriseContext) : base(enterpriseContext)
        { }

        public override List<EmployeeDTO> List()
        {
            return this._dbContext.Set<EmployeeDTO>().Include(d => d.Dependents).ToList();
        }

        public override void Save(EmployeeDTO Entity)
        {
            base.Save(Entity);

            this._dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.FindById(id);

            base.Delete(entity);

            this._dbContext.SaveChanges();
        }

        public override EmployeeDTO FindById(int Id)
        {
            return this._dbContext.Set<EmployeeDTO>().Include(d => d.Dependents).Where(e => e.Id == Id).FirstOrDefault();
        }

        public override void Update(EmployeeDTO Entity)
        {
            base.Update(Entity);

            this._dbContext.SaveChanges();
        }

        public (List<EmployeeDTO> employeesDTO, List<DependentDTO> dependentsDTO) BirthdaysOfTheMonth()
        {
            var employeesDTO = this._dbContext.Set<EmployeeDTO>().Where(e => e.Birthdate.Month == DateTime.Now.Month).ToList();
            var dependentsDTO = this._dbContext.Set<DependentDTO>().Where(d => d.Birthdate.Month == DateTime.Now.Month).ToList();

            return (employeesDTO, dependentsDTO);

        }
    }
}
