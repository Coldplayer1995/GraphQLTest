using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace BerryClient
{
    public class GetHeroOperation
        : IOperation<IGetHero>
    {
        public string Name => "getHero";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetHero);

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            return Array.Empty<VariableValue>();
        }
    }
}
