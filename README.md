# Longest Increasing Subsequence (LIS) Web App

This project is a simple ASP.NET Core MVC application that computes the **Longest Increasing Subsequence (LIS)** from a given sequence of integers.

The user provides a space-separated list of integers, and the application returns the longest increasing subsequence.  
If multiple LIS exist with the same length, the earliest one is returned.

---------------------------------------------------------------------------------------------------------------------------------------------------

## Tech Stack

- ASP.NET Core MVC (.NET)
- C#
- jQuery & AJAX
- Bootstrap
- GitHub Actions (CI)
- Docker (Containerisation)
    
---------------------------------------------------------------------------------------------------------------------------------------------------

## Problem Statement

- Input: A string containing integers separated by whitespace  
  Example: 6 1 5 9 2
- Output: Longest Increasing Subsequence  
  Result: 1 5 9
  
-----------------------------------------------------------------------------------------------------------------------------------------------------

## Application Flow

1. User enters numbers in the input textarea.
2. Input is sent to the controller using AJAX.
3. Controller processes the sequence and computes LIS.
4. Result is returned as JSON and displayed in the output area.

----------------------------------------------------------------------------------------------------------------------------------------------------

