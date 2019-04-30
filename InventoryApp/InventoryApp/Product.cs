using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{

    //PUBLIC CONSTRUCTOR 
    class Product 
    {
    //PRIVATE DATA 
    private string prodName;
    private int prodQuantity;
    private Decimal prodCost; 
    private Decimal prodPrice;
    


        //PUBLIC CONSTRUCTOR 
        public Product(string productName, int productQuantity, Decimal productCost, Decimal productPrice)
        {
            ProdName = productName;
            ProdQuantity = productQuantity; 
            ProdCost = productCost;
            ProdPrice = productPrice;
        }
            
        //PUBLIC PROPERTIES 
        public string ProdName
        {
            get { return prodName; }
            set
            {
                if (value.Trim().Length == 0)
                {
                    //BAD INPUT 
                    throw new Exception("Product description cannot be blank. ");

                }
                else
                {
                    prodName = value; 
                }
            }
        }
        
        public int ProdQuantity
        {
            get { return prodQuantity; }
            set
            {
                if (value <= 0 )
                {
                    //BAD INPUT 
                    throw new Exception("Product quantity cannot be less than or equal to zero. ");

                }
                else
                {
                    prodQuantity = value;
                }
            }
        }
        

       
        public Decimal ProdCost
        {
            get { return prodCost; }
            set
            {
                if (value <= 0)
                {
                    //BAD INPUT 
                    throw new Exception("Product cost cannot be less than or equal to zero. ");

                }
                else
                {
                    prodCost = value;
                }
            }
        }

        public Decimal ProdPrice
        {
            get { return prodPrice; }
            set
            {
                if (value <= 0)
                {
                    //BAD INPUT 
                    throw new Exception("Product price cannot be less than or equal to zero. ");

                }
                else
                {
                    prodPrice = value;
                }
            }
        }

        //PUBLIC METHODS 
        public override string ToString()
        {
            string displayString = "\nProduct Name:  " + prodName + "\nProduct Quantity: " + prodQuantity +  "\nProduct Cost: " + prodCost + "\nProduct Price: " + prodPrice + "\n";

            return displayString; 
                
        }



    }//END OF CLASS

   
} 
