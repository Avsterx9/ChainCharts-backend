using Crypto.API.Models.Dto;
using MediatR;

namespace Crypto.API.Queries.GetCGTokens;

public sealed class GetCGTokensQueryHandler : IRequestHandler<GetCGTokensQuery, IEnumerable<CryptoTokenDto>>
{
    

    public Task<IEnumerable<CryptoTokenDto>> Handle(GetCGTokensQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
