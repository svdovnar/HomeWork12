using System;
using ClassLibrary;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        public class ProductHandler 
        {
            // класс должен уметь сортировать магазины в алфавитном порядке
            // класс должен по названию магазина уметь по запросу возвращать все продукты магазина
            // если такого магазина нету, то должен выбрасываться exception

            private Product[] _allProducts;
            public ProductHandler(Product[] allProducts)
            {
                _allProducts = allProducts;
            }
            public string PrintProductsByStore(string storeName )
            {
                var products = _allProducts.Where(p => p.StoreName == storeName).ToArray();
                string result = string.Empty;
                if(products.Length > 0)
                {
                    for (int i = 0; i < products.Length; i++)
                    {
                        result += products[i];
                        result += Environment.NewLine;
                    }
                }
                else 
                {
                    throw new ProductException("Магазина с таким названием не существует!");
                }
                return result;
            }
            public string PrintOrderedProducts()
            {
                string result = string.Empty;
                var orderedProducts = _allProducts.OrderBy(p => p.StoreName).ToArray();
                foreach (var item in orderedProducts)
                {
                    result += item;
                    result += Environment.NewLine; 
                }
                return result;
            }
            public string PrintStroreByProduct(string productName)
            {
                // Точно также как с магазином,только теперь ищем по продуктом магазины и выдаем exception, если нет такого товара в магазине
                var filteredProducts = _allProducts.Where(p => p.ProductNames.Contains(productName)).ToArray();

                string result = string.Empty;
                if (filteredProducts.Length > 0)
                {
                    for (int i = 0; i < filteredProducts.Length; i++)
                    {
                        result += filteredProducts[i];
                        result += Environment.NewLine;
                    }
                }
                else
                {
                    throw new ProductException("Продукта с таким названием не существует!");
                }
                return result;
            }
               
        }
        public static void Main(string[] args)
        {
            Product[] products = new Product[5]
            {
                new Product("Евроопт","рыба", "свинина", "говядина", "сосиски"),
                new Product("Виталюр","рыба", "огурцы", "помидоры", "молоко", "капуста"),
                new Product("Санта", "сыр", "хлеб", "молоко", "пельмени"),
                new Product("Грин","батон", "яйца", "творог"),
                new Product("Соседи", "хлеб", "суши", "молоко", "виноград", "яблоки", "арбуз")
            };


            ProductHandler productHandler = new ProductHandler(products);

            Console.WriteLine("Отсортированный массив:");
            Console.WriteLine(productHandler.PrintOrderedProducts());
            
            Console.WriteLine();

            Console.WriteLine("Введите название искомого магазина:");
            string nameOfStore = Console.ReadLine();
            try
            {
                Console.WriteLine(productHandler.PrintProductsByStore(nameOfStore));  
            }
            catch (ProductException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine();

            Console.WriteLine("Введите название искомого продукта:");
            string productName = Console.ReadLine();
            try
            {
                Console.WriteLine(productHandler.PrintStroreByProduct(productName));
            }
            catch (ProductException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadKey();
        }
    }
}
