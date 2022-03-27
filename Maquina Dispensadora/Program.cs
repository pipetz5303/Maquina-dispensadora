using BD;
using Microsoft.EntityFrameworkCore;



//creacion del options builder con la cadena de conexion
DbContextOptionsBuilder<MaquinaDispensadoraContext> optionsBuilder = new DbContextOptionsBuilder<MaquinaDispensadoraContext>();
optionsBuilder.UseSqlServer("Server=FELIPE-DESKTOP\\SQLEXPRESS; Database=MaquinaDispensadora; Trusted_Connection= True;");


//variables auxiliares para usar en el menu
int option = 0;
bool repeat = true;


do
{
    ShowMenu();
    try
    {
        option = int.Parse(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.Clear();
        Console.WriteLine("Escoja un numero valido\n"+e.Message);
    }
    

    switch (option)
    {
        case 1:
            //Seleccionar productos
            //muestra productos agregados
            ShowProducts(optionsBuilder);

            break;
        case 2:
            //agregar producto
            //primero muestra las marcas disponibles para elegir
            Console.Clear();
            Console.WriteLine("Agregar productos\nEscriba el numero de la marca\n");
            ShowBrands(optionsBuilder);

            int brandSelected = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Escriba el nombre del producto");
            string productName = Console.ReadLine();

            Console.WriteLine("Escriba el precio del producto");
            int productPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese las unidades a agregar");
            int productTotal = int.Parse(Console.ReadLine());

            //Producto product = new Producto(brandSelected,productName,productPrice,productTotal);

            //AddProduct(product);//AddProduct();

            break;
        case 3:

            break;
        case 4:

            break;
        case 5:
            Console.WriteLine("Saliendo.");
            repeat = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("Escoger una opcion valida del menu");
            
            break;


    }


} while (repeat);

//crea la conexion para la consulta, trae 
static void ShowProducts(DbContextOptionsBuilder<MaquinaDispensadoraContext> optionsBuilder)
{

    using (MaquinaDispensadoraContext context = new MaquinaDispensadoraContext(optionsBuilder.Options))
    {
        var products = context.Productos.ToList();
        Console.WriteLine("Productos disponibles");
        //Por si la lista esta vacia
        if(products.Count >0)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{product.IdProducto}: {product.Nombre} ${product.Precio} Unidades: {product.UnidadesDisp}");
            }
            
        }
        else
        {
            Console.WriteLine("Aun no hay produtos agregados");
        }
       

    }
}


//Muestra en una lista todas las marcas 
static void ShowBrands(DbContextOptionsBuilder<MaquinaDispensadoraContext> optionsBuilder)
{

    using (MaquinaDispensadoraContext context = new MaquinaDispensadoraContext(optionsBuilder.Options))
    {
        var brands = context.Marcas.ToList();

       foreach (var product in brands)
            {
                Console.WriteLine($"{product.IdMarca}: {product.Nombre}");
            }
     }
}


static void AddProduct(Producto product)
{

};




//Muestra el menu de opciones para que el usuario elige
static void ShowMenu() {
    
    Console.WriteLine("\n------MAQUINA DISPENSADORA------");
    Console.WriteLine("--------------MENU--------------");
    Console.WriteLine("1- Seleccionar producto");
    Console.WriteLine("2- Agregar producto");
    Console.WriteLine("3- Recargar producto");
    Console.WriteLine("4- Eliminar producto");
    Console.WriteLine("5- Salir");
}

