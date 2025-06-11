# Mini Accounting Management System

## Overview
A minimal ASP.NET Core Razor Pages app to manage accounts, record vouchers, and export Excel reports.

## Features
- User authentication & roles (Admin, Viewer) via ASP.NET Identity  
- Chart of Accounts (add/view accounts)  
- Journal,Payment & Receipt vouchers (double-entry)  
- Excel export of vouchers via ClosedXML  
- User role management via stored procedures  

## Stored Procedures
- `sp_GetAllRoles`  
- `sp_GetUsersWithRoles`  
- `sp_AssignUserRole`  
-`sp_ManageAccounts`
-`sp_ManageVouchers`

## Structure
- **Pages/**: UI (.cshtml + .cs) – Index(Charts of Account), Voucher, Admin, Shared layout  
- **Areas/Identity/**: Login/Register pages  
- **Helper/**: `AccountHelper.cs` (ADO.NET calls & Excel export)  
- **DTO/**: Data Transfer Objects (accounts, roles)  
- **db/**: `AppDbContext` & EF entities (Accounts)  
- **Migrations/**: EF Core schema migrations  
- **wwwroot/**: Static assets (CSS, JS)  

## Technologies
- ASP.NET Core Razor Pages  
- Entity Framework Core & ADO.NET  
- ClosedXML  
- Bootstrap  







