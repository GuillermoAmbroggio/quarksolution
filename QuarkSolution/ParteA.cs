using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkSolution
{
    class Seller
    {
        public static int code_seller = 1;
        public static int idQuote = 1;

        public string Name { get; set; }
        public string Last_name { get; set; }

        public int Code_Seller_Id { get; set; }

        private List<Quote> quotes = new List<Quote>();
        internal List<Quote> Quotes { get => quotes; }
        public void Cotizar(Store.Shirt[] camisas, Store.Pant pantalones)
        {
            Quote quote = new Quote();
            quote.Id = idQuote;
            DateTime fecha = DateTime.Now;
            quote.Dates = fecha;
            quote.Code_seller = Code_Seller_Id;
            
            Console.WriteLine("¿Que producto quieres cotizar?:");
            Console.WriteLine(@"1-Pantalon
2-Camisa");
            int op = int.Parse(Console.ReadLine());
            bool isStandard = true;

            if (op == 1 && pantalones != null || op == 2 && camisas != null)
            {
                switch (op)
                {
                    case 1:
                        Console.WriteLine("¿Que tipo de pantalon quieres cotizar?:");
                        quote.Name_clothing = "Pantalon";
                        bool isChupin = true;
                        Console.WriteLine(@"1-Normal
2-Chupin");
                        int opPant = int.Parse(Console.ReadLine());
                        if (opPant == 1)
                        {
                            isChupin = false;
                        }
                        Console.WriteLine("¿Que tipo de calidad quieres cotizar?:");
                        Console.WriteLine(@"1-Standard
2-Premium");
                        int opCalid = int.Parse(Console.ReadLine());
                        if (opCalid == 2)
                        {
                            isStandard = false;
                        }
                        Console.WriteLine("Ingrese cantidad de pantalones a cotizar:");
                        int cantPant = int.Parse(Console.ReadLine());
                        if(isChupin && cantPant > pantalones.CantChupines)
                        {
                            Console.WriteLine("No hay suficiente stock de ese producto (Stock: {0})",pantalones.CantChupines);
                            break;
                        }
                        if (!isChupin && cantPant > pantalones.CantNormales)
                        {
                            Console.WriteLine("No hay suficiente stock de ese producto (Stock: {0})",pantalones.CantNormales);
                            break;
                        }
                        quote.Quantity_clothing = cantPant;
                        Console.WriteLine("Ingrese precio unitario:");
                        int pricePant = int.Parse(Console.ReadLine());
                        if (isChupin && isStandard) //eligio tipo chupin standard
                        {
                            quote.Type_clothing = "Chupin Standard";
                            quote.Total = (pricePant - (pricePant * 0.12)) * cantPant;
                        }
                        else if (isChupin && isStandard == false)//eligio tipo chupin premium
                        {
                            quote.Type_clothing = "Chupin Premium";
                            quote.Total = (pricePant - (pricePant * 0.12)) * cantPant * 1.3;
                        }
                        else if (isChupin == false && isStandard == false) //eligio tipo comun premium
                        {
                            quote.Type_clothing = "Normal Premium";
                            quote.Total = pricePant * cantPant * 1.3;
                        }
                        else //eligio tipo comun standard
                        {
                            quote.Type_clothing = "Comun Standard";
                            quote.Total = pricePant * cantPant;
                        }
                        Console.WriteLine("El resultado de la cotizacion es: {0}", quote.Total);
                        quotes.Add(quote);
                        break;
                    case 2:
                        Console.WriteLine("¿Que tipo de camisa quieres cotizar?:");
                        quote.Name_clothing = "Camisa";
                        bool isMangaCorta = true;
                        bool isCulloMao = true;
                        Console.WriteLine(@"1-Mangas cortas
2-Mangas Largas");
                        int opCam = int.Parse(Console.ReadLine());
                        if (opCam == 2)
                        {
                            isMangaCorta = false;
                        }
                        Console.WriteLine("¿Que tipo de calidad quieres cotizar?:");
                        Console.WriteLine(@"1-Standard
2-Premium");
                        int opCalidCam = int.Parse(Console.ReadLine());
                        if (opCalidCam == 2)
                        {
                            isStandard = false;
                        }
                        Console.WriteLine("¿Que tipo de cuello tiene la camisa?:");
                        Console.WriteLine(@"1-Comun
2-Cuello Mao");
                        int opCuelloCam = int.Parse(Console.ReadLine());
                        if (opCuelloCam == 1)
                        {
                            isCulloMao = false;
                        }
                        Console.WriteLine("Ingrese cantidad de camisas a cotizar:");
                        int cantCam = int.Parse(Console.ReadLine());
                        if (isMangaCorta && isCulloMao && cantCam > camisas[0].CantConCuello) 
                        {
                            Console.WriteLine("No hay suficiente stock de ese producto (Stock: {0})", camisas[0].CantConCuello);
                            break;
                        }
                        if (isMangaCorta && !isCulloMao && cantCam > camisas[0].CantSinCuello)
                        {
                            Console.WriteLine("No hay suficiente stock de ese producto (Stock: {0})", pantalones.CantNormales);
                            break;
                        }
                        if (!isMangaCorta && !isCulloMao && cantCam > camisas[1].CantSinCuello || !isMangaCorta && isCulloMao && cantCam > camisas[1].CantConCuello)
                        {
                            Console.WriteLine("No hay suficiente stock de ese producto (Stock: {0})", pantalones.CantNormales);
                            break;
                        }
                        quote.Quantity_clothing = cantCam;
                        Console.WriteLine("Ingrese precio unitario:");
                        int priceCam = int.Parse(Console.ReadLine());
                        if (isMangaCorta && isStandard && !isCulloMao) //eligio camisa Mcorta standard s/cuello
                        {
                            quote.Type_clothing = "Manga Corta Standard";
                            quote.Total = (priceCam - (priceCam * 0.1)) * cantCam;
                        }
                        else if (isMangaCorta && isStandard && isCulloMao) //eligio Mcorta camisa standard c/cuello
                        {
                            quote.Type_clothing = "Manga corta Standard con Cuello Mao";
                            quote.Total = (priceCam - (priceCam * 0.1)) * cantCam * 1.03;
                        }
                        else if (isMangaCorta && !isStandard && !isCulloMao) //eligio Mcorta camisa premium s/cuello
                        {
                            quote.Type_clothing = "Manga corta Premium";
                            quote.Total = (priceCam - (priceCam * 0.1)) * cantCam * 1.3;
                        }
                        else if (isMangaCorta && !isStandard && isCulloMao) //eligio Mcorta camisa premium c/cuello
                        {
                            quote.Type_clothing = "Manga corta Premium con cuello Mao";
                            quote.Total = (priceCam - (priceCam * 0.1)) * cantCam * 1.03 * 1.3;
                        }
                        else if (!isMangaCorta && isStandard && isCulloMao) //eligio Mlarga camisa standard c/cuello
                        {
                            quote.Type_clothing = "Manga larga standard con cuello Mao";
                            quote.Total = (priceCam) * cantCam * 1.03;
                        }
                        else if (!isMangaCorta && !isStandard && !isCulloMao) //eligio Mlarga camisa premium s/cuello
                        {
                            quote.Type_clothing = "Manga larga Premium";
                            quote.Total = (priceCam) * cantCam * 1.3;
                        }
                        else if (!isMangaCorta && !isStandard && isCulloMao) //eligio Mlarga camisa premium c/cuello
                        {
                            quote.Type_clothing = "Manga larga Premium con cuello Mao";
                            quote.Total = (priceCam) * cantCam * 1.3 * 1.03;
                        }
                        else //eligio Mlarga comun standard
                        {
                            quote.Type_clothing = "Manga larga Standard";
                            quote.Total = priceCam * cantCam;
                        }
                        Console.WriteLine("El resultado de la cotizacion es: {0}", quote.Total);
                        quotes.Add(quote);
                        break;
                    default: Console.Write("Se ingreso un valor fuera de rango");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No hay stock de ese producto");
            }
        }

        public Seller()
        {
            /*  Console.WriteLine($"Ingresar Nombre del Vendedor {code_seller}: ");
              Name = Console.ReadLine();
              Console.WriteLine($"Ingresar Apellido del Vendedor {code_seller}: ");
              Last_name = Console.ReadLine();
            */
            Code_Seller_Id = code_seller;
            code_seller++;
        }



        internal class Quote
        {
            public int Id { get; set; }

            public DateTime Dates { get; set; }
            public int Code_seller { get; set; }
            public string Name_clothing { get; set; }
            public string Type_clothing { get; set; }

            public int Quantity_clothing { get; set; }

            public double Total { get; set; }


        }
    }
}
