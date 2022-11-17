using CqrsMediatRExample.Data;
using MediatR;

namespace CqrsMediatRExample.Commands
{
    public record AddProductCommand(Product _product) : IRequest<Product>; 

}
