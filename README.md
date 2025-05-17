# C# Test Runner

## 📌 Objective

This project is a simple custom test runner built from scratch in C#. It discovers, executes, and reports the results of unit tests.

---

## 🚀 How to Run

### 🧱 Requirements

- .NET SDK (e.g., .NET 6 or later)
- Visual Studio or any C# editor/terminal

### ▶️ Steps

1. Clone or open the project in Visual Studio.
2. Build the project.
3. Run the program -> dotnet run or open the .sln file and run it.

---

## 🎯 Approach

To identify test methods, I initially considered using a naming convention (e.g., methods named `TestSomething` or `SetupSomething`). However, this approach is prone to errors (e.g., typos or inconsistent names) and not very flexible.
Instead, I implemented **custom attributes** (`[Test]`, `[Setup]`, `[Teardown]`) and used **reflection** to discover methods decorated with these tags.

---
