using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkSolution
{

    class Store
    {
    private List<Seller> sellers;
    internal List<Seller> Sellers { get => sellers; set => sellers = value; }

        public string Name { get; set; }
        public string Address { get; set; }      //                  Manga corta                        Manga larga
        public Shirt[] camisas = new Shirt[2] ; // camisas=[{conCuello: num, sinCuello:num},{conCuello: num, sinCuello:num}]


        public Pant pantalones; // pantalones=[{chupines:num , normales:num}]

        public Product[] products = new Product[2];
        //internal Product[] Products { get => products; }

        public void AddShirtShort(int conCuello, int sinCuello)
        {
            Shirt mangaCorta = new Shirt
            {
                CantConCuello = conCuello,
                CantSinCuello = sinCuello
            };
            camisas[0] = mangaCorta;
            
        }
         public void AddShirtLarge(int conCuello, int sinCuello)
        {
            Shirt mangaLarga = new Shirt
            {
                CantConCuello = conCuello,
                CantSinCuello = sinCuello
            };
            camisas[1] = mangaLarga;
            
        }

        public void AddPants(int chupines, int normales)
        {
            Pant pants = new Pant
            {
                CantChupines = chupines,
                CantNormales = normales
            };
            pantalones= pants;

        }
        internal class Products
        {
            public int StockTotal { get; set; }
        }


        internal class Product
        {
            public int StockTotal { get; set; }
        }

 
        internal class Pant 
        {
            public int CantChupines { get; set; }
            public int CantNormales { get; set; }
        }

        internal class Shirt
        {
                        public int CantConCuello { get; set; }
                        public int CantSinCuello { get; set; }
        
        }
   
    }
}
