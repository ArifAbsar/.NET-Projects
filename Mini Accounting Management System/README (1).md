![Login_page](https://github.com/user-attachments/assets/aec193f7-7f04-45c8-9ff9-65c8a9543b30)
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
- `sp_ManageAccounts`
- `sp_ManageVouchers`
- `sp_GetAllVouchers`
- `sp_GetJounrnalVouchers`
- `sp_GetPaymentVouchers `
- `sp_GetReceiptVouchers`

## Structure
- **Pages/**: UI (.cshtml + .cs) – Index(Charts of Account), Voucher, Admin, Shared layout  
- **Areas/Identity/**: Login/Register pages  
- **Helper/**: `AccountHelper.cs` (ADO.NET calls & Excel export)  
- **DTO/**: Data Transfer Objects (accounts, roles)  
- **db/**: `AppDbContext` & EF entities (AccountTypes,Sub_Account,Journal_Voucher, Payment Voucher, Receipt_Voucher, Voucher, VoucherDC)  
- **Migrations/**: EF Core schema migrations  
- **wwwroot/**: Static assets (CSS, JS)  

## Technologies
- ASP.NET Core Razor Pages
- MSSQL (Stored Procedure Only) 
- Entity Framework Core & ADO.NET  
- ClosedXML  
- Bootstrap

## Admin Control Panel Page (Only Admin Can access this page)
![Admin Control Panel](https://github.com/user-attachments/assets/645d781e-8089-4f66-82ea-b3f359181d90)

## Charts of Account Page
![Charts_of_Accounts](https://github.com/user-attachments/assets/f79e8576-83d9-4a76-9221-ae20e9693606)

## Voucher Page
![Voucher_page](https://github.com/user-attachments/assets/666f5a7e-5f46-4de0-9b69-879501286981)





