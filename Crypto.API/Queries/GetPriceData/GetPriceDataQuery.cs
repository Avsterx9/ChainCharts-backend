using Crypto.API.Models.Dto;
using MediatR;

namespace Crypto.API.Queries.GetPriceData;

public record GetPriceDataQuery(string TokenName, int Days) : IRequest<PriceDataDto>;
