using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper , ILeaveTypeRepository leaveTypeRepository)
        {
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data 
            var validator = new CreateLeaveTypeCommandValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Any()) 
            {
                throw new BadRequestException("InValid LeaveType", validationResult);
            }


            //convert to domain entity object 

            var leavetypeToCreate = mapper.Map<Domain.LeaveType>(request);
            //add to databse 
            await leaveTypeRepository.CreateAsync(leavetypeToCreate);

            //return record id 
            return leavetypeToCreate.Id;
        }
    }
}
