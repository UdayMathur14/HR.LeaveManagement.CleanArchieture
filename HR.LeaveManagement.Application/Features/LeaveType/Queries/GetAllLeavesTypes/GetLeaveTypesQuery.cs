using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeavesTypes
{
    //record will take little less space than class 
    //difference between classes and records is that record is immutable :means once you define it 
    //will pretty much nothing will change 
    
    
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
   // bool a = true;
    //Irequest m se request utha rha h and then leave type return kr rha h 
}
