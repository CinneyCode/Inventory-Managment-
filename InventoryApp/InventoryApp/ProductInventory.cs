using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //IO DIRECTIVE

namespace InventoryApp
{
    class ProductInventory
    {
        List<Product> myProduct;

        public ProductInventory()
        {
            myProduct = new List<Product>();

        }

        public bool LoadInventory()
        {
            try
            {
                string[] lineByLine = File.ReadAllLines("test.csv");
                for (int i = 0; i < lineByLine.Length; i++)
                {
                    string[] columns = lineByLine[i].Split(',');
                    Product newProduct = new Product(columns[0],Convert.ToInt32(columns[1]),
                    Convert.ToDecimal(columns[2]), Convert.ToDecimal(columns[3]));
                    myProduct.Add(newProduct);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n******   FILE ERROR: : {ex.Message}   ******");
                return false;
            }
        }
        public int GetNumberOfProducts()
        {
            return myProduct.Count;
        }

        //Tuple allows to return multiple values 
        public string GetSearchProducts()
        {

            Console.WriteLine("\nEnter the product that you are searching for: ");
            string searchTarget = Console.ReadLine();
            foreach (Product product in myProduct)
            {
                if (product.ProdName.Contains(searchTarget))
                {
                    return "\nThe description is: " + product.ProdName + 
                        "\nThe quantity is: " + product.ProdQuantity + "\nThe cost is: " + 
                        product.ProdCost.ToString("C2") + "\nThe price is: " + product.ProdPrice.ToString("C2");
                }

            }
            return "0 " + searchTarget;      
        }

        public Decimal CostOfGoodsOnHand()
        {

         Decimal cost = 0; 

         foreach(Product product in myProduct)
         {
                if (product.ProdCost > 0)
                {
                    cost = cost + (product.ProdCost * product.ProdQuantity);
                }
            }

         return cost; 
        }

        public Decimal ValueOfGoodsOnHand()
        {

            Decimal value = 0;

            foreach(Product product in myProduct)
            {
                if(product.ProdQuantity > 0  & product.ProdPrice > 0)
                {
                    value = value + (product.ProdPrice * product.ProdQuantity);
                }
               
            }

            return value;


        }




    }//END OF CLASS 
}
