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
- xUnit (Unit Testing)
    
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

## Setup Guide
1. Clone the repository: git clone https://github.com/<your-username>/<repo-name>.git
2. Navigate to you project: cd <repo-name>
3. Build the application: dotnet build
4. Run the application: dotnet run
 ---- The application will be available at https://localhost:5001 or http://localhost:5000. ---
5. Running Tests (xUnit): dotnet test
6. Using Docker (optional) And Build the Docker image: docker build -t liswebapp
7. Run the container (optional): docker run -p 5000:80 liswebapp

----------------------------------------------------------------------------------------------------------------------------------------------------

## Unit Testing (xUnit)
- xUnit is used for writing automated unit tests for the controller and service logic.
- Tests cover: Controller constructor validation, Input validation scenarios, LIS computation correctness, Exception handling

----------------------------------------------------------------------------------------------------------------------------------------------------

## CI/CD (GitHub Actions)
- On every push to the repository: 
     1. Builds the application 
     2. Runs unit tests

-----------------------------------------------------------------------------------------------------------------------------------------------------


