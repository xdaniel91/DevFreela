using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<LoginResponse>
{
    public long IdUser { get; set; }

    public GetUserByIdQuery(long idUser)
    {
        IdUser = idUser;
    }
}
