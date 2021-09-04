using System;

namespace ClassLibrary
{
    public struct Product 
    {
        private string[] _productNames;
        private string _storeName;

        public Product(string storeName, params string[] name)
        {
            _productNames = name;
            _storeName = storeName;
        }
        public string[] ProductNames
        {
            get { return _productNames; }
            set { _productNames = value; }
        }
        public string StoreName
        {
            get { return _storeName; }
            set { _storeName = value; }
        }
        public override string ToString()
        {
            string productList = string.Empty;
            foreach (var name in _productNames)
            {
                productList += $"\t {name}";
                productList += Environment.NewLine;
            }
            return $"Магазин: {_storeName}\n" +
                $"Продукты:----- \n{productList}";
        }
       
    }  
}
