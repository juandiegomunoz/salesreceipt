# Sales Receip from shopping list

*Organisation: Lastminute*

*Author: Juan Diego Munoz*

*Date: 26/02/2020*

## Introduction

This project is a coding exercise requested for Lastminute in order to evaluate the skills of the author.

The following exercise is sent to you as an additional tool to be used in your technical interview.
We ask you to solve it using the programming language that you prefer.
This problem requires some kind of input. You are free to implement any mechanism for feeding input into your solution (for example, using hard coded data within a unit test). You should provide sufficient evidence that your solution is complete by, as a minimum, indicating that it works correctly against the supplied test data.

The goal is to provide us with a full understanding of your coding style and skills. We’ll pay particular attention to:

* the code structure
* the design
* choice of data structures
* how you approach the problem

## The Problem

Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt. Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions.

When I purchase items I receive a receipt which lists the name of all the items and their price (including tax), finishing with the total cost of the items, and the total amounts of sales taxes paid. The rounding rules for sales tax are that for a tax rate of n%, a shelf price of p contains (np/100 rounded up to the nearest 0.05) amount of sales tax.

Write an application that prints out the receipt details for these shopping baskets... 

| Input                   | Output                |
| ----------------------- | --------------------- |
| 1 book at 12.49         | 1 book : 12.49        |
| 1 music CD at 14.99     | 1 music CD: 16.49     |
| 1 chocolate bar at 0.85 | 1 chocolate bar: 0.85 |
|                         | Sales Taxes: 1.50     |
|                         | Total: 29.83          |

## Prerequisites

### .Net Core
In order to build, test and run the code.

### Github
Account to store the code in a repository and make it accesible to third parties.
A workflow file has been created in .github/workflows directory called dotnetcore.yml in order to test and build the solution.

### Circle CI
For running the builds and test automatically. A configuration file is created at .circleci directory in order to test and build the solution. In a production environment, you can create your docker image or publish to a nuget or npm repository.

## Folder Structure
There is a solution in the root with three different projects. SalesReceipt is the reusable library. SalesReceiptApp has been created in order to make it run. SalesReceiptTest is the test project for the library.

## Data Structures

### Item
Basis unit of information for a shopping item. Isolated for storing the data. Contains the Name, the quantity and the price.

### Tax
Represent a tax. It has rules to include or exclude an item to the tax. Contains the rate to be applied.

### ITaxable
Interface to implement operations over taxes, like Get the base Price, get price after taxes and get payable taxes over an item.

### ItemExtensionStrings
Class to load information from a string into an item and to convert an item to a string.

### ItemExtensionIdentical
Class to compare the fields of an Item with another and determine if are identicals.

### ItemTaxable
Item with tax information that implements the ITaxable interface. Taxes are applied over this class statically using the method ApplyTax. Once the tax is added to the list of taxes, is used to calculate final price.

### ItemList
Represent the list of the items where we can calculate the total of the invoice.

## Run
To run the library, a project is prepared with a Program class.

``` bash
dotnet run --project "./SalesReceiptApp/SalesReceiptApp.csproj" --configuration Release
```

## Test
To test different aspects of the library, a Test project is prepared. In order to run the test

``` bash
dotnet test --configuration Release
```

### Standard test
Compare the results proccessed from the input files against the output files in the data directory.

### Data Test
The class DataTest validates the process of loading data from a string.

### Extreme Values
The class ExtremeValuesTest validates the values of maximum float, zero, negative values in price, tax rate and quantity.

### Performance Tests
This class test the performance of loading and representing huge list of items.


