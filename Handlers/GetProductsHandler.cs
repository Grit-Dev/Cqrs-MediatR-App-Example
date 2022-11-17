using CqrsMediatRExample.Data;
using CqrsMediatRExample.Queries;
using MediatR;

namespace CqrsMediatRExample.Handlers
{
    //To make this class a handler it needs to inherit the Iclass interface and 
    // provides two parameters
    //Get Products Query for the query we want to handle
    // IEnumerable<Product> For the type we want to return from the handler 
    public class GetProductsHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        //Example One: 
        /*
        public GetProductsHandler(FakeDataStore pFakeDataStor) => _fakeDataStore = pFakeDataStore;
        {
            _fakeDataStore = pFakeDataStor;
        }
        */
        

        //Dependency Injection: 
        //Cleaner way of doing this: 
        public GetProductsHandler(FakeDataStore pFakeDataStore) => _fakeDataStore = pFakeDataStore;

        /*
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                return await _fakeDataStore.GetAllProducts();
            }
        }*/

        //Example Two: 
        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
                => await _fakeDataStore.GetAllProducts();

   
    }
}
