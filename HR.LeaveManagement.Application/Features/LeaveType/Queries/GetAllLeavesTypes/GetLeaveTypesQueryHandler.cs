using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeavesTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveTypesQueryHandler(IMapper mapper , ILeaveTypeRepository leaveTypeRepository , IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //Query The Database 

            var leaveTypes = await leaveTypeRepository.GetAsync();


            //convert the data objects of Dto objects
            var data =mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            _logger.LogInformation("Leave tYPES WERE retrieve successfully");

            return data;
        }
    }
}

//continue = break point to break point 
//step over = next line where logic is being used or implemented 
//step into = get into the function 
