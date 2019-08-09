﻿using OpenCart414Test.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace OpenCart414Test.Pages
{
    public class SearchSuccessPage : SearchCriteriaPart
    {
        public ProductsCriteriaComponent ProductsCriteria { get; private set; }

        public IWebElement SearchResult
        { get { return driver.FindElement(By.CssSelector(".col-sm-6.text-right")); } }
        public SearchSuccessPage(IWebDriver driver) : base(driver)
        {
            CheckElements();
            InitElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            //IWebElement temp = CriteriaSearchField; // TODO All Web Elements
        }

        private void InitElements()
        {
            ProductsCriteria = new ProductsCriteriaComponent(driver);
        }

        // Page Object

        // ProductsCriteria

        // Functional

        // Business Logic
        public SearchSuccessPage ChooseCurrency(Currency currency)
        {
            ClickCurrencyByPartialName(currency);
            return new SearchSuccessPage(driver);
        }

        public SearchSuccessPage SortProductsByCriteria(string text) // TODO Use Enum
        {
            ProductsCriteria.SetInputSort(text);
            return new SearchSuccessPage(driver);
        }

        public SearchSuccessPage ShowProductsByCount(string text) // TODO Use Enum
        {
            ProductsCriteria.SetInputLimit(text);
            return new SearchSuccessPage(driver);
        }
        public IList<string> GetListByGrid()
        {
            ProductsCriteria.ClickGridViewButton();
            Thread.Sleep(3000); // For presentation only
            return new SearchSuccessPage(driver).ProductsCriteria.GetProductComponentNames();
        }
        public IList<string> GetListByList()
        {
            ProductsCriteria.ClickListViewButton();
            Thread.Sleep(3000); // For presentation only
            return new SearchSuccessPage(driver).ProductsCriteria.GetProductComponentNames();
        }
    }
}
