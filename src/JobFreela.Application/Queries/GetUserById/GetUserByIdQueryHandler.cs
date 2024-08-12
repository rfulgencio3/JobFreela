using JobFreela.Application.ViewModels;
using JobFreela.Infra.Persistence;
using MediatR;

namespace JobFreela.Application.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly JobFreelaDbContext _context;
    public GetUserByIdQueryHandler(JobFreelaDbContext context)
    {
        _context = context;
    }

    public Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
