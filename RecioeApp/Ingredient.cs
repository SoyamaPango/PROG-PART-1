using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Ingredient
    {
       
            public string Name { get; }
            public double Quantity { get; private set; }
            public string Unit { get; }

            private double originalQuantity;

            public Ingredient(string name, double quantity, string unit)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
                originalQuantity = quantity;
            }

            public void ScaleQuantity(double factor)
            {
                Quantity *= factor;
            }

            public void ResetQuantity()
            {
                Quantity = originalQuantity;
            }
        }
    }


