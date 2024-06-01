using Crypto.API.Models.Dto;
using MediatR;

namespace Crypto.API.Queries.GetWalletEstimation;

public record GetWalletEstimationQuery : IRequest<WalletEstimationDto>;
