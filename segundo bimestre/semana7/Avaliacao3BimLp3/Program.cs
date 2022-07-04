using Avaliacao3BimLp3.Database;
using Avaliacao3BimLp3.Models;
using Avaliacao3BimLp3.Repositories;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var productRepository = new ProductRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Product")
{
    if(modelAction == "New")
    {
        var id =  Convert.ToInt32(args[2]);

        if(productRepository.ExistsById(id))
        {
            Console.WriteLine($"Produto com Id {id} já existe");
        }

        else 
        {
            var name = args[3];
            var price =  Convert.ToDouble(args[4]);
            var active = Convert.ToBoolean(args[5]);

            var product = productRepository.Save(new Product(id, name, price, active));

            Console.WriteLine($"Produto {product.Name} cadastrado com sucesso");
        }

        
    }

    if(modelAction == "List")
    {
        var products = productRepository.GetAll();
        if(products.Count() == 0)
        {
            Console.WriteLine($"Nenhum produto cadastrado");
        }
        else
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.Active}");
            }
        }
    }

    if(modelAction == "Delete")
    {
        var id =  Convert.ToInt32(args[2]);

        if(productRepository.ExistsById(id))
        {
            productRepository.Delete(id);

            Console.WriteLine($"Produto {id} removido com sucesso");
        }

        else 
        {

            Console.WriteLine($"Produto {id} não encontrado");
        }
    }
}
