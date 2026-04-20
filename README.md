# Personal Finance Tracker

Console Application (CLI) based on .NET 10 to manage personal finance.
This simple project was intended for me as a part of learning excercise about basic `LINQ`, `file I/O`, `Layered Architecture`, and `C# programming` in general.

## 🚀 Main Feature

- **Transaction Documenting**: Manage `Income` and `Expense`.
- **Balance Validation**: Prevents withdrawal due to insufficient balance.
- **Permanent Storaging**: Automatic data perservation in JSON format: `serialized.json`.
- **Transaction History**: Display transaction history from the latest.
- **Safe Input**: Input validation to prevent bad data being saved.

## 🏗️ Project Architecture

This project applied *Separation of Concerns* with the following structure:
- **Common**: Enums and utilities
- **Models**: Entity class definition
- **Persistence**: File I/O logic
- **Services**: Main bussiness logic
- **Program**: Console UI

## 🛠️ Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet)

## 💻 How to run

In your terminal or command prompt:
### 1. Clone Repository

```bash
git clone https://github.com/binariez/PersonalFinanceTracker.git
cd PersonalFinanceTracker
```
### 2. Run or Build Project
```bash
dotnet run
```
```bash
dotnet build
```

## 📈 Future Scope

- [ ] Add transaction category.
- [ ] Weekly/monthly summary.
- [ ] Export to other file format, eg: `CSV`.