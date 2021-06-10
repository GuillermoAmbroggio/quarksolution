using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkSolution
{
    class QuarkSolution
    {
        static void Main(string[] args)
        {
            Store store1 = new Store();
            store1.Name = "tienda1";
            store1.Address = "direccion de tienda1";
            store1.AddShirtLarge(150, 350);
            store1.AddShirtShort(200, 300);
            store1.AddPants(1500, 500);
            //Console.WriteLine(store1.camisas[0].CantConCuello);


            Seller vendedor1 = new Seller();
            vendedor1.Name = "Guillermo";
            vendedor1.Last_name = "Ambroggio";
            Console.WriteLine($"Los datos del vendedor son: {vendedor1.Name} {vendedor1.Last_name} - id: {vendedor1.Code_Seller_Id} ");
            int opciones = 1;

            while (opciones != 0)
            {
                Console.WriteLine(@"¿Que operacion quiere realziar? :
                0-Salir
                1-Cotizar
                2-Ver Historial de cotizaciones");
                opciones = int.Parse(Console.ReadLine());
                switch (opciones)
                {
                    case 0:
                        Console.WriteLine("Gracias por usar el programa, adios!");
                        break;
                    case 1:
                        vendedor1.Cotizar(store1.camisas, store1.pantalones);
                        break;
                    case 2:
                        Console.WriteLine("Estas son las cotizaciones echas hasta el momento por {0}:", vendedor1.Name);
                        vendedor1.Quotes.ForEach(e => Console.WriteLine($"Id:{e.Id}- Fecha: {e.Dates} -Codigo de Vendedor: {e.Code_seller} -Nombre Producto: {e.Name_clothing} {e.Type_clothing} -Cantidad: {e.Quantity_clothing} -Total Cotizacion: {e.Total}"));
                        break;
                    default:
                        Console.WriteLine("Ingreso un valor fuera de rango");
                        break;
                }

            }

            //Seller vendedor2 = new Seller();
            //Seller vendedor3 = new Seller();

            //vendedor1.Cotizar(store1.products);

            Console.ReadKey();
        }
    }
}
