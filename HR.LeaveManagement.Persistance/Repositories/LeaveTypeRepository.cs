using Azure.Core;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistance.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Repositories
{
    public class LeaveTypeRepository :  GenericRepository<LeaveType> , ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext _context) : base(_context)
        {

        }

           
        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            //this_dbcontext is coming from the generic repositaory database dependency injection
            return await _context.LeaveTypes.AnyAsync(q => q.Name == name)==false;
        }

      
    }
}
