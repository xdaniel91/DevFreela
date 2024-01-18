using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserResponse>
{
    public long IdUser { get; set; }

    public GetUserByIdQuery(long idUser)
    {
        IdUser = idUser;
    }
}
