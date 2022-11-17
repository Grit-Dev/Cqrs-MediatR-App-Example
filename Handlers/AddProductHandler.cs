using CqrsMediatRExample.Commands;
using CqrsMediatRExample.Data;
using MediatR;

namespace CqrsMediatRExample.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddProductHandler(FakeDataStore pFakeDataStore) => _fakeDataStore = pFakeDataStore;
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            
            await _fakeDataStore.AddProduct(request._product);

            return request._product;
          
        }
    }
}
