using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 


namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool displayMenu = true;
            while (displayMenu == true)
            {

             displayMenu = MainMenu();
                
            }
        }//END OF MAIN 

        private static bool MainMenu()
        {
            //MAIN MENU 
            Console.WriteLine("\n\nChoose an option. ");
            Console.WriteLine("1. Enter '1' to enter a product. ");
            Console.WriteLine("2. Enter '2' to get an inventory product type count. ");
            Console.WriteLine("3. Enter '3' to search inventory. ");
            Console.WriteLine("4. Enter '4' to view total cost of goods on hand. ");
            Console.WriteLine("5. Enter '5' to view total value of goods on hand.");
            Console.WriteLine("6. Enter '0' to exit the program. ");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                ProductInput();
                return true;
            }
            else if (userInput == "2")
            {
                InventoryCount();
                return true; 
            }
            else if (userInput == "3")
            {
                InventorySearch();
                return true; 
            }

            else if (userInput == "4")
            {
                InventoryCost();
                return true; 
            }

            else if (userInput == "5")
            {
                InventoryValue();
                return true; 
            }
        
            else if (userInput == "0")
            {
                return false;
            }

            else
            {
                Console.WriteLine("\n******   Please enter a valid option.   ******");
                return true;
            }

        }//END OF MAIN MENU 



        private static void ProductInput()
        {
            while (true)
            {
                try
                {


                    //Create an inventory system 
                
                    Console.WriteLine("\nEnter the product name: ");
                    string ProductName = Console.ReadLine();
                    Console.WriteLine("\nEnter the product quantity (whole numbers only): ");
                    int ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nEnter the product cost (the number only):  ");
                    Decimal ProductCost = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("\nEnter the product price (the number only): ");
                    Decimal ProductPrice = Convert.ToDecimal(Console.ReadLine());
                    Product newProduct = new Product(ProductName, ProductQuantity, ProductCost, ProductPrice);
                    string[] writeToFile = new string[] {ProductName + "," +  ProductQuantity.ToString() + "," + ProductCost.ToString() + "," + ProductPrice.ToString() };
                    if (File.Exists("test.csv"))
                    {
                     File.AppendAllLines("test.csv", writeToFile);
                     Console.WriteLine("\n******   ALERT: The information below was saved successfully.   ******");
                    }
                    else
                    {
                        Console.WriteLine("\n******   ERROR: The CSV file that you are trying to add values to does not exist, or is not in the right location.   ******");
                        Console.WriteLine("******   ERROR: The information below was NOT SAVED.   ******");
                    }
                    
                    Console.WriteLine(newProduct.ToString());
                    //BREAKS OUT OF THE LOOP RETURNS TO MAIN MENU 
                    break;
                    


                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n\n******ERROR: " + ex.Message + "******");
                }
            }
        }//END OF PRODUCT INPUT
        private static void InventoryCount()
        {
            ProductInventory myInventory;
            while (true)
            {
                try
                {
                    myInventory = new ProductInventory();
                    myInventory.LoadInventory();
                    Console.WriteLine($"\n******   There are {myInventory.GetNumberOfProducts()} types of products in inventory.   ******");
                    break; 

                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n****** ERROR: " + ex.Message);

                }
            }
        }//END OF INVENTORY COUNT 


        private static void InventorySearch()
        {
            ProductInventory myInventory; 
            while (true)
            {
                try
                {
                    myInventory = new ProductInventory();
                    myInventory.LoadInventory();
                    Console.WriteLine($"\n******   The search results are below: \n{myInventory.GetSearchProducts()}");
                       
                    break; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n****** ERROR: " + ex.Message);
                }
            }
        }

        private static void InventoryCost()
        {
            ProductInventory myInventory;
            while (true)
            {
                try
                {
                    myInventory = new ProductInventory();
                    myInventory.LoadInventory();
                    Console.WriteLine($"\nThe total cost of goods on hand is: {myInventory.CostOfGoodsOnHand().ToString("C2")}");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n****** ERROR: " + ex.Message);
                }
            }
        }

        private static void InventoryValue()
        {
            ProductInventory myInventory;
            while (true)
            {
                try
                {
                    
                    myInventory = new ProductInventory();
                    myInventory.LoadInventory(); 
                    Console.WriteLine($"\nThe total value of goods on hand is: {myInventory.ValueOfGoodsOnHand().ToString("C2")}");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n****** ERROR: " + ex.Message);
                }
            }
        }





    }//END OF CLASS
}
