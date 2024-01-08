# PhotoBooth and TaxViewer Applications

This repository contains two distinct console applications: **PhotoBooth** and **TaxViewer**. Each application serves a unique purpose, with PhotoBooth focusing on user input, applying filters to the input, and order processing, while TaxViewer is designed for tax calculations based on the provided region.

## PhotoBooth Application

### Description
The PhotoBooth application is a console utility for processing user input through a series of steps: input collection, text filtering, and creating and saving an order.

### Components
- **ConsoleInputManager**: Manages user input, ensuring non-empty sentence input.
- **TextFilterManager**: Applies text filters to user input.
- **OrderManager**: Handles the creation and processing of orders.

### How to Use
1. Set the PhotoBooth as startup project, and run application.
2. Enter a sentence as prompted.
3. Choose and apply desired text filters.
4. Select packages and complete the order.

### Implementation Details
- Uses `ConsoleInputManager` for input validation.
- `TextFilterManager` offers a selection of text filters.
- `OrderManager` manages available and purchased packages.

## TaxViewer Application

### Description
TaxViewer is a console application for calculating taxes for a specified month and year, using selected tax calculation strategies based on the provided region.

### Components
- **TaxManager**: Manages tax calculation based on user-selected strategies.
- **NewYorkLongIslandTaxCalculationStrategy**: Calculates taxes for Long Island, New York.

### How to Use
1. Run the TaxViewer application.
2. Input the month and year for tax calculation.
3. Select a tax calculation strategy.
4. View the calculated tax amount.

### Implementation Details
- **TaxManager** interacts with a data service to retrieve order items and calculate taxes.
- **NewYorkLongIslandTaxCalculationStrategy** implements a specific tax calculation logic.
