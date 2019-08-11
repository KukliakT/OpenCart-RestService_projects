﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;


namespace OpenCart414Test.Tests
{
    [TestFixture]
    class AddToCartTests : TestRunner
    {
        // DataProvider
        private static readonly object[] ProductToAdd =
        {
            new object[] { ProductRepository.GetIPhone(), ProductRepository.GetMacBook() }
        };
        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void DeleteProduct(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();
            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(2000);        //Only for presentation
            homePage.AddProductToCart(addingProduct2);

            Thread.Sleep(2000);
            
            Assert.AreEqual(addingProduct1.Title, homePage.GetCartContainerComponent()
               .GetProductByName(addingProduct1).GetProductNameText());

            homePage.GetCartContainerComponent(); //for reopen page
            
            Assert.AreEqual(addingProduct2.Title, homePage.GetCartContainerComponent()
                .GetProductByName(addingProduct2).GetProductNameText());

            homePage.GetCartContainerComponent(); //for reopen page

            Thread.Sleep(2000);          //Only for presentation
            homePage.GetCartContainerComponent().RemoveProductByName(addingProduct2);
            Thread.Sleep(2000);

            //Console.WriteLine(homePage.GetCartButtonText());
            //Assert.IsTrue(homePage.GetCartButtonText().Contains("1 item(s)"));
            //Thread.Sleep(2000);          //Only for presentation

            homePage.GetCartContainerComponent().RemoveProductByName(addingProduct1);

            homePage.GetCartEmptyContainerComponent(); //for reopen page

            Assert.IsTrue(homePage.GetCartEmptyContainerComponent().GetInfoMessageText().Length > 0);
            //Add assert on EmptyPage
            Thread.Sleep(3000);
        }


        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void AddProduct(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();

            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(2000);
            homePage.AddProductToCart(addingProduct2);

            Thread.Sleep(2000);   //Only for presentation

            Assert.AreEqual(addingProduct1.Title, homePage.GetCartContainerComponent()
                 .GetProductByName(addingProduct1).GetProductNameText());

            homePage.GetCartContainerComponent(); //for reopen page

            Assert.AreEqual(addingProduct2.Title, homePage.GetCartContainerComponent()
                .GetProductByName(addingProduct2).GetProductNameText());

            Thread.Sleep(2000);  //Only for presentation
        }

        [Test, TestCaseSource(nameof(ProductToAdd))]
        public void CheckTotalSum(Product addingProduct1, Product addingProduct2)
        {
            HomePage homePage = LoadApplication();
            homePage.AddProductToCart(addingProduct1);
            Thread.Sleep(2000);    //Only for presentation
            homePage.AddProductToCart(addingProduct2);

            Thread.Sleep(2000);    //Only for presentation
            decimal a = homePage.GetCartContainerComponent().GetTotalSumProducts();
           
            homePage.GetCartContainerComponent(); //for reopen page

            decimal b = homePage.GetCartContainerComponent().GetTablePriceTotal();

            Assert.AreEqual(a, b);
           // Assert.AreEqual(homePage.GetCartContainerComponent().GetTotalSumProducts(),
           //  homePage.OpenCartButton().GetTablePriceTotal());
            Thread.Sleep(3000);
        }
    }
}
