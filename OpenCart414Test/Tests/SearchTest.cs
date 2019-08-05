﻿using System;
using System.IO;
using System.Text;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenCart414Test.Data;
using OpenCart414Test.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Interactions;

namespace OpenCart414Test.Tests
{
    [TestFixture]
    public class SearchTest : TestRunner
    {
        // DataProvider
        private static readonly object[] ProductSearch =
        {
            new object[] { ProductRepository.GetMacBook(),
                SearchCriteriaRepository.GetMacBook(),
                Currency.US_DOLLAR },
        };


        [Test, TestCaseSource(nameof(ProductSearch))]
        public void CheckSearch(Product expectedProduct, SearchCriteria searchCriteria, Currency currency)
        {
            // Steps
            // TODO Change Currency
            SearchSuccessPage searchSuccessPage = LoadApplication()
                .SearchSuccessfully(searchCriteria);
            ProductComponent actualPoductComponent = searchSuccessPage
                .ProductsCriteria
                .ProductsContainer
                .GetProductComponentByName(expectedProduct.Title);
            //
            // Check
            Assert.IsTrue(actualPoductComponent
                .GetPartialDescriptionText()
                .Contains(expectedProduct.Description));
            Assert.IsTrue(actualPoductComponent
                .GetPriceText()
                .Contains(expectedProduct.GetPrice(currency)));
            //
            // Continue Searching. Use SearchCriteria from SearchCriteriaPart
            //
            // Return to Previous State
            HomePage homePage = searchSuccessPage.GotoHomePage();
            //
            // Check (optional)
            Assert.IsTrue(homePage
                .GetSlideshow0FirstImageAttributeSrcText()
                .Contains(HomePage.IPHONE6));
        }

    }
}
