# 🛒 High-Performance E-Commerce Engine (Full-Stack)

[![Status](https://img.shields.io/badge/Status-In--Progress-orange)]()
[![Framework](https://img.shields.io/badge/.NET-8.0-blue)]()
[![Frontend](https://img.shields.io/badge/Angular-17-red)]()

A modern, decoupled e-commerce platform built from the ground up. This project focuses on implementing **Clean Architecture (Onion)** principles to ensure scalability, maintainability, and a clear separation of concerns.

## 🏗️ Architectural Overview
The system is designed using a layered approach to isolate business logic:
- **Core (Domain & Application):** Contains domain entities, specifications, and business interfaces.
- **Infrastructure:** The logic engine, containing **Business Logic**, Data Persistence (EF Core), **Generic Repository**, and **Unit of Work** patterns.
- **API (Web):** Managed RESTful endpoints, **DTOs** (Data Transfer Objects), and Global Exception Middleware.

## ✅ Completed Technical Achievements

### 🔹 Advanced Backend Logic
- **Dynamic Catalog Engine:** Fully implemented server-side logic for fetching products with integrated **Filtering** (by brand/type), **Searching** (by name), and **Sorting** (by price) directly within the Infrastructure layer.
- **Generic Pagination:** Designed a robust `Pagination<T>` container utilizing `IReadOnlyList<T>` for consistent, high-performance API responses.
- **Data Mapping & Security:** Leveraged **AutoMapper** to strictly decouple internal domain models from external API contracts (DTOs) in the API layer.
- **Global Error Handling:** Integrated custom middleware to globally intercept exceptions and ensure structured responses.

### 🔹 Frontend Sophistication (Angular 17)
- **Interactive Product Catalog:** Built a dynamic UI that consumes the API to display products with real-time **Server-Side Filtering and Pagination**.
- **Product Deep-Diving:** Implemented a detailed product view with optimized data fetching via Angular Services.
- **Reactive Cart System:** Developed a functional **Client-Side Cart** where users can add/remove items, with state persistence using **Local Storage** and **RxJS**.

## 🚀 Roadmap (Upcoming Milestones)
- [ ] **Security:** Secure Identity Management via JWT & Refresh Tokens.
- [ ] **Payments:** Full payment lifecycle integration with **Stripe API & Webhooks**.
- [ ] **Orders:** Checkout process and order history management.

---

## 📸 Project Teasers (Work in Progress)
*(Add your screenshots here to showcase the UI and API)*

<div align="center">
  <img src="رابط_صورة_المتجر" width="48%" alt="Product Gallery UI" />
  <img src="رابط_صورة_سواجر" width="48%" alt="Swagger API Logic" />
</div>

---
📂 **Backend Repo:** [Click Here](https://github.com/Ibrahem-Tabaneh/ECommerce-Asp.netCore-Angular-CleanArch)  
📂 **Frontend Repo:** [Click Here](https://github.com/Ibrahem-Tabaneh/Ecommerce3)

📫 **Connect with me:** [LinkedIn](https://www.linkedin.com/in/ibrahem-tabaneh-249683249/)
