using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace BerryClient
{
    public class StarWarsClient
        : IStarWarsClient
    {
        private const string _clientName = "StarWarsClient";

        private readonly IOperationExecutor _executor;

        public StarWarsClient(IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public Task<IOperationResult<IGetHero>> GetHeroAsync(
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetHeroOperation(),
                cancellationToken);
        }

        public Task<IOperationResult<IGetHero>> GetHeroAsync(
            GetHeroOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
