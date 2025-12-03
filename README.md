# 📦 OnlineStore API

A layered, modular **.NET 9 Web API** built to manage the core backend operations of an online store.  
It includes CRUD operations for products, categories, customers, payments, shipping, reviews, orders, and product images.

---

## 🚧 Project Status

This API is **still a work in progress**.  
It currently includes basic operations, but it is **not yet a complete e-commerce system**.

Planned future improvements include:

- Authentication & Authorization (JWT)
- Shopping cart module
- Order workflow (processing → shipped → delivered)
- Input validation
- Advanced filtering, sorting, and pagination
- Global error handling
- Logging (Serilog)
- Cloud image storage
- Enhanced architecture refactoring

This repository will continue to grow as development progresses.

---

## 🚀 Technologies Used

- **.NET 9**
- **Entity Framework Core**
- **SQL Server**
- **3-Tier Architecture**
  - **API Layer** → Controllers
  - **Business Layer** → DTOs, Services, Interfaces
  - **Data Layer** → Entities, Repositories, Interfaces
- **EF Core Reverse Engineering (Database-First)**

---

## 🛒 Features

### **Domain Entities**
- Categories  
- Products  
- Customers  
- Orders  
- Order Items  
- Payments  
- Shipping  
- Reviews  
- Product Images  

### **API Capabilities**
- CRUD operations for:
  - Products
  - Categories
  - Customers
  - Payments
  - Shipping
  - Reviews
- **Image upload**
- **Order creation** with order items

---

## 📁 Architecture Overview

OnlineStore/  
├── OnlineStore.API (Controllers)   
├── OnlineStore.Business (DTOs, Services, Interfaces)  
└── OnlineStore.Data (Entities, Repositories, Interfaces)  


---

## ⚙️ How to Run the Project

### 1️⃣ Requirements

- Visual Studio 2022+
- .NET 9 SDK
- SQL Server

### 2️⃣ Installation

  **1. Clone this repository:**
  ```bash
      git clone https://github.com/NedaAssem/OnlineStore.git
```
  **2. Open the solution in Visual Studio.**

  **3. Update your connection string in:**  

      appsettings.json → "ConnectionStrings"

  **4. Apply database migrations**

      dotnet ef database update
   
  **5. Run the project:**

      Press F5 in Visual Studio

      Or:  dotnet run

### 3️⃣ Swagger Documentation

      API docs are available at:

      https://localhost:<port>/swagger





