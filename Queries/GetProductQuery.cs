using CqrsMediatRExample.Data;
using MediatR;

namespace CqrsMediatRExample.Queries
{
    //The IRquest simple has product as Parameter
    //Ienum - simple iteration over the defined type.
    public class GetProductQuery : IRequest<IEnumerable<Product>> 
    {
    }
}
