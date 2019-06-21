using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazingPizza.Server
{
    public class OrderService
    {
        public async Task<List<OrderWithStatus>> GetOrders(string userId)
        {
            return default;
        }

        public async Task<int> PlaceOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;
            order.DeliveryLocation = new LatLong(51.5001, -0.1239);

            // Enforce existence of Pizza.SpecialId and Topping.ToppingId
            // in the database - prevent the submitter from making up
            // new specials and toppings
            foreach (var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;

                foreach (var topping in pizza.Toppings)
                {
                    topping.ToppingId = topping.Topping.Id;
                    topping.Topping = null;
                }
            }

            return default;
        }
    }
}
