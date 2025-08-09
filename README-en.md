# 🚀 Resume.Maui - Full-Stack Project Overview

---

## 🇬🇧 English Version

### 📝 Project Overview  

**Resume.Maui** is a **full-stack**, multi-platform application built using the latest Microsoft technologies. This project demonstrates a deep integration of **front-end UI**, **business logic**, and **database management** — all crafted with maintainability, scalability, and modern best practices in mind.

The goal was to deliver a clean, maintainable, and professional-grade app that runs seamlessly on Android, iOS, macOS, and Windows — all sharing the majority of their codebase through a shared MAUI XAML project.
> ⚠️ _Note:_  
> While a **MAUI Hybrid** approach (combining Blazor and MAUI) could simplify development by unifying web and native UI, this project deliberately uses pure **MAUI XAML** to demonstrate expertise in both **native MAUI UI development** and **cross-platform UI design**.  
>  
> Similarly, although **SQLite** is typically the preferred embedded database for projects of this size due to its simplicity and lightweight footprint, here **SQL Server** was used intentionally to showcase integration with a full-fledged RDBMS and more complex data scenarios.

---

### 💡 Technologies Used & Why

| Layer           | Technology                 | Purpose & Explanation |
|-----------------|----------------------------|-----------------------|
| **UI (Front-End)**    | **.NET MAUI (XAML)**          | Native cross-platform UI framework that allows writing a single UI codebase for Android, iOS, Mac, and Windows. XAML provides a powerful, declarative syntax to design clean, maintainable UI layouts with support for animations, styles, data binding, and MVVM patterns. |
| **MVVM Architecture** | **Model-View-ViewModel**       | A design pattern that separates UI logic (View), business logic (ViewModel), and data (Model), enhancing testability, maintainability, and separation of concerns. This makes the app robust and easier to extend. |
| **Dependency Injection** | **Microsoft.Extensions.DependencyInjection** | Ensures modular, loosely-coupled components by injecting dependencies through constructors or properties, which also improves testability and scalability. |
| **Data Access Layer** | **Entity Framework Core (EF Core)** | Object-relational mapper (ORM) used to interact with the SQL Server database using C# objects, abstracting raw SQL queries and enabling migrations, seeding, and LINQ queries for cleaner data access. |
| **Database**          | **Microsoft SQL Server**       | A full-featured, enterprise-grade relational database system. Chosen here to showcase integration with complex, scalable databases, and support advanced querying and transactional integrity beyond lightweight embedded databases like SQLite. |
| **Build & Deployment**| **.NET 9.0 + MAUI Tooling**    | The latest .NET SDK to ensure access to the newest language features, improved performance, and MAUI’s cross-platform deployment capabilities. Single-project structure simplifies multi-target builds for Android, iOS, Mac Catalyst, and Windows. |
| **Logging & Diagnostics** | **Microsoft.Extensions.Logging** | Provides robust logging support to help track app behavior during development and production, making debugging and monitoring easier and more professional. |

---

### ⚙️ Why Not Other Options?

- **Why not MAUI Hybrid (Blazor)?**  
  While MAUI Hybrid (Blazor + MAUI) allows building web and native UI together, this project purposely focuses on **pure MAUI XAML** to highlight proficiency in native UI design, providing smoother performance and deeper platform integration.

- **Why SQL Server, not SQLite?**  
  Although SQLite is ideal for small-scale local storage due to its simplicity, SQL Server was selected to demonstrate real-world database integration skills, including complex querying, migrations, and enterprise-grade data management.

---

### ⭐ Key Features & Full-Stack Architecture

- 🎯 **Multi-platform Support**  
  Runs natively on **Android**, **iOS**, **macOS**, and **Windows** — all sharing a single **MAUI XAML** codebase that ensures smooth, native user experiences.

- 🖼️ **XAML-based UI (Frontend)**  
  UI is crafted with declarative XAML, leveraging the **MVVM** pattern for clean separation of concerns. This enables powerful data binding, styles, animations, and maintainable UI layouts.

