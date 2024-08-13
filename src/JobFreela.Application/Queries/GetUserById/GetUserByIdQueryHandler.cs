using JobFreela.Application.ViewModels;
using JobFreela.Core.Repositories;
using MediatR;

namespace JobFreela.Application.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly IUserRepository _repository;
    public GetUserByIdQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        return new UserViewModel(user.FullName, user.Email, user.BirthDate);
    }
}
