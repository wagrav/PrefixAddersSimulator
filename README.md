# Prefix Adders Simulator Library

## Introduction
I wrote this library to get familiar with the concept of prefix adders.
It was also a great opportunity to practice TDD and make some more experience with modern .Net libraries like: 
* XUnit (unit testing tool), 
* Shouldby (assertion framework),
* NSubstitude (mocking library)


## About library

This project simulates an integrated circuit design to realize add operations.
It allows you to simulate circuits like:
* KoggeStone,
* HanCarlson,
* LadnerFischer,
* Sklansky,
* Knowles22111,
* Knowles44221,
* BrentKung 

## All you have to do/know to use it

All you have to do is prepare a special input file which maps the schema of choosen circuit to interial sysytem modules map. 

According to schema legend from wikipedia:

![Schema legend](https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/4_bit_Kogge_Stone_Adder_Example.png/352px-4_bit_Kogge_Stone_Adder_Example.png)

I found out that there are always only three types of modules on the schema:
* EntryChip (the red)
* NeutralChip (the green) 
* CalculatingChip (the yellow)

In library code:

    public enum SystemModuleType
    {
        EntryChip, NeutralChip, CalculatingChip
    }

After I noticed that, I designed a solution to describe circuit as input text file for the library. 

### Circuit map file legend: 
* EntryChip (the red) --> '99'
* NeutralChip (the green) --> '0'
* CalculatingChip (the yellow) --> any digit starts from 1 

### Examples 16 bits prefix adders:
 

1. Kogge Stone: 


>     99 99 99 99 99 99 99 99 99 99 99 99 99 99 99 99
>     1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0
>     2 2 2 2 2 2 2 2 2 2 2 2 2 2 0 0
>     4 4 4 4 4 4 4 4 4 4 4 4 0 0 0 0
>     8 8 8 8 8 8 8 8 0 0 0 0 0 0 0 0

2. Han Carlson:

>     99 99 99 99 99 99 99 99 99 99 99 99 99 99 99 99 
>     1 0 1 0 1 0 1 0 1 0 1 0 1 0 1 0
>     2 0 2 0 2 0 2 0 2 0 2 0 2 0 0 0
>     4 0 4 0 4 0 4 0 4 0 4 0 0 0 0 0
>     8 0 8 0 8 0 8 0 0 0 0 0 0 0 0 0
>     0 1 0 1 0 1 0 1 0 1 0 1 0 1 0 0


# How to calculate? 


The Usage is really simple, just type numbers and get results:
    
>    var calulator = new PrefixAdderSimulator(SystemMapFilePath);

>    var result = calculator.Calculate(firstNumber, secondNumber);


# Unit tests
> The library code is covered in 74 % by unit tests.

---

 Feel free to contribute and thank you for your attention :)
