using Crypto.API.Models.Dto;
using MediatR;

namespace Crypto.API.Queries.GetGlobalData;

public record GetGlobalDataQuery() : IRequest<GlobalDataDto>;