- 🌐 **Web API Backend**  
  The project includes an **ASP.NET Core Web API** backend that manages client-server communication, business logic, validation, and database interactions.

- 🔄 **RESTful API Architecture**  
  Uses REST principles for standard, secure, and scalable communication between frontend and backend, primarily exchanging JSON payloads.

- 🧩 **MVVM Architecture (Frontend)**  
  Clear division between View (UI), ViewModel (presentation logic), and Model (data), improving testability, maintainability, and code clarity.

- 🗄️ **Data Access Layer**  
  Utilizes **Entity Framework Core (EF Core)** as the ORM to model and interact with the **SQL Server** database, supporting migrations, LINQ queries, and data seeding.

- 🛠️ **Backend Technologies**  
  - **ASP.NET Core 9.0 Web API:** Robust platform for building RESTful services  
  - **Dependency Injection:** Manages service lifetimes and dependencies cleanly across backend layers  
  - **Logging & Monitoring:** Employs Microsoft.Extensions.Logging for production-grade diagnostics

- 🔌 **Dependency Injection**  
  Dependency Injection is employed throughout the entire stack, enabling modular, testable, and maintainable components.

- 💾 **Database**  
  Uses **Microsoft SQL Server** to showcase real-world enterprise database integration, enabling advanced querying and transactional consistency. While **SQLite** would be simpler for smaller projects, SQL Server demonstrates handling complex data scenarios.

- 🌍 **Localization Ready**  
  Designed with localization in mind, supporting multiple languages via resource files and XAML bindings.

- 🚀 **Modern .NET 9 + MAUI Tooling**  
  Leverages the latest .NET SDK and MAUI tools for optimal performance, streamlined multi-platform builds, and deployment.

---

### 📂 Project Layers Summary

| Layer                 | Technology & Role                                                                                     |
|-----------------------|-----------------------------------------------------------------------------------------------------|
| **Frontend UI**         | [.NET MAUI XAML](https://learn.microsoft.com/en-us/dotnet/maui/xaml/) — Native cross-platform UI with MVVM pattern                                         |
| **Frontend Logic**      | ViewModels, Services — Business and UI logic separated                                              |
| **API Backend**         | [ASP.NET Core 9.0 Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-9.0) — Exposes REST endpoints                                                   |
| **Business Logic**      | Backend Services, Controllers — Handle validation, authorization, and data flow                      |
| **Data Access Layer**   | [Entity Framework Core (EF Core)](https://learn.microsoft.com/en-us/ef/core/) — ORM for SQL Server                                                                         |
| **Database**            | [Microsoft SQL Server](https://learn.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver16) — Enterprise-grade relational database                                         |
| **Cross-cutting**       | [Dependency Injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection), [Logging](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-9.0), Configuration                                                        |



### 🏗️ Project Structure at a Glance

```plaintext
Resume.Maui.Shared/        # Shared XAML UI, ViewModels, Services, and Pages (Single source of truth)
Resume.Maui.Android/       # Android-specific project referencing shared code
Resume.Maui.iOS/           # iOS-specific project referencing shared code
Resume.Maui.MacCatalyst/   # Mac Catalyst-specific project referencing shared code
Resume.Maui.WinUI/         # Windows-specific project referencing shared code

```

---

### ▶️ How to Build and Run

```bash
git clone https://github.com/yourusername/Resume.Maui.git  
cd Resume.Maui  
dotnet restore  
dotnet ef database update     # Apply EF Core migrations to SQL Server  
# Open platform-specific project in Visual Studio or VS Code and run  

```

---

### 📞 Contact & Profile

<p align="center">
  <a href="https://github.com/amirsolo456">GitHub</a> | 
  <a href="https://www.linkedin.com/in/amir-soleymani-96b481336?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=android_app">LinkedIn</a> | 
  <a href="mailto:amirsol456@gmail.com">Email</a> | 
  <a href="https://www.google.com">Website/Portfolio</a>
</p>

<p align="center">
Feel free to reach out for collaboration, questions, or feedback!
</p>


