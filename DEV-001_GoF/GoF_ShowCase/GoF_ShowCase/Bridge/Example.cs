﻿using System;
using System.Collections.Generic;

namespace GoF_ShowCase.Bridge {
    public class Example {
        private readonly Dictionary<uint, uint> cart = new Dictionary<uint, uint>();

        public Money GetCartTotal(IPriceCalc calc) {
            /* Skipped */
            var itemsList = cart.Values;

            foreach (var item in itemsList) {
//                calc.AddItem(item.Item1, item.Item2);
            }

//            return calc.GetTotalPrice(userData.shippingAddr);

            return new Money();
        }

        public void ExecuteDemo() {
            var calcImplementation = PriceCalcImplFabric.GetPriceCalcImpl(DeliveryCompany.Self);

            IPriceCalc calc1 = new PriceCalcBasic(calcImplementation);
            var price1 = GetCartTotal(calc1);
            Console.WriteLine(price1);


            var priceCalcImpl = PriceCalcImplFabric.GetPriceCalcImpl(DeliveryCompany.CompanyA);
            IPriceCalc calc2 = new PriceCalcDiscount(priceCalcImpl);
            var price2 = GetCartTotal(calc2);
            Console.WriteLine(price2);
        }
    }
}