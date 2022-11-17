using CqrsMediatRExample.Data;
using CqrsMediatRExample.Queries;
using MediatR;
using MediatR.Wrappers;

namespace CqrsMediatRExample.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductByIdHandler(FakeDataStore pFakeDataStore) => _fakeDataStore = pFakeDataStore;
        
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetProductById(request.id);
        }
    }
}
